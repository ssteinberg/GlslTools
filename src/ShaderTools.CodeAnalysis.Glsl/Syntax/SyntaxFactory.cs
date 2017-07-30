using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ShaderTools.CodeAnalysis.Glsl.Parser;
using ShaderTools.CodeAnalysis.Glsl.Text;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public static class SyntaxFactory
    {
        public static SyntaxTree ParseSyntaxTree(SourceText sourceText, ParserOptions options = null, IIncludeFileSystem fileSystem = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Parse(sourceText, options, fileSystem ?? new DummyFileSystem(), p => p.ParseCompilationUnit(cancellationToken));
        }

        public static CompilationUnitSyntax ParseCompilationUnit(SourceText sourceText, IIncludeFileSystem fileSystem = null)
        {
            return (CompilationUnitSyntax) Parse(sourceText, null, fileSystem, p => p.ParseCompilationUnit(CancellationToken.None)).Root;
        }

        public static SyntaxTree ParseExpression(string text)
        {
            return Parse(SourceText.From(text), null, null, p => p.ParseExpression());
        }

        public static StatementSyntax ParseStatement(string text)
        {
            return (StatementSyntax) Parse(SourceText.From(text), null, null, p => p.ParseStatement()).Root;
        }

        private static SyntaxTree Parse(SourceText sourceText, ParserOptions options, IIncludeFileSystem fileSystem, Func<GlslParser, SyntaxNode> parseFunc)
        {
            var sourceFile = new SourceFile(sourceText, null);

            var lexer = new GlslLexer(sourceFile, options, fileSystem);
            var parser = new GlslParser(lexer);

            var result = new SyntaxTree(sourceFile,
                syntaxTree => new Tuple<SyntaxNode, List<FileSegment>>(
                    parseFunc(parser),
                    lexer.FileSegments));

            Debug.WriteLine(DateTime.Now +  " - Finished parsing");

            return result;
        }

        public static SyntaxToken ParseToken(string text)
        {
            return new GlslLexer(new SourceFile(SourceText.From(text), null)).Lex(LexerMode.Syntax);
        }

        public static IReadOnlyList<SyntaxToken> ParseAllTokens(SourceText sourceText, IIncludeFileSystem fileSystem = null)
        {
            var tokens = new List<SyntaxToken>();

            var lexer = new GlslLexer(new SourceFile(sourceText, null), includeFileSystem: fileSystem);
            SyntaxToken token;
            do
            {
                tokens.Add(token = lexer.Lex(LexerMode.Syntax));
            } while (token.Kind != SyntaxKind.EndOfFileToken);

            return tokens;
        }
    }
}