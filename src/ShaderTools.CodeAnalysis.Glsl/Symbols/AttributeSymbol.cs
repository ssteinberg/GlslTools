using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class AttributeSymbol : InvocableSymbol
    {
        public override ImmutableArray<SourceRange> Locations { get; } = ImmutableArray<SourceRange>.Empty;

        internal AttributeSymbol(string name, string documentation)
            : base(SymbolKind.Attribute, name, documentation, null, TypeFacts.Missing)
        {
        }
    }
}