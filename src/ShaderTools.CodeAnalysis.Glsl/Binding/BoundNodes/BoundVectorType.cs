using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundVectorType : BoundType
    {
        public IntrinsicVectorTypeSymbol VectorSymbol { get; }

        public BoundVectorType(IntrinsicVectorTypeSymbol vectorSymbol)
            : base(BoundNodeKind.IntrinsicGenericVectorType, vectorSymbol)
        {
            VectorSymbol = vectorSymbol;
        }
    }
}