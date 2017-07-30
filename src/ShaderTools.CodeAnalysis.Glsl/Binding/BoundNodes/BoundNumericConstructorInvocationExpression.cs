using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Binding.Signatures;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundNumericConstructorInvocationExpression : BoundExpression
    {
        public BoundNumericConstructorInvocationExpression(NumericConstructorInvocationExpressionSyntax syntax, TypeSymbol type, ImmutableArray<BoundExpression> arguments, OverloadResolutionResult<FunctionSymbolSignature> result)
            : base(BoundNodeKind.NumericConstructorInvocationExpression)
        {
            Syntax = syntax;
            Type = type;
            Arguments = arguments;
            Result = result;
        }

        public override TypeSymbol Type { get; }

        public FunctionSymbol Symbol => Result.Selected?.Signature.Symbol;

        public NumericConstructorInvocationExpressionSyntax Syntax { get; }
        public ImmutableArray<BoundExpression> Arguments { get; }
        public OverloadResolutionResult<FunctionSymbolSignature> Result { get; }

        public override string ToString()
        {
            return $"{Symbol.Name}({string.Join(",", Arguments)})";
        }
    }
}