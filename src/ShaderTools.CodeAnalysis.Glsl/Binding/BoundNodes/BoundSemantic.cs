using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes
{
    internal sealed class BoundSemantic : BoundVariableQualifier
    {
        public SemanticSymbol SemanticSymbol { get; }

        public BoundSemantic(SemanticSymbol semanticSymbol)
            : base(BoundNodeKind.Semantic)
        {
            SemanticSymbol = semanticSymbol;
        }
    }
}