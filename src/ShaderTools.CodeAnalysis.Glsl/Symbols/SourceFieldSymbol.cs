using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class SourceFieldSymbol : FieldSymbol
    {
        internal SourceFieldSymbol(VariableDeclaratorSyntax syntax, TypeSymbol parent, TypeSymbol valueType)
            : base(syntax.Identifier.Text, string.Empty, parent, valueType)
        {
            Syntax = syntax;

            Locations = ImmutableArray.Create(Syntax.Identifier.SourceRange);
        }

        public VariableDeclaratorSyntax Syntax { get; }

        public override ImmutableArray<SourceRange> Locations { get; }
    }
}