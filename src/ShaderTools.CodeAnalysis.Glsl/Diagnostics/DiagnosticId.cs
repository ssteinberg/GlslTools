﻿namespace ShaderTools.CodeAnalysis.Glsl.Diagnostics
{
    public enum DiagnosticId
    {
        IllegalInputCharacter,
        UnterminatedComment,
        UnterminatedString,

        InvalidInteger,
        InvalidReal,
        InvalidOctal,
        InvalidHex,
        NumberTooLarge,
        TokenExpected,
        TokenUnexpected,

        EndIfDirectiveExpected,
        UnexpectedDirective,
        DirectiveExpected,
        AlreadyDefined,
        BadDirectivePlacement,
        EndOfPreprocessorLineExpected,
        MissingPreprocessorFile,
        IncludeNotFound,
        IncludeUnexpectedError,
        NotEnoughMacroParameters,
        UnexpectedAttribute,

        InvalidExprTerm,

        NoVoidHere,
        NoVoidParameter,
        ExpressionExpected,
        TypeExpected,

        BadEmbeddedStatement,
        ConstantExpected,

        UndeclaredType,
        UndeclaredFunction,
        UndeclaredMethod,
        UndeclaredIndexer,
        UndeclaredVariable,
        UndeclaredField,
        AmbiguousInvocation,
        AmbiguousReference,
        AmbiguousType,
        AmbiguousField,
        CannotConvert,
        InvocationRequiresParenthesis,
        CannotApplyUnaryOperator,
        CannotApplyBinaryOperator,
        AmbiguousUnaryOperator,
        AmbiguousBinaryOperator,
        SymbolRedefined,
        FunctionMissingImplementation,
        LoopControlVariableConflict,
        ImplicitTruncation,
        UndeclaredNamespaceOrType,
        AmbiguousNamespaceOrType,
        UndeclaredFunctionInNamespaceOrClass,
        FunctionOverloadResolutionFailure,
        MethodOverloadResolutionFailure
    }
}