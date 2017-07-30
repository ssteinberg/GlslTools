﻿using System.Collections.Generic;
using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class ArraySymbol : TypeSymbol
    {
        public TypeSymbol ValueType { get; }
        public int? Dimension { get; }

        public override ImmutableArray<SourceRange> Locations => ValueType.Locations;

        internal ArraySymbol(TypeSymbol valueType, int? dimension)
            : base(SymbolKind.Array, $"{valueType.FullName}[{dimension?.ToString() ?? string.Empty}]", "Array of " + valueType.Name, null)
        {
            foreach (var member in CreateArrayMembers(this, valueType))
                AddMember(member);

            ValueType = valueType;
            Dimension = dimension;
        }

        private static IEnumerable<Symbol> CreateArrayMembers(TypeSymbol parent, TypeSymbol valueType)
        {
            yield return new IndexerSymbol("[]", string.Empty, parent, IntrinsicTypes.Uint, valueType);
        }

        private bool Equals(ArraySymbol other)
        {
            return base.Equals(other) 
                && Equals(ValueType, other.ValueType) 
                && Dimension == other.Dimension;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ArraySymbol && Equals((ArraySymbol) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ ValueType.GetHashCode();
                hashCode = (hashCode * 397) ^ Dimension.GetHashCode();
                return hashCode;
            }
        }
    }
}