using System;
using System.Collections.Immutable;
using System.Linq;
using ShaderTools.CodeAnalysis.Hlsl.Binding.BoundNodes;
using ShaderTools.CodeAnalysis.Hlsl.Diagnostics;
using ShaderTools.CodeAnalysis.Hlsl.Symbols;
using ShaderTools.CodeAnalysis.Hlsl.Syntax;

namespace ShaderTools.CodeAnalysis.Hlsl.Binding
{
    internal partial class Binder
    {
        private BoundType BindType(TypeSyntax syntax, Symbol parent)
        {
            switch (syntax.Kind)
            {
                case SyntaxKind.PredefinedScalarType:
                    return BindScalarType((ScalarTypeSyntax) syntax);
                case SyntaxKind.PredefinedVectorType:
                    return BindVectorType((VectorTypeSyntax) syntax);
                case SyntaxKind.PredefinedGenericVectorType:
                    return BindGenericVectorType((GenericVectorTypeSyntax) syntax);
                case SyntaxKind.PredefinedMatrixType:
                    return BindMatrixType((MatrixTypeSyntax) syntax);
                case SyntaxKind.PredefinedGenericMatrixType:
                    return BindGenericMatrixType((GenericMatrixTypeSyntax) syntax);
                case SyntaxKind.PredefinedObjectType:
                    return new BoundObjectType(BindObjectType((PredefinedObjectTypeSyntax) syntax));
                case SyntaxKind.StructType:
                case SyntaxKind.ClassType:
                    {
                        // Inline struct.
                        return BindStructDeclaration((StructTypeSyntax) syntax, parent);
                    }
                case SyntaxKind.IdentifierName:
                    {
                        var identifierName = (IdentifierNameSyntax) syntax;
                        var symbols = LookupTypeSymbol(identifierName.Name).ToImmutableArray();
                        if (symbols.Length == 0)
                        {
                            Diagnostics.ReportUndeclaredType(syntax);
                            return new BoundUnknownType();
                        }

                        if (symbols.Length > 1)
                            Diagnostics.ReportAmbiguousType(identifierName.Name, symbols);

                        return new BoundName(symbols.First());
                    }
                case SyntaxKind.QualifiedName:
                    {
                        var qualifiedName = (QualifiedNameSyntax) syntax;
                        return BindQualifiedType(qualifiedName);
                    }
                default:
                    throw new InvalidOperationException(syntax.Kind.ToString());
            }
        }

        private BoundType BindQualifiedType(QualifiedNameSyntax qualifiedName)
        {
            var container = LookupContainer(qualifiedName.Left);

            if (container == null)
                return new BoundUnknownType();

            var symbols = container.Members.OfType<TypeSymbol>()
                .Where(x => x.Name == qualifiedName.Right.Name.Text)
                .ToImmutableArray();

            if (symbols.Length == 0)
            {
                Diagnostics.ReportUndeclaredType(qualifiedName);
                return new BoundUnknownType();
            }

            if (symbols.Length > 1)
                Diagnostics.ReportAmbiguousType(qualifiedName.Right.Name, symbols);

            Bind(qualifiedName.Right, x => new BoundName(symbols.First()));

            return new BoundName(symbols.First());
        }

        private BoundScalarType BindScalarType(ScalarTypeSyntax node)
        {
            var scalarType = TypeFacts.GetScalarType(node);
            switch (scalarType)
            {
                case ScalarType.Void:
                    return new BoundScalarType(IntrinsicTypes.Void);
                case ScalarType.Bool:
                    return new BoundScalarType(IntrinsicTypes.Bool);
                case ScalarType.Int:
                    return new BoundScalarType(IntrinsicTypes.Int);
                case ScalarType.Uint:
                    return new BoundScalarType(IntrinsicTypes.Uint);
                case ScalarType.Float:
                    return new BoundScalarType(IntrinsicTypes.Float);
                case ScalarType.Double:
                    return new BoundScalarType(IntrinsicTypes.Double);
                case ScalarType.String:
                    return new BoundScalarType(IntrinsicTypes.String);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private BoundVectorType BindVectorType(VectorTypeSyntax node)
        {
            var vectorType = TypeFacts.GetVectorType(node.TypeToken.Kind);
            var scalarType = vectorType.Item1;
            var numComponents = vectorType.Item2;

            return new BoundVectorType(IntrinsicTypes.GetVectorType(scalarType, numComponents));
        }

        private BoundGenericVectorType BindGenericVectorType(GenericVectorTypeSyntax node)
        {
            var scalarType = TypeFacts.GetScalarType(node.ScalarType);
            var numComponents = (int) node.SizeToken.Value;

            return new BoundGenericVectorType(
                IntrinsicTypes.GetVectorType(scalarType, numComponents),
                Bind(node.ScalarType, BindScalarType));
        }

        private BoundMatrixType BindMatrixType(MatrixTypeSyntax node)
        {
            var matrixType = TypeFacts.GetMatrixType(node.TypeToken.Kind);
            var scalarType = matrixType.Item1;
            var numRows = matrixType.Item2;
            var numCols = matrixType.Item3;

            return new BoundMatrixType(IntrinsicTypes.GetMatrixType(scalarType, numRows, numCols));
        }

        private BoundGenericMatrixType BindGenericMatrixType(GenericMatrixTypeSyntax node)
        {
            var scalarType = TypeFacts.GetScalarType(node.ScalarType);
            var numRows = (int) node.RowsToken.Value;
            var numCols = (int) node.ColsToken.Value;

            return new BoundGenericMatrixType(
                IntrinsicTypes.GetMatrixType(scalarType, numRows, numCols),
                Bind(node.ScalarType, BindScalarType));
        }

        private IntrinsicObjectTypeSymbol BindObjectType(PredefinedObjectTypeSyntax node)
        {
            var predefinedObjectType = SyntaxFacts.GetPredefinedObjectType(node.ObjectTypeToken.Kind);
            switch (predefinedObjectType)
            {
                case PredefinedObjectType.texture1D:
                    return IntrinsicTypes.texture1D;
                case PredefinedObjectType.itexture1D:
                    return IntrinsicTypes.itexture1D;
                case PredefinedObjectType.utexture1D:
                    return IntrinsicTypes.utexture1D;
                case PredefinedObjectType.image1D:
                    return IntrinsicTypes.image1D;
                case PredefinedObjectType.iimage1D:
                    return IntrinsicTypes.iimage1D;
                case PredefinedObjectType.uimage1D:
                    return IntrinsicTypes.uimage1D;
                case PredefinedObjectType.texture1DArray:
                    return IntrinsicTypes.texture1DArray;
                case PredefinedObjectType.itexture1DArray:
                    return IntrinsicTypes.itexture1DArray;
                case PredefinedObjectType.utexture1DArray:
                    return IntrinsicTypes.utexture1DArray;
                case PredefinedObjectType.image1DArray:
                    return IntrinsicTypes.image1DArray;
                case PredefinedObjectType.iimage1DArray:
                    return IntrinsicTypes.iimage1DArray;
                case PredefinedObjectType.uimage1DArray:
                    return IntrinsicTypes.uimage1DArray;
                case PredefinedObjectType.texture2D:
                    return IntrinsicTypes.texture2D;
                case PredefinedObjectType.itexture2D:
                    return IntrinsicTypes.itexture2D;
                case PredefinedObjectType.utexture2D:
                    return IntrinsicTypes.utexture2D;
                case PredefinedObjectType.image2D:
                    return IntrinsicTypes.image2D;
                case PredefinedObjectType.iimage2D:
                    return IntrinsicTypes.iimage2D;
                case PredefinedObjectType.uimage2D:
                    return IntrinsicTypes.uimage2D;
                case PredefinedObjectType.image2DRect:
                    return IntrinsicTypes.image2DRect;
                case PredefinedObjectType.iimage2DRect:
                    return IntrinsicTypes.iimage2DRect;
                case PredefinedObjectType.uimage2DRect:
                    return IntrinsicTypes.uimage2DRect;
                case PredefinedObjectType.subpassInput:
                    return IntrinsicTypes.subpassInput;
                case PredefinedObjectType.subpassInputMS:
                    return IntrinsicTypes.subpassInputMS;
                case PredefinedObjectType.isubpassInput:
                    return IntrinsicTypes.isubpassInput;
                case PredefinedObjectType.isubpassInputMS:
                    return IntrinsicTypes.isubpassInputMS;
                case PredefinedObjectType.usubpassInput:
                    return IntrinsicTypes.usubpassInput;
                case PredefinedObjectType.usubpassInputMS:
                    return IntrinsicTypes.usubpassInputMS;
                case PredefinedObjectType.texture2DArray:
                    return IntrinsicTypes.texture2DArray;
                case PredefinedObjectType.itexture2DArray:
                    return IntrinsicTypes.itexture2DArray;
                case PredefinedObjectType.utexture2DArray:
                    return IntrinsicTypes.utexture2DArray;
                case PredefinedObjectType.image2DArray:
                    return IntrinsicTypes.image2DArray;
                case PredefinedObjectType.iimage2DArray:
                    return IntrinsicTypes.iimage2DArray;
                case PredefinedObjectType.uimage2DArray:
                    return IntrinsicTypes.uimage2DArray;
                case PredefinedObjectType.texture2DMS:
                    return IntrinsicTypes.texture2DMS;
                case PredefinedObjectType.itexture2DMS:
                    return IntrinsicTypes.itexture2DMS;
                case PredefinedObjectType.utexture2DMS:
                    return IntrinsicTypes.utexture2DMS;
                case PredefinedObjectType.image2DMS:
                    return IntrinsicTypes.image2DMS;
                case PredefinedObjectType.iimage2DMS:
                    return IntrinsicTypes.iimage2DMS;
                case PredefinedObjectType.uimage2DMS:
                    return IntrinsicTypes.uimage2DMS;
                case PredefinedObjectType.texture2DMSArray:
                    return IntrinsicTypes.texture2DMSArray;
                case PredefinedObjectType.itexture2DMSArray:
                    return IntrinsicTypes.itexture2DMSArray;
                case PredefinedObjectType.utexture2DMSArray:
                    return IntrinsicTypes.utexture2DMSArray;
                case PredefinedObjectType.image2DMSArray:
                    return IntrinsicTypes.image2DMSArray;
                case PredefinedObjectType.iimage2DMSArray:
                    return IntrinsicTypes.iimage2DMSArray;
                case PredefinedObjectType.uimage2DMSArray:
                    return IntrinsicTypes.uimage2DMSArray;
                case PredefinedObjectType.texture3D:
                    return IntrinsicTypes.texture3D;
                case PredefinedObjectType.itexture3D:
                    return IntrinsicTypes.itexture3D;
                case PredefinedObjectType.utexture3D:
                    return IntrinsicTypes.utexture3D;
                case PredefinedObjectType.image3D:
                    return IntrinsicTypes.image3D;
                case PredefinedObjectType.iimage3D:
                    return IntrinsicTypes.iimage3D;
                case PredefinedObjectType.uimage3D:
                    return IntrinsicTypes.uimage3D;
                case PredefinedObjectType.textureCube:
                    return IntrinsicTypes.textureCube;
                case PredefinedObjectType.itextureCube:
                    return IntrinsicTypes.itextureCube;
                case PredefinedObjectType.utextureCube:
                    return IntrinsicTypes.utextureCube;
                case PredefinedObjectType.imageCube:
                    return IntrinsicTypes.imageCube;
                case PredefinedObjectType.iimageCube:
                    return IntrinsicTypes.iimageCube;
                case PredefinedObjectType.uimageCube:
                    return IntrinsicTypes.uimageCube;
                case PredefinedObjectType.textureCubeArray:
                    return IntrinsicTypes.textureCubeArray;
                case PredefinedObjectType.itextureCubeArray:
                    return IntrinsicTypes.itextureCubeArray;
                case PredefinedObjectType.utextureCubeArray:
                    return IntrinsicTypes.utextureCubeArray;
                case PredefinedObjectType.imageCubeArray:
                    return IntrinsicTypes.imageCubeArray;
                case PredefinedObjectType.iimageCubeArray:
                    return IntrinsicTypes.iimageCubeArray;
                case PredefinedObjectType.uimageCubeArray:
                    return IntrinsicTypes.uimageCubeArray;
                case PredefinedObjectType.sampler:
                    return IntrinsicTypes.sampler;
                case PredefinedObjectType.samplerShadow:
                    return IntrinsicTypes.samplerShadow;
                case PredefinedObjectType.samplerBuffer:
                    return IntrinsicTypes.samplerBuffer;
                case PredefinedObjectType.isamplerBuffer:
                    return IntrinsicTypes.isamplerBuffer;
                case PredefinedObjectType.usamplerBuffer:
                    return IntrinsicTypes.usamplerBuffer;
                case PredefinedObjectType.sampler1D:
                    return IntrinsicTypes.sampler1D;
                case PredefinedObjectType.sampler1DArray:
                    return IntrinsicTypes.sampler1DArray;
                case PredefinedObjectType.sampler1DShadow:
                    return IntrinsicTypes.sampler1DShadow;
                case PredefinedObjectType.sampler1DArrayShadow:
                    return IntrinsicTypes.sampler1DArrayShadow;
                case PredefinedObjectType.isampler1D:
                    return IntrinsicTypes.isampler1D;
                case PredefinedObjectType.isampler1DArray:
                    return IntrinsicTypes.isampler1DArray;
                case PredefinedObjectType.usampler1D:
                    return IntrinsicTypes.usampler1D;
                case PredefinedObjectType.usampler1DArray:
                    return IntrinsicTypes.usampler1DArray;
                case PredefinedObjectType.sampler2D:
                    return IntrinsicTypes.sampler2D;
                case PredefinedObjectType.sampler2DArray:
                    return IntrinsicTypes.sampler2DArray;
                case PredefinedObjectType.sampler2DShadow:
                    return IntrinsicTypes.sampler2DShadow;
                case PredefinedObjectType.sampler2DArrayShadow:
                    return IntrinsicTypes.sampler2DArrayShadow;
                case PredefinedObjectType.sampler2DRect:
                    return IntrinsicTypes.sampler2DRect;
                case PredefinedObjectType.sampler2DRectShadow:
                    return IntrinsicTypes.sampler2DRectShadow;
                case PredefinedObjectType.sampler2DMS:
                    return IntrinsicTypes.sampler2DMS;
                case PredefinedObjectType.sampler2DMSArray:
                    return IntrinsicTypes.sampler2DMSArray;
                case PredefinedObjectType.isampler2D:
                    return IntrinsicTypes.isampler2D;
                case PredefinedObjectType.isampler2DArray:
                    return IntrinsicTypes.isampler2DArray;
                case PredefinedObjectType.isampler2DRect:
                    return IntrinsicTypes.isampler2DRect;
                case PredefinedObjectType.isampler2DMS:
                    return IntrinsicTypes.isampler2DMS;
                case PredefinedObjectType.isampler2DMSArray:
                    return IntrinsicTypes.isampler2DMSArray;
                case PredefinedObjectType.usampler2D:
                    return IntrinsicTypes.usampler2D;
                case PredefinedObjectType.usampler2DArray:
                    return IntrinsicTypes.usampler2DArray;
                case PredefinedObjectType.usampler2DRect:
                    return IntrinsicTypes.usampler2DRect;
                case PredefinedObjectType.usampler2DMS:
                    return IntrinsicTypes.usampler2DMS;
                case PredefinedObjectType.usampler2DMSArray:
                    return IntrinsicTypes.usampler2DMSArray;
                case PredefinedObjectType.sampler3D:
                    return IntrinsicTypes.sampler3D;
                case PredefinedObjectType.isampler3D:
                    return IntrinsicTypes.isampler3D;
                case PredefinedObjectType.usampler3D:
                    return IntrinsicTypes.usampler3D;
                case PredefinedObjectType.samplerCube:
                    return IntrinsicTypes.samplerCube;
                case PredefinedObjectType.samplerCubeArray:
                    return IntrinsicTypes.samplerCubeArray;
                case PredefinedObjectType.samplerCubeShadow:
                    return IntrinsicTypes.samplerCubeShadow;
                case PredefinedObjectType.samplerCubeArrayShadow:
                    return IntrinsicTypes.samplerCubeArrayShadow;
                case PredefinedObjectType.isamplerCube:
                    return IntrinsicTypes.isamplerCube;
                case PredefinedObjectType.isamplerCubeArray:
                    return IntrinsicTypes.isamplerCubeArray;
                case PredefinedObjectType.usamplerCube:
                    return IntrinsicTypes.usamplerCube;
                case PredefinedObjectType.usamplerCubeArray:
                    return IntrinsicTypes.usamplerCubeArray;
                case PredefinedObjectType.buffer:
                    return IntrinsicTypes.buffer;
                default:
                    throw new InvalidOperationException(predefinedObjectType.ToString());
            }
        }

        private void GetTextureValueAndScalarType(PredefinedObjectTypeSyntax node, out TypeSymbol valueType, out ScalarType scalarType)
        {
            if (node.TemplateArgumentList != null)
            {
                var valueTypeSyntax = (TypeSyntax) node.TemplateArgumentList.Arguments[0];
                valueType = Bind(valueTypeSyntax, x => BindType(x, null)).TypeSymbol;
                switch (valueTypeSyntax.Kind)
                {
                    case SyntaxKind.PredefinedScalarType:
                        scalarType = TypeFacts.GetScalarType((ScalarTypeSyntax) valueTypeSyntax);
                        break;
                    case SyntaxKind.PredefinedVectorType:
                        scalarType = TypeFacts.GetVectorType(((VectorTypeSyntax) valueTypeSyntax).TypeToken.Kind).Item1;
                        break;
                    case SyntaxKind.PredefinedGenericVectorType:
                        scalarType = TypeFacts.GetScalarType(((GenericVectorTypeSyntax) valueTypeSyntax).ScalarType);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                valueType = IntrinsicTypes.Float4;
                scalarType = ScalarType.Float;
            }
        }
    }
}