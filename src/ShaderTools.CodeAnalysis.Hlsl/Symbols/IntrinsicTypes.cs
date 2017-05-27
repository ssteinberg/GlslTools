using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using ShaderTools.CodeAnalysis.Hlsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;

namespace ShaderTools.CodeAnalysis.Hlsl.Symbols
{
    internal static class IntrinsicTypes
    {
        public static readonly IntrinsicScalarTypeSymbol Void;
        public static readonly IntrinsicScalarTypeSymbol String;
        public static readonly IntrinsicScalarTypeSymbol Bool;
        public static readonly IntrinsicScalarTypeSymbol Int;
        public static readonly IntrinsicScalarTypeSymbol Uint;
        public static readonly IntrinsicScalarTypeSymbol Float;
        public static readonly IntrinsicScalarTypeSymbol Double;

        public static readonly IntrinsicVectorTypeSymbol Bool1;
        public static readonly IntrinsicVectorTypeSymbol Bool2;
        public static readonly IntrinsicVectorTypeSymbol Bool3;
        public static readonly IntrinsicVectorTypeSymbol Bool4;

        public static readonly IntrinsicVectorTypeSymbol Int1;
        public static readonly IntrinsicVectorTypeSymbol Int2;
        public static readonly IntrinsicVectorTypeSymbol Int3;
        public static readonly IntrinsicVectorTypeSymbol Int4;

        public static readonly IntrinsicVectorTypeSymbol Uint1;
        public static readonly IntrinsicVectorTypeSymbol Uint2;
        public static readonly IntrinsicVectorTypeSymbol Uint3;
        public static readonly IntrinsicVectorTypeSymbol Uint4;

        public static readonly IntrinsicVectorTypeSymbol Float1;
        public static readonly IntrinsicVectorTypeSymbol Float2;
        public static readonly IntrinsicVectorTypeSymbol Float3;
        public static readonly IntrinsicVectorTypeSymbol Float4;

        public static readonly IntrinsicVectorTypeSymbol Double1;
        public static readonly IntrinsicVectorTypeSymbol Double2;
        public static readonly IntrinsicVectorTypeSymbol Double3;
        public static readonly IntrinsicVectorTypeSymbol Double4;

        public static readonly IntrinsicMatrixTypeSymbol Float2x2;
        public static readonly IntrinsicMatrixTypeSymbol Float2x3;
        public static readonly IntrinsicMatrixTypeSymbol Float2x4;
        public static readonly IntrinsicMatrixTypeSymbol Float3x2;
        public static readonly IntrinsicMatrixTypeSymbol Float3x3;
        public static readonly IntrinsicMatrixTypeSymbol Float3x4;
        public static readonly IntrinsicMatrixTypeSymbol Float4x2;
        public static readonly IntrinsicMatrixTypeSymbol Float4x3;
        public static readonly IntrinsicMatrixTypeSymbol Float4x4;

        public static readonly IntrinsicMatrixTypeSymbol FloatMat2;
        public static readonly IntrinsicMatrixTypeSymbol FloatMat3;
        public static readonly IntrinsicMatrixTypeSymbol FloatMat4;

        public static readonly IntrinsicMatrixTypeSymbol Double2x2;
        public static readonly IntrinsicMatrixTypeSymbol Double2x3;
        public static readonly IntrinsicMatrixTypeSymbol Double2x4;
        public static readonly IntrinsicMatrixTypeSymbol Double3x2;
        public static readonly IntrinsicMatrixTypeSymbol Double3x3;
        public static readonly IntrinsicMatrixTypeSymbol Double3x4;
        public static readonly IntrinsicMatrixTypeSymbol Double4x2;
        public static readonly IntrinsicMatrixTypeSymbol Double4x3;
        public static readonly IntrinsicMatrixTypeSymbol Double4x4;

        public static readonly IntrinsicMatrixTypeSymbol DoubleMat2;
        public static readonly IntrinsicMatrixTypeSymbol DoubleMat3;
        public static readonly IntrinsicMatrixTypeSymbol DoubleMat4;

        public static readonly IntrinsicScalarTypeSymbol[] AllScalarTypes;

        public static readonly IntrinsicVectorTypeSymbol[] AllBoolVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllIntVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllUintVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllFloatVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllDoubleVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllFloatDoubleVectorTypes;
        public static readonly IntrinsicVectorTypeSymbol[] AllVectorTypes;

        public static readonly IntrinsicMatrixTypeSymbol[] AllFloatMatrixTypes;
        public static readonly IntrinsicMatrixTypeSymbol[] AllFloatSquareMatrixTypes;
        public static readonly IntrinsicMatrixTypeSymbol[] AllDoubleMatrixTypes;
        public static readonly IntrinsicMatrixTypeSymbol[] AllDoubleSquareMatrixTypes;
        public static readonly IntrinsicMatrixTypeSymbol[] AllMatrixTypes;

        public static readonly IntrinsicNumericTypeSymbol[] AllBoolTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllIntTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllUintTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllFloatTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllDoubleTypes;

        public static readonly IntrinsicNumericTypeSymbol[] AllIntegralTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllNumericNonBoolTypes;
        public static readonly IntrinsicNumericTypeSymbol[] AllNumericTypes;

        public static readonly IntrinsicObjectTypeSymbol[] AllImage1DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage1DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage2DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage2DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage2DRectTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage2DMSTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage2DMSArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImage3DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImageCubeTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllImageCubeArrayTypes;

        public static readonly IntrinsicObjectTypeSymbol[] AllTexture1DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture1DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture2DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture2DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture2DMSTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture2DMSArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTexture3DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTextureCubeTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllTextureCubeArrayTypes;

        public static readonly IntrinsicObjectTypeSymbol[] AllSampler1DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler1DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler2DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler2DArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler2DRectTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler2DMSTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler2DMSArrayTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSampler3DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerCubeTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerCubeArrayTypes;

        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerWithSize1DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerWithSize2DTypes;
        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerWithSize3DTypes;

        public static readonly IntrinsicObjectTypeSymbol[] AllSamplerTypes;

        public static readonly IntrinsicObjectTypeSymbol texture1D;
        public static readonly IntrinsicObjectTypeSymbol itexture1D;
        public static readonly IntrinsicObjectTypeSymbol utexture1D;
        public static readonly IntrinsicObjectTypeSymbol image1D;
        public static readonly IntrinsicObjectTypeSymbol iimage1D;
        public static readonly IntrinsicObjectTypeSymbol uimage1D;
        public static readonly IntrinsicObjectTypeSymbol texture1DArray;
        public static readonly IntrinsicObjectTypeSymbol itexture1DArray;
        public static readonly IntrinsicObjectTypeSymbol utexture1DArray;
        public static readonly IntrinsicObjectTypeSymbol image1DArray;
        public static readonly IntrinsicObjectTypeSymbol iimage1DArray;
        public static readonly IntrinsicObjectTypeSymbol uimage1DArray;
        public static readonly IntrinsicObjectTypeSymbol texture2D;
        public static readonly IntrinsicObjectTypeSymbol itexture2D;
        public static readonly IntrinsicObjectTypeSymbol utexture2D;
        public static readonly IntrinsicObjectTypeSymbol image2D;
        public static readonly IntrinsicObjectTypeSymbol iimage2D;
        public static readonly IntrinsicObjectTypeSymbol uimage2D;
        public static readonly IntrinsicObjectTypeSymbol image2DRect;
        public static readonly IntrinsicObjectTypeSymbol iimage2DRect;
        public static readonly IntrinsicObjectTypeSymbol uimage2DRect;
        public static readonly IntrinsicObjectTypeSymbol subpassInput;
        public static readonly IntrinsicObjectTypeSymbol subpassInputMS;
        public static readonly IntrinsicObjectTypeSymbol isubpassInput;
        public static readonly IntrinsicObjectTypeSymbol isubpassInputMS;
        public static readonly IntrinsicObjectTypeSymbol usubpassInput;
        public static readonly IntrinsicObjectTypeSymbol usubpassInputMS;
        public static readonly IntrinsicObjectTypeSymbol texture2DArray;
        public static readonly IntrinsicObjectTypeSymbol itexture2DArray;
        public static readonly IntrinsicObjectTypeSymbol utexture2DArray;
        public static readonly IntrinsicObjectTypeSymbol image2DArray;
        public static readonly IntrinsicObjectTypeSymbol iimage2DArray;
        public static readonly IntrinsicObjectTypeSymbol uimage2DArray;
        public static readonly IntrinsicObjectTypeSymbol texture2DMS;
        public static readonly IntrinsicObjectTypeSymbol itexture2DMS;
        public static readonly IntrinsicObjectTypeSymbol utexture2DMS;
        public static readonly IntrinsicObjectTypeSymbol image2DMS;
        public static readonly IntrinsicObjectTypeSymbol iimage2DMS;
        public static readonly IntrinsicObjectTypeSymbol uimage2DMS;
        public static readonly IntrinsicObjectTypeSymbol texture2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol itexture2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol utexture2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol image2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol iimage2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol uimage2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol texture3D;
        public static readonly IntrinsicObjectTypeSymbol itexture3D;
        public static readonly IntrinsicObjectTypeSymbol utexture3D;
        public static readonly IntrinsicObjectTypeSymbol image3D;
        public static readonly IntrinsicObjectTypeSymbol iimage3D;
        public static readonly IntrinsicObjectTypeSymbol uimage3D;
        public static readonly IntrinsicObjectTypeSymbol textureCube;
        public static readonly IntrinsicObjectTypeSymbol itextureCube;
        public static readonly IntrinsicObjectTypeSymbol utextureCube;
        public static readonly IntrinsicObjectTypeSymbol imageCube;
        public static readonly IntrinsicObjectTypeSymbol iimageCube;
        public static readonly IntrinsicObjectTypeSymbol uimageCube;
        public static readonly IntrinsicObjectTypeSymbol textureCubeArray;
        public static readonly IntrinsicObjectTypeSymbol itextureCubeArray;
        public static readonly IntrinsicObjectTypeSymbol utextureCubeArray;
        public static readonly IntrinsicObjectTypeSymbol imageCubeArray;
        public static readonly IntrinsicObjectTypeSymbol iimageCubeArray;
        public static readonly IntrinsicObjectTypeSymbol uimageCubeArray;

        public static readonly IntrinsicObjectTypeSymbol sampler;
        public static readonly IntrinsicObjectTypeSymbol samplerShadow;
        public static readonly IntrinsicObjectTypeSymbol samplerBuffer;
        public static readonly IntrinsicObjectTypeSymbol isamplerBuffer;
        public static readonly IntrinsicObjectTypeSymbol usamplerBuffer;
        public static readonly IntrinsicObjectTypeSymbol sampler1D;
        public static readonly IntrinsicObjectTypeSymbol sampler1DArray;
        public static readonly IntrinsicObjectTypeSymbol sampler1DShadow;
        public static readonly IntrinsicObjectTypeSymbol sampler1DArrayShadow;
        public static readonly IntrinsicObjectTypeSymbol isampler1D;
        public static readonly IntrinsicObjectTypeSymbol isampler1DArray;
        public static readonly IntrinsicObjectTypeSymbol usampler1D;
        public static readonly IntrinsicObjectTypeSymbol usampler1DArray;
        public static readonly IntrinsicObjectTypeSymbol sampler2D;
        public static readonly IntrinsicObjectTypeSymbol sampler2DArray;
        public static readonly IntrinsicObjectTypeSymbol sampler2DShadow;
        public static readonly IntrinsicObjectTypeSymbol sampler2DArrayShadow;
        public static readonly IntrinsicObjectTypeSymbol sampler2DRect;
        public static readonly IntrinsicObjectTypeSymbol sampler2DRectShadow;
        public static readonly IntrinsicObjectTypeSymbol sampler2DMS;
        public static readonly IntrinsicObjectTypeSymbol sampler2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol isampler2D;
        public static readonly IntrinsicObjectTypeSymbol isampler2DArray;
        public static readonly IntrinsicObjectTypeSymbol isampler2DRect;
        public static readonly IntrinsicObjectTypeSymbol isampler2DMS;
        public static readonly IntrinsicObjectTypeSymbol isampler2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol usampler2D;
        public static readonly IntrinsicObjectTypeSymbol usampler2DArray;
        public static readonly IntrinsicObjectTypeSymbol usampler2DRect;
        public static readonly IntrinsicObjectTypeSymbol usampler2DMS;
        public static readonly IntrinsicObjectTypeSymbol usampler2DMSArray;
        public static readonly IntrinsicObjectTypeSymbol sampler3D;
        public static readonly IntrinsicObjectTypeSymbol isampler3D;
        public static readonly IntrinsicObjectTypeSymbol usampler3D;
        public static readonly IntrinsicObjectTypeSymbol samplerCube;
        public static readonly IntrinsicObjectTypeSymbol samplerCubeArray;
        public static readonly IntrinsicObjectTypeSymbol samplerCubeShadow;
        public static readonly IntrinsicObjectTypeSymbol samplerCubeArrayShadow;
        public static readonly IntrinsicObjectTypeSymbol isamplerCube;
        public static readonly IntrinsicObjectTypeSymbol isamplerCubeArray;
        public static readonly IntrinsicObjectTypeSymbol usamplerCube;
        public static readonly IntrinsicObjectTypeSymbol usamplerCubeArray;

        public static readonly IntrinsicObjectTypeSymbol buffer;

        public static readonly TypeSymbol[] AllTypes;

        static IntrinsicTypes()
        {
            // Scalar types.
            Void = new IntrinsicScalarTypeSymbol("void", "Represents a void value.", ScalarType.Void);
            String = new IntrinsicScalarTypeSymbol("string", "Represents a string value.", ScalarType.String);
            Bool = new IntrinsicScalarTypeSymbol("bool", "Represents a boolean value.", ScalarType.Bool);
            Int = new IntrinsicScalarTypeSymbol("int", "Represents a 32-bit signed integer value.", ScalarType.Int);
            Uint = new IntrinsicScalarTypeSymbol("uint", "Represents a 32-bit unsigned integer value.", ScalarType.Uint);
            Float = new IntrinsicScalarTypeSymbol("float", "Represents a 32-bit floating point value.", ScalarType.Float);
            Double = new IntrinsicScalarTypeSymbol("double", "Represents a 64-bit floating point value.", ScalarType.Double);

            // Vector types.
            Bool1 = new IntrinsicVectorTypeSymbol("bool1", "Represents a vector containing 1 boolean component.", ScalarType.Bool, 1);
            Bool2 = new IntrinsicVectorTypeSymbol("bool2", "Represents a vector containing 2 boolean components.", ScalarType.Bool, 2);
            Bool3 = new IntrinsicVectorTypeSymbol("bool3", "Represents a vector containing 3 boolean components.", ScalarType.Bool, 3);
            Bool4 = new IntrinsicVectorTypeSymbol("bool4", "Represents a vector containing 4 boolean components.", ScalarType.Bool, 4);
            Int1 = new IntrinsicVectorTypeSymbol("int1", "Represents a vector containing 1 signed integer component.", ScalarType.Int, 1);
            Int2 = new IntrinsicVectorTypeSymbol("int2", "Represents a vector containing 2 signed integer components.", ScalarType.Int, 2);
            Int3 = new IntrinsicVectorTypeSymbol("int3", "Represents a vector containing 3 signed integer components.", ScalarType.Int, 3);
            Int4 = new IntrinsicVectorTypeSymbol("int4", "Represents a vector containing 4 signed integer components.", ScalarType.Int, 4);
            Uint1 = new IntrinsicVectorTypeSymbol("uint1", "Represents a vector containing 1 unsigned integer component.", ScalarType.Uint, 1);
            Uint2 = new IntrinsicVectorTypeSymbol("uint2", "Represents a vector containing 2 unsigned integer components.", ScalarType.Uint, 2);
            Uint3 = new IntrinsicVectorTypeSymbol("uint3", "Represents a vector containing 3 unsigned integer components.", ScalarType.Uint, 3);
            Uint4 = new IntrinsicVectorTypeSymbol("uint4", "Represents a vector containing 4 unsigned integer components.", ScalarType.Uint, 4);
            Float1 = new IntrinsicVectorTypeSymbol("float1", "Represents a vector containing 1 floating point component.", ScalarType.Float, 1);
            Float2 = new IntrinsicVectorTypeSymbol("float2", "Represents a vector containing 2 floating point components.", ScalarType.Float, 2);
            Float3 = new IntrinsicVectorTypeSymbol("float3", "Represents a vector containing 3 floating point components.", ScalarType.Float, 3);
            Float4 = new IntrinsicVectorTypeSymbol("float4", "Represents a vector containing 4 floating point components.", ScalarType.Float, 4);
            Double1 = new IntrinsicVectorTypeSymbol("double1", "Represents a vector containing 1 floating point component.", ScalarType.Double, 1);
            Double2 = new IntrinsicVectorTypeSymbol("double2", "Represents a vector containing 2 floating point components.", ScalarType.Double, 2);
            Double3 = new IntrinsicVectorTypeSymbol("double3", "Represents a vector containing 3 floating point components.", ScalarType.Double, 3);
            Double4 = new IntrinsicVectorTypeSymbol("double4", "Represents a vector containing 4 floating point components.", ScalarType.Double, 4);

            Bool.AddMembers(CreateScalarTypeFields(1, Bool, Bool1, Bool2, Bool3, Bool4));
            Int.AddMembers(CreateScalarTypeFields(1, Int, Int1, Int2, Int3, Int4));
            Uint.AddMembers(CreateScalarTypeFields(1, Uint, Uint1, Uint2, Uint3, Uint4));
            Float.AddMembers(CreateScalarTypeFields(1, Float, Float1, Float2, Float3, Float4));
            Double.AddMembers(CreateScalarTypeFields(1, Double, Double1, Double2, Double3, Double4));

            Bool1.AddMembers(CreateVectorTypeFields(1, Bool1, Bool, Bool1, Bool2, Bool3, Bool4));
            Bool2.AddMembers(CreateVectorTypeFields(2, Bool2, Bool, Bool1, Bool2, Bool3, Bool4));
            Bool3.AddMembers(CreateVectorTypeFields(3, Bool3, Bool, Bool1, Bool2, Bool3, Bool4));
            Bool4.AddMembers(CreateVectorTypeFields(4, Bool4, Bool, Bool1, Bool2, Bool3, Bool4));
            Int1.AddMembers(CreateVectorTypeFields(1, Int1, Int, Int1, Int2, Int3, Int4));
            Int2.AddMembers(CreateVectorTypeFields(2, Int2, Int, Int1, Int2, Int3, Int4));
            Int3.AddMembers(CreateVectorTypeFields(3, Int3, Int, Int1, Int2, Int3, Int4));
            Int4.AddMembers(CreateVectorTypeFields(4, Int4, Int, Int1, Int2, Int3, Int4));
            Uint1.AddMembers(CreateVectorTypeFields(1, Uint1, Uint, Uint1, Uint2, Uint3, Uint4));
            Uint2.AddMembers(CreateVectorTypeFields(2, Uint2, Uint, Uint1, Uint2, Uint3, Uint4));
            Uint3.AddMembers(CreateVectorTypeFields(3, Uint3, Uint, Uint1, Uint2, Uint3, Uint4));
            Uint4.AddMembers(CreateVectorTypeFields(4, Uint4, Uint, Uint1, Uint2, Uint3, Uint4));
            Float1.AddMembers(CreateVectorTypeFields(1, Float1, Float, Float1, Float2, Float3, Float4));
            Float2.AddMembers(CreateVectorTypeFields(2, Float2, Float, Float1, Float2, Float3, Float4));
            Float3.AddMembers(CreateVectorTypeFields(3, Float3, Float, Float1, Float2, Float3, Float4));
            Float4.AddMembers(CreateVectorTypeFields(4, Float4, Float, Float1, Float2, Float3, Float4));
            Double1.AddMembers(CreateVectorTypeFields(1, Double1, Double, Double1, Double2, Double3, Double4));
            Double2.AddMembers(CreateVectorTypeFields(2, Double2, Double, Double1, Double2, Double3, Double4));
            Double3.AddMembers(CreateVectorTypeFields(3, Double3, Double, Double1, Double2, Double3, Double4));
            Double4.AddMembers(CreateVectorTypeFields(4, Double4, Double, Double1, Double2, Double3, Double4));

            // Matrix types.
            Float2x2 = new IntrinsicMatrixTypeSymbol("mat2x2", "Represents a matrix containing 2 columns 2 rows.", ScalarType.Float, 2, 2);
            FloatMat2 = new IntrinsicMatrixTypeSymbol("mat2", "Represents a matrix containing 2 columns 2 rows.", ScalarType.Float, 2, 2);
            Float2x3 = new IntrinsicMatrixTypeSymbol("mat2x3", "Represents a matrix containing 2 columns 3 rows.", ScalarType.Float, 2, 3);
            Float2x4 = new IntrinsicMatrixTypeSymbol("mat2x4", "Represents a matrix containing 2 columns 4 rows.", ScalarType.Float, 2, 4);
            Float3x2 = new IntrinsicMatrixTypeSymbol("mat3x2", "Represents a matrix containing 3 columns 2 rows.", ScalarType.Float, 3, 2);
            Float3x3 = new IntrinsicMatrixTypeSymbol("mat3x3", "Represents a matrix containing 3 columns 3 rows.", ScalarType.Float, 3, 3);
            FloatMat3 = new IntrinsicMatrixTypeSymbol("mat3", "Represents a matrix containing 3 columns 3 rows.", ScalarType.Float, 3, 3);
            Float3x4 = new IntrinsicMatrixTypeSymbol("mat3x4", "Represents a matrix containing 3 columns 4 rows.", ScalarType.Float, 3, 4);
            Float4x2 = new IntrinsicMatrixTypeSymbol("mat4x2", "Represents a matrix containing 4 columns 2 rows.", ScalarType.Float, 4, 2);
            Float4x3 = new IntrinsicMatrixTypeSymbol("mat4x3", "Represents a matrix containing 4 columns 3 rows.", ScalarType.Float, 4, 3);
            Float4x4 = new IntrinsicMatrixTypeSymbol("mat4x4", "Represents a matrix containing 4 columns 4 rows.", ScalarType.Float, 4, 4);
            FloatMat4 = new IntrinsicMatrixTypeSymbol("mat4", "Represents a matrix containing 4 columns 4 rows.", ScalarType.Float, 4, 4);
            DoubleMat2 = new IntrinsicMatrixTypeSymbol("dmat2", "Represents a matrix containing 2 columns 2 rows.", ScalarType.Double, 2, 2);
            Double2x2 = new IntrinsicMatrixTypeSymbol("dmat2x2", "Represents a matrix containing 2 columns 2 rows.", ScalarType.Double, 2, 2);
            Double2x3 = new IntrinsicMatrixTypeSymbol("dmat2x3", "Represents a matrix containing 2 columns 3 rows.", ScalarType.Double, 2, 3);
            Double2x4 = new IntrinsicMatrixTypeSymbol("dmat2x4", "Represents a matrix containing 2 columns 4 rows.", ScalarType.Double, 2, 4);
            Double3x2 = new IntrinsicMatrixTypeSymbol("dmat3x2", "Represents a matrix containing 3 columns 2 rows.", ScalarType.Double, 3, 2);
            DoubleMat3 = new IntrinsicMatrixTypeSymbol("dmat3", "Represents a matrix containing 3 columns 3 rows.", ScalarType.Double, 3, 3);
            Double3x3 = new IntrinsicMatrixTypeSymbol("dmat3x3", "Represents a matrix containing 3 columns 3 rows.", ScalarType.Double, 3, 3);
            Double3x4 = new IntrinsicMatrixTypeSymbol("dmat3x4", "Represents a matrix containing 3 columns 4 rows.", ScalarType.Double, 3, 4);
            Double4x2 = new IntrinsicMatrixTypeSymbol("dmat4x2", "Represents a matrix containing 4 columns 2 rows.", ScalarType.Double, 4, 2);
            Double4x3 = new IntrinsicMatrixTypeSymbol("dmat4x3", "Represents a matrix containing 4 columns 3 rows.", ScalarType.Double, 4, 3);
            DoubleMat4 = new IntrinsicMatrixTypeSymbol("dmat4", "Represents a matrix containing 4 columns 4 rows.", ScalarType.Double, 4, 4);
            Double4x4 = new IntrinsicMatrixTypeSymbol("dmat4x4", "Represents a matrix containing 4 columns 4 rows.", ScalarType.Double, 4, 4);

            FloatMat2.AddMembers(CreateMatrixTypeMembers(Float2x2, Float1, Float2, Float3, Float4));
            Float2x2.AddMembers(CreateMatrixTypeMembers(Float2x2, Float1, Float2, Float3, Float4));
            Float2x3.AddMembers(CreateMatrixTypeMembers(Float2x3, Float1, Float2, Float3, Float4));
            Float2x4.AddMembers(CreateMatrixTypeMembers(Float2x4, Float1, Float2, Float3, Float4));
            Float3x2.AddMembers(CreateMatrixTypeMembers(Float3x2, Float1, Float2, Float3, Float4));
            FloatMat3.AddMembers(CreateMatrixTypeMembers(Float3x3, Float1, Float2, Float3, Float4));
            Float3x3.AddMembers(CreateMatrixTypeMembers(Float3x3, Float1, Float2, Float3, Float4));
            Float3x4.AddMembers(CreateMatrixTypeMembers(Float3x4, Float1, Float2, Float3, Float4));
            Float4x2.AddMembers(CreateMatrixTypeMembers(Float4x2, Float1, Float2, Float3, Float4));
            Float4x3.AddMembers(CreateMatrixTypeMembers(Float4x3, Float1, Float2, Float3, Float4));
            FloatMat4.AddMembers(CreateMatrixTypeMembers(Float4x4, Float1, Float2, Float3, Float4));
            Float4x4.AddMembers(CreateMatrixTypeMembers(Float4x4, Float1, Float2, Float3, Float4));
            DoubleMat2.AddMembers(CreateMatrixTypeMembers(Double2x2, Double1, Double2, Double3, Double4));
            Double2x2.AddMembers(CreateMatrixTypeMembers(Double2x2, Double1, Double2, Double3, Double4));
            Double2x3.AddMembers(CreateMatrixTypeMembers(Double2x3, Double1, Double2, Double3, Double4));
            Double2x4.AddMembers(CreateMatrixTypeMembers(Double2x4, Double1, Double2, Double3, Double4));
            Double3x2.AddMembers(CreateMatrixTypeMembers(Double3x2, Double1, Double2, Double3, Double4));
            DoubleMat3.AddMembers(CreateMatrixTypeMembers(Double3x3, Double1, Double2, Double3, Double4));
            Double3x3.AddMembers(CreateMatrixTypeMembers(Double3x3, Double1, Double2, Double3, Double4));
            Double3x4.AddMembers(CreateMatrixTypeMembers(Double3x4, Double1, Double2, Double3, Double4));
            Double4x2.AddMembers(CreateMatrixTypeMembers(Double4x2, Double1, Double2, Double3, Double4));
            Double4x3.AddMembers(CreateMatrixTypeMembers(Double4x3, Double1, Double2, Double3, Double4));
            DoubleMat4.AddMembers(CreateMatrixTypeMembers(Double4x4, Double1, Double2, Double3, Double4));
            Double4x4.AddMembers(CreateMatrixTypeMembers(Double4x4, Double1, Double2, Double3, Double4));

            AllScalarTypes = new[]
            {
                Bool,
                Uint,
                Int,
                Float,
                Double
            };

            AllBoolVectorTypes = new[]
            {
                Bool1,
                Bool2,
                Bool3,
                Bool4
            };

            AllIntVectorTypes = new[]
            {
                Int1,
                Int2,
                Int3,
                Int4
            };

            AllUintVectorTypes = new[]
            {
                Uint1,
                Uint2,
                Uint3,
                Uint4
            };

            AllFloatVectorTypes = new[]
            {
                Float1,
                Float2,
                Float3,
                Float4
            };

            AllDoubleVectorTypes = new[]
            {
                Double1,
                Double2,
                Double3,
                Double4
            };

            AllFloatDoubleVectorTypes = new[]
            {
                Float1,
                Float2,
                Float3,
                Float4,
                Double1,
                Double2,
                Double3,
                Double4
            };

            AllVectorTypes = AllBoolVectorTypes
                .Union(AllIntVectorTypes)
                .Union(AllUintVectorTypes)
                .Union(AllFloatVectorTypes)
                .Union(AllDoubleVectorTypes)
                .ToArray();

            AllFloatMatrixTypes = new[]
            {
                FloatMat2,
                Float2x2,
                Float2x3,
                Float2x4,
                FloatMat3,
                Float3x2,
                Float3x3,
                Float3x4,
                FloatMat4,
                Float4x2,
                Float4x3,
                Float4x4
            };

            AllFloatSquareMatrixTypes = new[]
            {
                Float2x2,
                Float3x3,
                Float4x4,
                FloatMat2,
                FloatMat3,
                FloatMat4
            };

            AllDoubleMatrixTypes = new[]
            {
                DoubleMat2,
                Double2x2,
                Double2x3,
                Double2x4,
                DoubleMat3,
                Double3x2,
                Double3x3,
                Double3x4,
                DoubleMat4,
                Double4x2,
                Double4x3,
                Double4x4
            };

            AllDoubleSquareMatrixTypes = new[]
            {
                Double2x2,
                Double3x3,
                Double4x4,
                DoubleMat2,
                DoubleMat3,
                DoubleMat4
            };

            AllMatrixTypes = AllFloatMatrixTypes
                .Union(AllDoubleMatrixTypes)
                .ToArray();

            AllBoolTypes = new IntrinsicNumericTypeSymbol[] { Bool }
                .Union(AllBoolVectorTypes)
                .ToArray();

            AllIntTypes = new IntrinsicNumericTypeSymbol[] { Int }
                .Union(AllIntVectorTypes)
                .ToArray();

            AllUintTypes = new IntrinsicNumericTypeSymbol[] { Uint }
                .Union(AllUintVectorTypes)
                .ToArray();

            AllFloatTypes = new IntrinsicNumericTypeSymbol[] { Float }
                .Union(AllFloatVectorTypes)
                .Union(AllFloatMatrixTypes)
                .ToArray();

            AllDoubleTypes = new IntrinsicNumericTypeSymbol[] { Double }
                .Union(AllDoubleVectorTypes)
                .Union(AllDoubleMatrixTypes)
                .ToArray();

            AllIntegralTypes = AllBoolTypes
                .Union(AllIntTypes)
                .Union(AllUintTypes)
                .ToArray();

            AllNumericNonBoolTypes = AllIntTypes
                .Union(AllUintTypes)
                .Union(AllFloatTypes)
                .Union(AllDoubleTypes)
                .ToArray();

            AllNumericTypes = AllScalarTypes
                .Cast<IntrinsicNumericTypeSymbol>()
                .Union(AllVectorTypes)
                .Union(AllMatrixTypes)
                .ToArray();


            texture1D = new IntrinsicObjectTypeSymbol("texture1D", "", PredefinedObjectType.texture1D);
            itexture1D = new IntrinsicObjectTypeSymbol("itexture1D", "", PredefinedObjectType.itexture1D);
            utexture1D = new IntrinsicObjectTypeSymbol("utexture1D", "", PredefinedObjectType.utexture1D);
            image1D = new IntrinsicObjectTypeSymbol("image1D", "", PredefinedObjectType.image1D);
            iimage1D = new IntrinsicObjectTypeSymbol("iimage1D", "", PredefinedObjectType.iimage1D);
            uimage1D = new IntrinsicObjectTypeSymbol("uimage1D", "", PredefinedObjectType.uimage1D);
            texture1DArray = new IntrinsicObjectTypeSymbol("texture1DArray", "", PredefinedObjectType.texture1DArray);
            itexture1DArray = new IntrinsicObjectTypeSymbol("itexture1DArray", "", PredefinedObjectType.itexture1DArray);
            utexture1DArray = new IntrinsicObjectTypeSymbol("utexture1DArray", "", PredefinedObjectType.utexture1DArray);
            image1DArray = new IntrinsicObjectTypeSymbol("image1DArray", "", PredefinedObjectType.image1DArray);
            iimage1DArray = new IntrinsicObjectTypeSymbol("iimage1DArray", "", PredefinedObjectType.iimage1DArray);
            uimage1DArray = new IntrinsicObjectTypeSymbol("uimage1DArray", "", PredefinedObjectType.uimage1DArray);
            texture2D = new IntrinsicObjectTypeSymbol("texture2D", "", PredefinedObjectType.texture2D);
            itexture2D = new IntrinsicObjectTypeSymbol("itexture2D", "", PredefinedObjectType.itexture2D);
            utexture2D = new IntrinsicObjectTypeSymbol("utexture2D", "", PredefinedObjectType.utexture2D);
            image2D = new IntrinsicObjectTypeSymbol("image2D", "", PredefinedObjectType.image2D);
            iimage2D = new IntrinsicObjectTypeSymbol("iimage2D", "", PredefinedObjectType.iimage2D);
            uimage2D = new IntrinsicObjectTypeSymbol("uimage2D", "", PredefinedObjectType.uimage2D);
            image2DRect = new IntrinsicObjectTypeSymbol("image2DRect", "", PredefinedObjectType.image2DRect);
            iimage2DRect = new IntrinsicObjectTypeSymbol("iimage2DRect", "", PredefinedObjectType.iimage2DRect);
            uimage2DRect = new IntrinsicObjectTypeSymbol("uimage2DRect", "", PredefinedObjectType.uimage2DRect);
            subpassInput = new IntrinsicObjectTypeSymbol("subpassInput", "", PredefinedObjectType.subpassInput);
            subpassInputMS = new IntrinsicObjectTypeSymbol("subpassInputMS", "", PredefinedObjectType.subpassInputMS);
            isubpassInput = new IntrinsicObjectTypeSymbol("isubpassInput", "", PredefinedObjectType.isubpassInput);
            isubpassInputMS = new IntrinsicObjectTypeSymbol("isubpassInputMS", "", PredefinedObjectType.isubpassInputMS);
            usubpassInput = new IntrinsicObjectTypeSymbol("usubpassInput", "", PredefinedObjectType.usubpassInput);
            usubpassInputMS = new IntrinsicObjectTypeSymbol("usubpassInputMS", "", PredefinedObjectType.usubpassInputMS);
            texture2DArray = new IntrinsicObjectTypeSymbol("texture2DArray", "", PredefinedObjectType.texture2DArray);
            itexture2DArray = new IntrinsicObjectTypeSymbol("itexture2DArray", "", PredefinedObjectType.itexture2DArray);
            utexture2DArray = new IntrinsicObjectTypeSymbol("utexture2DArray", "", PredefinedObjectType.utexture2DArray);
            image2DArray = new IntrinsicObjectTypeSymbol("image2DArray", "", PredefinedObjectType.image2DArray);
            iimage2DArray = new IntrinsicObjectTypeSymbol("iimage2DArray", "", PredefinedObjectType.iimage2DArray);
            uimage2DArray = new IntrinsicObjectTypeSymbol("uimage2DArray", "", PredefinedObjectType.uimage2DArray);
            texture2DMS = new IntrinsicObjectTypeSymbol("texture2DMS", "", PredefinedObjectType.texture2DMS);
            itexture2DMS = new IntrinsicObjectTypeSymbol("itexture2DMS", "", PredefinedObjectType.itexture2DMS);
            utexture2DMS = new IntrinsicObjectTypeSymbol("utexture2DMS", "", PredefinedObjectType.utexture2DMS);
            image2DMS = new IntrinsicObjectTypeSymbol("image2DMS", "", PredefinedObjectType.image2DMS);
            iimage2DMS = new IntrinsicObjectTypeSymbol("iimage2DMS", "", PredefinedObjectType.iimage2DMS);
            uimage2DMS = new IntrinsicObjectTypeSymbol("uimage2DMS", "", PredefinedObjectType.uimage2DMS);
            texture2DMSArray = new IntrinsicObjectTypeSymbol("texture2DMSArray", "", PredefinedObjectType.texture2DMSArray);
            itexture2DMSArray = new IntrinsicObjectTypeSymbol("itexture2DMSArray", "", PredefinedObjectType.itexture2DMSArray);
            utexture2DMSArray = new IntrinsicObjectTypeSymbol("utexture2DMSArray", "", PredefinedObjectType.utexture2DMSArray);
            image2DMSArray = new IntrinsicObjectTypeSymbol("image2DMSArray", "", PredefinedObjectType.image2DMSArray);
            iimage2DMSArray = new IntrinsicObjectTypeSymbol("iimage2DMSArray", "", PredefinedObjectType.iimage2DMSArray);
            uimage2DMSArray = new IntrinsicObjectTypeSymbol("uimage2DMSArray", "", PredefinedObjectType.uimage2DMSArray);
            texture3D = new IntrinsicObjectTypeSymbol("texture3D", "", PredefinedObjectType.texture3D);
            itexture3D = new IntrinsicObjectTypeSymbol("itexture3D", "", PredefinedObjectType.itexture3D);
            utexture3D = new IntrinsicObjectTypeSymbol("utexture3D", "", PredefinedObjectType.utexture3D);
            image3D = new IntrinsicObjectTypeSymbol("image3D", "", PredefinedObjectType.image3D);
            iimage3D = new IntrinsicObjectTypeSymbol("iimage3D", "", PredefinedObjectType.iimage3D);
            uimage3D = new IntrinsicObjectTypeSymbol("uimage3D", "", PredefinedObjectType.uimage3D);
            textureCube = new IntrinsicObjectTypeSymbol("textureCube", "", PredefinedObjectType.textureCube);
            itextureCube = new IntrinsicObjectTypeSymbol("itextureCube", "", PredefinedObjectType.itextureCube);
            utextureCube = new IntrinsicObjectTypeSymbol("utextureCube", "", PredefinedObjectType.utextureCube);
            imageCube = new IntrinsicObjectTypeSymbol("imageCube", "", PredefinedObjectType.imageCube);
            iimageCube = new IntrinsicObjectTypeSymbol("iimageCube", "", PredefinedObjectType.iimageCube);
            uimageCube = new IntrinsicObjectTypeSymbol("uimageCube", "", PredefinedObjectType.uimageCube);
            textureCubeArray = new IntrinsicObjectTypeSymbol("textureCubeArray", "", PredefinedObjectType.textureCubeArray);
            itextureCubeArray = new IntrinsicObjectTypeSymbol("itextureCubeArray", "", PredefinedObjectType.itextureCubeArray);
            utextureCubeArray = new IntrinsicObjectTypeSymbol("utextureCubeArray", "", PredefinedObjectType.utextureCubeArray);
            imageCubeArray = new IntrinsicObjectTypeSymbol("imageCubeArray", "", PredefinedObjectType.imageCubeArray);
            iimageCubeArray = new IntrinsicObjectTypeSymbol("iimageCubeArray", "", PredefinedObjectType.iimageCubeArray);
            uimageCubeArray = new IntrinsicObjectTypeSymbol("uimageCubeArray", "", PredefinedObjectType.uimageCubeArray);

            sampler = new IntrinsicObjectTypeSymbol("sampler", "", PredefinedObjectType.sampler);
            samplerShadow = new IntrinsicObjectTypeSymbol("samplerShadow", "", PredefinedObjectType.samplerShadow);
            samplerBuffer = new IntrinsicObjectTypeSymbol("samplerBuffer", "", PredefinedObjectType.samplerBuffer);
            isamplerBuffer = new IntrinsicObjectTypeSymbol("isamplerBuffer", "", PredefinedObjectType.isamplerBuffer);
            usamplerBuffer = new IntrinsicObjectTypeSymbol("usamplerBuffer", "", PredefinedObjectType.usamplerBuffer);
            sampler1D = new IntrinsicObjectTypeSymbol("sampler1D", "", PredefinedObjectType.sampler1D);
            sampler1DArray = new IntrinsicObjectTypeSymbol("sampler1DArray", "", PredefinedObjectType.sampler1DArray);
            sampler1DShadow = new IntrinsicObjectTypeSymbol("sampler1DShadow", "", PredefinedObjectType.sampler1DShadow);
            sampler1DArrayShadow = new IntrinsicObjectTypeSymbol("sampler1DArrayShadow", "", PredefinedObjectType.sampler1DArrayShadow);
            isampler1D = new IntrinsicObjectTypeSymbol("isampler1D", "", PredefinedObjectType.isampler1D);
            isampler1DArray = new IntrinsicObjectTypeSymbol("isampler1DArray", "", PredefinedObjectType.isampler1DArray);
            usampler1D = new IntrinsicObjectTypeSymbol("usampler1D", "", PredefinedObjectType.usampler1D);
            usampler1DArray = new IntrinsicObjectTypeSymbol("usampler1DArray", "", PredefinedObjectType.usampler1DArray);
            sampler2D = new IntrinsicObjectTypeSymbol("sampler2D", "", PredefinedObjectType.sampler2D);
            sampler2DArray = new IntrinsicObjectTypeSymbol("sampler2DArray", "", PredefinedObjectType.sampler2DArray);
            sampler2DShadow = new IntrinsicObjectTypeSymbol("sampler2DShadow", "", PredefinedObjectType.sampler2DShadow);
            sampler2DArrayShadow = new IntrinsicObjectTypeSymbol("sampler2DArrayShadow", "", PredefinedObjectType.sampler2DArrayShadow);
            sampler2DRect = new IntrinsicObjectTypeSymbol("sampler2DRect", "", PredefinedObjectType.sampler2DRect);
            sampler2DRectShadow = new IntrinsicObjectTypeSymbol("sampler2DRectShadow", "", PredefinedObjectType.sampler2DRectShadow);
            sampler2DMS = new IntrinsicObjectTypeSymbol("sampler2DMS", "", PredefinedObjectType.sampler2DMS);
            sampler2DMSArray = new IntrinsicObjectTypeSymbol("sampler2DMSArray", "", PredefinedObjectType.sampler2DMSArray);
            isampler2D = new IntrinsicObjectTypeSymbol("isampler2D", "", PredefinedObjectType.isampler2D);
            isampler2DArray = new IntrinsicObjectTypeSymbol("isampler2DArray", "", PredefinedObjectType.isampler2DArray);
            isampler2DRect = new IntrinsicObjectTypeSymbol("isampler2DRect", "", PredefinedObjectType.isampler2DRect);
            isampler2DMS = new IntrinsicObjectTypeSymbol("isampler2DMS", "", PredefinedObjectType.isampler2DMS);
            isampler2DMSArray = new IntrinsicObjectTypeSymbol("isampler2DMSArray", "", PredefinedObjectType.isampler2DMSArray);
            usampler2D = new IntrinsicObjectTypeSymbol("usampler2D", "", PredefinedObjectType.usampler2D);
            usampler2DArray = new IntrinsicObjectTypeSymbol("usampler2DArray", "", PredefinedObjectType.usampler2DArray);
            usampler2DRect = new IntrinsicObjectTypeSymbol("usampler2DRect", "", PredefinedObjectType.usampler2DRect);
            usampler2DMS = new IntrinsicObjectTypeSymbol("usampler2DMS", "", PredefinedObjectType.usampler2DMS);
            usampler2DMSArray = new IntrinsicObjectTypeSymbol("usampler2DMSArray", "", PredefinedObjectType.usampler2DMSArray);
            sampler3D = new IntrinsicObjectTypeSymbol("sampler3D", "", PredefinedObjectType.sampler3D);
            isampler3D = new IntrinsicObjectTypeSymbol("isampler3D", "", PredefinedObjectType.isampler3D);
            usampler3D = new IntrinsicObjectTypeSymbol("usampler3D", "", PredefinedObjectType.usampler3D);
            samplerCube = new IntrinsicObjectTypeSymbol("samplerCube", "", PredefinedObjectType.samplerCube);
            samplerCubeArray = new IntrinsicObjectTypeSymbol("samplerCubeArray", "", PredefinedObjectType.samplerCubeArray);
            samplerCubeShadow = new IntrinsicObjectTypeSymbol("samplerCubeShadow", "", PredefinedObjectType.samplerCubeShadow);
            samplerCubeArrayShadow = new IntrinsicObjectTypeSymbol("samplerCubeArrayShadow", "", PredefinedObjectType.samplerCubeArrayShadow);
            isamplerCube = new IntrinsicObjectTypeSymbol("isamplerCube", "", PredefinedObjectType.isamplerCube);
            isamplerCubeArray = new IntrinsicObjectTypeSymbol("isamplerCubeArray", "", PredefinedObjectType.isamplerCubeArray);
            usamplerCube = new IntrinsicObjectTypeSymbol("usamplerCube", "", PredefinedObjectType.usamplerCube);
            usamplerCubeArray = new IntrinsicObjectTypeSymbol("usamplerCubeArray", "", PredefinedObjectType.usamplerCubeArray);

            buffer = new IntrinsicObjectTypeSymbol("buffer", "", PredefinedObjectType.buffer);

            AllImage1DTypes = new[] { image1D, iimage1D, uimage1D };
            AllImage1DArrayTypes = new[] { image1DArray, iimage1DArray, uimage1DArray };
            AllImage2DTypes = new[] { image2D, iimage2D, uimage2D };
            AllImage2DArrayTypes = new[] { image2DArray, iimage2DArray, uimage2DArray };
            AllImage2DRectTypes = new[] { image2DRect, iimage2DRect, uimage2DRect };
            AllImage2DMSTypes = new[] { image2DMS, iimage2DMS, uimage2DMS };
            AllImage2DMSArrayTypes = new[] { image2DMSArray, iimage2DMSArray, uimage2DMSArray };
            AllImage3DTypes = new[] { image3D, iimage3D, uimage3D };
            AllImageCubeTypes = new[] { imageCube, iimageCube, uimageCube };
            AllImageCubeArrayTypes = new[] { imageCubeArray, iimageCubeArray, uimageCubeArray };

            AllSampler1DTypes = new[] { sampler1D, isampler1D, usampler1D };
            AllSampler1DArrayTypes = new[] { sampler1DArray, isampler1DArray, usampler1DArray };
            AllSampler2DTypes = new[] { sampler2D, isampler2D, usampler2D };
            AllSampler2DArrayTypes = new[] { sampler2DArray, isampler2DArray, usampler2DArray };
            AllSampler2DRectTypes = new[] { sampler2DRect, isampler2DRect, usampler2DRect };
            AllSampler2DMSTypes = new[] { sampler2DMS, isampler2DMS, usampler2DMS };
            AllSampler2DMSArrayTypes = new[] { sampler2DMSArray, isampler2DMSArray, usampler2DMSArray };
            AllSampler3DTypes = new[] { sampler3D, isampler3D, usampler3D };
            AllSamplerCubeTypes = new[] { samplerCube, isamplerCube, usamplerCube };
            AllSamplerCubeArrayTypes = new[] { samplerCubeArray, isamplerCubeArray, usamplerCubeArray };

            AllSamplerWithSize1DTypes = AllSampler1DTypes
                .Union(new[] { sampler1DShadow })
                .ToArray();
            AllSamplerWithSize2DTypes = AllSampler2DTypes
                .Union(AllSampler1DArrayTypes)
                .Union(AllSampler2DRectTypes)
                .Union(AllSampler2DMSTypes)
                .Union(AllSamplerCubeTypes)
                .Union(new[] { sampler2DShadow, sampler1DArrayShadow })
                .ToArray();
            AllSamplerWithSize3DTypes = AllSampler3DTypes
                .Union(AllSampler2DArrayTypes)
                .Union(AllSampler2DMSArrayTypes)
                .Union(AllSamplerCubeArrayTypes)
                .Union(new[] { sampler2DArrayShadow })
                .ToArray();

            AllSamplerTypes = AllSamplerWithSize1DTypes.Union(AllSamplerWithSize2DTypes).Union(AllSamplerWithSize3DTypes).ToArray();

            AllTexture1DTypes = new[] { texture1D, itexture1D, utexture1D };
            AllTexture1DArrayTypes = new[] { texture1DArray, itexture1DArray, utexture1DArray };
            AllTexture2DTypes = new[] { texture2D, itexture2D, utexture2D };
            AllTexture2DArrayTypes = new[] { texture2DArray, itexture2DArray, utexture2DArray };
            AllTexture2DMSTypes = new[] { texture2DMS, itexture2DMS, utexture2DMS };
            AllTexture2DMSArrayTypes = new[] { texture2DMSArray, itexture2DMSArray, utexture2DMSArray };
            AllTexture3DTypes = new[] { texture3D, itexture3D, utexture3D };
            AllTextureCubeTypes = new[] { textureCube, itextureCube, utextureCube };
            AllTextureCubeArrayTypes = new[] { textureCubeArray, itextureCubeArray, utextureCubeArray };

            AllTypes = AllNumericTypes
                .Cast<TypeSymbol>()
                .Union(new[] { texture1D, itexture1D, utexture1D, image1D, iimage1D, uimage1D, texture1DArray, itexture1DArray, utexture1DArray, image1DArray, iimage1DArray, uimage1DArray, texture2D, itexture2D, utexture2D, image2D, iimage2D, uimage2D, image2DRect, iimage2DRect, uimage2DRect, subpassInput, subpassInputMS, isubpassInput, isubpassInputMS, usubpassInput, usubpassInputMS, texture2DArray, itexture2DArray, utexture2DArray, image2DArray, iimage2DArray, uimage2DArray, texture2DMS, itexture2DMS, utexture2DMS, image2DMS, iimage2DMS, uimage2DMS, texture2DMSArray, itexture2DMSArray, utexture2DMSArray, image2DMSArray, iimage2DMSArray, uimage2DMSArray, texture3D, itexture3D, utexture3D, image3D, iimage3D, uimage3D, textureCube, itextureCube, utextureCube, imageCube, iimageCube, uimageCube, textureCubeArray, itextureCubeArray, utextureCubeArray, imageCubeArray, iimageCubeArray })
                .Union(new[] { sampler, samplerShadow, samplerBuffer, isamplerBuffer, usamplerBuffer, sampler1D, sampler1DArray, sampler1DShadow, sampler1DArrayShadow, isampler1D, isampler1DArray, usampler1D, usampler1DArray, sampler2D, sampler2DArray, sampler2DShadow, sampler2DArrayShadow, sampler2DRect, sampler2DRectShadow, sampler2DMS, sampler2DMSArray, isampler2D, isampler2DArray, isampler2DRect, isampler2DMS, isampler2DMSArray, usampler2D, usampler2DArray, usampler2DRect, usampler2DMS, usampler2DMSArray, sampler3D, isampler3D, usampler3D, samplerCube, samplerCubeArray, samplerCubeShadow, samplerCubeArrayShadow, isamplerCube, isamplerCubeArray, usamplerCube, usamplerCubeArray })
                .Union(new[] { buffer })
                .ToArray();
        }

        private static IEnumerable<Symbol> CreateScalarTypeFields(int numComponents,
            IntrinsicNumericTypeSymbol parentType,
            IntrinsicVectorTypeSymbol v1,
            IntrinsicVectorTypeSymbol v2,
            IntrinsicVectorTypeSymbol v3,
            IntrinsicVectorTypeSymbol v4)
        {
            var componentNameSets = new[] { "xyzw", "rgba" }.Select(x => x.Substring(0, numComponents).ToCharArray()).ToList();
            var vectorTypes = new[] { v1, v2, v3, v4 };

            foreach (var componentNameSet in componentNameSets)
                for (var i = 0; i < 4; i++)
                    foreach (var namePermutation in GetVectorComponentNamePermutations(componentNameSet, i + 1))
                        yield return new FieldSymbol(namePermutation, "", parentType, vectorTypes[i]);
        }

        private static IEnumerable<Symbol> CreateVectorTypeFields(
            int numComponents, IntrinsicVectorTypeSymbol vectorType, IntrinsicScalarTypeSymbol scalarType,
            IntrinsicVectorTypeSymbol v1,
            IntrinsicVectorTypeSymbol v2,
            IntrinsicVectorTypeSymbol v3,
            IntrinsicVectorTypeSymbol v4)
        {
            foreach (var field in CreateScalarTypeFields(numComponents, vectorType, v1, v2, v3, v4))
                yield return field;

            yield return new IndexerSymbol("[]", "", vectorType, Uint, scalarType);
        }

        private static IEnumerable<string> GetVectorComponentNamePermutations(char[] components, int num)
        {
            // for example:

            // components = ['x'], num = 1
            // => return ['x']

            // components = ['x'], num = 4
            // => return ['xxxx']

            // components = ['x', 'y'], num = 1
            // => return ['x', 'y']

            // components = ['x', 'y'], num = 2
            // => return ['xx', 'xy', 'yx', 'yy']

            // Yes, I probably should use some kind of clever code to generate the possible combinations.
            switch (num)
            {
                case 1:
                    return from a in components
                           select string.Concat(a);
                case 2:
                    return from a in components
                           from b in components
                           select string.Concat(a, b);
                case 3:
                    return from a in components
                           from b in components
                           from c in components
                           select string.Concat(a, b, c);
                case 4:
                    return from a in components
                           from b in components
                           from c in components
                           from d in components
                           select string.Concat(a, b, c, d);
                default:
                    throw new ArgumentOutOfRangeException("num");
            }
        }

        private static IEnumerable<Symbol> CreateMatrixTypeMembers(IntrinsicMatrixTypeSymbol matrixType,
            IntrinsicVectorTypeSymbol v1,
            IntrinsicVectorTypeSymbol v2,
            IntrinsicVectorTypeSymbol v3,
            IntrinsicVectorTypeSymbol v4)
        {
            var componentNameSets = new[]
            {
                new[,]
                {
                    { "_m00", "_m01", "_m02", "_m03" },
                    { "_m10", "_m11", "_m12", "_m13" },
                    { "_m20", "_m21", "_m22", "_m23" },
                    { "_m30", "_m31", "_m32", "_m33" }
                },
                new[,]
                {
                    { "_11", "_12", "_13", "_14" },
                    { "_21", "_22", "_23", "_24" },
                    { "_31", "_32", "_33", "_34" },
                    { "_41", "_42", "_43", "_44" }
                }
            }.Select(x => Slice(x, 0, matrixType.Rows - 1, 0, matrixType.Cols - 1)).Select(x => x.Cast<string>().ToArray()).ToList();

            var vectorTypes = new[] { v1, v2, v3, v4 };

            foreach (var componentNameSet in componentNameSets)
                for (var i = 0; i < 4; i++)
                    foreach (var namePermutation in GetMatrixComponentNamePermutations(componentNameSet, i + 1))
                        yield return new FieldSymbol(namePermutation, "", matrixType, vectorTypes[i]);

            yield return new IndexerSymbol("[]", "", matrixType, Uint, vectorTypes[matrixType.Cols - 1]);
        }

        private static T[,] Slice<T>(T[,] source, int fromIdxRank0, int toIdxRank0, int fromIdxRank1, int toIdxRank1)
        {
            T[,] ret = new T[toIdxRank0 - fromIdxRank0 + 1, toIdxRank1 - fromIdxRank1 + 1];

            for (int srcIdxRank0 = fromIdxRank0, dstIdxRank0 = 0; srcIdxRank0 <= toIdxRank0; srcIdxRank0++, dstIdxRank0++)
            {
                for (int srcIdxRank1 = fromIdxRank1, dstIdxRank1 = 0; srcIdxRank1 <= toIdxRank1; srcIdxRank1++, dstIdxRank1++)
                {
                    ret[dstIdxRank0, dstIdxRank1] = source[srcIdxRank0, srcIdxRank1];
                }
            }
            return ret;
        }

        private static IEnumerable<string> GetMatrixComponentNamePermutations(string[] components, int num)
        {
            // for example:

            // components = ["_11"], num = 1
            // => return ['x']

            // components = ["_11], num = 4
            // => return ["_11_11_11_11"]

            // components = ["_11", "_12"], num = 1
            // => return ["_11", "_12"]

            // components = ["_11", "_12"], num = 2
            // => return ["_11_11", "_11_12", "_12_11", "_12_12"]

            // components = ["_11", "_12", "_13, "_21", "_22", "_23", "_31", "_32", "_33"], num = 2
            // => return ["_11_11", "_11_12", "_11_13", "_11_21", ...]

            // Yes, I probably should use some kind of clever code to generate the possible combinations.
            switch (num)
            {
                case 1:
                    return from a in components
                           select string.Concat(a);
                case 2:
                    return from a in components
                           from b in components
                           select string.Concat(a, b);
                case 3:
                    return from a in components
                           from b in components
                           from c in components
                           select string.Concat(a, b, c);
                case 4:
                    return from a in components
                           from b in components
                           from c in components
                           from d in components
                           select string.Concat(a, b, c, d);
                default:
                    throw new ArgumentOutOfRangeException(nameof(num));
            }
        }

        public static IntrinsicScalarTypeSymbol GetScalarType(ScalarType scalarType)
        {
            return AllScalarTypes[(int)scalarType - 1];
        }

        public static IntrinsicVectorTypeSymbol GetVectorType(ScalarType scalarType, int numComponents)
        {
            return AllVectorTypes[(((int)scalarType - 1) * 4) + (numComponents - 1)];
        }

        public static IntrinsicMatrixTypeSymbol GetMatrixType(ScalarType scalarType, int numRows, int numCols)
        {
            return AllMatrixTypes[(((int)scalarType - 1) * 16) + ((numRows - 1) * 4) + (numCols - 1)];
        }


        private static IntrinsicObjectTypeSymbol CreatePredefinedObjectType(string name, string documentation, PredefinedObjectType predefinedObjectType, Func<TypeSymbol, IEnumerable<Symbol>> membersCallback)
        {
            var result = new IntrinsicObjectTypeSymbol(name, documentation, predefinedObjectType);
            result.AddMembers(membersCallback(result));
            return result;
        }
    }
}