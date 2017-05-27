using System.Collections.Generic;
using System.Linq;

namespace ShaderTools.CodeAnalysis.Hlsl.Symbols
{
    internal static partial class IntrinsicFunctions
    {
        public static readonly IEnumerable<FunctionSymbol> AllFunctions;

        static IntrinsicFunctions()
        {
            var allFunctions = new List<FunctionSymbol>();




            // GLSL functions

            allFunctions.AddRange(Create1(
                "abs",
                "abs returns the absolute value of x.",
                IntrinsicTypes.AllVectorTypes,
                "x", "Specify the value of which to return the absolute."));
            
            allFunctions.AddRange(Create1(
                "acos",
                "acos returns the angle whose trigonometric cosine is x. The range of values returned by acos is [0,π]. The result is undefined if |x|>1",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose arccosine to return."));

            allFunctions.AddRange(Create1(
                "acosh",
                "acosh returns the arc hyperbolic cosine of x; the non-negative inverse of cosh. The result is undefined if x<1",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose arc hyperbolic cosine to return."));

            allFunctions.AddRange(Create1(
                "all",
                "all returns true if all elements of x are true and false otherwise",
                IntrinsicTypes.AllBoolVectorTypes,
                "x", "Specifies the vector to be tested for truth.",
                IntrinsicTypes.Bool));

            allFunctions.AddRange(Create1(
                "any",
                "any returns true if any element of x is true and false otherwise",
                IntrinsicTypes.AllBoolVectorTypes,
                "x", "Specifies the vector to be tested for truth.",
                IntrinsicTypes.Bool));

            allFunctions.AddRange(Create1(
                "asin",
                "asin returns the angle whose trigonometric sine is x. The range of values returned by asin is [−π2,π2]. The result is undefined if |x|>1",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose arcsine to return."));

            allFunctions.AddRange(Create1(
                "asinh",
                "asinh returns the arc hyperbolic sine of x; the inverse of sinh",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose arc hyperbolic sine to return."));

            allFunctions.AddRange(Create1(
                "atan",
                "atan returns the angle whose trigonometric arctangent is y_over_x. atan returns the angle whose tangent is y_over_x. The value returned in this case is in the range [−π2,π2].",
                IntrinsicTypes.AllFloatVectorTypes,
                "y_over_x", "Specify the fraction whose arctangent to return."));
            allFunctions.AddRange(Create2(
                "atan",
                "atan returns the angle whose trigonometric arctangent is y/x. The signs of y and x are used to determine the quadrant that the angle lies in. The value returned by atan in this case is in the range [−π,π]. The result is undefined if x=0.",
                IntrinsicTypes.AllFloatVectorTypes,
                "y", "Specify the numerator of the fraction whose arctangent to return.",
                "x", "Specify the denominator  of the fraction whose arctangent to return."));

            allFunctions.AddRange(Create1(
                "atanh",
                "atanh returns the arc hyperbolic tangent of x; the inverse of tanh. The result is undefined if |x|>1.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose arc hyperbolic tangent to return"));

            allFunctions.AddRange(Create2(
                "atomicAdd",
                "atomicAdd performs an atomic addition of data to the contents of mem and returns the original contents of mem from before the addition occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be added to mem."));

            allFunctions.AddRange(Create2(
                "atomicAnd",
                "atomicAnd performs an atomic logical AND with data to the contents of mem and returns the original contents of mem from before the logical operation occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written.\n Atomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be logically ANDed with to mem."));

            allFunctions.Add(new FunctionSymbol(
                "atomicCompSwap",
                "atomicCompSwap performs an atomic comparison of compare with the contents of mem. If the content of mem is equal to compare, then the content of data is written into mem, otherwise the content of mem is unmodifed. The function returns the original content of mem regardless of the outcome of the comparison. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                null, IntrinsicTypes.Int1,
                f => new[]
                {
                    new ParameterSymbol("mem", "The variable to use as the target of the operation.", f, IntrinsicTypes.Int1),
                    new ParameterSymbol("compare", "The data to be compared to.", f, IntrinsicTypes.Uint1),
                    new ParameterSymbol("data", "The data to be potentially exchanged with mem.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "atomicCompSwap",
                "atomicCompSwap performs an atomic comparison of compare with the contents of mem. If the content of mem is equal to compare, then the content of data is written into mem, otherwise the content of mem is unmodifed. The function returns the original content of mem regardless of the outcome of the comparison. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                null, IntrinsicTypes.Uint1,
                f => new[]
                {
                    new ParameterSymbol("mem", "The variable to use as the target of the operation.", f, IntrinsicTypes.Uint1),
                    new ParameterSymbol("compare", "The data to be compared to.", f, IntrinsicTypes.Uint1),
                    new ParameterSymbol("data", "The data to be potentially exchanged with mem.", f, IntrinsicTypes.Uint1)
                }));

            allFunctions.AddRange(Create2(
                "atomicExchange",
                "atomicExchange performs an atomic exhange of data with the contents of mem. The content of data is written into mem and the original contents of mem are returned. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be exchanged with mem."));

            allFunctions.AddRange(Create2(
                "atomicMax",
                "atomicMax performs an atomic comparison of data to the contents of mem, writes the maximum value into mem and returns the original contents of mem from before the comparison occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be compared to mem."));

            allFunctions.AddRange(Create2(
                "atomicMin",
                "atomicMin performs an atomic comparison of data to the contents of mem, writes the minimum value into mem and returns the original contents of mem from before the comparison occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be compared to mem."));

            allFunctions.AddRange(Create2(
                "atomicOr",
                "atomicOr performs an atomic logical OR with data to the contents of mem and returns the original contents of mem from before the logical operation occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be logically ORed with to mem."));

            allFunctions.AddRange(Create2(
                "atomicXor",
                "atomicXor performs an atomic logical exclusive OR with data to the contents of mem and returns the original contents of mem from before the logical operation occured. The contents of the memory being updated by the atomic operation are guaranteed not to be modified by any other assignment or atomic memory function in any shader invocation between the time the original value is read and the time the new value is written. \nAtomic memory functions are supported only for a limited set of variables.A shader will fail to compile if the value passed to the mem argument of an atomic memory function does not correspond to a buffer or shared variable. It is acceptable to pass an element of an array or a single component of a vector to the mem argument of an atomic memory function, as long as the underlying array or vector is a buffer or shared variable.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Uint1 },
                "mem", "(inout) The variable to use as the target of the operation.",
                "data", "The data to be logically exclusive ORed with to mem."));

            allFunctions.Add(new FunctionSymbol(
                "barrier",
                "Available only in the Tessellation Control and Compute Shaders, barrier provides a partially defined order of execution between shader invocations. For any given static instance of barrier, in a tessellation control shader, all invocations for a single input patch must enter it before any will be allowed to continue beyond it. For any given static instance of barrier in a compute shader, all invocations within a single work group must enter it before any are allowed to continue beyond it. This ensures that values written by one invocation prior to a given static instance of barrier can be safely read by other invocations after their call to the same static instance of barrier. Because invocations may execute in undefined order between these barrier calls, the values of a per-vertex or per-patch output variable, or any shared variable will be undefined in a number of cases. \nbarrier may only be placed inside the function main() of the tessellation control shader, but may be placed anywhere in a compute shader.Calls to barrier may not be placed within any control flow.Barriers are also disallowed after a return statement in the function main().",
                null, IntrinsicTypes.Void));

            allFunctions.AddRange(Create1(
                "bitCount",
                "bitCount returns the number of bits that are set to 1 in the binary representation of value.",
                IntrinsicTypes.AllIntVectorTypes,
                "value", "Specifies the value whose bits to count"));
            allFunctions.AddRange(Create1(
                "bitCount",
                "bitCount returns the number of bits that are set to 1 in the binary representation of value.",
                IntrinsicTypes.AllUintVectorTypes,
                "value", "Specifies the value whose bits to count",
                IntrinsicTypes.AllIntVectorTypes));

            allFunctions.AddRange(Create3pack(
                "bitfieldExtract",
                "bitfieldExtract extracts a subset of the bits of value and returns it in the least significant bits of the result. The range of bits extracted is [offset, offset + bits - 1]. \nFor unsigned data types, the most significant bits of the result will be set to zero.For signed data types, the most significant bits will be set to the value of bit offset + base - 1 (i.e., it is sign extended to the width of the return type). \nIf bits is zero, the result will be zero.The result will be undefined if offset or bits is negative, or if the sum of offset and bits is greater than the number of bits used to store the operand.",
                IntrinsicTypes.AllIntVectorTypes,
                "value", "Specifies the integer from which to extract bits",
                "offset", "Specifies the index of the first bit to extract",
                "bits", "Specifies the number of bits to extract"));
            allFunctions.AddRange(Create3pack(
                "bitfieldExtract",
                "bitfieldExtract extracts a subset of the bits of value and returns it in the least significant bits of the result. The range of bits extracted is [offset, offset + bits - 1]. \nFor unsigned data types, the most significant bits of the result will be set to zero.For signed data types, the most significant bits will be set to the value of bit offset + base - 1 (i.e., it is sign extended to the width of the return type). \nIf bits is zero, the result will be zero.The result will be undefined if offset or bits is negative, or if the sum of offset and bits is greater than the number of bits used to store the operand.",
                IntrinsicTypes.AllUintVectorTypes,
                "value", "Specifies the integer from which to extract bits",
                "offset", "Specifies the index of the first bit to extract",
                "bits", "Specifies the number of bits to extract"));

            allFunctions.AddRange(Create4(
                "bitfieldInsert",
                "bitfieldInsert inserts the bits least significant bits of insert into base at offset offset. The returned value will have bits [offset, offset + bits + 1] taken from [0, bits - 1] of insert and all other bits taken directly from the corresponding bits of base. If bits is zero, the result will simply be the original value of base. The result will be undefined if offset or bits is negative, or if the sum of offset and bits is greater than the number of bits used to store the operand.",
                IntrinsicTypes.AllIntVectorTypes,
                "base", "Specifies the integer into which to insert 'insert'",
                "insert", "Specifies the the value of the bits to insert",
                "offset", "Specifies the index of the first bit to extract",
                "bits", "Specifies the number of bits to extract"));
            allFunctions.AddRange(Create4(
                "bitfieldInsert",
                "bitfieldInsert inserts the bits least significant bits of insert into base at offset offset. The returned value will have bits [offset, offset + bits + 1] taken from [0, bits - 1] of insert and all other bits taken directly from the corresponding bits of base. If bits is zero, the result will simply be the original value of base. The result will be undefined if offset or bits is negative, or if the sum of offset and bits is greater than the number of bits used to store the operand.",
                IntrinsicTypes.AllUintVectorTypes,
                "base", "Specifies the integer into which to insert 'insert'",
                "insert", "Specifies the the value of the bits to insert",
                "offset", "Specifies the index of the first bit to extract",
                "bits", "Specifies the number of bits to extract"));

            allFunctions.AddRange(Create1(
                "bitfieldReverse",
                "bitfieldReverse returns the reversal of the bits of value. The bit numbered n will be taken from bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.",
                IntrinsicTypes.AllIntVectorTypes,
                "value", "Specifies the value whose bits to reverse"));
            allFunctions.AddRange(Create1(
                "bitfieldReverse",
                "bitfieldReverse returns the reversal of the bits of value. The bit numbered n will be taken from bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.",
                IntrinsicTypes.AllUintVectorTypes,
                "value", "Specifies the value whose bits to reverse",
                IntrinsicTypes.AllIntVectorTypes));

            allFunctions.AddRange(Create1(
                "ceil",
                "ceil returns a value equal to the nearest integer that is greater than or equal to x.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create3pack(
                "clamp",
                "clamp returns the value of x constrained to the range minVal to maxVal. The returned value is computed as min(max(x, minVal), maxVal).",
                IntrinsicTypes.AllVectorTypes,
                "x", "Specify the value to constrain.",
                "minVal", "Specify the lower end of the range into which to constrain x.",
                "maxVal", "Specify the upper end of the range into which to constrain x."));
            allFunctions.AddRange(Create3pack(
                "clamp",
                "clamp returns the value of x constrained to the range minVal to maxVal. The returned value is computed as min(max(x, minVal), maxVal).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value to constrain.",
                "minVal", "Specify the lower end of the range into which to constrain x.",
                "maxVal", "Specify the upper end of the range into which to constrain x.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1 },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create3pack(
                "clamp",
                "clamp returns the value of x constrained to the range minVal to maxVal. The returned value is computed as min(max(x, minVal), maxVal).",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the value to constrain.",
                "minVal", "Specify the lower end of the range into which to constrain x.",
                "maxVal", "Specify the upper end of the range into which to constrain x.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1 },
                overrideParameterTypes3: new[] { IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1 }));
            allFunctions.AddRange(Create3pack(
                "clamp",
                "clamp returns the value of x constrained to the range minVal to maxVal. The returned value is computed as min(max(x, minVal), maxVal).",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specify the value to constrain.",
                "minVal", "Specify the lower end of the range into which to constrain x.",
                "maxVal", "Specify the upper end of the range into which to constrain x.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 },
                overrideParameterTypes3: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create3pack(
                "clamp",
                "clamp returns the value of x constrained to the range minVal to maxVal. The returned value is computed as min(max(x, minVal), maxVal).",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specify the value to constrain.",
                "minVal", "Specify the lower end of the range into which to constrain x.",
                "maxVal", "Specify the upper end of the range into which to constrain x.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterTypes3: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 }));

            allFunctions.AddRange(Create1(
                "cos",
                "cos returns the trigonometric cosine of angle.",
                IntrinsicTypes.AllFloatVectorTypes,
                "angle", "Specify the quantity, in radians, of which to return the cosine."));

            allFunctions.AddRange(Create1(
                "cosh",
                "cosh returns the hyperbolic cosine of x. The hyperbolic cosine of x is computed as 0.5*(e^x+e^(−x)).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose hyperbolic cosine to return."));

            allFunctions.AddRange(Create2(
                "cross",
                "cross returns the cross product of two vectors.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specifies the first of two vectors.",
                "y", "Specifies the second of two vectors."));

            allFunctions.AddRange(Create1(
                "degrees",
                "degrees converts a quantity specified in radians into degrees. The return value is 180×radians/π.",
                IntrinsicTypes.AllFloatVectorTypes,
                "radians", "Specify the quantity, in radians, to be converted to degrees."));

            allFunctions.AddRange(Create1(
                "determinant",
                "determinant returns the determinant of the matrix m.",
                IntrinsicTypes.AllFloatSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the determinant."));
            allFunctions.AddRange(Create1(
                "determinant",
                "determinant returns the determinant of the matrix m.",
                IntrinsicTypes.AllDoubleSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the determinant."));

            allFunctions.AddRange(Create1(
                "dFdx",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "dFdy",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "dFdxCoarse",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "dFdyCoarse",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "dFdxFine",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "dFdyFine",
                "Available only in the fragment shader, these functions return the partial derivative of expression p with respect to the window x coordinate (for dFdx*) and y coordinate (for dFdy*). \ndFdxFine and dFdyFine calculate derivatives using local differencing based on on the value of p for the current fragment and its immediate neighbor(s). \ndFdxCoarse and dFdyCoarse calculate derivatives using local differencing based on the value of p for the current fragment's neighbors, and will possibly, but not necessarily, include the value for the current fragment. That is, over a given area, the implementation can compute derivatives in fewer unique locations than would be allowed for the corresponding dFdxFine and dFdyFine functions. \ndFdx returns either dFdxCoarse or dFdxFine.dFdy returns either dFdyCoarse or dFdyFine.The implementation may choose which calculation to perform based upon factors such as performance or the value of the API GL_FRAGMENT_SHADER_DERIVATIVE_HINT hint. \nExpressions that imply higher order derivatives such as dFdx(dFdx(n)) have undefined results, as do mixed - order derivatives such as dFdx(dFdy(n)).It is assumed that the expression p is continuous and therefore, expressions evaluated via non-uniform control flow may be undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));

            allFunctions.AddRange(Create2(
                "distance",
                "distance returns the distance between the two points p0 and p1. i.e., length(p0 - p1);",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "p0", "Specifies the first of two points.",
                "p1", "Specifies the second of two points."));

            allFunctions.AddRange(Create2(
                "dot",
                "dot returns the dot product of two vectors, x and y. i.e., x[0]⋅y[0]+x[1]⋅y[1]+...",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specifies the first of two vectors.",
                "y", "Specifies the second of two vectors."));

            allFunctions.AddRange(Create2(
                "equal",
                "equal returns a boolean vector in which each element i is computed as x[i] == y[i].",
                new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Float1, IntrinsicTypes.Int1, IntrinsicTypes.Uint1, IntrinsicTypes.Double1 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1 }));
            allFunctions.AddRange(Create2(
                "equal",
                "equal returns a boolean vector in which each element i is computed as x[i] == y[i].",
                new[] { IntrinsicTypes.Bool2, IntrinsicTypes.Float2, IntrinsicTypes.Int2, IntrinsicTypes.Uint2, IntrinsicTypes.Double2 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2 }));
            allFunctions.AddRange(Create2(
                "equal",
                "equal returns a boolean vector in which each element i is computed as x[i] == y[i].",
                new[] { IntrinsicTypes.Bool3, IntrinsicTypes.Float3, IntrinsicTypes.Int3, IntrinsicTypes.Uint3, IntrinsicTypes.Double3 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3 }));
            allFunctions.AddRange(Create2(
                "equal",
                "equal returns a boolean vector in which each element i is computed as x[i] == y[i].",
                new[] { IntrinsicTypes.Bool4, IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4, IntrinsicTypes.Double4 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4 }));

            allFunctions.AddRange(Create1(
                "exp",
                "exp returns the natural exponentiation of x. i.e., e^x.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value to exponentiate."));

            allFunctions.AddRange(Create1(
                "exp2",
                "exp2 returns 2 raised to the power of x. i.e., 2^x.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value of the power to which 2 will be raised."));

            allFunctions.AddRange(Create3pack(
                "faceforward",
                "faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) < 0 faceforward returns N, otherwise it returns -N.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "N", "Specifies the vector to orient.",
                "I", "Specifies the incident vector.",
                "Nref", "Specifies the reference vector."));

            allFunctions.AddRange(Create1(
                "findLSB",
                "findLSB returns the bit number of the least significant bit that is set to 1 in the binary representation of value. If value is zero, -1 will be returned.",
                IntrinsicTypes.AllIntVectorTypes,
                "value", "Specifies the value whose bits to scan."));
            allFunctions.AddRange(Create1(
                "findLSB",
                "findLSB returns the bit number of the least significant bit that is set to 1 in the binary representation of value. If value is zero, -1 will be returned.",
                IntrinsicTypes.AllUintVectorTypes,
                "value", "Specifies the value whose bits to scan.",
                IntrinsicTypes.AllIntVectorTypes));

            allFunctions.AddRange(Create1(
                "findMSB",
                "findMSB returns the bit number of the most significant bit that is set to 1 in the binary representation of value. For positive integers, the result will be the bit number of the most significant bit that is set to 1. For negative integers, the result will be the bit number of the most significant bit set to 0. For a value of zero or negative 1, -1 will be returned.",
                IntrinsicTypes.AllIntVectorTypes,
                "value", "Specifies the value whose bits to scan."));
            allFunctions.AddRange(Create1(
                "findMSB",
                "findMSB returns the bit number of the most significant bit that is set to 1 in the binary representation of value. For positive integers, the result will be the bit number of the most significant bit that is set to 1. For negative integers, the result will be the bit number of the most significant bit set to 0. For a value of zero or negative 1, -1 will be returned.",
                IntrinsicTypes.AllUintVectorTypes,
                "value", "Specifies the value whose bits to scan.",
                IntrinsicTypes.AllIntVectorTypes));

            allFunctions.AddRange(Create1(
                "floatBitsToInt",
                "floatBitsToInt and floatBitsToUint return the encoding of their floating-point parameters as int or uint, respectively. The floating-point bit-level representation is preserved.",
                new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float2, IntrinsicTypes.Float3, IntrinsicTypes.Float4 },
                "x", "Specifies the value whose floating point encoding to return.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int2, IntrinsicTypes.Int3, IntrinsicTypes.Int4 }));
            allFunctions.AddRange(Create1(
                "floatBitsToUint",
                "floatBitsToInt and floatBitsToUint return the encoding of their floating-point parameters as int or uint, respectively. The floating-point bit-level representation is preserved.",
                new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float2, IntrinsicTypes.Float3, IntrinsicTypes.Float4 },
                "x", "Specifies the value whose floating point encoding to return.",
                new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint2, IntrinsicTypes.Uint3, IntrinsicTypes.Uint4 }));

            allFunctions.AddRange(Create1(
                "floor",
                "floor returns a value equal to the nearest integer that is less than or equal to x.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create3pack(
                "fma",
                "fma performs, where possible, a fused multiply-add operation, returning a * b + c. In use cases where the return value is eventually consumed by a variable declared as precise: \nfma() is considered a single operation, whereas the expression a * b + c consumed by a variable declared as precise is considered two operations. \nThe precision of fma() can differ from the precision of the expression a * b + c. \nfma() will be computed with the same precision as any other fma() consumed by a precise variable, giving invariant results for the same input values of a, b and c. \nOtherwise, in the absense of precise consumption, there are no special constraints on the number of operations or difference in precision between fma() and the expression a * b + c.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "a", "Specifies the first multiplicand.",
                "b", "Specifies the second multiplicand.",
                "c", "Specifies the value to be added to the result."));

            allFunctions.AddRange(Create1(
                "fract",
                "fract returns the fractional part of x. This is calculated as x - floor(x).",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create2pack(
                "frexp",
                "frexp extracts x into a floating-point significand in the range [0.5, 1.0) and in integral exponent of two, such that: \nx = significand⋅2^exponent \n\nThe significand is returned by the function and the exponent is returned in the output parameter exp.For a floating - point value of zero, the significand and exponent are both zero.For a floating - point value that is an infinity or a floating - point NaN, the results are undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value from which significand and exponent are to be extracted.",
                "exp", "Specifies the variable into which to place the exponent.",
                overrideParameterTypes2: IntrinsicTypes.AllIntVectorTypes,
                overrideParameterDirection2: ParameterDirection.Out));
            allFunctions.AddRange(Create2pack(
                "frexp",
                "frexp extracts x into a floating-point significand in the range [0.5, 1.0) and in integral exponent of two, such that: \nx = significand⋅2^exponent \n\nThe significand is returned by the function and the exponent is returned in the output parameter exp.For a floating - point value of zero, the significand and exponent are both zero.For a floating - point value that is an infinity or a floating - point NaN, the results are undefined.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specifies the value from which significand and exponent are to be extracted.",
                "exp", "Specifies the variable into which to place the exponent.",
                overrideParameterTypes2: IntrinsicTypes.AllIntVectorTypes,
                overrideParameterDirection2: ParameterDirection.Out));

            allFunctions.AddRange(Create1(
                "fwidth",
                "Available only in the fragment shader, these functions return the sum of the absolute derivatives in x and y using local differencing for the input argument p. fwidth is equivalent to abs(dFdx(p)) + abs(dFdy(p)) . fwidthCoarse is equivalent to abs(dFdxCoarse(p)) + abs(dFdyCoarse(p)) . fwidthFine is equivalent to abs(dFdxFine(p)) + abs(dFdyFine(p)).",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "fwidthCoarse",
                "Available only in the fragment shader, these functions return the sum of the absolute derivatives in x and y using local differencing for the input argument p. fwidth is equivalent to abs(dFdx(p)) + abs(dFdy(p)) . fwidthCoarse is equivalent to abs(dFdxCoarse(p)) + abs(dFdyCoarse(p)) . fwidthFine is equivalent to abs(dFdxFine(p)) + abs(dFdyFine(p)).",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));
            allFunctions.AddRange(Create1(
                "fwidthFine",
                "Available only in the fragment shader, these functions return the sum of the absolute derivatives in x and y using local differencing for the input argument p. fwidth is equivalent to abs(dFdx(p)) + abs(dFdy(p)) . fwidthCoarse is equivalent to abs(dFdxCoarse(p)) + abs(dFdyCoarse(p)) . fwidthFine is equivalent to abs(dFdxFine(p)) + abs(dFdyFine(p)).",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "p", "Specifies the expression of which to take the partial derivative."));

            allFunctions.AddRange(Create2(
                "greaterThan",
                "greaterThan returns a boolean vector in which each element i is computed as x[i] > y[i].",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "greaterThan",
                "greaterThan returns a boolean vector in which each element i is computed as x[i] > y[i].",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "greaterThan",
                "greaterThan returns a boolean vector in which each element i is computed as x[i] > y[i].",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));

            allFunctions.AddRange(Create2(
                "greaterThanEqual",
                "greaterThanEqual returns a boolean vector in which each element i is computed as x[i] ≥ y[i].",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "greaterThanEqual",
                "greaterThanEqual returns a boolean vector in which each element i is computed as x[i] ≥ y[i].",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "greaterThanEqual",
                "greaterThanEqual returns a boolean vector in which each element i is computed as x[i] ≥ y[i].",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));

            allFunctions.Add(new FunctionSymbol(
                "groupMemoryBarrier",
                "groupMemoryBarrier waits on the completion of all memory accesses performed by an invocation of a compute shader relative to the same access performed by other invocations in the same work group and then returns with no other effect.",
                null, IntrinsicTypes.Void));

            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAdd",
                "imageAtomicAdd atomically computes a new value by adding the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to add data.",
                "P", "Specify the coordinate at which to add the data.",
                "data", "Specifies the data to add into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicAnd",
                "imageAtomicAnd atomically computes a new value by logically ANDing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically AND into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1,
                overrideParameterType4: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "imageAtomicCompSwap",
                "imageAtomicCompSwap atomically compares the value of compare with that of the texel at coordinate P and sample (for multisampled forms) in the image bound to uint image. If the values are equal, data is stored into the texel, otherwise it is discarded. It returns the original value of the texel regardless of the result of the comparison operation.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "compare", "Specifies the value to compare with the contents of the image.",
                "data", "Specifies the data to store into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicExchange",
                "imageAtomicExchange atomically stores the value of data into the texel at coordinate P and sample in the image bound to unit image, and returns the original value of the texel.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to exchange with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMax",
                "imageAtomicMax atomically computes a new value by finding the maximum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the maximum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicMin",
                "imageAtomicMin atomically computes a new value by finding the minimum of the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data of which to take the minimum with that stored in the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicOr",
                "imageAtomicOr atomically computes a new value logically ORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically OR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Uint1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "imageAtomicXor",
                "imageAtomicXor atomically computes a new value logically XORing the value of data to the contents of the texel at coordinate P and sample in the image bound to uint image, stores that value into the image and returns the original value.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store data.",
                "P", "Specify the coordinate at which to store the data.",
                "data", "Specifies the data to logically XOR into the image.",
                overrideReturnTypes: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create2(
                "imageLoad",
                "imageLoad loads the texel at the coordinate P from the image unit image. For multi-sample loads, the sample number is given by sample. When image, P, sample identify a valid texel, the bits used to represent the selected texel in memory are converted to a vec4, ivec4, or uvec4 in the manner described in the OpenGL Specification and returned.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3));

            allFunctions.AddRange(Create1(
                "imageSamples",
                "imageSamples returns the number of samples per texel of the image bound to image.",
                IntrinsicTypes.AllImage2DMSTypes,
                "image", "Specifies the image to which the texture is bound.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create1(
                "imageSamples",
                "imageSamples returns the number of samples per texel of the image bound to image.",
                IntrinsicTypes.AllImage2DMSArrayTypes,
                "image", "Specifies the image to which the texture is bound.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));

            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));
            allFunctions.AddRange(Create1(
                "imageSize",
                "imageSize returns the dimensions of the image bound to image. The components in the return value are filled in, in order, with the width, height and depth of the image. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image whose dimensions to retrieve.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));

            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage1DTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage2DTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage3DTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage2DRectTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImageCubeTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage1DArrayTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int2, IntrinsicTypes.Int2, IntrinsicTypes.Int2 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImage2DArrayTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));
            allFunctions.AddRange(Create3pack(
                "imageStore",
                "imageStore stores data into the texel at the coordinate P from the image specified by image. For multi-sample stores, the sample number is given by sample. When image, P, and sample identify a valid texel, the bits used to represent data are converted to the format of the image unit in the manner described in of the OpenGL Specification and stored to the specified texel.",
                IntrinsicTypes.AllImageCubeArrayTypes,
                "image", "Specify the image unit into which to store a texel.",
                "P", "Specify the coordinate at which to store the texel.",
                "data", "Specify the data to store into the image",
                overrideReturnTypes: new[] { IntrinsicTypes.Void, IntrinsicTypes.Void, IntrinsicTypes.Void },
                overrideParameterTypes3: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterTypes2: new[] { IntrinsicTypes.Int3, IntrinsicTypes.Int3, IntrinsicTypes.Int3 }));

            allFunctions.AddRange(Create4(
                "umulExtended",
                "umulExtended and imulExtended perform multiplication of the two 32-bit integer quantities x and y, producing a 64-bit integer result. The 32 least significant bits of this product are returned in lsb and the 32 most significant bits are returned in msb. umulExtended and imulExtended perform unsigned and signed multiplication, respectively.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first multiplicand.",
                "y", "Specifies the second multiplicand.",
                "msb", "Specifies the variable to receive the most significant word of the product",
                "lsb", "Specifies the variable to receive the least significant word of the product",
                overrideReturnTypes: new[] { IntrinsicTypes.Void },
                overrideParameterDirection3: ParameterDirection.Out,
                overrideParameterDirection4: ParameterDirection.Out));
            allFunctions.AddRange(Create4(
                "imulExtended",
                "umulExtended and imulExtended perform multiplication of the two 32-bit integer quantities x and y, producing a 64-bit integer result. The 32 least significant bits of this product are returned in lsb and the 32 most significant bits are returned in msb. umulExtended and imulExtended perform unsigned and signed multiplication, respectively.",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specifies the first multiplicand.",
                "y", "Specifies the second multiplicand.",
                "msb", "Specifies the variable to receive the most significant word of the product",
                "lsb", "Specifies the variable to receive the least significant word of the product",
                overrideReturnTypes: new[] { IntrinsicTypes.Void },
                overrideParameterDirection3: ParameterDirection.Out,
                overrideParameterDirection4: ParameterDirection.Out));

            allFunctions.AddRange(Create1(
                "intBitsToFloat",
                "intBitsToFloat and uintBitsToFloat return the encoding passed in parameter x as a floating-point value. If the encoding of a NaN is passed in x, it will not signal and the resulting value will be undefined. If the encoding of a floating point infinity is passed in parameter x, the resulting floating-point value is the corresponding (positive or negative) floating point infinity.",
                new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int2, IntrinsicTypes.Int3, IntrinsicTypes.Int4 },
                "x", "Specifies the bit encoding to return as a floating point value.",
                new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float2, IntrinsicTypes.Float3, IntrinsicTypes.Float4 }));
            allFunctions.AddRange(Create1(
                "uintBitsToFloat",
                "intBitsToFloat and uintBitsToFloat return the encoding passed in parameter x as a floating - point value. If the encoding of a NaN is passed in x, it will not signal and the resulting value will be undefined.If the encoding of a floating point infinity is passed in parameter x, the resulting floating-point value is the corresponding (positive or negative) floating point infinity.",
                new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint2, IntrinsicTypes.Uint3, IntrinsicTypes.Uint4 },
                "x", "Specifies the bit encoding to return as a floating point value.",
                new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float2, IntrinsicTypes.Float3, IntrinsicTypes.Float4 }));

            allFunctions.AddRange(Create1(
                "interpolateAtCentroid",
                "interpolateAtCentroid returns the value of the input varying interpolant sampled at a location inside both the pixel and the primitive being processed. The value obtained would be the value assigned to the input variable if declared with the centroid qualifier.",
                IntrinsicTypes.AllFloatVectorTypes,
                "interpolant", "Specifies the interpolant to be sampled at the pixel centroid."));

            allFunctions.AddRange(Create2(
                "interpolateAtOffset",
                "interpolateAtOffset returns the value of the input varying interpolant sampled at an offset from the center of the pixel specified by offset. The two floating-point components of offset give the offset in pixels in the x and y directions from the center of the pixel, respectively. An offset of (0, 0) identifies the center of the pixel. The range and granularity of offsets supported by this function is implementation-dependent.",
                IntrinsicTypes.AllFloatVectorTypes,
                "interpolant", "Specifies the interpolant to be sampled at the specified offset.",
                "offset", "Specifies the offset from the center of the pixel at which to sample interpolant",
                overrideParameterType2: IntrinsicTypes.Float2));

            allFunctions.AddRange(Create2(
                "interpolateAtSample",
                "interpolateAtSample returns the value of the input varying interpolant sampled at the location of sample number sample. If multisample buffers are not available, the input varying will be evaluated at the center of the pixel. If sample sample does not exist, the position used to interpolate the input varying is undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "interpolant", "Specifies the interpolant to be sampled at the location of sample sample.",
                "sample", "Specifies the index of the sample whose location will be used to sample interpolant",
                overrideParameterType2: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create1(
                "inverse",
                "inverse returns the inverse of the matrix m. The values in the returned matrix are undefined if m is singular or poorly-conditioned (nearly singular).",
                IntrinsicTypes.AllFloatSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the inverse."));
            allFunctions.AddRange(Create1(
                "inverse",
                "inverse returns the inverse of the matrix m. The values in the returned matrix are undefined if m is singular or poorly-conditioned (nearly singular).",
                IntrinsicTypes.AllDoubleSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the inverse."));

            allFunctions.AddRange(Create1(
                "inversesqrt",
                "inversesqrt returns the inverse of the square root of x; i.e. the value 1/√x. The result is undefined if x≤0.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value of which to take the inverse of the square root."));

            allFunctions.AddRange(Create1(
                "isinf",
                "For each element element i of the result, isinf returns true if x[i] is posititve or negative floating point infinity and false otherwise.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to test for infinity.",
                overrideReturnTypes: new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool2, IntrinsicTypes.Bool3, IntrinsicTypes.Bool4 }));
            allFunctions.AddRange(Create1(
                "isinf",
                "For each element element i of the result, isinf returns true if x[i] is posititve or negative floating point infinity and false otherwise.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specifies the value to test for infinity.",
                overrideReturnTypes: new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool2, IntrinsicTypes.Bool3, IntrinsicTypes.Bool4 }));

            allFunctions.AddRange(Create1(
                "isnan",
                "For each element element i of the result, isinf returns true if x[i] is posititve or negative floating point NaN (Not a Number) and false otherwise.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to test for NaN.",
                overrideReturnTypes: new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool2, IntrinsicTypes.Bool3, IntrinsicTypes.Bool4 }));
            allFunctions.AddRange(Create1(
                "isnan",
                "For each element element i of the result, isinf returns true if x[i] is posititve or negative floating point NaN (Not a Number) and false otherwise.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specifies the value to test for NaN.",
                overrideReturnTypes: new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool2, IntrinsicTypes.Bool3, IntrinsicTypes.Bool4 }));

            allFunctions.AddRange(Create2pack(
                "ldexp",
                "ldexp builds a floating point number from x and the corresponding integral exponent of two in exp, returning: \nsignificand⋅2^exponent \nIf this product is too large to be represented in the floating point type, the result is undefined.",
                IntrinsicTypes.AllFloatVectorTypes,
                "significand", "Specifies the value to be used as a source of significand.",
                "exponent", "Specifies the value to be used as a source of exponent.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int2, IntrinsicTypes.Int3, IntrinsicTypes.Int4 }));
            allFunctions.AddRange(Create2pack(
                "ldexp",
                "ldexp builds a floating point number from x and the corresponding integral exponent of two in exp, returning: \nsignificand⋅2^exponent \nIf this product is too large to be represented in the floating point type, the result is undefined.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "significand", "Specifies the value to be used as a source of significand.",
                "exponent", "Specifies the value to be used as a source of exponent.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int2, IntrinsicTypes.Int3, IntrinsicTypes.Int4 }));

            allFunctions.AddRange(Create1(
                "length",
                "length returns the length of the vector, i.e. √(x[0]^2+x[1]^2+…).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies a vector of which to calculate the length.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create1(
                "length",
                "length returns the length of the vector, i.e. √(x[0]^2+x[1]^2+…).",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specifies a vector of which to calculate the length.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float1 }));

            allFunctions.AddRange(Create2(
                "lessThan",
                "lessThan returns a boolean vector in which each element i is computed as x[i] < y[i].",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "lessThan",
                "lessThan returns a boolean vector in which each element i is computed as x[i] < y[i].",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "lessThan",
                "lessThan returns a boolean vector in which each element i is computed as x[i] < y[i].",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));

            allFunctions.AddRange(Create2(
                "lessThanEqual",
                "lessThanEqual returns a boolean vector in which each element i is computed as x[i] ≤ y[i].",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "lessThanEqual",
                "lessThanEqual returns a boolean vector in which each element i is computed as x[i] ≤ y[i].",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create2(
                "lessThanEqual",
                "lessThanEqual returns a boolean vector in which each element i is computed as x[i] ≤ y[i].",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the comparison operation.",
                "x", "Specifies the second vector to be used in the comparison operation.",
                IntrinsicTypes.AllBoolVectorTypes));

            allFunctions.AddRange(Create1(
                "log",
                "log returns the natural logarithm of x, i.e. the value y which satisfies x=e^y. The result is undefined if x≤0.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value of which to take the natural logarithm."));

            allFunctions.AddRange(Create1(
                "log2",
                "log2 returns the base 2 logarithm of x, i.e. the value y which satisfies x=2^y. The result is undefined if x≤0.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value of which to take the base 2 logarithm."));

            allFunctions.AddRange(Create2(
                "matrixCompMult",
                "matrixCompMult performs a component-wise multiplication of two matrices, yielding a result matrix where each component, result[i][j] is computed as the scalar product of x[i][j] and y[i][j].",
                IntrinsicTypes.AllMatrixTypes,
                "x", "Specifies the first matrix multiplicand.",
                "y", "Specifies the second matrix multiplicand."));

            allFunctions.AddRange(Create2pack(
                "max",
                "max returns the maximum of the two parameters. It returns y if y is greater than x, otherwise it returns x.",
                IntrinsicTypes.AllVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify the second value to compare."));
            allFunctions.AddRange(Create2pack(
                "max",
                "max returns the maximum of the two parameters. It returns y if y is greater than x, otherwise it returns x.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create2pack(
                "max",
                "max returns the maximum of the two parameters. It returns y if y is greater than x, otherwise it returns x.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1 }));
            allFunctions.AddRange(Create2pack(
                "max",
                "max returns the maximum of the two parameters. It returns y if y is greater than x, otherwise it returns x.",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create2pack(
                "max",
                "max returns the maximum of the two parameters. It returns y if y is greater than x, otherwise it returns x.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 }));

            allFunctions.AddRange(Create2pack(
                "min",
                "min returns the minimum of the two parameters. It returns y if y is less than x, otherwise it returns x.",
                IntrinsicTypes.AllVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify the second value to compare."));
            allFunctions.AddRange(Create2pack(
                "min",
                "min returns the minimum of the two parameters. It returns y if y is less than x, otherwise it returns x.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create2pack(
                "min",
                "min returns the minimum of the two parameters. It returns y if y is less than x, otherwise it returns x.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1 }));
            allFunctions.AddRange(Create2pack(
                "min",
                "min returns the minimum of the two parameters. It returns y if y is less than x, otherwise it returns x.",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1, IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create2pack(
                "min",
                "min returns the minimum of the two parameters. It returns y if y is less than x, otherwise it returns x.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specify the first value to compare.",
                "y", "Specify second value to compare.",
                overrideParameterTypes2: new[] { IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1, IntrinsicTypes.Uint1 }));

            allFunctions.Add(new FunctionSymbol(
                "memoryBarrier",
                "memoryBarrier waits on the completion of all memory accesses resulting from the use of image variables or atomic counters and then returns with no other effect. When this function returns, the results of any memory stores performed using coherent variables performed prior to the call will be visible to any future coherent memory access to the same addresses from other shader invocations. In particular, the values written this way in one shader stage are guaranteed to be visible to coherent memory accesses performed by shader invocations in subsequent stages when those invocations were triggered by the execution of the original shader invocation (e.g., fragment shader invocations for a primitive resulting from a particular geometry shader invocation).",
                null, IntrinsicTypes.Void));

            allFunctions.Add(new FunctionSymbol(
                "memoryBarrierBuffer",
                "memoryBarrierBuffer waits on the completion of all memory accesses resulting from the use of buffer variables and then returns with no other effect. When this function returns, the results of any modifications to the content of buffer variables will be visible to any access to the same buffer from other shader invocations. In particular, any modifications made in one shader stage are guaranteed to be visible to accesses performed by shader invocations in subsequent stages when those invocations were triggered by the execution of the original shader invocation (e.g., fragment shader invocations for a primitive resulting from a particular geometry shader invocation).",
                null, IntrinsicTypes.Void));

            allFunctions.Add(new FunctionSymbol(
                "memoryBarrierImage",
                "memoryBarrierImage waits on the completion of all memory accesses resulting from the use of image variables and then returns with no other effect. When this function returns, the results of any modifications to the content of image variables will be visible to any access to the same buffer from other shader invocations. In particular, any modifications made in one shader stage are guaranteed to be visible to accesses performed by shader invocations in subsequent stages when those invocations were triggered by the execution of the original shader invocation (e.g., fragment shader invocations for a primitive resulting from a particular geometry shader invocation).",
                null, IntrinsicTypes.Void));

            allFunctions.Add(new FunctionSymbol(
                "memoryBarrierShared",
                "memoryBarrierShared waits on the completion of all memory accesses resulting from the use of shared variables and then returns with no other effect. When this function returns, the results of any modifications to the content of shared variables will be visible to any access to the same buffer from other shader invocations. In particular, any modifications made in one shader stage are guaranteed to be visible to accesses performed by shader invocations in subsequent stages when those invocations were triggered by the execution of the original shader invocation (e.g., fragment shader invocations for a primitive resulting from a particular geometry shader invocation). \nmemoryBarrierShared is available only in the compute language.",
                null, IntrinsicTypes.Void));

            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y."));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: new[] { IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1, IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: new[] { IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1, IntrinsicTypes.Double1 }));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: IntrinsicTypes.AllBoolVectorTypes));
            allFunctions.AddRange(Create3pack(
                "mix",
                "mix performs a linear interpolation between x and y using a to weight between them. The return value is computed as x×(1−a)+y×x. \nThe variants of mix where a is genBType select which vector each returned component comes from.For a component of a that is false, the corresponding component of x is returned.For a component of a that is true, the corresponding component of y is returned.Components of x and y that are not selected are allowed to be invalid floating - point values and will have no effect on the results.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the start of the range in which to interpolate.",
                "y", "Specify the end of the range in which to interpolate.",
                "a", "Specify the value to use to interpolate between x and y.",
                overrideParameterTypes3: IntrinsicTypes.AllBoolVectorTypes));

            allFunctions.AddRange(Create2(
                "mod",
                "mod returns the value of x modulo y. This is computed as x - y * floor(x/y).",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate.",
                "y", "Specify the modulo value"));
            allFunctions.AddRange(Create2(
                "mod",
                "mod returns the value of x modulo y. This is computed as x - y * floor(x/y).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value to evaluate.",
                "y", "Specify the modulo value.",
                overrideParameterType2: IntrinsicTypes.Float1 ));
            allFunctions.AddRange(Create2(
                "mod",
                "mod returns the value of x modulo y. This is computed as x - y * floor(x/y).",
                IntrinsicTypes.AllDoubleVectorTypes,
                "x", "Specify the value to evaluate.",
                "y", "Specify the modulo value.",
                overrideParameterType2: IntrinsicTypes.Double1));

            allFunctions.AddRange(Create2(
                "modf",
                "modf separates a floating point value x into its integer and fractional parts. The fractional part of the number is returned from the function and the integer part (as a floating point quantity) is returned in the output parameter i.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to separate.",
                "i", "A variable that receives the integer part of the argument",
                overrideParameterDirection2: ParameterDirection.Out));

            allFunctions.AddRange(Create1(
                "noise1",
                "noise1, noise2, noise3 and noise4 return noise values (vector or scalar) based on the input value x. The noise function is a stochastic function that can be used to increase visual complexity. Values returned by the noise functions give the appearance of randomness, but are not truly random. They are defined to have the following characteristics: \nThe return value(s) are always in the range[-1.0, 1.0], and cover at least the range[-0.6, 0.6], with a Gaussian - like distribution. \nThe return value(s) have an overall average of 0.0. \nThey are repeatable, in that a particular input value will always produce the same return value. \nThey are statistically invariant under rotation(i.e., no matter how the domain is rotated, it has the same statistical character). \nThey have a statistical invariance under translation(i.e., no matter how the domain is translated, it has the same statistical character). \nThey typically give different results under translation. \nThe spatial frequency is narrowly concentrated, centered somewhere between 0.5 to 1.0. \nThey are C1 continuous everywhere(i.e., the first derivative is continuous).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to be used to seed the noise function.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float1 }));
            allFunctions.AddRange(Create1(
                "noise2",
                "noise1, noise2, noise3 and noise4 return noise values (vector or scalar) based on the input value x. The noise function is a stochastic function that can be used to increase visual complexity. Values returned by the noise functions give the appearance of randomness, but are not truly random. They are defined to have the following characteristics: \nThe return value(s) are always in the range[-1.0, 1.0], and cover at least the range[-0.6, 0.6], with a Gaussian - like distribution. \nThe return value(s) have an overall average of 0.0. \nThey are repeatable, in that a particular input value will always produce the same return value. \nThey are statistically invariant under rotation(i.e., no matter how the domain is rotated, it has the same statistical character). \nThey have a statistical invariance under translation(i.e., no matter how the domain is translated, it has the same statistical character). \nThey typically give different results under translation. \nThe spatial frequency is narrowly concentrated, centered somewhere between 0.5 to 1.0. \nThey are C1 continuous everywhere(i.e., the first derivative is continuous).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to be used to seed the noise function.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float2 }));
            allFunctions.AddRange(Create1(
                "noise3",
                "noise1, noise2, noise3 and noise4 return noise values (vector or scalar) based on the input value x. The noise function is a stochastic function that can be used to increase visual complexity. Values returned by the noise functions give the appearance of randomness, but are not truly random. They are defined to have the following characteristics: \nThe return value(s) are always in the range[-1.0, 1.0], and cover at least the range[-0.6, 0.6], with a Gaussian - like distribution. \nThe return value(s) have an overall average of 0.0. \nThey are repeatable, in that a particular input value will always produce the same return value. \nThey are statistically invariant under rotation(i.e., no matter how the domain is rotated, it has the same statistical character). \nThey have a statistical invariance under translation(i.e., no matter how the domain is translated, it has the same statistical character). \nThey typically give different results under translation. \nThe spatial frequency is narrowly concentrated, centered somewhere between 0.5 to 1.0. \nThey are C1 continuous everywhere(i.e., the first derivative is continuous).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to be used to seed the noise function.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float3 }));
            allFunctions.AddRange(Create1(
                "noise4",
                "noise1, noise2, noise3 and noise4 return noise values (vector or scalar) based on the input value x. The noise function is a stochastic function that can be used to increase visual complexity. Values returned by the noise functions give the appearance of randomness, but are not truly random. They are defined to have the following characteristics: \nThe return value(s) are always in the range[-1.0, 1.0], and cover at least the range[-0.6, 0.6], with a Gaussian - like distribution. \nThe return value(s) have an overall average of 0.0. \nThey are repeatable, in that a particular input value will always produce the same return value. \nThey are statistically invariant under rotation(i.e., no matter how the domain is rotated, it has the same statistical character). \nThey have a statistical invariance under translation(i.e., no matter how the domain is translated, it has the same statistical character). \nThey typically give different results under translation. \nThe spatial frequency is narrowly concentrated, centered somewhere between 0.5 to 1.0. \nThey are C1 continuous everywhere(i.e., the first derivative is continuous).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specifies the value to be used to seed the noise function.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4 }));

            allFunctions.AddRange(Create1(
                "normalize",
                "normalize returns a vector with the same direction as its parameter, v, but with length 1.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "v", "Specify the vector to normalize."));

            allFunctions.AddRange(Create1(
                "not",
                "not logically inverts the boolean vector x. It returns a new boolean vector for which each element i is computed as !x[i].",
                IntrinsicTypes.AllBoolVectorTypes,
                "x", "Specifies the vector to be inverted."));

            allFunctions.AddRange(Create2(
                "notEqual",
                "notEqual returns a boolean vector in which each element i is computed as x[i] != y[i].",
                new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Float1, IntrinsicTypes.Int1, IntrinsicTypes.Uint1, IntrinsicTypes.Double1 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1, IntrinsicTypes.Bool1 }));
            allFunctions.AddRange(Create2(
                "notEqual",
                "notEqual returns a boolean vector in which each element i is computed as x[i] != y[i].",
                new[] { IntrinsicTypes.Bool2, IntrinsicTypes.Float2, IntrinsicTypes.Int2, IntrinsicTypes.Uint2, IntrinsicTypes.Double2 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2, IntrinsicTypes.Bool2 }));
            allFunctions.AddRange(Create2(
                "notEqual",
                "notEqual returns a boolean vector in which each element i is computed as x[i] != y[i].",
                new[] { IntrinsicTypes.Bool3, IntrinsicTypes.Float3, IntrinsicTypes.Int3, IntrinsicTypes.Uint3, IntrinsicTypes.Double3 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3, IntrinsicTypes.Bool3 }));
            allFunctions.AddRange(Create2(
                "notEqual",
                "notEqual returns a boolean vector in which each element i is computed as x[i] != y[i].",
                new[] { IntrinsicTypes.Bool4, IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4, IntrinsicTypes.Double4 },
                "x", "Specifies the first vector to be used in the comparison operation.",
                "y", "Specifies the second vector to be used in the comparison operation.",
                new[] { IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4, IntrinsicTypes.Bool4 }));

            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float2x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float3x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float4x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float4),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float2x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float4x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float4),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float2x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float3x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float3x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Float4x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Float4),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double2x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double3x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double4x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double4),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double2x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double4x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double4),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double2x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double2),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double3x2,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double2),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double3x4,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double4),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double3),
                }));
            allFunctions.Add(new FunctionSymbol(
                "outerProduct",
                "outerProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.",
                null, IntrinsicTypes.Double4x3,
                f => new[] {
                    new ParameterSymbol("c", "Specifies the parameter to be treated as a column vector.", f, IntrinsicTypes.Double3),
                    new ParameterSymbol("r", "Specifies the parameter to be treated as a row vector.", f, IntrinsicTypes.Double4),
                }));

            allFunctions.Add(new FunctionSymbol(
                "packDouble2x32",
                "packDouble2x32 packs the component of parameter v into a 64-bit value. If an IEEE-754 infinity or NaN is created, it will not signal and the resulting floating-point value is undefined. Otherwise, the bit-level representation of v is preserved. The first vector component (v[0]) specifies the 32 least significant bits of the result; the second component (v[1]) specifies the 32 most significant bits.",
                null, IntrinsicTypes.Double1,
                f => new[] {
                    new ParameterSymbol("v", "Specifies a vector of two unsigned integers to be packed into a single double-precision result.", f, IntrinsicTypes.Uint2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "packHalf2x16",
                "packHalf2x16 returns an unsigned integer obtained by converting the components of a two-component floating-point vector to the 16-bit floating-point representation found in the OpenGL Specification, and then packing these two 16-bit integers into a 32-bit unsigned integer. The first vector component specifies the 16 least-significant bits of the result; the second component specifies the 16 most-significant bits.",
                null, IntrinsicTypes.Uint1,
                f => new[] {
                    new ParameterSymbol("v", "Specify a vector of two 32-bit floating point values that are to be converted to 16-bit representation and packed into the result.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "packUnorm2x16",
                "packUnorm2x16, packSnorm2x16, packUnorm4x8 and packSnorm4x8 convert each component of the normalized floating-ponit value v into 8- or 16-bit integer values and then packs the results into a 32-bit unsigned intgeter. \nThe conversion for component c of v to fixed-point is performed as follows: \npackUnorm2x16: round(clamp(c, 0.0, 1.0) * 65535.0) \npackSnorm2x16: round(clamp(c, -1.0, 1.0) * 32767.0) \npackUnorm4x8: round(clamp(c, 0.0, 1.0) * 255.0) \npackSnorm4x8: round(clamp(c, -1.0, 1.0) * 127.0) \nThe first component of the vector will be written to the least significant bits of the output; the last component will be written to the most significant bits.",
                null, IntrinsicTypes.Uint1,
                f => new[] {
                    new ParameterSymbol("v", "Specifies a vector of values to be packed into an unsigned integer.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "packSnorm2x16",
                "packUnorm2x16, packSnorm2x16, packUnorm4x8 and packSnorm4x8 convert each component of the normalized floating-ponit value v into 8- or 16-bit integer values and then packs the results into a 32-bit unsigned intgeter. \nThe conversion for component c of v to fixed-point is performed as follows: \npackUnorm2x16: round(clamp(c, 0.0, 1.0) * 65535.0) \npackSnorm2x16: round(clamp(c, -1.0, 1.0) * 32767.0) \npackUnorm4x8: round(clamp(c, 0.0, 1.0) * 255.0) \npackSnorm4x8: round(clamp(c, -1.0, 1.0) * 127.0) \nThe first component of the vector will be written to the least significant bits of the output; the last component will be written to the most significant bits.",
                null, IntrinsicTypes.Uint1,
                f => new[] {
                    new ParameterSymbol("v", "Specifies a vector of values to be packed into an unsigned integer.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "packUnorm4x8",
                "packUnorm2x16, packSnorm2x16, packUnorm4x8 and packSnorm4x8 convert each component of the normalized floating-ponit value v into 8- or 16-bit integer values and then packs the results into a 32-bit unsigned intgeter. \nThe conversion for component c of v to fixed-point is performed as follows: \npackUnorm2x16: round(clamp(c, 0.0, 1.0) * 65535.0) \npackSnorm2x16: round(clamp(c, -1.0, 1.0) * 32767.0) \npackUnorm4x8: round(clamp(c, 0.0, 1.0) * 255.0) \npackSnorm4x8: round(clamp(c, -1.0, 1.0) * 127.0) \nThe first component of the vector will be written to the least significant bits of the output; the last component will be written to the most significant bits.",
                null, IntrinsicTypes.Uint1,
                f => new[] {
                    new ParameterSymbol("v", "Specifies a vector of values to be packed into an unsigned integer.", f, IntrinsicTypes.Float4)
                }));
            allFunctions.Add(new FunctionSymbol(
                "packSnorm4x8",
                "packUnorm2x16, packSnorm2x16, packUnorm4x8 and packSnorm4x8 convert each component of the normalized floating-ponit value v into 8- or 16-bit integer values and then packs the results into a 32-bit unsigned intgeter. \nThe conversion for component c of v to fixed-point is performed as follows: \npackUnorm2x16: round(clamp(c, 0.0, 1.0) * 65535.0) \npackSnorm2x16: round(clamp(c, -1.0, 1.0) * 32767.0) \npackUnorm4x8: round(clamp(c, 0.0, 1.0) * 255.0) \npackSnorm4x8: round(clamp(c, -1.0, 1.0) * 127.0) \nThe first component of the vector will be written to the least significant bits of the output; the last component will be written to the most significant bits.",
                null, IntrinsicTypes.Uint1,
                f => new[] {
                    new ParameterSymbol("v", "Specifies a vector of values to be packed into an unsigned integer.", f, IntrinsicTypes.Float4)
                }));

            allFunctions.AddRange(Create2(
                "pow",
                "pow returns the value of x raised to the y power, i.e. x^y. The result is undefined if x<0 or if x=0 and y≤0.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value to raise to the power y.",
                "y", "Specify the power to which to raise x."));

            allFunctions.AddRange(Create1(
                "radians",
                "radians converts a quantity specified in degrees into radians. The return value is π×degrees/180.",
                IntrinsicTypes.AllFloatVectorTypes,
                "degrees", "Specify the quantity, in degrees, to be converted to radians."));

            allFunctions.AddRange(Create2(
                "reflect",
                "For a given incident vector I and surface normal N reflect returns the reflection direction calculated as I - 2.0 * dot(N, I) * N. \nN should be normalized in order to achieve the desired result.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "I", "Specifies the incident vector.",
                "N", "Specifies the normal vector."));

            allFunctions.AddRange(Create3(
                "refract",
                "For a given incident vector I, surface normal N and ratio of indices of refraction, eta, refract returns the refraction vector, R.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "I", "Specifies the incident vector.",
                "N", "Specifies the normal vector.",
                "eta", "Specifies the ratio of indices of refraction",
                overrideParameterType3: IntrinsicTypes.Float1));

            allFunctions.AddRange(Create1(
                "round",
                "round returns a value equal to the nearest integer to x. The fraction 0.5 will round in a direction chosen by the implementation, presumably the direction that is fastest. This includes the possibility that round(x) returns the same value as roundEven(x) for all values of x.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create1(
                "roundEven",
                "roundEven returns a value equal to the nearest integer to x. The fractional part of 0.5 will round toward the nearest even integer. For example, both 3.5 and 4.5 will round to 4.0.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create1(
                "sign",
                "sign returns -1.0 if x is less than 0.0, 0.0 if x is equal to 0.0, and +1.0 if x is greater than 0.0.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value from which to extract the sign."));
            allFunctions.AddRange(Create1(
                "sign",
                "sign returns -1.0 if x is less than 0.0, 0.0 if x is equal to 0.0, and +1.0 if x is greater than 0.0.",
                IntrinsicTypes.AllIntVectorTypes,
                "x", "Specify the value from which to extract the sign."));

            allFunctions.AddRange(Create1(
                "sin",
                "sin returns the trigonometric sine of angle.",
                IntrinsicTypes.AllFloatVectorTypes,
                "angle", "Specify the quantity, in radians, of which to return the sine."));

            allFunctions.AddRange(Create1(
                "sinh",
                "sinh returns the hyperbolic sine of x. The hyperbolic sine of x is computed as 0.5*(e^x−e^(−x)).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose hyperbolic sine to return."));

            allFunctions.AddRange(Create3(
                "smoothstep",
                "smoothstep performs smooth Hermite interpolation between 0 and 1 when edge0 < x < edge1. This is useful in cases where a threshold function with a smooth transition is desired. \nResults are undefined if edge0 ≥ edge1.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "edge0", "Specifies the value of the lower edge of the Hermite function.",
                "edge1", "Specifies the value of the upper edge of the Hermite function.",
                "x", "Specifies the source value for interpolation."));
            allFunctions.AddRange(Create3(
                "smoothstep",
                "smoothstep performs smooth Hermite interpolation between 0 and 1 when edge0 < x < edge1. This is useful in cases where a threshold function with a smooth transition is desired. \nResults are undefined if edge0 ≥ edge1.",
                IntrinsicTypes.AllFloatVectorTypes,
                "edge0", "Specifies the value of the lower edge of the Hermite function.",
                "edge1", "Specifies the value of the upper edge of the Hermite function.",
                "x", "Specifies the source value for interpolation.",
                overrideParameterType1: IntrinsicTypes.Float1,
                overrideParameterType2: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "smoothstep",
                "smoothstep performs smooth Hermite interpolation between 0 and 1 when edge0 < x < edge1. This is useful in cases where a threshold function with a smooth transition is desired. \nResults are undefined if edge0 ≥ edge1.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "edge0", "Specifies the value of the lower edge of the Hermite function.",
                "edge1", "Specifies the value of the upper edge of the Hermite function.",
                "x", "Specifies the source value for interpolation.",
                overrideParameterType1: IntrinsicTypes.Double1,
                overrideParameterType2: IntrinsicTypes.Double1));

            allFunctions.AddRange(Create1(
                "sqrt",
                "sqrt returns the square root of x, i.e. the value √x. The result is undefined if x<0.",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value of which to take the square root."));

            allFunctions.AddRange(Create2(
                "step",
                "step generates a step function by comparing x to edge. \nFor element i of the return value, 0.0 is returned if x[i] < edge[i], and 1.0 is returned otherwise.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "edge", "Specifies the value of the location of the edge of the function.",
                "x", "Specifies the source value for interpolation."));
            allFunctions.AddRange(Create2(
                "step",
                "step generates a step function by comparing x to edge. \nFor element i of the return value, 0.0 is returned if x[i] < edge[i], and 1.0 is returned otherwise.",
                IntrinsicTypes.AllFloatVectorTypes,
                "edge", "Specifies the value of the location of the edge of the function.",
                "x", "Specifies the source value for interpolation.",
                overrideParameterType1: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create2(
                "step",
                "step generates a step function by comparing x to edge. \nFor element i of the return value, 0.0 is returned if x[i] < edge[i], and 1.0 is returned otherwise.",
                IntrinsicTypes.AllDoubleVectorTypes,
                "edge", "Specifies the value of the location of the edge of the function.",
                "x", "Specifies the source value for interpolation.",
                overrideParameterType1: IntrinsicTypes.Double1));

            allFunctions.AddRange(Create1(
                "tan",
                "tan returns the trigonometric tangent of angle.",
                IntrinsicTypes.AllFloatVectorTypes,
                "angle", "Specify the quantity, in radians, of which to return the tangent."));

            allFunctions.AddRange(Create1(
                "tanh",
                "tanh returns the hyperbolic tangent of x. The hyperbolic tangent of x is computed as sinh(x)/cosh(x).",
                IntrinsicTypes.AllFloatVectorTypes,
                "x", "Specify the value whose hyperbolic tangent to return."));

            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail within the texture from which the texel will be fetched.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create2(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "texelFetch",
                "texelFetch performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail within the texture from which the texel will be fetched.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create3(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "texelFetchOffset",
                "texelFetchOffset performs a lookup of a single texel from texture coordinate P in the texture bound to sampler. Before fetching the texel, the offset specified in offset is added to P. offset must be a constant expression. The array layer is specified in the last component of P for array forms. The lod parameter (if present) specifies the level-of-detail from which the texel will be fetched. The sample parameter specifies which sample within the texel will be returned when reading from a multi-sample texure.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail of the texture to fetch.",
                "offset", "Offset, in texels, that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Int3));

            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create2(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Uint1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("compare", "Specifies the value to which the fetched texel will be compared.", f, IntrinsicTypes.Float1)
                }));
            
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create3(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int1));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "texture",
                "texture samples texels from the texture bound to sampler at texture coordinate P. An optional bias, specified in bias is included in the level-of-detail computation that is used to choose mipmap(s) from which to sample. \nFor shadow forms, when compare is present, it is used as DsubDsub and the array layer is specified in P.w.When compare is not present, the last component of P is used as DsubDsub and the array layer is specified in the second to last component of P. (The second component of P is unused for 1D shadow lookups.) \nFor non-shadow variants, the array layer comes from the last component of P.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGather",
                "textureGather returns the value:\nvec4(Sample_i0_j1(P, base).comp,\n\tSample_i1_j1(P, base).comp,\n\tSample_i1_j0(P, base).comp, \n\tSample_i0_j0(P, base).comp); \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                null, IntrinsicTypes.Float4,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("refZ", "Specifies the reference Z value for shadow comparison.", f, IntrinsicTypes.Float1)
                }));

            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                new[] { IntrinsicTypes.sampler2DShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                new[] { IntrinsicTypes.sampler2DArrayShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureGatherOffset",
                "textureGatherOffset returns the value: \nvec4(Sample_i0_j1(P + offset, base).comp, \n\tSample_i1_j1(P + offset, base).comp, \n\tSample_i1_j0(P + offset, base).comp, \n\tSample_i0_j0(P + offset, base).comp); \nIt perfoms as textureGather but with offset applied as described in textureOffset, except that the implementation-dependent minimum and maximum offset values are given by GL_MIN_PROGRRAM_TEXTURE_GATHER_OFFSET and GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET, respectively. \nIf specified, the value of comp must ba constant integer expression with a value of 0, 1, 2, or 3, identifying the x, y, z or w component of the four - component vector lookup result for each texel, respectively. If comp is not specified, it is treated as 0, selecting the x component of each texel to generate the result.",
                new[] { IntrinsicTypes.sampler2DRectShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offset", "Specifies the offset from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float3 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Int2));

            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                "[comp]", "Component to gather.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                new[] { IntrinsicTypes.sampler2DShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                new[] { IntrinsicTypes.sampler2DArrayShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureGatherOffsets",
                "textureGatherOffsets operates identically to textureGatherOffset, except that offsets is used to determine the location of the four texels to sample. Each of the four texels is obtained by applying the offset in offsets as a (u, v) coordinate offset to P, identifying the four-texel GL_LINEAR footprint, and then selecting the texel i0i0i0i0 of that footprint. The specified values in offsets must be set with constant integral expressions.",
                new[] { IntrinsicTypes.sampler2DRectShadow },
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "refZ", "Specifies reference Z value for shadow comparison",
                "offsets", "(ivec2[4]) Specifies the offsets from the specified texture coordinate P from which the texels will be gathered.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float3 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Int2));

            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3));
            allFunctions.AddRange(Create4(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGrad",
                "textureGrad performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float3)
                }));

            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Float1,
                overrideParameterType5: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2,
                overrideParameterType5: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3,
                overrideParameterType5: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3,
                overrideParameterType5: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2,
                overrideParameterType5: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3,
                overrideParameterType5: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3,
                overrideParameterType5: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create5(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the derivative of P w.r.t. x.",
                "dPdy", "Specifies the derivative of P w.r.t. y.",
                "offset", "Specifies the offset to be applied to texture before sampling.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2,
                overrideParameterType5: IntrinsicTypes.Int2));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureGradOffset",
                "textureGradOffset performs a texture lookup at coordinate P from the texture bound to sampler with explicit texture coordinate gradiends as specified in dPdx and dPdy. An explicit offset is also supplied in offset. textureGradOffset consumes dPdx and dPdy as textureGrad and offset as textureOffset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the derivative of P w.r.t. x.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("dPdy", "Specifies the derivative of P w.r.t. y.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset to be applied to texture before sampling.", f, IntrinsicTypes.Int3)
                }));

            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLod",
                "textureLod performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the value to which the fetched texel be compared.", f, IntrinsicTypes.Float1)
                }));

            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail to be applied.",
                "offset", "Specifies the offset that will be applied to P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail to be applied.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureLodOffset",
                "textureLodOffset performs a texture lookup at coordinate P from the texture bound to sampler with an explicit level-of-detail as specified in lod. Behavior is the same as in textureLod except that before sampling, offset is added to P.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the value to which the fetched texel be compared.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2)
                }));

            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int1,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSamplerCubeTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler1DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Int2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler2DArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSamplerCubeArrayTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Int3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that will be applied to P.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int1),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int1),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.samplerCubeArrayShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureOffset",
                "textureOffset performs a texture lookup at coordinate P from the texture bound to sampler with an an additional offset, specified in texels in offset that will be applied to the (u, v, w) texture coordinates before looking up each texel. The offset value must be a constant expression. A limited range of offset values are supported; the minimum and maximum offset values are implementation-dependent and may be determined by querying GL_MIN_PROGRAM_TEXEL_OFFSET and GL_MAX_PROGRAM_TEXEL_OFFSET, respectively. \nNote that offset does not apply to the layer coordinate for texture arrays. Also note that offsets are not supported for cube maps.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float3),
                    new ParameterSymbol("offset", "Specifies the offset that will be applied to P.", f, IntrinsicTypes.Int2)
                }));

            allFunctions.AddRange(Create3(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create2(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3));
            allFunctions.Add(new FunctionSymbol(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProj",
                "textureProj performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in texture.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4)
                }));

            allFunctions.AddRange(Create4(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2));
            allFunctions.AddRange(Create4(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3));
            allFunctions.AddRange(Create4(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGrad",
                "textureProjGrad performs a texture lookup with projection and explicit gradients. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGrad, passing dPdx and dPdy as gradients.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float2)
                }));

            allFunctions.AddRange(Create5(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                "offset", "Specifies the offset, in texels, relative to projection of P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Float1,
                overrideParameterType5: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create5(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                "offset", "Specifies the offset, in texels, relative to projection of P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2,
                overrideParameterType5: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create5(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                "offset", "Specifies the offset, in texels, relative to projection of P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Float3,
                overrideParameterType4: IntrinsicTypes.Float3,
                overrideParameterType5: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create5(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "dPdx", "Specifies the partial derivative w.r.t. x.",
                "dPdy", "Specifies the partial derivative w.r.t. y.",
                "offset", "Specifies the offset, in texels, relative to projection of P.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float2,
                overrideParameterType4: IntrinsicTypes.Float2,
                overrideParameterType5: IntrinsicTypes.Int2));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, relative to projection of P.", f, IntrinsicTypes.Int)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, relative to projection of P.", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjGradOffset",
                "textureProjGradOffset performs a texture lookup with projection and explicit gradients and offsets. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureGradOffset, passing dPdx and dPdy as gradients, and offset as the offset.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("dPdx", "Specifies the partial derivative w.r.t. x.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("dPdy", "Specifies the partial derivative w.r.t. y.", f, IntrinsicTypes.Float2),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, relative to projection of P.", f, IntrinsicTypes.Int2)
                }));

            allFunctions.AddRange(Create3(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLod",
                "textureProjLod performs a texture lookup with projection from an explicitly specified level-of-detail. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLod, with lod used to specify the level-of-detail from which the texture will be sampled.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1)
                }));

            allFunctions.AddRange(Create4(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                "offset", "Specifies the offset, in texels, to be applied to P before fetching texels",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create4(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                "offset", "Specifies the offset, in texels, to be applied to P before fetching texels",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.AddRange(Create4(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                "offset", "Specifies the offset, in texels, to be applied to P before fetching texels",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int3));
            allFunctions.AddRange(Create4(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "lod", "Specifies the level-of-detail.",
                "offset", "Specifies the offset, in texels, to be applied to P before fetching texels",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Float1,
                overrideParameterType4: IntrinsicTypes.Int2));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, to be applied to P before fetching texels", f, IntrinsicTypes.Int1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, to be applied to P before fetching texels", f, IntrinsicTypes.Int2)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjLodOffset",
                "textureProjLodOffset performs a texture lookup with projection from an explicitly specified level-of-detail with an offset applied to the texture coordinates before sampling. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureLodOffset, with lod used to specify the level-of-detail from which the texture will be sampled and offset used to specifiy the offset, in texels, to be applied to the texture coordinates before sampling.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("lod", "Specifies the level-of-detail.", f, IntrinsicTypes.Float1),
                    new ParameterSymbol("offset", "Specifies the offset, in texels, to be applied to P before fetching texels", f, IntrinsicTypes.Int2)
                }));

            allFunctions.AddRange(Create4(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                IntrinsicTypes.AllSampler1DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that is applied to P before sampling occurs.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float2,
                overrideParameterType3: IntrinsicTypes.Int1,
                overrideParameterType4: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                IntrinsicTypes.AllSampler2DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that is applied to P before sampling occurs.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int2,
                overrideParameterType4: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create4(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                IntrinsicTypes.AllSampler3DTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that is applied to P before sampling occurs.",
                "[bias]", "Specifies the level-of-detail bias to be applied.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float4,
                overrideParameterType3: IntrinsicTypes.Int3,
                overrideParameterType4: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create3(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                IntrinsicTypes.AllSampler2DRectTypes,
                "sampler", "Specify the sampler from which to load a texel.",
                "P", "Specify the coordinate at which to load the texel.",
                "offset", "Specifies the offset that is applied to P before sampling occurs.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float4, IntrinsicTypes.Int4, IntrinsicTypes.Uint4 },
                overrideParameterType2: IntrinsicTypes.Float3,
                overrideParameterType3: IntrinsicTypes.Int2));
            allFunctions.Add(new FunctionSymbol(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler1DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("offset", "Specifies the offset that is applied to P before sampling occurs.", f, IntrinsicTypes.Int1),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("offset", "Specifies the offset that is applied to P before sampling occurs.", f, IntrinsicTypes.Int2),
                    new ParameterSymbol("[bias]", "Specifies the level-of-detail bias to be applied.", f, IntrinsicTypes.Float1)
                }));
            allFunctions.Add(new FunctionSymbol(
                "textureProjOffset",
                "textureProjOffset performs a texture lookup with projection. The texture coordinates consumed from P, not including the last component of P, are divided by the last component of P. The resulting 3rd component of P in the shadow forms is used as Dref. After these values are computed, the texture lookup proceeds as in textureOffset, with the offset used to offset the computed texture coordinates.",
                null, IntrinsicTypes.Float1,
                f => new[]
                {
                    new ParameterSymbol("sampler", "Specify the sampler from which to load a texel.", f, IntrinsicTypes.sampler2DRectShadow),
                    new ParameterSymbol("P", "Specify the coordinate at which to load the texel.", f, IntrinsicTypes.Float4),
                    new ParameterSymbol("offset", "Specifies the offset that is applied to P before sampling occurs.", f, IntrinsicTypes.Int2)
                }));

            allFunctions.AddRange(Create1(
                "textureQueryLevels",
                "textureQueryLevels returns the number of accessible mipmap levels in the texture associated with sampler. \nIf called on an incomplete texture, or if no texture is associated with sampler, zero is returned.",
                IntrinsicTypes.AllSamplerTypes,
                "sampler", "Specifies the sampler to which the texture whose mipmap level count will be queried is bound.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1 }));

            allFunctions.AddRange(Create2(
                "textureQueryLod",
                "Available only in the fragment shader, textureQueryLod computes the level-of-detail that would be used to sample from a texture. The mipmap array(s) that would be accessed is returned in the x component of the return value. The computed level-of-detail relative to the base level is returned in the y component of the return value. \nIf called on an incomplete texture, the result of the operation is undefined.",
                IntrinsicTypes.AllSamplerWithSize1DTypes,
                "sampler", "Specifies the sampler to which the texture whose level-of-detail will be queried is bound.",
                "P", "Specifies the texture coordinates at which the level-of-detail will be queried.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float2 },
                overrideParameterType2: IntrinsicTypes.Float1));
            allFunctions.AddRange(Create2(
                "textureQueryLod",
                "Available only in the fragment shader, textureQueryLod computes the level-of-detail that would be used to sample from a texture. The mipmap array(s) that would be accessed is returned in the x component of the return value. The computed level-of-detail relative to the base level is returned in the y component of the return value. \nIf called on an incomplete texture, the result of the operation is undefined.",
                IntrinsicTypes.AllSamplerWithSize2DTypes,
                "sampler", "Specifies the sampler to which the texture whose level-of-detail will be queried is bound.",
                "P", "Specifies the texture coordinates at which the level-of-detail will be queried.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float2 },
                overrideParameterType2: IntrinsicTypes.Float2));
            allFunctions.AddRange(Create2(
                "textureQueryLod",
                "Available only in the fragment shader, textureQueryLod computes the level-of-detail that would be used to sample from a texture. The mipmap array(s) that would be accessed is returned in the x component of the return value. The computed level-of-detail relative to the base level is returned in the y component of the return value. \nIf called on an incomplete texture, the result of the operation is undefined.",
                IntrinsicTypes.AllSamplerWithSize3DTypes,
                "sampler", "Specifies the sampler to which the texture whose level-of-detail will be queried is bound.",
                "P", "Specifies the texture coordinates at which the level-of-detail will be queried.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float2 },
                overrideParameterType2: IntrinsicTypes.Float3));

            allFunctions.AddRange(Create1(
                "textureSamples",
                "textureSamples returns the number of samples per texel of the texture bound to sampler.",
                IntrinsicTypes.AllSampler2DMSTypes,
                "sampler", "Specifies the sampler to which the texture is bound.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1 }));
            allFunctions.AddRange(Create1(
                "textureSamples",
                "textureSamples returns the number of samples per texel of the texture bound to sampler.",
                IntrinsicTypes.AllSampler2DMSArrayTypes,
                "sampler", "Specifies the sampler to which the texture is bound.",
                overrideReturnTypes: new[] { IntrinsicTypes.Int1 }));

            allFunctions.AddRange(Create2(
                "textureSize",
                "textureSize returns the dimensions of level lod (if present) of the texture bound to sampler. The components in the return value are filled in, in order, with the width, height and depth of the texture. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllSamplerWithSize1DTypes,
                "sampler", "Specifies the sampler to which the texture whose dimensions to retrieve is bound.",
                "lod", "Specifies the level of the texture for which to retrieve the dimensions.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float1 },
                overrideParameterType2: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create2(
                "textureSize",
                "textureSize returns the dimensions of level lod (if present) of the texture bound to sampler. The components in the return value are filled in, in order, with the width, height and depth of the texture. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllSamplerWithSize2DTypes,
                "sampler", "Specifies the sampler to which the texture whose dimensions to retrieve is bound.",
                "lod", "Specifies the level of the texture for which to retrieve the dimensions.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float2 },
                overrideParameterType2: IntrinsicTypes.Int1));
            allFunctions.AddRange(Create2(
                "textureSize",
                "textureSize returns the dimensions of level lod (if present) of the texture bound to sampler. The components in the return value are filled in, in order, with the width, height and depth of the texture. For the array forms, the last component of the return value is the number of layers in the texture array.",
                IntrinsicTypes.AllSamplerWithSize3DTypes,
                "sampler", "Specifies the sampler to which the texture whose dimensions to retrieve is bound.",
                "lod", "Specifies the level of the texture for which to retrieve the dimensions.",
                overrideReturnTypes: new[] { IntrinsicTypes.Float3 },
                overrideParameterType2: IntrinsicTypes.Int1));

            allFunctions.AddRange(Create1(
                "transpose",
                "transpose returns the transpose of the matrix m.",
                IntrinsicTypes.AllFloatSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the transpose."));
            allFunctions.AddRange(Create1(
                "transpose",
                "transpose returns the transpose of the matrix m.",
                IntrinsicTypes.AllDoubleSquareMatrixTypes,
                "m", "Specifies the matrix of which to take the transpose."));

            allFunctions.AddRange(Create1(
                "trunc",
                "trunc returns a a value equal to the nearest integer to x whose absolute value is not larger than the absolute value of x.",
                IntrinsicTypes.AllFloatDoubleVectorTypes,
                "x", "Specify the value to evaluate."));

            allFunctions.AddRange(Create3(
                "uaddCarry",
                "uaddCarry adds two 32-bit unsigned integer variables (scalars or vectors) and generates a 32-bit unsigned integer result, along with a carry output. The result is the sum of x and y modulo 2^32. The value carry is set to 0 if the sum is less than 2^32 and to 1 otherwise.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the summation operation.",
                "y", "Specifies the second vector to be used in the summation operation.",
                "carry", "Specifies the variable to receive the carry output of the sum.",
                overrideParameterDirection3: ParameterDirection.Out));

            allFunctions.AddRange(Create1(
                "unpackDouble2x32",
                "unpackDouble2x32 returns a two-component unsigned integer vector representation of d. The bit-level representation of d is preserved. The first component of the returned vector contains the 32 least significant bits of the double; the second component consists the 32 most significant bits.",
                new[] { IntrinsicTypes.Double1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Uint2 }));

            allFunctions.AddRange(Create1(
                "unpackHalf2x16",
                "unpackHalf2x16 returns a two-component floating-point vector with components obtained by unpacking a 32-bit unsigned integer into a pair of 16-bit values, interpreting those values as 16-bit floating-point numbers according to the OpenGL Specification, and converting them to 32-bit floating-point values. The first component of the vector is obtained from the 16 least-significant bits of v; the second component is obtained from the 16 most-significant bits of v.",
                new[] { IntrinsicTypes.Uint1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Float2 }));

            allFunctions.AddRange(Create1(
                "unpackUnorm2x16",
                "unpackUnorm2x16, unpackSnorm2x16, unpackUnorm4x8 and unpackSnorm4x8 unpack single 32-bit unsigned integers, specified in the parameter p into a pair of 16-bit unsigned integers, four 8-bit unsigned integers or four 8-bit signed integers. Then, each component is converted to a normalized floating-point value to generate the returned two- or four-component vector. \nThe conversion for unpacked fixed point value f to floating - point is performed as follows: \n\tpackUnorm2x16: f / 65535.0 \n\tpackSnorm2x16: clamp(f / 32727.0, -1.0, 1.0) \n\tpackUnorm4x8: f / 255.0 \n\tpackSnorm4x8: clamp(f / 127.0, -1.0, 1.0) \nThe first component of the returned vector will be extracted from the least significant bits of the input; the last component will be extracted from the most significant bits.",
                new[] { IntrinsicTypes.Uint1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Float2 }));
            allFunctions.AddRange(Create1(
                "unpackSnorm2x16",
                "unpackUnorm2x16, unpackSnorm2x16, unpackUnorm4x8 and unpackSnorm4x8 unpack single 32-bit unsigned integers, specified in the parameter p into a pair of 16-bit unsigned integers, four 8-bit unsigned integers or four 8-bit signed integers. Then, each component is converted to a normalized floating-point value to generate the returned two- or four-component vector. \nThe conversion for unpacked fixed point value f to floating - point is performed as follows: \n\tpackUnorm2x16: f / 65535.0 \n\tpackSnorm2x16: clamp(f / 32727.0, -1.0, 1.0) \n\tpackUnorm4x8: f / 255.0 \n\tpackSnorm4x8: clamp(f / 127.0, -1.0, 1.0) \nThe first component of the returned vector will be extracted from the least significant bits of the input; the last component will be extracted from the most significant bits.",
                new[] { IntrinsicTypes.Uint1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Float2 }));
            allFunctions.AddRange(Create1(
                "unpackUnorm4x8",
                "unpackUnorm2x16, unpackSnorm2x16, unpackUnorm4x8 and unpackSnorm4x8 unpack single 32-bit unsigned integers, specified in the parameter p into a pair of 16-bit unsigned integers, four 8-bit unsigned integers or four 8-bit signed integers. Then, each component is converted to a normalized floating-point value to generate the returned two- or four-component vector. \nThe conversion for unpacked fixed point value f to floating - point is performed as follows: \n\tpackUnorm2x16: f / 65535.0 \n\tpackSnorm2x16: clamp(f / 32727.0, -1.0, 1.0) \n\tpackUnorm4x8: f / 255.0 \n\tpackSnorm4x8: clamp(f / 127.0, -1.0, 1.0) \nThe first component of the returned vector will be extracted from the least significant bits of the input; the last component will be extracted from the most significant bits.",
                new[] { IntrinsicTypes.Uint1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Float4 }));
            allFunctions.AddRange(Create1(
                "unpackSnorm4x8",
                "unpackUnorm2x16, unpackSnorm2x16, unpackUnorm4x8 and unpackSnorm4x8 unpack single 32-bit unsigned integers, specified in the parameter p into a pair of 16-bit unsigned integers, four 8-bit unsigned integers or four 8-bit signed integers. Then, each component is converted to a normalized floating-point value to generate the returned two- or four-component vector. \nThe conversion for unpacked fixed point value f to floating - point is performed as follows: \n\tpackUnorm2x16: f / 65535.0 \n\tpackSnorm2x16: clamp(f / 32727.0, -1.0, 1.0) \n\tpackUnorm4x8: f / 255.0 \n\tpackSnorm4x8: clamp(f / 127.0, -1.0, 1.0) \nThe first component of the returned vector will be extracted from the least significant bits of the input; the last component will be extracted from the most significant bits.",
                new[] { IntrinsicTypes.Uint1 },
                "d", "Specifies double precision value to break into a pair of unsigned integers.",
                new[] { IntrinsicTypes.Float4 }));

            allFunctions.AddRange(Create3(
                "usubBorrow",
                "usubBorrow subtracts two 32-bit unsigned integer variables (scalars or vectors) and generates a 32-bit unsigned integer result, along with a borrow output. The result is the difference of x and y if non-negative, or 2^32 plus that difference otherwise. The value borrow is set to 0 if x ≥ y and to 1 otherwise.",
                IntrinsicTypes.AllUintVectorTypes,
                "x", "Specifies the first vector to be used in the subtraction  operation.",
                "y", "Specifies the second vector to be used in the subtraction  operation.",
                "carry", "Specifies the variable to receive the borrow output of the difference.",
                overrideParameterDirection3: ParameterDirection.Out));




            AllFunctions = allFunctions;
        }

        private static FunctionSymbol Create0(string name, string documentation, TypeSymbol returnType)
        {
            return new FunctionSymbol(
                name, documentation, null, returnType,
                f => new ParameterSymbol[0]);
        }

        private static IEnumerable<FunctionSymbol> Create1(
            string name, string documentation, TypeSymbol[] types,
            string parameterName, string parameterDocumentation,
            params TypeSymbol[] overrideReturnTypes)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName ?? "value", parameterDocumentation ?? "The specified value.", f, type)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create2(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol overrideParameterType1 = null,
            TypeSymbol overrideParameterType2 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterType1 ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterType2 ?? type, overrideParameterDirection2)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create2pack(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol[] overrideParameterTypes1 = null,
            TypeSymbol[] overrideParameterTypes2 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);
            overrideParameterTypes1 = GetPossiblyExpandedArray(types, overrideParameterTypes1);
            overrideParameterTypes2 = GetPossiblyExpandedArray(types, overrideParameterTypes2);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterTypes1?[i] ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterTypes2?[i] ?? type, overrideParameterDirection2),
                }));
        }

        private static IEnumerable<FunctionSymbol> Create3(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol overrideParameterType1 = null,
            TypeSymbol overrideParameterType2 = null,
            TypeSymbol overrideParameterType3 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterType1 ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterType2 ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterType3 ?? type, overrideParameterDirection3)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create3pack(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol[] overrideParameterTypes1 = null,
            TypeSymbol[] overrideParameterTypes2 = null,
            TypeSymbol[] overrideParameterTypes3 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);
            overrideParameterTypes1 = GetPossiblyExpandedArray(types, overrideParameterTypes1);
            overrideParameterTypes2 = GetPossiblyExpandedArray(types, overrideParameterTypes2);
            overrideParameterTypes3 = GetPossiblyExpandedArray(types, overrideParameterTypes3);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterTypes1?[i] ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterTypes2?[i] ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterTypes3?[i] ?? type, overrideParameterDirection3)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create4(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            string parameterName4, string parameterDocumentation4,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol overrideParameterType1 = null,
            TypeSymbol overrideParameterType2 = null,
            TypeSymbol overrideParameterType3 = null,
            TypeSymbol overrideParameterType4 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection4 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterType1 ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterType2 ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterType3 ?? type, overrideParameterDirection3),
                    new ParameterSymbol(parameterName4, parameterDocumentation4, f, overrideParameterType4 ?? type, overrideParameterDirection4)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create4pack(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            string parameterName4, string parameterDocumentation4,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol[] overrideParameterTypes1 = null,
            TypeSymbol[] overrideParameterTypes2 = null,
            TypeSymbol[] overrideParameterTypes3 = null,
            TypeSymbol[] overrideParameterTypes4 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection4 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);
            overrideParameterTypes1 = GetPossiblyExpandedArray(types, overrideParameterTypes1);
            overrideParameterTypes2 = GetPossiblyExpandedArray(types, overrideParameterTypes2);
            overrideParameterTypes3 = GetPossiblyExpandedArray(types, overrideParameterTypes3);
            overrideParameterTypes4 = GetPossiblyExpandedArray(types, overrideParameterTypes4);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterTypes1?[i] ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterTypes2?[i] ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterTypes3?[i] ?? type, overrideParameterDirection3),
                    new ParameterSymbol(parameterName4, parameterDocumentation4, f, overrideParameterTypes4?[i] ?? type, overrideParameterDirection4)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create5(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            string parameterName4, string parameterDocumentation4,
            string parameterName5, string parameterDocumentation5,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol overrideParameterType1 = null,
            TypeSymbol overrideParameterType2 = null,
            TypeSymbol overrideParameterType3 = null,
            TypeSymbol overrideParameterType4 = null,
            TypeSymbol overrideParameterType5 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection4 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection5 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterType1 ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterType2 ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterType3 ?? type, overrideParameterDirection3),
                    new ParameterSymbol(parameterName4, parameterDocumentation4, f, overrideParameterType4 ?? type, overrideParameterDirection4),
                    new ParameterSymbol(parameterName5, parameterDocumentation5, f, overrideParameterType5 ?? type, overrideParameterDirection5)
                }));
        }

        private static IEnumerable<FunctionSymbol> Create5pack(
            string name, string documentation, TypeSymbol[] types,
            string parameterName1, string parameterDocumentation1,
            string parameterName2, string parameterDocumentation2,
            string parameterName3, string parameterDocumentation3,
            string parameterName4, string parameterDocumentation4,
            string parameterName5, string parameterDocumentation5,
            TypeSymbol[] overrideReturnTypes = null,
            TypeSymbol[] overrideParameterTypes1 = null,
            TypeSymbol[] overrideParameterTypes2 = null,
            TypeSymbol[] overrideParameterTypes3 = null,
            TypeSymbol[] overrideParameterTypes4 = null,
            TypeSymbol[] overrideParameterTypes5 = null,
            ParameterDirection overrideParameterDirection2 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection3 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection4 = ParameterDirection.In,
            ParameterDirection overrideParameterDirection5 = ParameterDirection.In)
        {
            overrideReturnTypes = GetPossiblyExpandedArray(types, overrideReturnTypes);
            overrideParameterTypes1 = GetPossiblyExpandedArray(types, overrideParameterTypes1);
            overrideParameterTypes2 = GetPossiblyExpandedArray(types, overrideParameterTypes2);
            overrideParameterTypes3 = GetPossiblyExpandedArray(types, overrideParameterTypes3);
            overrideParameterTypes4 = GetPossiblyExpandedArray(types, overrideParameterTypes4);
            overrideParameterTypes5 = GetPossiblyExpandedArray(types, overrideParameterTypes5);

            return types.Select((type, i) => new FunctionSymbol(
                name, documentation, null, overrideReturnTypes?[i] ?? type,
                f => new[]
                {
                    new ParameterSymbol(parameterName1, parameterDocumentation1, f, overrideParameterTypes1?[i] ?? type),
                    new ParameterSymbol(parameterName2, parameterDocumentation2, f, overrideParameterTypes2?[i] ?? type, overrideParameterDirection2),
                    new ParameterSymbol(parameterName3, parameterDocumentation3, f, overrideParameterTypes3?[i] ?? type, overrideParameterDirection3),
                    new ParameterSymbol(parameterName4, parameterDocumentation4, f, overrideParameterTypes4?[i] ?? type, overrideParameterDirection4),
                    new ParameterSymbol(parameterName5, parameterDocumentation5, f, overrideParameterTypes5?[i] ?? type, overrideParameterDirection5)
                }));
        }

        private static TypeSymbol[] GetPossiblyExpandedArray(TypeSymbol[] types, TypeSymbol[] overrideTypes)
        {
            if (overrideTypes != null && overrideTypes.Length == 0)
                return null;
            else if (overrideTypes != null && overrideTypes.Length == 1)
                return Enumerable.Repeat(overrideTypes[0], types.Length).ToArray();
            else
                return overrideTypes;
        }
    }
}