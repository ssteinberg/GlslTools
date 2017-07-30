﻿using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public abstract class IntrinsicTypeSymbol : TypeSymbol
    {
        public override ImmutableArray<SourceRange> Locations { get; } = ImmutableArray<SourceRange>.Empty;

        internal IntrinsicTypeSymbol(SymbolKind kind, string name, string documentation)
            : base(kind, name, documentation, null)
        {
            
        }
    }
}