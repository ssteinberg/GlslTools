﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Host;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.VisualStudio.LanguageServices
{
    [Export(typeof(VisualStudioWorkspace))]
    internal sealed class VisualStudioWorkspace : Workspace
    {
        private readonly ITextDocumentFactoryService _textDocumentFactoryService;
        private readonly BackgroundParser _backgroundParser;
        private readonly ConditionalWeakTable<ITextBuffer, ITextDocument> _textBufferToTextDocumentMap;
        private readonly ConditionalWeakTable<ITextBuffer, DocumentId> _textBufferToDocumentIdMap;
        private readonly ConditionalWeakTable<ITextBuffer, List<ITextView>> _textBufferToViewsMap;

        [ImportingConstructor]
        public VisualStudioWorkspace(
            SVsServiceProvider serviceProvider,
            ITextDocumentFactoryService textDocumentFactoryService)
            : base(MefV1HostServices.Create(GetExportProvider(serviceProvider)))
        {
            PrimaryWorkspace.Register(this);

            _textDocumentFactoryService = textDocumentFactoryService;

            _backgroundParser = new BackgroundParser(this);
            _backgroundParser.Start();

            _textBufferToTextDocumentMap = new ConditionalWeakTable<ITextBuffer, ITextDocument>();
            _textBufferToDocumentIdMap = new ConditionalWeakTable<ITextBuffer, DocumentId>();
            _textBufferToViewsMap = new ConditionalWeakTable<ITextBuffer, List<ITextView>>();
        }

        private static ExportProvider GetExportProvider(SVsServiceProvider serviceProvider)
        {
            var componentModel = (IComponentModel) serviceProvider.GetService(typeof(SComponentModel));
            return componentModel.DefaultExportProvider;
        }

        protected override void OnDocumentTextChanged(Document document)
        {
            if (_backgroundParser != null)
            {
                _backgroundParser.Parse(document);
            }
        }

        protected override void OnDocumentClosing(DocumentId documentId)
        {
            if (_backgroundParser != null)
            {
                _backgroundParser.CancelParse(documentId);
            }
        }

        internal void OnSubjectBufferConnected(ITextView textView, ITextBuffer textBuffer)
        {
            // Add this ITextView to the list of known views for this buffer.
            _textBufferToViewsMap.GetOrCreateValue(textBuffer).Add(textView);

            // Do we already know about this text buffer?
            if (_textBufferToDocumentIdMap.TryGetValue(textBuffer, out var _))
            {
                return;
            }

            // If this is the disk buffer, get the associated ITextDocument.
            if (_textDocumentFactoryService.TryGetTextDocument(textBuffer, out var textDocument))
            {
                _textBufferToTextDocumentMap.Add(textBuffer, textDocument);

                // TODO: hookup textDocument.FileActionOccurred for renames.
            }

            var debugName = textDocument?.FilePath ?? "EmbeddedBuffer"; // TODO: Use more useful name based on projection buffer hierarchy.
            var documentId = DocumentId.CreateNewId(debugName);

            _textBufferToDocumentIdMap.Add(textBuffer, documentId);

            var textContainer = textBuffer.AsTextContainer();

            var document = CreateDocument(
                documentId, 
                textBuffer.ContentType.TypeName, 
                textContainer.CurrentText,
                textDocument?.FilePath);

            OnDocumentOpened(document);
        }

        internal void OnSubjectBufferDisconnected(ITextView textView, ITextBuffer textBuffer)
        {
            // Remove text view from the list of known text views for this text buffer.
            var textViews = _textBufferToViewsMap.GetOrCreateValue(textBuffer);
            textViews.Remove(textView);

            // Only close document if this is the last view referencing the text buffer.
            if (textViews.Count > 0)
            {
                return;
            }

            if (!_textBufferToDocumentIdMap.TryGetValue(textBuffer, out var _))
            {
                throw new InvalidOperationException();
            }

            var document = textBuffer.AsTextContainer().GetOpenDocumentInCurrentContext();

            OnDocumentClosed(document.Id);

            _textBufferToDocumentIdMap.Remove(textBuffer);
            _textBufferToTextDocumentMap.Remove(textBuffer);
            _textBufferToViewsMap.Remove(textBuffer);
        }

        protected override void ApplyDocumentTextChanged(DocumentId id, SourceText text)
        {
            var currentDocumentBuffer = CurrentDocuments.GetDocument(id)?.SourceText.Container.GetTextBuffer();
            if (currentDocumentBuffer == null)
            {
                return;
            }

            using (var edit = currentDocumentBuffer.CreateEdit(EditOptions.DefaultMinimalChange, reiteratedVersionNumber: null, editTag: null))
            {
                var oldSnapshot = currentDocumentBuffer.CurrentSnapshot;
                var oldText = oldSnapshot.AsText();
                var changes = text.GetTextChanges(oldText);
                //if (Workspace.TryGetWorkspace(oldText.Container, out var workspace))
                //{
                //    var undoService = workspace.Services.GetService<ISourceTextUndoService>();
                //    undoService.BeginUndoTransaction(oldSnapshot);
                //}

                foreach (var change in changes)
                {
                    edit.Replace(change.Span.Start, change.Span.Length, change.NewText);
                }

                edit.Apply();
            }
        }
    }
}
