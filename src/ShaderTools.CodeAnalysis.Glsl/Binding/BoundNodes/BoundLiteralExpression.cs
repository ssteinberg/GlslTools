using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public BoundLiteralExpression(LiteralExpressionSyntax syntax, TypeSymbol type)
            : base(BoundNodeKind.LiteralExpression)
        {
            Type = type;
            Value = syntax.Token.Value;
        }

        public override TypeSymbol Type { get; }
        public object Value { get; }
    }
}