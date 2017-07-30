﻿using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class InterfaceSymbol : TypeSymbol
    {
        public override ImmutableArray<SourceRange> Locations { get; }

        internal InterfaceSymbol(InterfaceTypeSyntax syntax, Symbol parent)
            : base(SymbolKind.Interface, syntax.Name.Text, string.Empty, parent)
        {
            Locations = ImmutableArray.Create(syntax.Name.SourceRange);
        }
    }
}