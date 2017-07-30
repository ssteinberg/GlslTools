using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundFunctionDeclaration : BoundFunction
    {
        public BoundType ReturnType { get; }

        public BoundFunctionDeclaration(FunctionSymbol functionSymbol, BoundType returnType, ImmutableArray<BoundVariableDeclaration> parameters)
            : base(BoundNodeKind.FunctionDeclaration, functionSymbol, parameters)
        {
            ReturnType = returnType;
        }
    }
}