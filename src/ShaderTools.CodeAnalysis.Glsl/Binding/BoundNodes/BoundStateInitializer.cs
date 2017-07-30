namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundStateInitializer : BoundInitializer
    {
        public BoundStateInitializer()
            : base(BoundNodeKind.StateInitializer)
        {
        }
    }
}