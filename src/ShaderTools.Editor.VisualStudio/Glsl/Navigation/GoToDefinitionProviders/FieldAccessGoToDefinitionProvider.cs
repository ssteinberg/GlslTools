using System.ComponentModel.Composition;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    [Export(typeof(IGoToDefinitionProvider))]
    internal sealed class FieldAccessGoToDefinitionProvider : SymbolReferenceGoToDefinitionProvider<FieldAccessExpressionSyntax>
    {
        protected override SyntaxToken GetNameToken(FieldAccessExpressionSyntax node)
        {
            return node.Name;
        }
    }
}