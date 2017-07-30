namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundStateArrayInitializer : BoundInitializer
    {
        public BoundStateArrayInitializer()
            : base(BoundNodeKind.StateArrayInitializer)
        {
        }
    }
}