using System;

namespace ShaderTools.CodeAnalysis.Hlsl.Symbols
{
    [Flags]
    public enum SemanticUsages
    {
        None = 0,

        VertexShaderInput = 1 << 0,
        VertexShaderOutput = 1 << 1,

        PixelShaderInput = 1 << 2,
        PixelShaderOutput = 1 << 3,

        GeometryShaderInput = 1 << 4,
        GeometryShaderOutput = 1 << 5,

        TessEvalShaderInput = 1 << 6,
        TessEvalShaderOutput = 1 << 7,

        TessControlShaderInput = 1 << 8,
        TessControlShaderOutput = 1 << 9,

        ComputeShaderInput = 1 << 10,
        ComputeShaderOutput = 1 << 11,

        AllShaders = VertexShaderInput | VertexShaderOutput
                     | PixelShaderInput | PixelShaderOutput 
                     | GeometryShaderInput | GeometryShaderOutput
                     | TessControlShaderInput | TessControlShaderOutput
                     | TessEvalShaderInput | TessEvalShaderOutput
                     | ComputeShaderInput | ComputeShaderOutput
    }
}