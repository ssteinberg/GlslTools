namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundContinueStatement : BoundStatement
    {
        public BoundContinueStatement()
            : base(BoundNodeKind.ContinueStatement)
        {
        }
    }
}