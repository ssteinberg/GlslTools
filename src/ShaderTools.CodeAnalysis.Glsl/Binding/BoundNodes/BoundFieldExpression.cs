using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundFieldExpression : BoundExpression
    {
        public BoundFieldExpression(BoundExpression objectReference, FieldSymbol field)
            : base(BoundNodeKind.FieldExpression)
        {
            ObjectReference = objectReference;
            Field = field;
            Type = field.ValueType;
        }

        public override TypeSymbol Type { get; }
        public BoundExpression ObjectReference { get; }
        public FieldSymbol Field { get; }
    }
}