using ShaderTools.CodeAnalysis.Glsl.Binding.Signatures;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {
        public UnaryOperatorKind OperatorKind { get; }
        public BoundExpression Expression { get; }
        public OverloadResolutionResult<UnaryOperatorSignature> Result { get; }

        public override TypeSymbol Type => Result.Selected == null ? TypeFacts.Unknown : Result.Selected.Signature.ReturnType;

        public BoundUnaryExpression(UnaryOperatorKind operatorKind, BoundExpression expression, OverloadResolutionResult<UnaryOperatorSignature> result)
            : base(BoundNodeKind.UnaryExpression)
        {
            OperatorKind = operatorKind;
            Expression = expression;
            Result = result;
        }
    }
}