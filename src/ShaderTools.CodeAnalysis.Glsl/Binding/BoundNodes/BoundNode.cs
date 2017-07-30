namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal abstract class BoundNode
    {
        public BoundNodeKind Kind { get; }

        protected BoundNode(BoundNodeKind kind)
        {
            Kind = kind;
        }
    }
}