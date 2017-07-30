using System.ComponentModel.Composition;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    [Export(typeof(IGoToDefinitionProvider))]
    internal sealed class FunctionInvocationGoToDefinitionProvider : SymbolReferenceGoToDefinitionProvider<FunctionInvocationExpressionSyntax>
    {
        protected override SyntaxToken GetNameToken(FunctionInvocationExpressionSyntax node)
        {
            return node.Name.GetUnqualifiedName().Name;
        }
    }
}