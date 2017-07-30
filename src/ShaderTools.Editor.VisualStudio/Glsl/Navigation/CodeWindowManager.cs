﻿using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.TextManager.Interop;
using ShaderTools.Editor.VisualStudio.Core;
using ShaderTools.Editor.VisualStudio.Core.Navigation;
using ShaderTools.Editor.VisualStudio.Core.Util.Extensions;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation
{
    internal sealed class CodeWindowManager : CodeWindowManagerBase
    {
        public CodeWindowManager(LanguagePackageBase languagePackage, IVsCodeWindow codeWindow, SVsServiceProvider serviceProvider)
            : base(languagePackage, codeWindow, serviceProvider)
        {
        }

        protected override bool TryCreateDropdownBarClient(out int comboBoxCount, out IVsDropdownBarClient client)
        {
            comboBoxCount = 2;
            client = CreateDropdownBarClient();

            return true;
        }

        private IVsDropdownBarClient CreateDropdownBarClient()
        {
            var componentModel = ComponentModel;

            var editorAdaptersFactory = componentModel.DefaultExportProvider.GetExportedValueOrDefault<IVsEditorAdaptersFactoryService>();
            var bufferGraphFactoryService = componentModel.DefaultExportProvider.GetExportedValue<IBufferGraphFactoryService>();

            var textView = editorAdaptersFactory.GetWpfTextView(CodeWindow.GetPrimaryView());

            var editorNavigationSourceProvider = componentModel.DefaultExportProvider.GetExportedValueOrDefault<EditorNavigationSourceProvider>();
            var editorNavigationSource = editorNavigationSourceProvider.TryCreateEditorNavigationSource(textView.TextBuffer);

            return new EditorNavigationDropdownBarClient(CodeWindow, editorAdaptersFactory, editorNavigationSource, bufferGraphFactoryService);
        }
    }
}