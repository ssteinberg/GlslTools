﻿using System;
using System.Diagnostics;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public static class TypeFacts
    {
        public static readonly TypeSymbol Missing = new IntrinsicObjectTypeSymbol("[Missing]", string.Empty, PredefinedObjectType.texture2D);
        public static readonly TypeSymbol Unknown = new IntrinsicObjectTypeSymbol("[Unknown]", string.Empty, PredefinedObjectType.texture2D);
        public static readonly TypeSymbol Variadic = new IntrinsicObjectTypeSymbol("[Variadic]", string.Empty, PredefinedObjectType.texture2D);

        public static bool IsMissing(this TypeSymbol type)
        {
            return type == Missing;
        }

        public static bool IsUnknown(this TypeSymbol type)
        {
            return type == Unknown;
        }

        public static bool IsError(this TypeSymbol type)
        {
            return type.IsMissing() || type.IsUnknown();
        }

        internal static string ToDisplayName(this TypeSymbol type)
        {
            if (type.IsUnknown())
                return "<?>";

            if (type.IsMissing())
                return "<missing>";

            return type.Name;
        }

        internal static bool HasExplicitConversionTo(this TypeSymbol left, TypeSymbol right)
        {
            if (left.Equals(right))
                return true;

            if (left.IsIntrinsicNumericType() && right.Kind == SymbolKind.Struct)
                return true;

            return left.HasImplicitConversionTo(right);
        }

        internal static bool HasImplicitConversionTo(this TypeSymbol left, TypeSymbol right)
        {
            if (left.Equals(right))
                return true;

            // TODO: Need to be able to implicitly cast classes to base class and interfaces?
            if (left.IsUserDefined() || right.IsUserDefined())
                return false;

            switch (left.Kind)
            {
                case SymbolKind.Array:
                    switch (right.Kind)
                    {
                        case SymbolKind.Array:
                        {
                            var leftArray = (ArraySymbol) left;
                            var rightArray = (ArraySymbol) right;
                            return leftArray.ValueType.HasImplicitConversionTo(rightArray.ValueType);
                        }
                        default:
                            return false;
                    }
            }

            if (left.Kind == SymbolKind.IntrinsicScalarType || right.Kind == SymbolKind.IntrinsicScalarType)
                return true;

            switch (left.Kind)
            {
                case SymbolKind.IntrinsicVectorType:
                    switch (right.Kind)
                    {
                        case SymbolKind.IntrinsicScalarType:
                            return true;
                        case SymbolKind.IntrinsicVectorType:
                            return ((IntrinsicVectorTypeSymbol) left).NumComponents == 1 || ((IntrinsicVectorTypeSymbol) left).NumComponents >= ((IntrinsicVectorTypeSymbol) right).NumComponents;
                        case SymbolKind.IntrinsicMatrixType:
                        {
                            var leftVector = (IntrinsicVectorTypeSymbol) left;
                            var rightMatrix = (IntrinsicMatrixTypeSymbol) right;
                            return (leftVector.NumComponents >= rightMatrix.Cols && rightMatrix.Rows == 1)
                                || (leftVector.NumComponents >= rightMatrix.Rows && rightMatrix.Cols == 1);
                        }
                        case SymbolKind.Array:
                        {
                            var leftVector = (IntrinsicVectorTypeSymbol) left;
                            var rightArray = (ArraySymbol) right;
                            if (!leftVector.HasImplicitConversionTo(rightArray.ValueType))
                                return false;
                            if (rightArray.Dimension == null)
                                return true;
                            return leftVector.NumComponents >= rightArray.Dimension.Value;
                        }
                    }
                    break;
                case SymbolKind.IntrinsicMatrixType:
                    switch (right.Kind)
                    {
                        case SymbolKind.IntrinsicScalarType:
                            return true;
                        case SymbolKind.IntrinsicVectorType:
                        {
                            var leftMatrix = (IntrinsicMatrixTypeSymbol) left;
                            var rightVector = (IntrinsicVectorTypeSymbol) right;
                            return (leftMatrix.Rows >= rightVector.NumComponents && leftMatrix.Cols == 1)
                                || (leftMatrix.Cols >= rightVector.NumComponents && leftMatrix.Rows == 1);
                        }
                        case SymbolKind.IntrinsicMatrixType:
                        {
                            var leftMatrix = (IntrinsicMatrixTypeSymbol) left;
                            var rightMatrix = (IntrinsicMatrixTypeSymbol) right;
                            return leftMatrix.Rows >= rightMatrix.Rows && leftMatrix.Cols >= rightMatrix.Cols;
                        }
                    }
                    break;
            }

            if (left.GetNumElements() >= right.GetNumElements())
                return true;

            return false;
        }

        public static bool IsIntrinsicNumericType(this TypeSymbol type)
        {
            return type.Kind == SymbolKind.IntrinsicMatrixType
                || type.Kind == SymbolKind.IntrinsicScalarType
                || type.Kind == SymbolKind.IntrinsicVectorType;
        }

        internal static bool IsUserDefined(this TypeSymbol type)
        {
            return type.Kind == SymbolKind.Struct
                || type.Kind == SymbolKind.Class
                || type.Kind == SymbolKind.Interface;
        }

        internal static int GetDimensionSize(this IntrinsicNumericTypeSymbol type, int dimension)
        {
            switch (type.Kind)
            {
                case SymbolKind.IntrinsicMatrixType:
                    var matrixType = (IntrinsicMatrixTypeSymbol) type;
                    return dimension == 0 ? matrixType.Rows : matrixType.Cols;
                case SymbolKind.IntrinsicVectorType:
                    var vectorType = (IntrinsicVectorTypeSymbol) type;
                    return dimension == 0 ? vectorType.NumComponents : 1;
                case SymbolKind.IntrinsicScalarType:
                    return 1;
                default:
                    throw new InvalidOperationException();
            }
        }

        internal static IntrinsicNumericTypeSymbol GetNumericTypeWithScalarType(this IntrinsicNumericTypeSymbol type, ScalarType scalarType)
        {
            switch (type.Kind)
            {
                case SymbolKind.IntrinsicMatrixType:
                    var matrixType = (IntrinsicMatrixTypeSymbol) type;
                    return IntrinsicTypes.GetMatrixType(scalarType, matrixType.Rows, matrixType.Cols);
                case SymbolKind.IntrinsicScalarType:
                    return IntrinsicTypes.GetScalarType(scalarType);
                case SymbolKind.IntrinsicVectorType:
                    return IntrinsicTypes.GetVectorType(scalarType, ((IntrinsicVectorTypeSymbol) type).NumComponents);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static int GetNumElements(this TypeSymbol type)
        {
            switch (type.Kind)
            {
                case SymbolKind.Array:
                {
                    var arrayType = (ArraySymbol) type;
                    return arrayType.Dimension ?? 0;
                }
                case SymbolKind.IntrinsicMatrixType:
                {
                    var matrixType = (IntrinsicMatrixTypeSymbol) type;
                    return matrixType.Rows * matrixType.Cols;
                }
                case SymbolKind.IntrinsicScalarType:
                {
                    return 1;
                }
                case SymbolKind.IntrinsicVectorType:
                {
                    var vectorType = (IntrinsicVectorTypeSymbol) type;
                    return vectorType.NumComponents;
                }
                default:
                {
                    return 1;
                }
            }
        }

        internal static bool IsPromotion(ScalarType left, ScalarType right)
        {
            if (left == right)
                return false;

            switch (right)
            {
                case ScalarType.Float:
                    switch (left)
                    {
                        case ScalarType.Double:
                            return true;
                    }
                    break;
            }

            return false;
        }

        internal static bool IsCast(ScalarType left, ScalarType right)
        {
            if (left == right)
                return false;

            switch (left)
            {
                case ScalarType.Int:
                    switch (right)
                    {
                        case ScalarType.Uint:
                            return false;
                    }
                    break;
                case ScalarType.Uint:
                    switch (right)
                    {
                        case ScalarType.Int:
                            return false;
                    }
                    break;
            }

            return true;
        }

        internal static bool IsIntCast(ScalarType left, ScalarType right)
        {
            if (left == right)
                return false;

            // TODO

            return true;
        }

        internal static ScalarType GetScalarType(ScalarTypeSyntax node)
        {
            if (node.TypeTokens.Count == 2 && node.TypeTokens[0].Kind == SyntaxKind.UnsignedKeyword && node.TypeTokens[1].Kind == SyntaxKind.IntKeyword)
                return ScalarType.Uint;

            Debug.Assert(node.TypeTokens.Count == 1);

            switch (node.TypeTokens[0].Kind)
            {
                case SyntaxKind.VoidKeyword:
                    return ScalarType.Void;
                case SyntaxKind.BoolKeyword:
                    return ScalarType.Bool;
                case SyntaxKind.IntKeyword:
                case SyntaxKind.DwordKeyword:
                    return ScalarType.Int;
                case SyntaxKind.UintKeyword:
                    return ScalarType.Uint;
                case SyntaxKind.FloatKeyword:
                    return ScalarType.Float;
                case SyntaxKind.DoubleKeyword:
                    return ScalarType.Double;
                case SyntaxKind.StringKeyword:
                    return ScalarType.String;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static Tuple<ScalarType, int> GetVectorType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.VectorKeyword:
                    return Tuple.Create(ScalarType.Float, 4);

                case SyntaxKind.Bool1Keyword:
                    return Tuple.Create(ScalarType.Bool, 1);
                case SyntaxKind.Bool2Keyword:
                    return Tuple.Create(ScalarType.Bool, 2);
                case SyntaxKind.Bool3Keyword:
                    return Tuple.Create(ScalarType.Bool, 3);
                case SyntaxKind.Bool4Keyword:
                    return Tuple.Create(ScalarType.Bool, 4);
                case SyntaxKind.Int1Keyword:
                    return Tuple.Create(ScalarType.Int, 1);
                case SyntaxKind.Int2Keyword:
                    return Tuple.Create(ScalarType.Int, 2);
                case SyntaxKind.Int3Keyword:
                    return Tuple.Create(ScalarType.Int, 3);
                case SyntaxKind.Int4Keyword:
                    return Tuple.Create(ScalarType.Int, 4);
                case SyntaxKind.Uint1Keyword:
                    return Tuple.Create(ScalarType.Uint, 1);
                case SyntaxKind.Uint2Keyword:
                    return Tuple.Create(ScalarType.Uint, 2);
                case SyntaxKind.Uint3Keyword:
                    return Tuple.Create(ScalarType.Uint, 3);
                case SyntaxKind.Uint4Keyword:
                    return Tuple.Create(ScalarType.Uint, 4);
                case SyntaxKind.Float1Keyword:
                    return Tuple.Create(ScalarType.Float, 1);
                case SyntaxKind.Float2Keyword:
                    return Tuple.Create(ScalarType.Float, 2);
                case SyntaxKind.Float3Keyword:
                    return Tuple.Create(ScalarType.Float, 3);
                case SyntaxKind.Float4Keyword:
                    return Tuple.Create(ScalarType.Float, 4);
                case SyntaxKind.Double1Keyword:
                    return Tuple.Create(ScalarType.Double, 1);
                case SyntaxKind.Double2Keyword:
                    return Tuple.Create(ScalarType.Double, 2);
                case SyntaxKind.Double3Keyword:
                    return Tuple.Create(ScalarType.Double, 3);
                case SyntaxKind.Double4Keyword:
                    return Tuple.Create(ScalarType.Double, 4);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static Tuple<ScalarType, int, int> GetMatrixType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.MatrixKeyword:
                    return Tuple.Create(ScalarType.Float, 4, 4);
                    
                case SyntaxKind.Float2x2Keyword:
                    return Tuple.Create(ScalarType.Float, 2, 2);
                case SyntaxKind.Float2x3Keyword:
                    return Tuple.Create(ScalarType.Float, 2, 3);
                case SyntaxKind.Float2x4Keyword:
                    return Tuple.Create(ScalarType.Float, 2, 4);
                case SyntaxKind.Float3x2Keyword:
                    return Tuple.Create(ScalarType.Float, 3, 2);
                case SyntaxKind.Float3x3Keyword:
                    return Tuple.Create(ScalarType.Float, 3, 3);
                case SyntaxKind.Float3x4Keyword:
                    return Tuple.Create(ScalarType.Float, 3, 4);
                case SyntaxKind.Float4x2Keyword:
                    return Tuple.Create(ScalarType.Float, 4, 2);
                case SyntaxKind.Float4x3Keyword:
                    return Tuple.Create(ScalarType.Float, 4, 3);
                case SyntaxKind.Float4x4Keyword:
                    return Tuple.Create(ScalarType.Float, 4, 4);
                    
                case SyntaxKind.Double2x2Keyword:
                    return Tuple.Create(ScalarType.Double, 2, 2);
                case SyntaxKind.Double2x3Keyword:
                    return Tuple.Create(ScalarType.Double, 2, 3);
                case SyntaxKind.Double2x4Keyword:
                    return Tuple.Create(ScalarType.Double, 2, 4);
                case SyntaxKind.Double3x2Keyword:
                    return Tuple.Create(ScalarType.Double, 3, 2);
                case SyntaxKind.Double3x3Keyword:
                    return Tuple.Create(ScalarType.Double, 3, 3);
                case SyntaxKind.Double3x4Keyword:
                    return Tuple.Create(ScalarType.Double, 3, 4);
                case SyntaxKind.Double4x2Keyword:
                    return Tuple.Create(ScalarType.Double, 4, 2);
                case SyntaxKind.Double4x3Keyword:
                    return Tuple.Create(ScalarType.Double, 4, 3);
                case SyntaxKind.Double4x4Keyword:
                    return Tuple.Create(ScalarType.Double, 4, 4);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static TypeSymbol GetMatchingBoolType(TypeSymbol numericType)
        {
            switch (numericType.Kind)
            {
                case SymbolKind.IntrinsicScalarType:
                    return IntrinsicTypes.Bool;
                case SymbolKind.IntrinsicVectorType:
                    return IntrinsicTypes.GetVectorType(ScalarType.Bool, ((IntrinsicVectorTypeSymbol)numericType).NumComponents);
                case SymbolKind.IntrinsicMatrixType:
                    var matrixType = (IntrinsicMatrixTypeSymbol)numericType;
                    return IntrinsicTypes.GetMatrixType(ScalarType.Bool, matrixType.Rows, matrixType.Cols);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}