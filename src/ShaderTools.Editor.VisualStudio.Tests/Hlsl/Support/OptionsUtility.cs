using System;
using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Glsl.Options;
using ShaderTools.CodeAnalysis.Options;

namespace ShaderTools.Editor.VisualStudio.Tests.Glsl.Support
{
    internal class FakeOptionsService : IGlslOptionsService
    {
        public FormattingOptions GetPrimaryWorkspaceFormattingOptions()
        {
            return new FormattingOptions();
        }

        public FormattingOptions GetFormattingOptions(OptionSet options)
        {
            return new FormattingOptions();
        }
    }
}