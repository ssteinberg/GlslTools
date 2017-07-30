namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundErrorNode : BoundNode
    {
        public BoundErrorNode()
            : base(BoundNodeKind.Error)
        {
            
        }
    }
}