using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Options;

namespace ShaderTools.CodeAnalysis.Glsl.Options
{
    internal interface IGlslOptionsService
    {
        FormattingOptions GetPrimaryWorkspaceFormattingOptions();
        FormattingOptions GetFormattingOptions(OptionSet options);
    }
}