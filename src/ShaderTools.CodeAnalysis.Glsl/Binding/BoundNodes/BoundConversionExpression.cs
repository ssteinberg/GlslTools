using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundConversionExpression : BoundExpression
    {
        public BoundConversionExpression(BoundExpression expression, TypeSymbol type, Conversion conversion)
            : base(BoundNodeKind.ConversionExpression)
        {
            Expression = expression;
            Type = type;
            Conversion = conversion;
        }

        public override TypeSymbol Type { get; }
        public Conversion Conversion { get; }

        public BoundExpression Expression { get; }
    }
}