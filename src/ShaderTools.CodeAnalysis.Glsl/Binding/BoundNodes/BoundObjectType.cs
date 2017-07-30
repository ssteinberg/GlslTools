using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundObjectType : BoundType
    {
        public IntrinsicObjectTypeSymbol ObjectSymbol { get; }

        public BoundObjectType(IntrinsicObjectTypeSymbol objectSymbol)
            : base(BoundNodeKind.IntrinsicObjectType, objectSymbol)
        {
            ObjectSymbol = objectSymbol;
        }
    }
}