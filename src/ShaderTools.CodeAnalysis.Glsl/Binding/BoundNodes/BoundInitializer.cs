namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal abstract class BoundInitializer : BoundNode
    {
        protected BoundInitializer(BoundNodeKind kind)
            : base(kind)
        {
        }
    }
}