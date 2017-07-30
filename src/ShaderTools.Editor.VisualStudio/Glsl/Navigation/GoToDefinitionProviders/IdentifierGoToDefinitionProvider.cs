using System.ComponentModel.Composition;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    [Export(typeof(IGoToDefinitionProvider))]
    internal sealed class IdentifierGoToDefinitionProvider : SymbolReferenceGoToDefinitionProvider<IdentifierNameSyntax>
    {
        protected override SyntaxToken GetNameToken(IdentifierNameSyntax node)
        {
            return node.Name;
        }
    }
}