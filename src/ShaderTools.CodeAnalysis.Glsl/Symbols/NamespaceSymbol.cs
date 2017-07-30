using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class NamespaceSymbol : ContainerSymbol
    {
        public NamespaceSyntax Syntax { get; }

        public override ImmutableArray<SourceRange> Locations { get; }

        internal NamespaceSymbol(NamespaceSyntax syntax, Symbol parent)
            : base(SymbolKind.Namespace, syntax.Name.Text, string.Empty, parent)
        {
            Syntax = syntax;

            Locations = ImmutableArray.Create(syntax.Name.SourceRange);
        }
    }
}