using System.Collections.Generic;
using System.Composition;
using System.Linq;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.SignatureHelp;
using ShaderTools.CodeAnalysis.Text;
using ShaderTools.Utilities.Collections;

namespace ShaderTools.CodeAnalysis.Glsl.SignatureHelp
{
    [ExportSignatureHelpProvider(nameof(NumericConstructorInvocationExpressionSignatureHelpProvider), LanguageNames.Glsl), Shared]
    internal sealed class NumericConstructorInvocationExpressionSignatureHelpProvider : InvocationExpressionSignatureHelpProvider<NumericConstructorInvocationExpressionSyntax>
    {
        protected override IEnumerable<FunctionSymbol> GetFunctionSymbols(SemanticModel semanticModel, NumericConstructorInvocationExpressionSyntax node, SourceLocation position)
        {
            var typeSymbol = semanticModel.GetExpressionType(node);
            if (typeSymbol.IsError())
                return SpecializedCollections.EmptyEnumerable<FunctionSymbol>();

            return semanticModel
                .LookupSymbols(node.Type.SourceRange.Start)
                .OfType<FunctionSymbol>()
                .Where(f => f.IsNumericConstructor && f.ReturnType.Equals(typeSymbol));
        }
    }
}
