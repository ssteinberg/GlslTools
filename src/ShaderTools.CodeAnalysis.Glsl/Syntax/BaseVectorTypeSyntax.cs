namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public abstract class BaseVectorTypeSyntax : NumericTypeSyntax
    {
        protected BaseVectorTypeSyntax(SyntaxKind kind)
            : base(kind)
        {
        }
    }
}