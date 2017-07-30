using System;
using System.Collections.Generic;
using System.Linq;
using ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public static class SyntaxFacts
    {
        public static string GetDisplayText(this SyntaxToken token)
        {
            var result = token.Text;
            return !string.IsNullOrEmpty(result) ? result : token.Kind.GetDisplayText();
        }

        public static string GetDisplayText(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.EndOfFileToken:
                    return "<end-of-file>";

                case SyntaxKind.IdentifierToken:
                    return "<identifier>";

                case SyntaxKind.FloatLiteralToken:
                    return "<float-literal>";

                case SyntaxKind.IntegerLiteralToken:
                    return "<integer-literal>";

                case SyntaxKind.StringLiteralToken:
                    return "<string-literal>";

                default:
                    return GetText(kind);
            }
        }

        public static string GetText(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.TildeToken:
                    return "~";
                case SyntaxKind.NotToken:
                    return "!";
                case SyntaxKind.PercentToken:
                    return "%";
                case SyntaxKind.CaretToken:
                    return "^";
                case SyntaxKind.AmpersandToken:
                    return "&";
                case SyntaxKind.AsteriskToken:
                    return "*";
                case SyntaxKind.OpenParenToken:
                    return "(";
                case SyntaxKind.CloseParenToken:
                    return ")";
                case SyntaxKind.MinusToken:
                    return "-";
                case SyntaxKind.PlusToken:
                    return "+";
                case SyntaxKind.EqualsToken:
                    return "=";
                case SyntaxKind.OpenBraceToken:
                    return "{";
                case SyntaxKind.CloseBraceToken:
                    return "}";
                case SyntaxKind.OpenBracketToken:
                    return "[";
                case SyntaxKind.CloseBracketToken:
                    return "]";
                case SyntaxKind.BarToken:
                    return "|";
                case SyntaxKind.ColonToken:
                    return ":";
                case SyntaxKind.SemiToken:
                    return ";";
                //case SyntaxKind.DoubleQuoteToken:
                //    return "\"";
                case SyntaxKind.LessThanToken:
                    return "<";
                case SyntaxKind.CommaToken:
                    return ",";
                case SyntaxKind.GreaterThanToken:
                    return ">";
                case SyntaxKind.DotToken:
                    return ".";
                case SyntaxKind.QuestionToken:
                    return "?";
                case SyntaxKind.HashToken:
                    return "#";
                case SyntaxKind.SlashToken:
                    return "/";

                // compound
                case SyntaxKind.BarBarToken:
                    return "||";
                case SyntaxKind.AmpersandAmpersandToken:
                    return "&&";
                case SyntaxKind.MinusMinusToken:
                    return "--";
                case SyntaxKind.PlusPlusToken:
                    return "++";
                case SyntaxKind.ColonColonToken:
                    return "::";
                case SyntaxKind.ExclamationEqualsToken:
                    return "!=";
                case SyntaxKind.EqualsEqualsToken:
                    return "==";
                case SyntaxKind.LessThanEqualsToken:
                    return "<=";
                case SyntaxKind.LessThanLessThanToken:
                    return "<<";
                case SyntaxKind.LessThanLessThanEqualsToken:
                    return "<<=";
                case SyntaxKind.GreaterThanEqualsToken:
                    return ">=";
                case SyntaxKind.GreaterThanGreaterThanToken:
                    return ">>";
                case SyntaxKind.GreaterThanGreaterThanEqualsToken:
                    return ">>=";
                case SyntaxKind.SlashEqualsToken:
                    return "/=";
                case SyntaxKind.AsteriskEqualsToken:
                    return "*=";
                case SyntaxKind.BarEqualsToken:
                    return "|=";
                case SyntaxKind.AmpersandEqualsToken:
                    return "&=";
                case SyntaxKind.PlusEqualsToken:
                    return "+=";
                case SyntaxKind.MinusEqualsToken:
                    return "-=";
                case SyntaxKind.CaretEqualsToken:
                    return "^=";
                case SyntaxKind.PercentEqualsToken:
                    return "%=";

                // Keywords
                case SyntaxKind.BoolKeyword:
                    return "bool";
                case SyntaxKind.BreakKeyword:
                    return "break";
                case SyntaxKind.CaseKeyword:
                    return "case";
                case SyntaxKind.ClassKeyword:
                    return "class";
                case SyntaxKind.ConstKeyword:
                    return "const";
                case SyntaxKind.ContinueKeyword:
                    return "continue";
                case SyntaxKind.DefKeyword:
                    return "def";
                case SyntaxKind.DefineKeyword:
                    return "define";
                case SyntaxKind.DoKeyword:
                    return "do";
                case SyntaxKind.DefaultKeyword:
                    return "default";
                case SyntaxKind.DoubleKeyword:
                    return "double";
                case SyntaxKind.ElifKeyword:
                    return "elif";
                case SyntaxKind.ElseKeyword:
                    return "else";
                case SyntaxKind.EndIfKeyword:
                    return "endif";
                case SyntaxKind.ErrorKeyword:
                    return "error";
                case SyntaxKind.ExportKeyword:
                    return "export";
                case SyntaxKind.ExternKeyword:
                    return "extern";
                case SyntaxKind.FalseKeyword:
                    return "false";
                case SyntaxKind.FloatKeyword:
                    return "float";
                case SyntaxKind.ForKeyword:
                    return "for";
                case SyntaxKind.IfKeyword:
                    return "if";
                case SyntaxKind.IncludeKeyword:
                    return "include";
                case SyntaxKind.InKeyword:
                    return "in";
                case SyntaxKind.InlineKeyword:
                    return "inline";
                case SyntaxKind.InoutKeyword:
                    return "inout";
                case SyntaxKind.InterfaceKeyword:
                    return "interface";
                case SyntaxKind.IntKeyword:
                    return "int";
                case SyntaxKind.LineKeyword:
                    return "line";
                case SyntaxKind.OutKeyword:
                    return "out";
                case SyntaxKind.PackMatrixKeyword:
                    return "pack_matrix";
                case SyntaxKind.PackoffsetKeyword:
                    return "packoffset";
                case SyntaxKind.PragmaKeyword:
                    return "pragma";
                case SyntaxKind.RegisterKeyword:
                    return "register";
                case SyntaxKind.ReturnKeyword:
                    return "return";
                case SyntaxKind.SNormKeyword:
                    return "snorm";
                case SyntaxKind.StaticKeyword:
                    return "static";
                case SyntaxKind.StringKeyword:
                    return "string";
                case SyntaxKind.StructKeyword:
                    return "struct";
                case SyntaxKind.SwitchKeyword:
                    return "switch";
                case SyntaxKind.TrueKeyword:
                    return "true";
                case SyntaxKind.UintKeyword:
                    return "uint";
                case SyntaxKind.UndefKeyword:
                    return "undef";
                case SyntaxKind.UNormKeyword:
                    return "unorm";
                case SyntaxKind.VoidKeyword:
                    return "void";
                case SyntaxKind.VolatileKeyword:
                    return "volatile";
                case SyntaxKind.WarningKeyword:
                    return "warning";
                case SyntaxKind.WhileKeyword:
                    return "while";

                default:
                    return string.Empty;
            }
        }

        public static bool IsIdentifierOrKeyword(this SyntaxKind kind)
        {
            return kind == SyntaxKind.IdentifierToken || kind.IsKeyword();
        }

        public static bool IsRightAssociative(SyntaxKind op)
        {
            switch (op)
            {
                case SyntaxKind.SimpleAssignmentExpression:
                case SyntaxKind.AddAssignmentExpression:
                case SyntaxKind.SubtractAssignmentExpression:
                case SyntaxKind.MultiplyAssignmentExpression:
                case SyntaxKind.DivideAssignmentExpression:
                case SyntaxKind.ModuloAssignmentExpression:
                case SyntaxKind.AndAssignmentExpression:
                case SyntaxKind.ExclusiveOrAssignmentExpression:
                case SyntaxKind.OrAssignmentExpression:
                case SyntaxKind.LeftShiftAssignmentExpression:
                case SyntaxKind.RightShiftAssignmentExpression:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsAssignmentExpression(SyntaxKind token)
        {
            return GetAssignmentExpression(token) != SyntaxKind.None;
        }

        public static SyntaxKind GetAssignmentExpression(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.EqualsToken:
                    return SyntaxKind.SimpleAssignmentExpression;
                case SyntaxKind.AsteriskEqualsToken:
                    return SyntaxKind.MultiplyAssignmentExpression;
                case SyntaxKind.SlashEqualsToken:
                    return SyntaxKind.DivideAssignmentExpression;
                case SyntaxKind.PercentEqualsToken:
                    return SyntaxKind.ModuloAssignmentExpression;
                case SyntaxKind.PlusEqualsToken:
                    return SyntaxKind.AddAssignmentExpression;
                case SyntaxKind.MinusEqualsToken:
                    return SyntaxKind.SubtractAssignmentExpression;
                case SyntaxKind.LessThanLessThanEqualsToken:
                    return SyntaxKind.LeftShiftAssignmentExpression;
                case SyntaxKind.GreaterThanGreaterThanEqualsToken:
                    return SyntaxKind.RightShiftAssignmentExpression;
                case SyntaxKind.AmpersandEqualsToken:
                    return SyntaxKind.AndAssignmentExpression;
                case SyntaxKind.CaretEqualsToken:
                    return SyntaxKind.ExclusiveOrAssignmentExpression;
                case SyntaxKind.BarEqualsToken:
                    return SyntaxKind.OrAssignmentExpression;
                default:
                    return SyntaxKind.None;
            }
        }

        public static bool IsBinaryExpression(SyntaxKind token)
        {
            return GetBinaryExpression(token) != SyntaxKind.None;
        }

        public static SyntaxKind GetBinaryExpression(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.AsteriskToken:
                    return SyntaxKind.MultiplyExpression;
                case SyntaxKind.SlashToken:
                    return SyntaxKind.DivideExpression;
                case SyntaxKind.PercentToken:
                    return SyntaxKind.ModuloExpression;
                case SyntaxKind.PlusToken:
                    return SyntaxKind.AddExpression;
                case SyntaxKind.MinusToken:
                    return SyntaxKind.SubtractExpression;
                case SyntaxKind.LessThanLessThanToken:
                    return SyntaxKind.LeftShiftExpression;
                case SyntaxKind.GreaterThanGreaterThanToken:
                    return SyntaxKind.RightShiftExpression;
                case SyntaxKind.LessThanToken:
                    return SyntaxKind.LessThanExpression;
                case SyntaxKind.GreaterThanToken:
                    return SyntaxKind.GreaterThanExpression;
                case SyntaxKind.LessThanEqualsToken:
                    return SyntaxKind.LessThanOrEqualExpression;
                case SyntaxKind.GreaterThanEqualsToken:
                    return SyntaxKind.GreaterThanOrEqualExpression;
                case SyntaxKind.EqualsEqualsToken:
                    return SyntaxKind.EqualsExpression;
                case SyntaxKind.ExclamationEqualsToken:
                    return SyntaxKind.NotEqualsExpression;
                case SyntaxKind.AmpersandToken:
                    return SyntaxKind.BitwiseAndExpression;
                case SyntaxKind.CaretToken:
                    return SyntaxKind.ExclusiveOrExpression;
                case SyntaxKind.BarToken:
                    return SyntaxKind.BitwiseOrExpression;
                case SyntaxKind.AmpersandAmpersandToken:
                    return SyntaxKind.LogicalAndExpression;
                case SyntaxKind.BarBarToken:
                    return SyntaxKind.LogicalOrExpression;
                default:
                    return SyntaxKind.None;
            }
        }

        public static bool IsPredefinedScalarType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.BoolKeyword:
                case SyntaxKind.IntKeyword:
                case SyntaxKind.UnsignedKeyword: // Needs to be followed by IntKeyword
                case SyntaxKind.DwordKeyword:
                case SyntaxKind.UintKeyword:
                case SyntaxKind.FloatKeyword:
                case SyntaxKind.DoubleKeyword:
                case SyntaxKind.VoidKeyword:
                case SyntaxKind.StringKeyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPredefinedVectorType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.VectorKeyword:
                case SyntaxKind.Bool1Keyword:
                case SyntaxKind.Bool2Keyword:
                case SyntaxKind.Bool3Keyword:
                case SyntaxKind.Bool4Keyword:
                case SyntaxKind.Int1Keyword:
                case SyntaxKind.Int2Keyword:
                case SyntaxKind.Int3Keyword:
                case SyntaxKind.Int4Keyword:
                case SyntaxKind.Uint1Keyword:
                case SyntaxKind.Uint2Keyword:
                case SyntaxKind.Uint3Keyword:
                case SyntaxKind.Uint4Keyword:
                case SyntaxKind.Float1Keyword:
                case SyntaxKind.Float2Keyword:
                case SyntaxKind.Float3Keyword:
                case SyntaxKind.Float4Keyword:
                case SyntaxKind.Double1Keyword:
                case SyntaxKind.Double2Keyword:
                case SyntaxKind.Double3Keyword:
                case SyntaxKind.Double4Keyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPredefinedMatrixType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.MatrixKeyword:
                case SyntaxKind.Double2x2Keyword:
                case SyntaxKind.Double2x3Keyword:
                case SyntaxKind.Double2x4Keyword:
                case SyntaxKind.Double3x2Keyword:
                case SyntaxKind.Double3x3Keyword:
                case SyntaxKind.Double3x4Keyword:
                case SyntaxKind.Double4x2Keyword:
                case SyntaxKind.Double4x3Keyword:
                case SyntaxKind.Double4x4Keyword:
                case SyntaxKind.Float2x2Keyword:
                case SyntaxKind.Float2x3Keyword:
                case SyntaxKind.Float2x4Keyword:
                case SyntaxKind.Float3x2Keyword:
                case SyntaxKind.Float3x3Keyword:
                case SyntaxKind.Float3x4Keyword:
                case SyntaxKind.Float4x2Keyword:
                case SyntaxKind.Float4x3Keyword:
                case SyntaxKind.Float4x4Keyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPredefinedObjectType(SyntaxToken token)
        {
            switch (token.Kind)
            {
                case SyntaxKind.BufferKeyword:
                case SyntaxKind.OutputPatchKeyword:
                case SyntaxKind.PointStreamKeyword:
                case SyntaxKind.TriangleStreamKeyword:

                case SyntaxKind.SamplerKeyword:
                case SyntaxKind.SamplerShadowKeyword:
                case SyntaxKind.SamplerBufferKeyword:
                case SyntaxKind.IsamplerBufferKeyword:
                case SyntaxKind.UsamplerBufferKeyword:
                case SyntaxKind.Sampler1DKeyword:
                case SyntaxKind.Sampler1DArrayKeyword:
                case SyntaxKind.Sampler1DShadowKeyword:
                case SyntaxKind.Sampler1DArrayShadowKeyword:
                case SyntaxKind.Isampler1DKeyword:
                case SyntaxKind.Isampler1DArrayKeyword:
                case SyntaxKind.Usampler1DKeyword:
                case SyntaxKind.Usampler1DArrayKeyword:
                case SyntaxKind.Sampler2DKeyword:
                case SyntaxKind.Sampler2DArrayKeyword:
                case SyntaxKind.Sampler2DShadowKeyword:
                case SyntaxKind.Sampler2DArrayShadowKeyword:
                case SyntaxKind.Sampler2DRectKeyword:
                case SyntaxKind.Sampler2DRectShadowKeyword:
                case SyntaxKind.Sampler2DMSKeyword:
                case SyntaxKind.Sampler2DMSArrayKeyword:
                case SyntaxKind.Isampler2DKeyword:
                case SyntaxKind.Isampler2DArrayKeyword:
                case SyntaxKind.Isampler2DRectKeyword:
                case SyntaxKind.Isampler2DMSKeyword:
                case SyntaxKind.Isampler2DMSArrayKeyword:
                case SyntaxKind.Usampler2DKeyword:
                case SyntaxKind.Usampler2DArrayKeyword:
                case SyntaxKind.Usampler2DRectKeyword:
                case SyntaxKind.Usampler2DMSKeyword:
                case SyntaxKind.Usampler2DMSArrayKeyword:
                case SyntaxKind.Sampler3DKeyword:
                case SyntaxKind.Isampler3DKeyword:
                case SyntaxKind.Usampler3DKeyword:
                case SyntaxKind.SamplerCubeKeyword:
                case SyntaxKind.SamplerCubeArrayKeyword:
                case SyntaxKind.SamplerCubeShadowKeyword:
                case SyntaxKind.SamplerCubeArrayShadowKeyword:
                case SyntaxKind.IsamplerCubeKeyword:
                case SyntaxKind.IsamplerCubeArrayKeyword:
                case SyntaxKind.UsamplerCubeKeyword:
                case SyntaxKind.UsamplerCubeArrayKeyword:
                case SyntaxKind.Texture1DKeyword:
                case SyntaxKind.Itexture1DKeyword:
                case SyntaxKind.Utexture1DKeyword:
                case SyntaxKind.Image1DKeyword:
                case SyntaxKind.Iimage1DKeyword:
                case SyntaxKind.Uimage1DKeyword:
                case SyntaxKind.Texture1DArrayKeyword:
                case SyntaxKind.Itexture1DArrayKeyword:
                case SyntaxKind.Utexture1DArrayKeyword:
                case SyntaxKind.Image1DArrayKeyword:
                case SyntaxKind.Iimage1DArrayKeyword:
                case SyntaxKind.Uimage1DArrayKeyword:
                case SyntaxKind.Texture2DKeyword:
                case SyntaxKind.Itexture2DKeyword:
                case SyntaxKind.Utexture2DKeyword:
                case SyntaxKind.Image2DKeyword:
                case SyntaxKind.Iimage2DKeyword:
                case SyntaxKind.Uimage2DKeyword:
                case SyntaxKind.Image2DRectKeyword:
                case SyntaxKind.Iimage2DRectKeyword:
                case SyntaxKind.Uimage2DRectKeyword:
                case SyntaxKind.SubpassInputKeyword:
                case SyntaxKind.SubpassInputMSKeyword:
                case SyntaxKind.IsubpassInputKeyword:
                case SyntaxKind.IsubpassInputMSKeyword:
                case SyntaxKind.UsubpassInputKeyword:
                case SyntaxKind.UsubpassInputMSKeyword:
                case SyntaxKind.Texture2DArrayKeyword:
                case SyntaxKind.Itexture2DArrayKeyword:
                case SyntaxKind.Utexture2DArrayKeyword:
                case SyntaxKind.Image2DArrayKeyword:
                case SyntaxKind.Iimage2DArrayKeyword:
                case SyntaxKind.Uimage2DArrayKeyword:
                case SyntaxKind.Texture2DMSKeyword:
                case SyntaxKind.Itexture2DMSKeyword:
                case SyntaxKind.Utexture2DMSKeyword:
                case SyntaxKind.Image2DMSKeyword:
                case SyntaxKind.Iimage2DMSKeyword:
                case SyntaxKind.Uimage2DMSKeyword:
                case SyntaxKind.Texture2DMSArrayKeyword:
                case SyntaxKind.Itexture2DMSArrayKeyword:
                case SyntaxKind.Utexture2DMSArrayKeyword:
                case SyntaxKind.Image2DMSArrayKeyword:
                case SyntaxKind.Iimage2DMSArrayKeyword:
                case SyntaxKind.Uimage2DMSArrayKeyword:
                case SyntaxKind.Texture3DKeyword:
                case SyntaxKind.Itexture3DKeyword:
                case SyntaxKind.Utexture3DKeyword:
                case SyntaxKind.Image3DKeyword:
                case SyntaxKind.Iimage3DKeyword:
                case SyntaxKind.Uimage3DKeyword:
                case SyntaxKind.TextureCubeKeyword:
                case SyntaxKind.ItextureCubeKeyword:
                case SyntaxKind.UtextureCubeKeyword:
                case SyntaxKind.ImageCubeKeyword:
                case SyntaxKind.IimageCubeKeyword:
                case SyntaxKind.UimageCubeKeyword:
                case SyntaxKind.TextureCubeArrayKeyword:
                case SyntaxKind.ItextureCubeArrayKeyword:
                case SyntaxKind.UtextureCubeArrayKeyword:
                case SyntaxKind.ImageCubeArrayKeyword:
                case SyntaxKind.IimageCubeArrayKeyword:
                case SyntaxKind.UimageCubeArrayKeyword:
                    return true;

                default:
                    switch (token.ContextualKind)
                    {
                        default:
                            return false;
                    }
            }
        }

        public static bool IsPredefinedType(SyntaxToken token)
        {
            if (IsPredefinedScalarType(token.Kind))
                return true;

            if (IsPredefinedVectorType(token.Kind))
                return true;

            if (IsPredefinedMatrixType(token.Kind))
                return true;

            if (IsPredefinedObjectType(token))
                return true;

            return false;
        }

        public static PredefinedObjectType GetPredefinedObjectType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.BufferKeyword:
                    return PredefinedObjectType.buffer;
                case SyntaxKind.LineStreamKeyword:
                    return PredefinedObjectType.LineStream;
                case SyntaxKind.OutputPatchKeyword:
                    return PredefinedObjectType.OutputPatch;
                case SyntaxKind.PointStreamKeyword:
                    return PredefinedObjectType.PointStream;
                case SyntaxKind.TriangleStreamKeyword:
                    return PredefinedObjectType.TriangleStream;

                case SyntaxKind.SamplerKeyword:
                    return PredefinedObjectType.sampler;
                case SyntaxKind.SamplerShadowKeyword:
                    return PredefinedObjectType.samplerShadow;
                case SyntaxKind.SamplerBufferKeyword:
                    return PredefinedObjectType.samplerBuffer;
                case SyntaxKind.IsamplerBufferKeyword:
                    return PredefinedObjectType.isamplerBuffer;
                case SyntaxKind.UsamplerBufferKeyword:
                    return PredefinedObjectType.usamplerBuffer;
                case SyntaxKind.Sampler1DKeyword:
                    return PredefinedObjectType.sampler1D;
                case SyntaxKind.Sampler1DArrayKeyword:
                    return PredefinedObjectType.sampler1DArray;
                case SyntaxKind.Sampler1DShadowKeyword:
                    return PredefinedObjectType.sampler1DShadow;
                case SyntaxKind.Sampler1DArrayShadowKeyword:
                    return PredefinedObjectType.sampler1DArrayShadow;
                case SyntaxKind.Isampler1DKeyword:
                    return PredefinedObjectType.isampler1D;
                case SyntaxKind.Isampler1DArrayKeyword:
                    return PredefinedObjectType.isampler1DArray;
                case SyntaxKind.Usampler1DKeyword:
                    return PredefinedObjectType.usampler1D;
                case SyntaxKind.Usampler1DArrayKeyword:
                    return PredefinedObjectType.usampler1DArray;
                case SyntaxKind.Sampler2DKeyword:
                    return PredefinedObjectType.sampler2D;
                case SyntaxKind.Sampler2DArrayKeyword:
                    return PredefinedObjectType.sampler2DArray;
                case SyntaxKind.Sampler2DShadowKeyword:
                    return PredefinedObjectType.sampler2DShadow;
                case SyntaxKind.Sampler2DArrayShadowKeyword:
                    return PredefinedObjectType.sampler2DArrayShadow;
                case SyntaxKind.Sampler2DRectKeyword:
                    return PredefinedObjectType.sampler2DRect;
                case SyntaxKind.Sampler2DRectShadowKeyword:
                    return PredefinedObjectType.sampler2DRectShadow;
                case SyntaxKind.Sampler2DMSKeyword:
                    return PredefinedObjectType.sampler2DMS;
                case SyntaxKind.Sampler2DMSArrayKeyword:
                    return PredefinedObjectType.sampler2DMSArray;
                case SyntaxKind.Isampler2DKeyword:
                    return PredefinedObjectType.isampler2D;
                case SyntaxKind.Isampler2DArrayKeyword:
                    return PredefinedObjectType.isampler2DArray;
                case SyntaxKind.Isampler2DRectKeyword:
                    return PredefinedObjectType.isampler2DRect;
                case SyntaxKind.Isampler2DMSKeyword:
                    return PredefinedObjectType.isampler2DMS;
                case SyntaxKind.Isampler2DMSArrayKeyword:
                    return PredefinedObjectType.isampler2DMSArray;
                case SyntaxKind.Usampler2DKeyword:
                    return PredefinedObjectType.usampler2D;
                case SyntaxKind.Usampler2DArrayKeyword:
                    return PredefinedObjectType.usampler2DArray;
                case SyntaxKind.Usampler2DRectKeyword:
                    return PredefinedObjectType.usampler2DRect;
                case SyntaxKind.Usampler2DMSKeyword:
                    return PredefinedObjectType.usampler2DMS;
                case SyntaxKind.Usampler2DMSArrayKeyword:
                    return PredefinedObjectType.usampler2DMSArray;
                case SyntaxKind.Sampler3DKeyword:
                    return PredefinedObjectType.sampler3D;
                case SyntaxKind.Isampler3DKeyword:
                    return PredefinedObjectType.isampler3D;
                case SyntaxKind.Usampler3DKeyword:
                    return PredefinedObjectType.usampler3D;
                case SyntaxKind.SamplerCubeKeyword:
                    return PredefinedObjectType.samplerCube;
                case SyntaxKind.SamplerCubeArrayKeyword:
                    return PredefinedObjectType.samplerCubeArray;
                case SyntaxKind.SamplerCubeShadowKeyword:
                    return PredefinedObjectType.samplerCubeShadow;
                case SyntaxKind.SamplerCubeArrayShadowKeyword:
                    return PredefinedObjectType.samplerCubeArrayShadow;
                case SyntaxKind.IsamplerCubeKeyword:
                    return PredefinedObjectType.isamplerCube;
                case SyntaxKind.IsamplerCubeArrayKeyword:
                    return PredefinedObjectType.isamplerCubeArray;
                case SyntaxKind.UsamplerCubeKeyword:
                    return PredefinedObjectType.usamplerCube;
                case SyntaxKind.UsamplerCubeArrayKeyword:
                    return PredefinedObjectType.usamplerCubeArray;
                case SyntaxKind.Texture1DKeyword:
                    return PredefinedObjectType.texture1D;
                case SyntaxKind.Itexture1DKeyword:
                    return PredefinedObjectType.itexture1D;
                case SyntaxKind.Utexture1DKeyword:
                    return PredefinedObjectType.utexture1D;
                case SyntaxKind.Image1DKeyword:
                    return PredefinedObjectType.image1D;
                case SyntaxKind.Iimage1DKeyword:
                    return PredefinedObjectType.iimage1D;
                case SyntaxKind.Uimage1DKeyword:
                    return PredefinedObjectType.uimage1D;
                case SyntaxKind.Texture1DArrayKeyword:
                    return PredefinedObjectType.texture1DArray;
                case SyntaxKind.Itexture1DArrayKeyword:
                    return PredefinedObjectType.itexture1DArray;
                case SyntaxKind.Utexture1DArrayKeyword:
                    return PredefinedObjectType.utexture1DArray;
                case SyntaxKind.Image1DArrayKeyword:
                    return PredefinedObjectType.image1DArray;
                case SyntaxKind.Iimage1DArrayKeyword:
                    return PredefinedObjectType.iimage1DArray;
                case SyntaxKind.Uimage1DArrayKeyword:
                    return PredefinedObjectType.uimage1DArray;
                case SyntaxKind.Texture2DKeyword:
                    return PredefinedObjectType.texture2D;
                case SyntaxKind.Itexture2DKeyword:
                    return PredefinedObjectType.itexture2D;
                case SyntaxKind.Utexture2DKeyword:
                    return PredefinedObjectType.utexture2D;
                case SyntaxKind.Image2DKeyword:
                    return PredefinedObjectType.image2D;
                case SyntaxKind.Iimage2DKeyword:
                    return PredefinedObjectType.iimage2D;
                case SyntaxKind.Uimage2DKeyword:
                    return PredefinedObjectType.uimage2D;
                case SyntaxKind.Image2DRectKeyword:
                    return PredefinedObjectType.image2DRect;
                case SyntaxKind.Iimage2DRectKeyword:
                    return PredefinedObjectType.iimage2DRect;
                case SyntaxKind.Uimage2DRectKeyword:
                    return PredefinedObjectType.uimage2DRect;
                case SyntaxKind.SubpassInputKeyword:
                    return PredefinedObjectType.subpassInput;
                case SyntaxKind.SubpassInputMSKeyword:
                    return PredefinedObjectType.subpassInputMS;
                case SyntaxKind.IsubpassInputKeyword:
                    return PredefinedObjectType.isubpassInput;
                case SyntaxKind.IsubpassInputMSKeyword:
                    return PredefinedObjectType.isubpassInputMS;
                case SyntaxKind.UsubpassInputKeyword:
                    return PredefinedObjectType.usubpassInput;
                case SyntaxKind.UsubpassInputMSKeyword:
                    return PredefinedObjectType.usubpassInputMS;
                case SyntaxKind.Texture2DArrayKeyword:
                    return PredefinedObjectType.texture2DArray;
                case SyntaxKind.Itexture2DArrayKeyword:
                    return PredefinedObjectType.itexture2DArray;
                case SyntaxKind.Utexture2DArrayKeyword:
                    return PredefinedObjectType.utexture2DArray;
                case SyntaxKind.Image2DArrayKeyword:
                    return PredefinedObjectType.image2DArray;
                case SyntaxKind.Iimage2DArrayKeyword:
                    return PredefinedObjectType.iimage2DArray;
                case SyntaxKind.Uimage2DArrayKeyword:
                    return PredefinedObjectType.uimage2DArray;
                case SyntaxKind.Texture2DMSKeyword:
                    return PredefinedObjectType.texture2DMS;
                case SyntaxKind.Itexture2DMSKeyword:
                    return PredefinedObjectType.itexture2DMS;
                case SyntaxKind.Utexture2DMSKeyword:
                    return PredefinedObjectType.utexture2DMS;
                case SyntaxKind.Image2DMSKeyword:
                    return PredefinedObjectType.image2DMS;
                case SyntaxKind.Iimage2DMSKeyword:
                    return PredefinedObjectType.iimage2DMS;
                case SyntaxKind.Uimage2DMSKeyword:
                    return PredefinedObjectType.uimage2DMS;
                case SyntaxKind.Texture2DMSArrayKeyword:
                    return PredefinedObjectType.texture2DMSArray;
                case SyntaxKind.Itexture2DMSArrayKeyword:
                    return PredefinedObjectType.itexture2DMSArray;
                case SyntaxKind.Utexture2DMSArrayKeyword:
                    return PredefinedObjectType.utexture2DMSArray;
                case SyntaxKind.Image2DMSArrayKeyword:
                    return PredefinedObjectType.image2DMSArray;
                case SyntaxKind.Iimage2DMSArrayKeyword:
                    return PredefinedObjectType.iimage2DMSArray;
                case SyntaxKind.Uimage2DMSArrayKeyword:
                    return PredefinedObjectType.uimage2DMSArray;
                case SyntaxKind.Texture3DKeyword:
                    return PredefinedObjectType.texture3D;
                case SyntaxKind.Itexture3DKeyword:
                    return PredefinedObjectType.itexture3D;
                case SyntaxKind.Utexture3DKeyword:
                    return PredefinedObjectType.utexture3D;
                case SyntaxKind.Image3DKeyword:
                    return PredefinedObjectType.image3D;
                case SyntaxKind.Iimage3DKeyword:
                    return PredefinedObjectType.iimage3D;
                case SyntaxKind.Uimage3DKeyword:
                    return PredefinedObjectType.uimage3D;
                case SyntaxKind.TextureCubeKeyword:
                    return PredefinedObjectType.textureCube;
                case SyntaxKind.ItextureCubeKeyword:
                    return PredefinedObjectType.itextureCube;
                case SyntaxKind.UtextureCubeKeyword:
                    return PredefinedObjectType.utextureCube;
                case SyntaxKind.ImageCubeKeyword:
                    return PredefinedObjectType.imageCube;
                case SyntaxKind.IimageCubeKeyword:
                    return PredefinedObjectType.iimageCube;
                case SyntaxKind.UimageCubeKeyword:
                    return PredefinedObjectType.uimageCube;
                case SyntaxKind.TextureCubeArrayKeyword:
                    return PredefinedObjectType.textureCubeArray;
                case SyntaxKind.ItextureCubeArrayKeyword:
                    return PredefinedObjectType.itextureCubeArray;
                case SyntaxKind.UtextureCubeArrayKeyword:
                    return PredefinedObjectType.utextureCubeArray;
                case SyntaxKind.ImageCubeArrayKeyword:
                    return PredefinedObjectType.imageCubeArray;
                case SyntaxKind.IimageCubeArrayKeyword:
                    return PredefinedObjectType.iimageCubeArray;
                case SyntaxKind.UimageCubeArrayKeyword:
                    return PredefinedObjectType.uimageCubeArray;

                default:
                    throw new ArgumentOutOfRangeException(nameof(kind), kind.ToString());
            }
        }

        public static bool CanStartDeclaration(SyntaxToken token)
        {
            if (IsPredefinedType(token))
                return true;

            switch (token.Kind)
            {
                case SyntaxKind.ClassKeyword:
                case SyntaxKind.ConstKeyword:
                case SyntaxKind.ExportKeyword:
                case SyntaxKind.ExternKeyword:
                case SyntaxKind.InlineKeyword:
                case SyntaxKind.InterfaceKeyword:
                case SyntaxKind.StaticKeyword:
                case SyntaxKind.SNormKeyword:
                case SyntaxKind.UNormKeyword:
                case SyntaxKind.StructKeyword:
                case SyntaxKind.VolatileKeyword:
                case SyntaxKind.IdentifierToken:
                case SyntaxKind.TildeToken:
                case SyntaxKind.OpenBracketToken:
                    return true;

                default:
                    return false;
            }
        }

        public static bool CanFollowCast(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.SemiToken:
                case SyntaxKind.CloseParenToken:
                case SyntaxKind.CloseBracketToken:
                case SyntaxKind.OpenBraceToken:
                case SyntaxKind.CloseBraceToken:
                case SyntaxKind.CommaToken:
                case SyntaxKind.EqualsToken:
                case SyntaxKind.PlusEqualsToken:
                case SyntaxKind.MinusEqualsToken:
                case SyntaxKind.AsteriskEqualsToken:
                case SyntaxKind.SlashEqualsToken:
                case SyntaxKind.PercentEqualsToken:
                case SyntaxKind.AmpersandEqualsToken:
                case SyntaxKind.CaretEqualsToken:
                case SyntaxKind.BarEqualsToken:
                case SyntaxKind.LessThanLessThanEqualsToken:
                case SyntaxKind.GreaterThanGreaterThanEqualsToken:
                case SyntaxKind.QuestionToken:
                case SyntaxKind.ColonToken:
                case SyntaxKind.BarBarToken:
                case SyntaxKind.AmpersandAmpersandToken:
                case SyntaxKind.BarToken:
                case SyntaxKind.CaretToken:
                case SyntaxKind.AmpersandToken:
                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.ExclamationEqualsToken:
                case SyntaxKind.LessThanToken:
                case SyntaxKind.LessThanEqualsToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.GreaterThanEqualsToken:
                case SyntaxKind.LessThanLessThanToken:
                case SyntaxKind.GreaterThanGreaterThanToken:
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.AsteriskToken:
                case SyntaxKind.SlashToken:
                case SyntaxKind.PercentToken:
                case SyntaxKind.PlusPlusToken:
                case SyntaxKind.MinusMinusToken:
                case SyntaxKind.OpenBracketToken:
                case SyntaxKind.DotToken:
                case SyntaxKind.EndOfFileToken:
                    return false;
                default:
                    return true;
            }
        }

        public static bool IsAnyUnaryExpression(SyntaxKind token)
        {
            return IsPrefixUnaryExpression(token) || IsPostfixUnaryExpression(token);
        }

        public static bool IsPrefixUnaryExpression(SyntaxKind token, bool forPreprocessor = false)
        {
            return GetPrefixUnaryExpression(token) != SyntaxKind.None;
        }

        public static SyntaxKind GetPrefixUnaryExpression(SyntaxKind kind, bool forPreprocessor = false)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                    return SyntaxKind.UnaryPlusExpression;
                case SyntaxKind.MinusToken:
                    return SyntaxKind.UnaryMinusExpression;
                case SyntaxKind.NotToken:
                    return SyntaxKind.LogicalNotExpression;
                case SyntaxKind.TildeToken:
                    if (forPreprocessor)
                        goto default;
                    return SyntaxKind.BitwiseNotExpression;
                case SyntaxKind.MinusMinusToken:
                    if (forPreprocessor)
                        goto default;
                    return SyntaxKind.PreDecrementExpression;
                case SyntaxKind.PlusPlusToken:
                    if (forPreprocessor)
                        goto default;
                    return SyntaxKind.PreIncrementExpression;
                default:
                    return SyntaxKind.None;
            }
        }

        public static bool IsPostfixUnaryExpression(SyntaxKind token)
        {
            return GetPostfixUnaryExpression(token) != SyntaxKind.None;
        }

        public static SyntaxKind GetPostfixUnaryExpression(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.MinusMinusToken:
                    return SyntaxKind.PostDecrementExpression;
                case SyntaxKind.PlusPlusToken:
                    return SyntaxKind.PostIncrementExpression;
                default:
                    return SyntaxKind.None;
            }
        }

        public static uint GetOperatorPrecedence(SyntaxKind op)
        {
            switch (op)
            {
                case SyntaxKind.CompoundExpression:
                    return 1;
                case SyntaxKind.SimpleAssignmentExpression:
                case SyntaxKind.AddAssignmentExpression:
                case SyntaxKind.SubtractAssignmentExpression:
                case SyntaxKind.MultiplyAssignmentExpression:
                case SyntaxKind.DivideAssignmentExpression:
                case SyntaxKind.ModuloAssignmentExpression:
                case SyntaxKind.AndAssignmentExpression:
                case SyntaxKind.ExclusiveOrAssignmentExpression:
                case SyntaxKind.OrAssignmentExpression:
                case SyntaxKind.LeftShiftAssignmentExpression:
                case SyntaxKind.RightShiftAssignmentExpression:
                case SyntaxKind.ConditionalExpression:
                    return 2;
                case SyntaxKind.LogicalOrExpression:
                    return 3;
                case SyntaxKind.LogicalAndExpression:
                    return 4;
                case SyntaxKind.BitwiseOrExpression:
                    return 5;
                case SyntaxKind.ExclusiveOrExpression:
                    return 6;
                case SyntaxKind.BitwiseAndExpression:
                    return 7;
                case SyntaxKind.EqualsExpression:
                case SyntaxKind.NotEqualsExpression:
                    return 8;
                case SyntaxKind.LessThanExpression:
                case SyntaxKind.LessThanOrEqualExpression:
                case SyntaxKind.GreaterThanExpression:
                case SyntaxKind.GreaterThanOrEqualExpression:
                    return 9;
                case SyntaxKind.LeftShiftExpression:
                case SyntaxKind.RightShiftExpression:
                    return 10;
                case SyntaxKind.AddExpression:
                case SyntaxKind.SubtractExpression:
                    return 11;
                case SyntaxKind.MultiplyExpression:
                case SyntaxKind.DivideExpression:
                case SyntaxKind.ModuloExpression:
                    return 12;
                case SyntaxKind.UnaryPlusExpression:
                case SyntaxKind.UnaryMinusExpression:
                case SyntaxKind.BitwiseNotExpression:
                case SyntaxKind.LogicalNotExpression:
                case SyntaxKind.PreIncrementExpression:
                case SyntaxKind.PreDecrementExpression:
                    return 13;
                case SyntaxKind.CastExpression:
                    return 14;
                default:
                    return 0;
            }
        }

        public static SyntaxKind GetLiteralExpression(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.FloatLiteralToken:
                case SyntaxKind.IntegerLiteralToken:
                    return SyntaxKind.NumericLiteralExpression;
                case SyntaxKind.TrueKeyword:
                    return SyntaxKind.TrueLiteralExpression;
                case SyntaxKind.FalseKeyword:
                    return SyntaxKind.FalseLiteralExpression;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static BinaryOperatorKind GetBinaryOperatorKind(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.MultiplyExpression:
                case SyntaxKind.MultiplyAssignmentExpression:
                    return BinaryOperatorKind.Multiply;
                case SyntaxKind.DivideExpression:
                case SyntaxKind.DivideAssignmentExpression:
                    return BinaryOperatorKind.Divide;
                case SyntaxKind.ModuloExpression:
                case SyntaxKind.ModuloAssignmentExpression:
                    return BinaryOperatorKind.Modulo;
                case SyntaxKind.AddExpression:
                case SyntaxKind.AddAssignmentExpression:
                    return BinaryOperatorKind.Add;
                case SyntaxKind.SubtractExpression:
                case SyntaxKind.SubtractAssignmentExpression:
                    return BinaryOperatorKind.Subtract;
                case SyntaxKind.LeftShiftExpression:
                case SyntaxKind.LeftShiftAssignmentExpression:
                    return BinaryOperatorKind.LeftShift;
                case SyntaxKind.RightShiftExpression:
                case SyntaxKind.RightShiftAssignmentExpression:
                    return BinaryOperatorKind.RightShift;
                case SyntaxKind.LessThanExpression:
                    return BinaryOperatorKind.Less;
                case SyntaxKind.GreaterThanExpression:
                    return BinaryOperatorKind.Greater;
                case SyntaxKind.LessThanOrEqualExpression:
                    return BinaryOperatorKind.LessEqual;
                case SyntaxKind.GreaterThanOrEqualExpression:
                    return BinaryOperatorKind.GreaterEqual;
                case SyntaxKind.EqualsExpression:
                    return BinaryOperatorKind.Equal;
                case SyntaxKind.NotEqualsExpression:
                    return BinaryOperatorKind.NotEqual;
                case SyntaxKind.BitwiseAndExpression:
                case SyntaxKind.AndAssignmentExpression:
                    return BinaryOperatorKind.BitwiseAnd;
                case SyntaxKind.ExclusiveOrExpression:
                case SyntaxKind.ExclusiveOrAssignmentExpression:
                    return BinaryOperatorKind.BitwiseXor;
                case SyntaxKind.BitwiseOrExpression:
                case SyntaxKind.OrAssignmentExpression:
                    return BinaryOperatorKind.BitwiseOr;
                case SyntaxKind.LogicalAndExpression:
                    return BinaryOperatorKind.LogicalAnd;
                case SyntaxKind.LogicalOrExpression:
                    return BinaryOperatorKind.LogicalOr;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static UnaryOperatorKind GetUnaryOperatorKind(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.UnaryPlusExpression:
                    return UnaryOperatorKind.Plus;
                case SyntaxKind.UnaryMinusExpression:
                    return UnaryOperatorKind.Minus;
                case SyntaxKind.PreIncrementExpression:
                    return UnaryOperatorKind.PreIncrement;
                case SyntaxKind.PostIncrementExpression:
                    return UnaryOperatorKind.PostIncrement;
                case SyntaxKind.PreDecrementExpression:
                    return UnaryOperatorKind.PreDecrement;
                case SyntaxKind.PostDecrementExpression:
                    return UnaryOperatorKind.PostDecrement;
                case SyntaxKind.LogicalNotExpression:
                    return UnaryOperatorKind.LogicalNot;
                case SyntaxKind.BitwiseNotExpression:
                    return UnaryOperatorKind.BitwiseNot;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static bool IsTrivia(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.WhitespaceTrivia:
                case SyntaxKind.EndOfLineTrivia:
                case SyntaxKind.SingleLineCommentTrivia:
                case SyntaxKind.MultiLineCommentTrivia:
                case SyntaxKind.BlockCommentEndOfFile:
                case SyntaxKind.SkippedTokensTrivia:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsLiteral(this SyntaxKind kind)
        {
            return kind == SyntaxKind.FloatLiteralToken ||
                   kind == SyntaxKind.IntegerLiteralToken ||
                   kind == SyntaxKind.StringLiteralToken;
        }

        public static bool IsKeyword(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.BoolKeyword:
                case SyntaxKind.Bool1Keyword:
                case SyntaxKind.Bool2Keyword:
                case SyntaxKind.Bool3Keyword:
                case SyntaxKind.Bool4Keyword:
                case SyntaxKind.BufferKeyword:
                case SyntaxKind.BreakKeyword:
                case SyntaxKind.CaseKeyword:
                case SyntaxKind.CentroidKeyword:
                case SyntaxKind.ClassKeyword:
                case SyntaxKind.ColumnMajorKeyword:
                case SyntaxKind.CompileKeyword:
                case SyntaxKind.CompileShaderKeyword:
                case SyntaxKind.ConstKeyword:
                case SyntaxKind.ContinueKeyword:
                case SyntaxKind.DefaultKeyword:
                case SyntaxKind.DiscardKeyword:
                case SyntaxKind.DoKeyword:
                case SyntaxKind.DoubleKeyword:
                case SyntaxKind.Double1Keyword:
                case SyntaxKind.Double2Keyword:
                case SyntaxKind.Double3Keyword:
                case SyntaxKind.Double4Keyword:
                case SyntaxKind.Double2x2Keyword:
                case SyntaxKind.Double2x3Keyword:
                case SyntaxKind.Double2x4Keyword:
                case SyntaxKind.Double3x2Keyword:
                case SyntaxKind.Double3x3Keyword:
                case SyntaxKind.Double3x4Keyword:
                case SyntaxKind.Double4x2Keyword:
                case SyntaxKind.Double4x3Keyword:
                case SyntaxKind.Double4x4Keyword:
                case SyntaxKind.ElseKeyword:
                case SyntaxKind.ExportKeyword:
                case SyntaxKind.ExternKeyword:
                case SyntaxKind.FalseKeyword:
                case SyntaxKind.FloatKeyword:
                case SyntaxKind.Float1Keyword:
                case SyntaxKind.Float2Keyword:
                case SyntaxKind.Float3Keyword:
                case SyntaxKind.Float4Keyword:
                case SyntaxKind.Float2x2Keyword:
                case SyntaxKind.Float2x3Keyword:
                case SyntaxKind.Float2x4Keyword:
                case SyntaxKind.Float3x2Keyword:
                case SyntaxKind.Float3x3Keyword:
                case SyntaxKind.Float3x4Keyword:
                case SyntaxKind.Float4x2Keyword:
                case SyntaxKind.Float4x3Keyword:
                case SyntaxKind.Float4x4Keyword:
                case SyntaxKind.ForKeyword:
                case SyntaxKind.GloballycoherentKeyword:
                case SyntaxKind.GroupsharedKeyword:
                case SyntaxKind.IfKeyword:
                case SyntaxKind.InKeyword:
                case SyntaxKind.InlineKeyword:
                case SyntaxKind.InoutKeyword:
                case SyntaxKind.IntKeyword:
                case SyntaxKind.Int1Keyword:
                case SyntaxKind.Int2Keyword:
                case SyntaxKind.Int3Keyword:
                case SyntaxKind.Int4Keyword:
                case SyntaxKind.InterfaceKeyword:
                case SyntaxKind.LineKeyword:
                case SyntaxKind.LineAdjKeyword:
                case SyntaxKind.LinearKeyword:
                case SyntaxKind.LineStreamKeyword:
                case SyntaxKind.MatrixKeyword:
                case SyntaxKind.NamespaceKeyword:
                case SyntaxKind.NointerpolationKeyword:
                case SyntaxKind.NoperspectiveKeyword:
                case SyntaxKind.NullKeyword:
                case SyntaxKind.OutKeyword:
                case SyntaxKind.OutputPatchKeyword:
                case SyntaxKind.PackoffsetKeyword:
                case SyntaxKind.PassKeyword:
                case SyntaxKind.PointKeyword:
                case SyntaxKind.PointStreamKeyword:
                case SyntaxKind.PreciseKeyword:
                case SyntaxKind.RegisterKeyword:
                case SyntaxKind.ReturnKeyword:
                case SyntaxKind.RowMajorKeyword:

                case SyntaxKind.SamplerKeyword:
                case SyntaxKind.SamplerShadowKeyword:
                case SyntaxKind.SamplerBufferKeyword:
                case SyntaxKind.IsamplerBufferKeyword:
                case SyntaxKind.UsamplerBufferKeyword:
                case SyntaxKind.Sampler1DKeyword:
                case SyntaxKind.Sampler1DArrayKeyword:
                case SyntaxKind.Sampler1DShadowKeyword:
                case SyntaxKind.Sampler1DArrayShadowKeyword:
                case SyntaxKind.Isampler1DKeyword:
                case SyntaxKind.Isampler1DArrayKeyword:
                case SyntaxKind.Usampler1DKeyword:
                case SyntaxKind.Usampler1DArrayKeyword:
                case SyntaxKind.Sampler2DKeyword:
                case SyntaxKind.Sampler2DArrayKeyword:
                case SyntaxKind.Sampler2DShadowKeyword:
                case SyntaxKind.Sampler2DArrayShadowKeyword:
                case SyntaxKind.Sampler2DRectKeyword:
                case SyntaxKind.Sampler2DRectShadowKeyword:
                case SyntaxKind.Sampler2DMSKeyword:
                case SyntaxKind.Sampler2DMSArrayKeyword:
                case SyntaxKind.Isampler2DKeyword:
                case SyntaxKind.Isampler2DArrayKeyword:
                case SyntaxKind.Isampler2DRectKeyword:
                case SyntaxKind.Isampler2DMSKeyword:
                case SyntaxKind.Isampler2DMSArrayKeyword:
                case SyntaxKind.Usampler2DKeyword:
                case SyntaxKind.Usampler2DArrayKeyword:
                case SyntaxKind.Usampler2DRectKeyword:
                case SyntaxKind.Usampler2DMSKeyword:
                case SyntaxKind.Usampler2DMSArrayKeyword:
                case SyntaxKind.Sampler3DKeyword:
                case SyntaxKind.Isampler3DKeyword:
                case SyntaxKind.Usampler3DKeyword:
                case SyntaxKind.SamplerCubeKeyword:
                case SyntaxKind.SamplerCubeArrayKeyword:
                case SyntaxKind.SamplerCubeShadowKeyword:
                case SyntaxKind.SamplerCubeArrayShadowKeyword:
                case SyntaxKind.IsamplerCubeKeyword:
                case SyntaxKind.IsamplerCubeArrayKeyword:
                case SyntaxKind.UsamplerCubeKeyword:
                case SyntaxKind.UsamplerCubeArrayKeyword:
                case SyntaxKind.Texture1DKeyword:
                case SyntaxKind.Itexture1DKeyword:
                case SyntaxKind.Utexture1DKeyword:
                case SyntaxKind.Image1DKeyword:
                case SyntaxKind.Iimage1DKeyword:
                case SyntaxKind.Uimage1DKeyword:
                case SyntaxKind.Texture1DArrayKeyword:
                case SyntaxKind.Itexture1DArrayKeyword:
                case SyntaxKind.Utexture1DArrayKeyword:
                case SyntaxKind.Image1DArrayKeyword:
                case SyntaxKind.Iimage1DArrayKeyword:
                case SyntaxKind.Uimage1DArrayKeyword:
                case SyntaxKind.Texture2DKeyword:
                case SyntaxKind.Itexture2DKeyword:
                case SyntaxKind.Utexture2DKeyword:
                case SyntaxKind.Image2DKeyword:
                case SyntaxKind.Iimage2DKeyword:
                case SyntaxKind.Uimage2DKeyword:
                case SyntaxKind.Image2DRectKeyword:
                case SyntaxKind.Iimage2DRectKeyword:
                case SyntaxKind.Uimage2DRectKeyword:
                case SyntaxKind.SubpassInputKeyword:
                case SyntaxKind.SubpassInputMSKeyword:
                case SyntaxKind.IsubpassInputKeyword:
                case SyntaxKind.IsubpassInputMSKeyword:
                case SyntaxKind.UsubpassInputKeyword:
                case SyntaxKind.UsubpassInputMSKeyword:
                case SyntaxKind.Texture2DArrayKeyword:
                case SyntaxKind.Itexture2DArrayKeyword:
                case SyntaxKind.Utexture2DArrayKeyword:
                case SyntaxKind.Image2DArrayKeyword:
                case SyntaxKind.Iimage2DArrayKeyword:
                case SyntaxKind.Uimage2DArrayKeyword:
                case SyntaxKind.Texture2DMSKeyword:
                case SyntaxKind.Itexture2DMSKeyword:
                case SyntaxKind.Utexture2DMSKeyword:
                case SyntaxKind.Image2DMSKeyword:
                case SyntaxKind.Iimage2DMSKeyword:
                case SyntaxKind.Uimage2DMSKeyword:
                case SyntaxKind.Texture2DMSArrayKeyword:
                case SyntaxKind.Itexture2DMSArrayKeyword:
                case SyntaxKind.Utexture2DMSArrayKeyword:
                case SyntaxKind.Image2DMSArrayKeyword:
                case SyntaxKind.Iimage2DMSArrayKeyword:
                case SyntaxKind.Uimage2DMSArrayKeyword:
                case SyntaxKind.Texture3DKeyword:
                case SyntaxKind.Itexture3DKeyword:
                case SyntaxKind.Utexture3DKeyword:
                case SyntaxKind.Image3DKeyword:
                case SyntaxKind.Iimage3DKeyword:
                case SyntaxKind.Uimage3DKeyword:
                case SyntaxKind.TextureCubeKeyword:
                case SyntaxKind.ItextureCubeKeyword:
                case SyntaxKind.UtextureCubeKeyword:
                case SyntaxKind.ImageCubeKeyword:
                case SyntaxKind.IimageCubeKeyword:
                case SyntaxKind.UimageCubeKeyword:
                case SyntaxKind.TextureCubeArrayKeyword:
                case SyntaxKind.ItextureCubeArrayKeyword:
                case SyntaxKind.UtextureCubeArrayKeyword:
                case SyntaxKind.ImageCubeArrayKeyword:
                case SyntaxKind.IimageCubeArrayKeyword:
                case SyntaxKind.UimageCubeArrayKeyword:

                case SyntaxKind.SharedKeyword:
                case SyntaxKind.SNormKeyword:
                case SyntaxKind.StaticKeyword:
                case SyntaxKind.StringKeyword:
                case SyntaxKind.StructKeyword:
                case SyntaxKind.SwitchKeyword:
                case SyntaxKind.TriangleKeyword:
                case SyntaxKind.TriangleAdjKeyword:
                case SyntaxKind.TriangleStreamKeyword:
                case SyntaxKind.TrueKeyword:
                case SyntaxKind.TypedefKeyword:
                case SyntaxKind.UniformKeyword:
                case SyntaxKind.UNormKeyword:
                case SyntaxKind.UintKeyword:
                case SyntaxKind.Uint1Keyword:
                case SyntaxKind.Uint2Keyword:
                case SyntaxKind.Uint3Keyword:
                case SyntaxKind.Uint4Keyword:
                case SyntaxKind.VectorKeyword:
                case SyntaxKind.VolatileKeyword:
                case SyntaxKind.VoidKeyword:
                case SyntaxKind.WhileKeyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsWord(this SyntaxToken token)
        {
            return token.Kind == SyntaxKind.IdentifierToken
                || token.Kind.IsKeyword()
                || token.Kind.IsPreprocessorKeyword();
        }

        public static bool IsComment(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.SingleLineCommentTrivia:
                case SyntaxKind.MultiLineCommentTrivia:
                case SyntaxKind.BlockCommentEndOfFile:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPreprocessorDirective(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.IfKeyword:
                case SyntaxKind.IfDefKeyword:
                case SyntaxKind.IfNDefKeyword:
                case SyntaxKind.ElseKeyword:
                case SyntaxKind.ElifKeyword:
                case SyntaxKind.EndIfKeyword:
                case SyntaxKind.DefineKeyword:
                case SyntaxKind.UndefKeyword:
                case SyntaxKind.IncludeKeyword:
                case SyntaxKind.LineKeyword:
                case SyntaxKind.ErrorKeyword:
                case SyntaxKind.PragmaKeyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsIfLikeDirective(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.IfDirectiveTrivia:
                case SyntaxKind.IfDefDirectiveTrivia:
                case SyntaxKind.IfNDefDirectiveTrivia:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsWhitespace(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.WhitespaceTrivia:
                case SyntaxKind.EndOfLineTrivia:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsNumericLiteral(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.IntegerLiteralToken:
                case SyntaxKind.FloatLiteralToken:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsOperator(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.LessThanToken:
                case SyntaxKind.LessThanEqualsToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.GreaterThanEqualsToken:
                case SyntaxKind.LessThanLessThanToken:
                case SyntaxKind.GreaterThanGreaterThanToken:
                case SyntaxKind.PlusToken:
                case SyntaxKind.PlusPlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.MinusMinusToken:
                case SyntaxKind.AsteriskToken:
                case SyntaxKind.SlashToken:
                case SyntaxKind.PercentToken:
                case SyntaxKind.AmpersandToken:
                case SyntaxKind.BarToken:
                case SyntaxKind.AmpersandAmpersandToken:
                case SyntaxKind.BarBarToken:
                case SyntaxKind.CaretToken:
                case SyntaxKind.NotToken:
                case SyntaxKind.TildeToken:
                case SyntaxKind.QuestionToken:
                case SyntaxKind.ColonToken:
                case SyntaxKind.ColonColonToken:
                case SyntaxKind.EqualsToken:
                case SyntaxKind.AsteriskEqualsToken:
                case SyntaxKind.SlashEqualsToken:
                case SyntaxKind.PercentEqualsToken:
                case SyntaxKind.PlusEqualsToken:
                case SyntaxKind.MinusEqualsToken:
                case SyntaxKind.LessThanLessThanEqualsToken:
                case SyntaxKind.GreaterThanGreaterThanEqualsToken:
                case SyntaxKind.AmpersandEqualsToken:
                case SyntaxKind.CaretEqualsToken:
                case SyntaxKind.BarEqualsToken:
                case SyntaxKind.EqualsEqualsToken:
                case SyntaxKind.ExclamationEqualsToken:
                case SyntaxKind.DotToken:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPunctuation(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.OpenParenToken:
                case SyntaxKind.CloseParenToken:
                case SyntaxKind.OpenBracketToken:
                case SyntaxKind.CloseBracketToken:
                case SyntaxKind.OpenBraceToken:
                case SyntaxKind.CloseBraceToken:
                case SyntaxKind.SemiToken:
                case SyntaxKind.CommaToken:
                    return true;

                default:
                    return false;
            }
        }

        public static SyntaxKind GetKeywordKind(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            switch (text)
            {
                case "bool":
                    return SyntaxKind.Bool1Keyword;
                case "bvec2":
                    return SyntaxKind.Bool2Keyword;
                case "bvec3":
                    return SyntaxKind.Bool3Keyword;
                case "bvec4":
                    return SyntaxKind.Bool4Keyword;
                case "buffer":
                    return SyntaxKind.BufferKeyword;
                case "break":
                    return SyntaxKind.BreakKeyword;
                case "case":
                    return SyntaxKind.CaseKeyword;
                case "centroid":
                    return SyntaxKind.CentroidKeyword;
                case "class":
                    return SyntaxKind.ClassKeyword;
                case "column_major":
                    return SyntaxKind.ColumnMajorKeyword;
                case "compile":
                    return SyntaxKind.CompileKeyword;
                case "const":
                    return SyntaxKind.ConstKeyword;
                case "continue":
                    return SyntaxKind.ContinueKeyword;
                case "default":
                    return SyntaxKind.DefaultKeyword;
                case "discard":
                    return SyntaxKind.DiscardKeyword;
                case "do":
                    return SyntaxKind.DoKeyword;
                case "double":
                    return SyntaxKind.Double1Keyword;
                case "dvec2":
                    return SyntaxKind.Double2Keyword;
                case "dvec3":
                    return SyntaxKind.Double3Keyword;
                case "dvec4":
                    return SyntaxKind.Double4Keyword;
                case "dmat2":
                case "dmat2x2":
                    return SyntaxKind.Double2x2Keyword;
                case "dmat2x3":
                    return SyntaxKind.Double2x3Keyword;
                case "dmat2x4":
                    return SyntaxKind.Double2x4Keyword;
                case "dmat3x2":
                    return SyntaxKind.Double3x2Keyword;
                case "dmat3":
                case "dmat3x3":
                    return SyntaxKind.Double3x3Keyword;
                case "dmat3x4":
                    return SyntaxKind.Double3x4Keyword;
                case "dmat4x2":
                    return SyntaxKind.Double4x2Keyword;
                case "dmat4x3":
                    return SyntaxKind.Double4x3Keyword;
                case "dmat4":
                case "dmat4x4":
                    return SyntaxKind.Double4x4Keyword;
                case "else":
                    return SyntaxKind.ElseKeyword;
                case "export":
                    return SyntaxKind.ExportKeyword;
                case "extern":
                    return SyntaxKind.ExternKeyword;
                case "float":
                    return SyntaxKind.Float1Keyword;
                case "vec2":
                    return SyntaxKind.Float2Keyword;
                case "vec3":
                    return SyntaxKind.Float3Keyword;
                case "vec4":
                    return SyntaxKind.Float4Keyword;
                case "mat2":
                case "mat2x2":
                    return SyntaxKind.Float2x2Keyword;
                case "mat2x3":
                    return SyntaxKind.Float2x3Keyword;
                case "mat2x4":
                    return SyntaxKind.Float2x4Keyword;
                case "mat3x2":
                    return SyntaxKind.Float3x2Keyword;
                case "mat3":
                case "mat3x3":
                    return SyntaxKind.Float3x3Keyword;
                case "mat3x4":
                    return SyntaxKind.Float3x4Keyword;
                case "mat4x2":
                    return SyntaxKind.Float4x2Keyword;
                case "mat4x3":
                    return SyntaxKind.Float4x3Keyword;
                case "mat4":
                case "mat4x4":
                    return SyntaxKind.Float4x4Keyword;
                case "for":
                    return SyntaxKind.ForKeyword;
                case "restrict":
                    return SyntaxKind.GloballycoherentKeyword;
                case "groupshared":
                    return SyntaxKind.GroupsharedKeyword;
                case "if":
                    return SyntaxKind.IfKeyword;
                case "in":
                    return SyntaxKind.InKeyword;
                case "inline":
                    return SyntaxKind.InlineKeyword;
                case "inout":
                    return SyntaxKind.InoutKeyword;
                case "int":
                    return SyntaxKind.Int1Keyword;
                case "ivec2":
                    return SyntaxKind.Int2Keyword;
                case "ivec3":
                    return SyntaxKind.Int3Keyword;
                case "ivec4":
                    return SyntaxKind.Int4Keyword;
                case "linear":
                    return SyntaxKind.LinearKeyword;
                case "layout":
                case "location":
                    return SyntaxKind.RegisterLocation;
                case "namespace":
                    return SyntaxKind.NamespaceKeyword;
                case "nointerpolation":
                    return SyntaxKind.NointerpolationKeyword;
                case "noperspective":
                    return SyntaxKind.NoperspectiveKeyword;
                case "out":
                    return SyntaxKind.OutKeyword;
                case "packoffset":
                    return SyntaxKind.PackoffsetKeyword;
                case "pass":
                    return SyntaxKind.PassKeyword;
                case "point":
                    return SyntaxKind.PointKeyword;
                case "precise":
                    return SyntaxKind.PreciseKeyword;
                case "register":
                    return SyntaxKind.RegisterKeyword;
                case "return":
                    return SyntaxKind.ReturnKeyword;
                case "row_major":
                    return SyntaxKind.RowMajorKeyword;
                case "sampler":
                    return SyntaxKind.SamplerKeyword;
                case "samplerShadow":
                    return SyntaxKind.SamplerShadowKeyword;
                case "samplerBuffer":
                    return SyntaxKind.SamplerBufferKeyword;
                case "isamplerBuffer":
                    return SyntaxKind.IsamplerBufferKeyword;
                case "usamplerBuffer":
                    return SyntaxKind.UsamplerBufferKeyword;
                case "sampler1D":
                    return SyntaxKind.Sampler1DKeyword;
                case "sampler1DArray":
                    return SyntaxKind.Sampler1DArrayKeyword;
                case "sampler1DShadow":
                    return SyntaxKind.Sampler1DShadowKeyword;
                case "sampler1DArrayShadow":
                    return SyntaxKind.Sampler1DArrayShadowKeyword;
                case "isampler1D":
                    return SyntaxKind.Isampler1DKeyword;
                case "isampler1DArray":
                    return SyntaxKind.Isampler1DArrayKeyword;
                case "usampler1D":
                    return SyntaxKind.Usampler1DKeyword;
                case "usampler1DArray":
                    return SyntaxKind.Usampler1DArrayKeyword;
                case "sampler2D":
                    return SyntaxKind.Sampler2DKeyword;
                case "sampler2DArray":
                    return SyntaxKind.Sampler2DArrayKeyword;
                case "sampler2DShadow":
                    return SyntaxKind.Sampler2DShadowKeyword;
                case "sampler2DArrayShadow":
                    return SyntaxKind.Sampler2DArrayShadowKeyword;
                case "sampler2DRect":
                    return SyntaxKind.Sampler2DRectKeyword;
                case "sampler2DRectShadow":
                    return SyntaxKind.Sampler2DRectShadowKeyword;
                case "sampler2DMS":
                    return SyntaxKind.Sampler2DMSKeyword;
                case "sampler2DMSArray":
                    return SyntaxKind.Sampler2DMSArrayKeyword;
                case "isampler2D":
                    return SyntaxKind.Isampler2DKeyword;
                case "isampler2DArray":
                    return SyntaxKind.Isampler2DArrayKeyword;
                case "isampler2DRect":
                    return SyntaxKind.Isampler2DRectKeyword;
                case "isampler2DMS":
                    return SyntaxKind.Isampler2DMSKeyword;
                case "isampler2DMSArray":
                    return SyntaxKind.Isampler2DMSArrayKeyword;
                case "usampler2D":
                    return SyntaxKind.Usampler2DKeyword;
                case "usampler2DArray":
                    return SyntaxKind.Usampler2DArrayKeyword;
                case "usampler2DRect":
                    return SyntaxKind.Usampler2DRectKeyword;
                case "usampler2DMS":
                    return SyntaxKind.Usampler2DMSKeyword;
                case "usampler2DMSArray":
                    return SyntaxKind.Usampler2DMSArrayKeyword;
                case "sampler3D":
                    return SyntaxKind.Sampler3DKeyword;
                case "isampler3D":
                    return SyntaxKind.Isampler3DKeyword;
                case "usampler3D":
                    return SyntaxKind.Usampler3DKeyword;
                case "samplerCube":
                    return SyntaxKind.SamplerCubeKeyword;
                case "samplerCubeArray":
                    return SyntaxKind.SamplerCubeArrayKeyword;
                case "samplerCubeShadow":
                    return SyntaxKind.SamplerCubeShadowKeyword;
                case "samplerCubeArrayShadow":
                    return SyntaxKind.SamplerCubeArrayShadowKeyword;
                case "isamplerCube":
                    return SyntaxKind.IsamplerCubeKeyword;
                case "isamplerCubeArray":
                    return SyntaxKind.IsamplerCubeArrayKeyword;
                case "usamplerCube":
                    return SyntaxKind.UsamplerCubeKeyword;
                case "usamplerCubeArray":
                    return SyntaxKind.UsamplerCubeArrayKeyword;
                case "shared":
                    return SyntaxKind.SharedKeyword;
                case "snorm":
                    return SyntaxKind.SNormKeyword;
                case "static":
                    return SyntaxKind.StaticKeyword;
                case "string":
                    return SyntaxKind.StringKeyword;
                case "struct":
                    return SyntaxKind.StructKeyword;
                case "switch":
                    return SyntaxKind.SwitchKeyword;
                case "texture1D":
                    return SyntaxKind.Texture1DKeyword;
                case "itexture1D":
                    return SyntaxKind.Itexture1DKeyword;
                case "utexture1D":
                    return SyntaxKind.Utexture1DKeyword;
                case "image1D":
                    return SyntaxKind.Image1DKeyword;
                case "iimage1D":
                    return SyntaxKind.Iimage1DKeyword;
                case "uimage1D":
                    return SyntaxKind.Uimage1DKeyword;
                case "texture1DArray":
                    return SyntaxKind.Texture1DArrayKeyword;
                case "itexture1DArray":
                    return SyntaxKind.Itexture1DArrayKeyword;
                case "utexture1DArray":
                    return SyntaxKind.Utexture1DArrayKeyword;
                case "image1DArray":
                    return SyntaxKind.Image1DArrayKeyword;
                case "iimage1DArray":
                    return SyntaxKind.Iimage1DArrayKeyword;
                case "uimage1DArray":
                    return SyntaxKind.Uimage1DArrayKeyword;
                case "texture2D":
                    return SyntaxKind.Texture2DKeyword;
                case "itexture2D":
                    return SyntaxKind.Itexture2DKeyword;
                case "utexture2D":
                    return SyntaxKind.Utexture2DKeyword;
                case "image2D":
                    return SyntaxKind.Image2DKeyword;
                case "iimage2D":
                    return SyntaxKind.Iimage2DKeyword;
                case "uimage2D":
                    return SyntaxKind.Uimage2DKeyword;
                case "image2DRect":
                    return SyntaxKind.Image2DRectKeyword;
                case "iimage2DRect":
                    return SyntaxKind.Iimage2DRectKeyword;
                case "uimage2DRect":
                    return SyntaxKind.Uimage2DRectKeyword;
                case "subpassInput":
                    return SyntaxKind.SubpassInputKeyword;
                case "subpassInputMS":
                    return SyntaxKind.SubpassInputMSKeyword;
                case "isubpassInput":
                    return SyntaxKind.IsubpassInputKeyword;
                case "isubpassInputMS":
                    return SyntaxKind.IsubpassInputMSKeyword;
                case "usubpassInput":
                    return SyntaxKind.UsubpassInputKeyword;
                case "usubpassInputMS":
                    return SyntaxKind.UsubpassInputMSKeyword;
                case "texture2DArray":
                    return SyntaxKind.Texture2DArrayKeyword;
                case "itexture2DArray":
                    return SyntaxKind.Itexture2DArrayKeyword;
                case "utexture2DArray":
                    return SyntaxKind.Utexture2DArrayKeyword;
                case "image2DArray":
                    return SyntaxKind.Image2DArrayKeyword;
                case "iimage2DArray":
                    return SyntaxKind.Iimage2DArrayKeyword;
                case "uimage2DArray":
                    return SyntaxKind.Uimage2DArrayKeyword;
                case "texture2DMS":
                    return SyntaxKind.Texture2DMSKeyword;
                case "itexture2DMS":
                    return SyntaxKind.Itexture2DMSKeyword;
                case "utexture2DMS":
                    return SyntaxKind.Utexture2DMSKeyword;
                case "image2DMS":
                    return SyntaxKind.Image2DMSKeyword;
                case "iimage2DMS":
                    return SyntaxKind.Iimage2DMSKeyword;
                case "uimage2DMS":
                    return SyntaxKind.Uimage2DMSKeyword;
                case "texture2DMSArray":
                    return SyntaxKind.Texture2DMSArrayKeyword;
                case "itexture2DMSArray":
                    return SyntaxKind.Itexture2DMSArrayKeyword;
                case "utexture2DMSArray":
                    return SyntaxKind.Utexture2DMSArrayKeyword;
                case "image2DMSArray":
                    return SyntaxKind.Image2DMSArrayKeyword;
                case "iimage2DMSArray":
                    return SyntaxKind.Iimage2DMSArrayKeyword;
                case "uimage2DMSArray":
                    return SyntaxKind.Uimage2DMSArrayKeyword;
                case "texture3D":
                    return SyntaxKind.Texture3DKeyword;
                case "itexture3D":
                    return SyntaxKind.Itexture3DKeyword;
                case "utexture3D":
                    return SyntaxKind.Utexture3DKeyword;
                case "image3D":
                    return SyntaxKind.Image3DKeyword;
                case "iimage3D":
                    return SyntaxKind.Iimage3DKeyword;
                case "uimage3D":
                    return SyntaxKind.Uimage3DKeyword;
                case "textureCube":
                    return SyntaxKind.TextureCubeKeyword;
                case "itextureCube":
                    return SyntaxKind.ItextureCubeKeyword;
                case "utextureCube":
                    return SyntaxKind.UtextureCubeKeyword;
                case "imageCube":
                    return SyntaxKind.ImageCubeKeyword;
                case "iimageCube":
                    return SyntaxKind.IimageCubeKeyword;
                case "uimageCube":
                    return SyntaxKind.UimageCubeKeyword;
                case "textureCubeArray":
                    return SyntaxKind.TextureCubeArrayKeyword;
                case "itextureCubeArray":
                    return SyntaxKind.ItextureCubeArrayKeyword;
                case "utextureCubeArray":
                    return SyntaxKind.UtextureCubeArrayKeyword;
                case "imageCubeArray":
                    return SyntaxKind.ImageCubeArrayKeyword;
                case "iimageCubeArray":
                    return SyntaxKind.IimageCubeArrayKeyword;
                case "uimageCubeArray":
                    return SyntaxKind.UimageCubeArrayKeyword;

                case "triangle":
                    return SyntaxKind.TriangleKeyword;
                case "triangleadj":
                    return SyntaxKind.TriangleAdjKeyword;
                case "typedef":
                    return SyntaxKind.TypedefKeyword;
                case "uniform":
                    return SyntaxKind.UniformKeyword;
                case "unorm":
                    return SyntaxKind.UNormKeyword;
                case "unsigned":
                    return SyntaxKind.UnsignedKeyword;
                case "uint":
                    return SyntaxKind.Uint1Keyword;
                case "uvec2":
                    return SyntaxKind.Uint2Keyword;
                case "uvec3":
                    return SyntaxKind.Uint3Keyword;
                case "uvec4":
                    return SyntaxKind.Uint4Keyword;
                case "volatile":
                    return SyntaxKind.VolatileKeyword;
                case "void":
                    return SyntaxKind.VoidKeyword;
                case "while":
                    return SyntaxKind.WhileKeyword;

                case "false":
                    return SyntaxKind.FalseKeyword;
                case "true":
                    return SyntaxKind.TrueKeyword;

                default:
                    return SyntaxKind.IdentifierToken;
            }
        }

        public static SyntaxKind GetContextualKeywordKind(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            switch (text)
            {
                case "CompileShader":
                    return SyntaxKind.CompileShaderKeyword;
                case "NULL":
                    return SyntaxKind.NullKeyword;
                case "line":
                    return SyntaxKind.LineKeyword;
                default:
                    return SyntaxKind.IdentifierToken;
            }
        }

        public static SyntaxKind GetPreprocessorKeywordKind(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            switch (text)
            {
                case "define":
                    return SyntaxKind.DefineKeyword;
                case "defined":
                    return SyntaxKind.DefinedKeyword;
                case "if":
                    return SyntaxKind.IfKeyword;
                case "elif":
                    return SyntaxKind.ElifKeyword;
                case "else":
                    return SyntaxKind.ElseKeyword;
                case "endif":
                    return SyntaxKind.EndIfKeyword;
                case "ifdef":
                    return SyntaxKind.IfDefKeyword;
                case "ifndef":
                    return SyntaxKind.IfNDefKeyword;
                case "undef":
                    return SyntaxKind.UndefKeyword;
                case "include":
                    return SyntaxKind.IncludeKeyword;
                case "line":
                    return SyntaxKind.LineKeyword;
                case "error":
                    return SyntaxKind.ErrorKeyword;
                case "pragma":
                    return SyntaxKind.PragmaKeyword;
                case "def":
                    return SyntaxKind.DefKeyword;
                case "pack_matrix":
                    return SyntaxKind.PackMatrixKeyword;
                case "warning":
                    return SyntaxKind.WarningKeyword;
                case "type":
                    return SyntaxKind.PragmaKeyword;
                case "version":
                    return SyntaxKind.PragmaKeyword;
                default:
                    return SyntaxKind.IdentifierToken;
            }
        }

        public static bool IsPreprocessorKeyword(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.DefineKeyword:
                case SyntaxKind.DefinedKeyword:
                case SyntaxKind.IfKeyword:
                case SyntaxKind.ElifKeyword:
                case SyntaxKind.ElseKeyword:
                case SyntaxKind.EndIfKeyword:
                case SyntaxKind.IfDefKeyword:
                case SyntaxKind.IfNDefKeyword:
                case SyntaxKind.UndefKeyword:
                case SyntaxKind.IncludeKeyword:
                case SyntaxKind.LineKeyword:
                case SyntaxKind.ErrorKeyword:
                case SyntaxKind.PragmaKeyword:
                case SyntaxKind.DefKeyword:
                case SyntaxKind.PackMatrixKeyword:
                case SyntaxKind.WarningKeyword:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsDeclarationModifier(SyntaxToken token)
        {
            switch (token.Kind)
            {
                case SyntaxKind.ConstKeyword:
                case SyntaxKind.RowMajorKeyword:
                case SyntaxKind.ColumnMajorKeyword:
                    return true;

                case SyntaxKind.ExportKeyword:
                case SyntaxKind.ExternKeyword:
                case SyntaxKind.InlineKeyword:
                case SyntaxKind.PreciseKeyword:
                case SyntaxKind.SharedKeyword:
                case SyntaxKind.GloballycoherentKeyword:
                case SyntaxKind.GroupsharedKeyword:
                case SyntaxKind.StaticKeyword:
                case SyntaxKind.UniformKeyword:
                case SyntaxKind.VolatileKeyword:
                    return true;

                case SyntaxKind.SNormKeyword:
                case SyntaxKind.UNormKeyword:
                    return true;

                case SyntaxKind.LinearKeyword:
                case SyntaxKind.CentroidKeyword:
                case SyntaxKind.NointerpolationKeyword:
                case SyntaxKind.NoperspectiveKeyword:
                    return true;

                default:
                    switch (token.ContextualKind)
                    {

                        default:
                            return false;
                    }
            }
        }

        public static bool IsParameterModifier(SyntaxToken token)
        {
            if (IsDeclarationModifier(token))
                return true;

            switch (token.Kind)
            {
                case SyntaxKind.InKeyword:
                case SyntaxKind.OutKeyword:
                case SyntaxKind.InoutKeyword:
                    return true;

                // Geometry shader modifiers.
                case SyntaxKind.PointKeyword:
                case SyntaxKind.TriangleKeyword:
                case SyntaxKind.TriangleAdjKeyword:
                case SyntaxKind.LineAdjKeyword:
                    return true;

                default:
                    switch (token.ContextualKind)
                    {
                        case SyntaxKind.LineKeyword:
                            return true;

                        default:
                            return false;
                    }
            }
        }

        public static ParameterDirection GetParameterDirection(IList<SyntaxToken> modifiers)
        {
            if ((modifiers.Any(x => x.Kind == SyntaxKind.InKeyword) && modifiers.Any(x => x.Kind == SyntaxKind.OutKeyword))
                || modifiers.Any(x => x.Kind == SyntaxKind.InoutKeyword))
                return ParameterDirection.Inout;

            if (modifiers.Any(x => x.Kind == SyntaxKind.OutKeyword))
                return ParameterDirection.Out;

            return ParameterDirection.In;
        }

        public static bool HaveMatchingSignatures(FunctionSyntax left, FunctionSyntax right)
        {
            // TODO: Whitespace differences will result in a false negative.
            // Instead we should do this test on FunctionSymbol objects.

            if (left.Name.GetUnqualifiedName().Name.Text != right.Name.GetUnqualifiedName().Name.Text)
                return false;

            if (left.ParameterList.Parameters.Count != right.ParameterList.Parameters.Count)
                return false;

            for (var i = 0; i < left.ParameterList.Parameters.Count; i++)
            {
                var leftParameter = left.ParameterList.Parameters[i];
                var rightParameter = right.ParameterList.Parameters[i];

                if (leftParameter.Type.ToStringIgnoringMacroReferences() != rightParameter.Type.ToStringIgnoringMacroReferences())
                    return false;

                if (leftParameter.Declarator.ArrayRankSpecifiers.Count != rightParameter.Declarator.ArrayRankSpecifiers.Count)
                    return false;

                for (var j = 0; j < leftParameter.Declarator.ArrayRankSpecifiers.Count; j++)
                {
                    var leftDimension = leftParameter.Declarator.ArrayRankSpecifiers[j].Dimension;
                    var rightDimension = rightParameter.Declarator.ArrayRankSpecifiers[j].Dimension;
                    if ((leftDimension != null) != (rightDimension != null))
                        return false;
                    if (leftDimension == null)
                        return false;
                    if (leftDimension.ToStringIgnoringMacroReferences() != rightDimension.ToStringIgnoringMacroReferences())
                        return false;
                }

                if (leftParameter.Modifiers.Count != rightParameter.Modifiers.Count)
                    return false;

                for (var j = 0; j < leftParameter.Modifiers.Count; j++)
                    if (leftParameter.Modifiers[j].Text != rightParameter.Modifiers[j].Text)
                        return false;
            }

            return true;
        }
    }
}