namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public abstract class NumericTypeSyntax : PredefinedTypeSyntax
    {
        protected NumericTypeSyntax(SyntaxKind kind)
            : base(kind)
        {
        }
    }
}