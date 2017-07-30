using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundErrorExpression : BoundExpression
    {
        public BoundErrorExpression()
            : base(BoundNodeKind.ErrorExpression)
        {
            Type = TypeFacts.Unknown;
        }

        public override TypeSymbol Type { get; }
    }
}