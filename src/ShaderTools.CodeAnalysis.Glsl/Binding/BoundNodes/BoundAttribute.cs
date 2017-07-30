using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundAttribute : BoundNode
    {
        public AttributeSymbol AttributeSymbol { get; }

        public BoundAttribute(AttributeSymbol attributeSymbol)
            : base(BoundNodeKind.Attribute)
        {
            AttributeSymbol = attributeSymbol;
        }
    }
}