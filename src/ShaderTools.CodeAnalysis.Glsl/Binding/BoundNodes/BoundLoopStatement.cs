namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal abstract class BoundLoopStatement : BoundStatement
    {
        protected BoundLoopStatement(BoundNodeKind kind)
            : base(kind)
        {
        }
    }
}