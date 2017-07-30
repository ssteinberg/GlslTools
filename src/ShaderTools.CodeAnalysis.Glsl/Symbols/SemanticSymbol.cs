using System.Collections.Immutable;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public sealed class SemanticSymbol : Symbol
    {
        public override ImmutableArray<SourceRange> Locations { get; } = ImmutableArray<SourceRange>.Empty;

        internal SemanticSymbol(string name, string documentation, bool allowsMultiple, SemanticUsages usages, params TypeSymbol[] valueTypes)
            : base(SymbolKind.Semantic, name, documentation, null)
        {
            AllowsMultiple = allowsMultiple;
            Usages = usages;
            ValueTypes = valueTypes.ToImmutableArray();
        }

        public bool AllowsMultiple { get; }
        public SemanticUsages Usages { get; }
        public ImmutableArray<TypeSymbol> ValueTypes { get; }

        public string FullDescription
        {
            get
            {
                var usageString = string.Empty;
                if (Usages.HasFlag(SemanticUsages.VertexShaderInput))
                    usageString += "\n- Vertex shader input";
                if (Usages.HasFlag(SemanticUsages.VertexShaderOutput))
                    usageString += "\n- Vertex shader output";
                if (Usages.HasFlag(SemanticUsages.TessControlShaderInput))
                    usageString += "\n- Tessellation control shader input";
                if (Usages.HasFlag(SemanticUsages.TessControlShaderOutput))
                    usageString += "\n- Tessellation control shader output";
                if (Usages.HasFlag(SemanticUsages.TessEvalShaderInput))
                    usageString += "\n- Tessellation evaluation shader input";
                if (Usages.HasFlag(SemanticUsages.TessEvalShaderOutput))
                    usageString += "\n- Tessellation evaluation shader output";
                if (Usages.HasFlag(SemanticUsages.GeometryShaderInput))
                    usageString += "\n- Geometry shader input";
                if (Usages.HasFlag(SemanticUsages.GeometryShaderOutput))
                    usageString += "\n- Geometry shader output";
                if (Usages.HasFlag(SemanticUsages.PixelShaderInput))
                    usageString += "\n- Pixel shader input";
                if (Usages.HasFlag(SemanticUsages.PixelShaderOutput))
                    usageString += "\n- Pixel shader output";
                return $"{Documentation}\n\nAvailable for use in:{usageString}";
            }
        }
    }
}