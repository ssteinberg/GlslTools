using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundTypeAlias : BoundNode
    {
        public BoundTypeAlias(TypeAliasSymbol typeAliasSymbol, TypeSymbol declaredType, ImmutableArray<BoundVariableQualifier> qualifiers)
            : base(BoundNodeKind.TypeAlias)
        {
            TypeAliasSymbol = typeAliasSymbol;
            DeclaredType = declaredType;
            Qualifiers = qualifiers;
        }

        public TypeAliasSymbol TypeAliasSymbol { get; }
        public TypeSymbol DeclaredType { get; }
        public ImmutableArray<BoundVariableQualifier> Qualifiers { get; }
    }
}