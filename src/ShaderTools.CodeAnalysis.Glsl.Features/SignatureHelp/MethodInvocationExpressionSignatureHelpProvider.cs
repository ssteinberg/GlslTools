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
    [ExportSignatureHelpProvider(nameof(MethodInvocationExpressionSignatureHelpProvider), LanguageNames.Glsl), Shared]
    internal sealed class MethodInvocationExpressionSignatureHelpProvider : InvocationExpressionSignatureHelpProvider<MethodInvocationExpressionSyntax>
    {
        protected override IEnumerable<FunctionSymbol> GetFunctionSymbols(SemanticModel semanticModel, MethodInvocationExpressionSyntax node, SourceLocation position)
        {
            var targetType = semanticModel.GetExpressionType(node.Target);
            var name = node.Name;
            return targetType
                .LookupMembers<FunctionSymbol>(name.Text)
                .OrderBy(f => f.Parameters.Length);
        }
    }
}
