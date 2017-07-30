using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal abstract class BoundFunction : BoundNode
    {
        public FunctionSymbol FunctionSymbol { get; }
        public ImmutableArray<BoundVariableDeclaration> Parameters { get; }

        protected BoundFunction(BoundNodeKind kind, FunctionSymbol functionSymbol, ImmutableArray<BoundVariableDeclaration> parameters)
            : base(kind)
        {
            FunctionSymbol = functionSymbol;
            Parameters = parameters;
        }
    }
}