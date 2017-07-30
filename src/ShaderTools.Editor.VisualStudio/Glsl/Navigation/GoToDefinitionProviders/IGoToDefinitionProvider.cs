using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    internal interface IGoToDefinitionProvider
    {
        SourceFileSpan? GetTargetSpan(Document document, SemanticModel semanticModel, SourceLocation position);
    }
}