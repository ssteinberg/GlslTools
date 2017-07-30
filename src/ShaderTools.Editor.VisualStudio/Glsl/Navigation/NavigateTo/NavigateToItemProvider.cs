﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.NavigateTo.Interfaces;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.TextManager.Interop;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;
using ShaderTools.Editor.VisualStudio.Core.Glyphs;
using ShaderTools.Editor.VisualStudio.Glsl.Util.Extensions;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.NavigateTo
{
    internal sealed class NavigateToItemProvider : INavigateToItemProvider
    {
        private readonly IBufferGraphFactoryService _bufferGraphFactoryService;
        private readonly NavigateToItemProviderFactory _navigateToItemProviderFactory;
        private readonly DispatcherGlyphService _glyphService;
        private readonly IServiceProvider _serviceProvider;
        private CancellationTokenSource _searchCancellationTokenSource;

        public NavigateToItemProvider(
            IBufferGraphFactoryService bufferGraphFactoryService, 
            NavigateToItemProviderFactory navigateToItemProviderFactory, 
            DispatcherGlyphService glyphService,
            IServiceProvider serviceProvider)
        {
            _bufferGraphFactoryService = bufferGraphFactoryService;
            _navigateToItemProviderFactory = navigateToItemProviderFactory;
            _glyphService = glyphService;
            _serviceProvider = serviceProvider;
        }

        public void StartSearch(INavigateToCallback callback, string searchValue)
        {
            var textView = GetCurrentTextView();
            if (textView == null)
            {
                callback.Done();
                return;
            }

            var cancellationTokenSource = new CancellationTokenSource();
            _searchCancellationTokenSource = cancellationTokenSource;

            var cancellationToken = cancellationTokenSource.Token;

            var snapshot = textView.TextSnapshot;
            var document = snapshot.GetOpenDocumentInCurrentContextWithChanges();

            Task.Run(async () =>
            {
                try
                {
                    var syntaxTree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);

                    var visitor = new NavigateToVisitor(
                        searchValue, snapshot, textView, callback, _bufferGraphFactoryService,
                        _navigateToItemProviderFactory, _glyphService, cancellationToken);

                    visitor.Visit((SyntaxNode) syntaxTree.Root);
                }
                catch (OperationCanceledException)
                {
                    
                }
                finally
                {
                    callback.Done();
                }
            }, cancellationToken);
        }

        public void StopSearch()
        {
            var currentCancellationTokenSource = Interlocked.Exchange(ref _searchCancellationTokenSource, null);
            currentCancellationTokenSource?.Cancel();
        }

        public void Dispose()
        {
            
        }

        private IWpfTextView GetCurrentTextView()
        {
            try
            {
                var componentModel = (IComponentModel) _serviceProvider.GetService(typeof(SComponentModel));
                var textManager = (IVsTextManager) _serviceProvider.GetService(typeof(SVsTextManager));

                var editorAdaptersFactoryService = componentModel.GetService<IVsEditorAdaptersFactoryService>();

                IVsTextView vsTextView;
                ErrorHandler.ThrowOnFailure(textManager.GetActiveView(0, null, out vsTextView));
                return editorAdaptersFactoryService.GetWpfTextView(vsTextView);
            }
            catch
            {
                // Both ThrowOnFailure and GetWpfTextView can throw an exception.  The latter will
                // throw even if a non-null value is passed into it 
                return null;
            }
        }
    }
}