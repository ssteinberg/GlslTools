namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundDiscardStatement : BoundStatement
    {
        public BoundDiscardStatement()
            : base(BoundNodeKind.DiscardStatement)
        {
        }
    }
}