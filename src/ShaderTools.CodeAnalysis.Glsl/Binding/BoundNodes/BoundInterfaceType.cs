using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundInterfaceType : BoundType
    {
        public InterfaceSymbol InterfaceSymbol { get; }
        public ImmutableArray<BoundFunction> Methods { get; }

        public BoundInterfaceType(InterfaceSymbol interfaceSymbol, ImmutableArray<BoundFunction> methods)
            : base(BoundNodeKind.InterfaceType, interfaceSymbol)
        {
            InterfaceSymbol = interfaceSymbol;
            Methods = methods;
        }
    }
}