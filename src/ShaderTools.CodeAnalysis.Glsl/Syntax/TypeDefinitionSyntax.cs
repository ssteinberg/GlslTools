namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public abstract class TypeDefinitionSyntax : TypeSyntax
    {
        public abstract SyntaxToken NameToken { get; }

        protected TypeDefinitionSyntax(SyntaxKind kind)
            : base(kind)
        {
        }
    }
}