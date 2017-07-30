using System.ComponentModel.Composition;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    [Export(typeof(IGoToDefinitionProvider))]
    internal sealed class MacroReferenceGoToDefinitionProvider : GoToDefinitionProvider<SyntaxToken>
    {
        protected override SourceFileSpan? CreateTargetSpan(Document document, SemanticModel semanticModel, SourceLocation position, SyntaxToken node)
        {
            if (node.MacroReference == null)
                return null;

            var nameToken = node.MacroReference.NameToken;

            if (!nameToken.SourceRange.ContainsOrTouches(position))
                return null;

            if (!nameToken.FileSpan.IsInRootFile)
                return null;

            return node.MacroReference.DefineDirective.MacroName.FileSpan;
        }
    }
}