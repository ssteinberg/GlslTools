using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class SourceParameterSymbol : ParameterSymbol
    {
        internal SourceParameterSymbol(ParameterSyntax syntax, Symbol parent, TypeSymbol valueType, ParameterDirection direction = ParameterDirection.In)
            : base(syntax.Declarator.Identifier.Text, string.Empty, parent, valueType, direction)
        {
            Syntax = syntax;

            Locations = ImmutableArray.Create(Syntax.Declarator.Identifier.SourceRange);
        }

        public ParameterSyntax Syntax { get; }

        public override bool HasDefaultValue => Syntax.Declarator.Initializer != null;

        public override string DefaultValueText => Syntax.Declarator.Initializer?.ToString();

        public override ImmutableArray<SourceRange> Locations { get; }
    }
}