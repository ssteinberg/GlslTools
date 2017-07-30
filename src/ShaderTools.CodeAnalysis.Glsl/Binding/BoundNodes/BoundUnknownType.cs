using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundUnknownType : BoundType
    {
        public BoundUnknownType()
            : base(BoundNodeKind.UnknownType, TypeFacts.Unknown)
        {
        }
    }
}