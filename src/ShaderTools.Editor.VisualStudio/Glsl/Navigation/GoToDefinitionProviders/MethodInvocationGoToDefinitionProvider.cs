using System.ComponentModel.Composition;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    [Export(typeof(IGoToDefinitionProvider))]
    internal sealed class MethodInvocationGoToDefinitionProvider : SymbolReferenceGoToDefinitionProvider<MethodInvocationExpressionSyntax>
    {
        protected override SyntaxToken GetNameToken(MethodInvocationExpressionSyntax node)
        {
            return node.Name;
        }
    }
}