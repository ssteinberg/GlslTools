using System.Composition;
using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Options;

namespace ShaderTools.CodeAnalysis.Glsl.Options
{
    [Export(typeof(IGlslOptionsService))]
    internal sealed class GlslOptionsService : IGlslOptionsService
    {
        public FormattingOptions GetFormattingOptions(OptionSet options)
        {
            return new FormattingOptions
            {
                Indentation = new IndentationOptions
                {
                    IndentBlockContents = options.GetOption(GlslFormattingOptions.IndentBlockContents),
                    IndentCaseContents = options.GetOption(GlslFormattingOptions.IndentCaseContents),
                    IndentCaseLabels = options.GetOption(GlslFormattingOptions.IndentCaseLabels),
                    IndentOpenAndCloseBraces = options.GetOption(GlslFormattingOptions.IndentOpenAndCloseBraces),
                    PreprocessorDirectivePosition = options.GetOption(GlslFormattingOptions.PreprocessorDirectivePosition)
                },

                NewLines = new NewLinesOptions
                {
                    OpenBracePositionForArrayInitializers = options.GetOption(GlslFormattingOptions.OpenBracePositionForArrayInitializers),
                    OpenBracePositionForControlBlocks = options.GetOption(GlslFormattingOptions.OpenBracePositionForControlBlocks),
                    OpenBracePositionForFunctions = options.GetOption(GlslFormattingOptions.OpenBracePositionForFunctions),
                    OpenBracePositionForStateBlocks = options.GetOption(GlslFormattingOptions.OpenBracePositionForStateBlocks),
                    OpenBracePositionForTechniquesAndPasses = options.GetOption(GlslFormattingOptions.OpenBracePositionForTechniques),
                    OpenBracePositionForTypes = options.GetOption(GlslFormattingOptions.OpenBracePositionForTypes),
                    PlaceElseOnNewLine = options.GetOption(GlslFormattingOptions.PlaceElseOnNewLine)
                },

                Spacing = new SpacingOptions
                {
                    BinaryOperatorSpaces = options.GetOption(GlslFormattingOptions.BinaryOperatorSpaces),
                    FunctionCallInsertSpaceAfterFunctionName = options.GetOption(GlslFormattingOptions.SpaceAfterFunctionCallName),
                    FunctionCallInsertSpaceWithinArgumentListParentheses = options.GetOption(GlslFormattingOptions.SpaceWithinFunctionCallParentheses),
                    FunctionCallInsertSpaceWithinEmptyArgumentListParentheses = options.GetOption(GlslFormattingOptions.SpaceWithinFunctionCallEmptyParentheses),
                    FunctionDeclarationInsertSpaceAfterFunctionName = options.GetOption(GlslFormattingOptions.SpaceAfterFunctionDeclarationName),
                    FunctionDeclarationInsertSpaceWithinArgumentListParentheses = options.GetOption(GlslFormattingOptions.SpaceWithinFunctionDeclarationParentheses),
                    FunctionDeclarationInsertSpaceWithinEmptyArgumentListParentheses = options.GetOption(GlslFormattingOptions.SpaceWithinFunctionDeclarationEmptyParentheses),
                    InsertSpaceAfterCast = options.GetOption(GlslFormattingOptions.SpaceAfterTypeCast),
                    InsertSpaceAfterColonForBaseOrInterfaceInTypeDeclaration = options.GetOption(GlslFormattingOptions.SpaceAfterColonInBaseTypeDeclaration),
                    InsertSpaceAfterColonForSemanticOrRegisterOrPackOffset = options.GetOption(GlslFormattingOptions.SpaceAfterColonInSemanticOrRegisterOrPackOffset),
                    InsertSpaceAfterComma = options.GetOption(GlslFormattingOptions.SpaceAfterComma),
                    InsertSpaceAfterDot = options.GetOption(GlslFormattingOptions.SpaceAfterDot),
                    InsertSpaceAfterKeywordsInControlFlowStatements = options.GetOption(GlslFormattingOptions.SpaceAfterControlFlowStatementKeyword),
                    InsertSpaceAfterSemicolonInForStatement = options.GetOption(GlslFormattingOptions.SpaceAfterSemicolonsInForStatement),
                    InsertSpaceBeforeColonForBaseOrInterfaceInTypeDeclaration = options.GetOption(GlslFormattingOptions.SpaceBeforeColonInBaseTypeDeclaration),
                    InsertSpaceBeforeColonForSemanticOrRegisterOrPackOffset = options.GetOption(GlslFormattingOptions.SpaceBeforeColonInSemanticOrRegisterOrPackOffset),
                    InsertSpaceBeforeComma = options.GetOption(GlslFormattingOptions.SpaceBeforeComma),
                    InsertSpaceBeforeDot = options.GetOption(GlslFormattingOptions.SpaceBeforeDot),
                    InsertSpaceBeforeOpenSquareBracket = options.GetOption(GlslFormattingOptions.SpaceBeforeOpenSquareBracket),
                    InsertSpaceBeforeSemicolonInForStatement = options.GetOption(GlslFormattingOptions.SpaceBeforeSemicolonsInForStatement),
                    InsertSpacesWithinArrayInitializerBraces = options.GetOption(GlslFormattingOptions.SpaceWithinArrayInitializerBraces),
                    InsertSpacesWithinParenthesesOfControlFlowStatements = options.GetOption(GlslFormattingOptions.SpaceWithinControlFlowStatementParentheses),
                    InsertSpacesWithinParenthesesOfExpressions = options.GetOption(GlslFormattingOptions.SpaceWithinExpressionParentheses),
                    InsertSpacesWithinParenthesesOfRegisterOrPackOffsetQualifiers = options.GetOption(GlslFormattingOptions.SpaceWithinRegisterOrPackOffsetParentheses),
                    InsertSpacesWithinParenthesesOfTypeCasts = options.GetOption(GlslFormattingOptions.SpaceWithinTypeCastParentheses),
                    InsertSpacesWithinSquareBrackets = options.GetOption(GlslFormattingOptions.SpaceWithinSquareBrackets),
                    InsertSpaceWithinEmptySquareBrackets = options.GetOption(GlslFormattingOptions.SpaceWithinEmptySquareBrackets)
                },

                SpacesPerIndent = options.GetOption(CodeAnalysis.Formatting.FormattingOptions.IndentationSize, LanguageNames.Glsl)
            };
        }

        public FormattingOptions GetPrimaryWorkspaceFormattingOptions()
        {
            return GetFormattingOptions(PrimaryWorkspace.Workspace.Options);
        }
    }
}