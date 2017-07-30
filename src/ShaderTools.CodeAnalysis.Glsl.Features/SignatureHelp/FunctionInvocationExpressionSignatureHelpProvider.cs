using System.Collections.Generic;
using System.Composition;
using System.Linq;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.SignatureHelp;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.SignatureHelp
{
    [ExportSignatureHelpProvider(nameof(FunctionInvocationExpressionSignatureHelpProvider), LanguageNames.Glsl), Shared]
    internal sealed class FunctionInvocationExpressionSignatureHelpProvider : InvocationExpressionSignatureHelpProvider<FunctionInvocationExpressionSyntax>
    {
        protected override IEnumerable<FunctionSymbol> GetFunctionSymbols(SemanticModel semanticModel, FunctionInvocationExpressionSyntax node, SourceLocation position)
        {
            var name = node.Name;
            return semanticModel
                .LookupSymbols(name.SourceRange.Start)
                .OfType<FunctionSymbol>()
                .Where(f => !f.IsNumericConstructor && name.GetUnqualifiedName().Name.Text == f.Name);
        }
    }
}
