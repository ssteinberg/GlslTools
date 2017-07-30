using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class TechniqueSymbol : Symbol
    {
        public override ImmutableArray<SourceRange> Locations { get; }

        internal TechniqueSymbol(TechniqueSyntax syntax)
            : base(SymbolKind.Technique, syntax.Name?.Text, string.Empty, null)
        {
            Locations = syntax.Name != null
                ? ImmutableArray.Create(syntax.Name.SourceRange)
                : ImmutableArray<SourceRange>.Empty;
        }
    }
}