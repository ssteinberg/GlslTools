﻿using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation
{
    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType(GlslConstants.ContentTypeName)]
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class GoToDefinitionTextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        public IVsEditorAdaptersFactoryService EditorAdaptersFactoryService { get; set; }

        [Import]
        public GoToDefinitionProviderService GoToDefinitionProviderService { get; set; }

        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            var textView = EditorAdaptersFactoryService.GetWpfTextView(textViewAdapter);

            textView.Properties.GetOrCreateSingletonProperty(() => new GoToDefinitionCommandTarget(textViewAdapter, textView, GoToDefinitionProviderService, ServiceProvider));
            textView.Properties.GetOrCreateSingletonProperty(() => new OpenIncludeFileCommandTarget(textViewAdapter, textView, ServiceProvider));
        }
    }
}