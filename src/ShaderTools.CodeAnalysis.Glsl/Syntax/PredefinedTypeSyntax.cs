namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public abstract class PredefinedTypeSyntax : TypeSyntax
    {
        protected PredefinedTypeSyntax(SyntaxKind kind)
            : base(kind)
        {
        }
    }
}