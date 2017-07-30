namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public class SyntaxWalker : SyntaxVisitor
    {
        protected override void DefaultVisit(SyntaxNode node)
        {
            foreach (var childNode in node.ChildNodes)
                Visit((SyntaxNode) childNode);
        }
    }
}