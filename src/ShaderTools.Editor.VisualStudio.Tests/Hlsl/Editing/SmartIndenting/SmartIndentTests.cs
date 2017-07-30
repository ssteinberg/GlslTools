﻿using ShaderTools.CodeAnalysis.Editor.Glsl.SmartIndent;
using ShaderTools.CodeAnalysis.Editor.Implementation.SmartIndent;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;
using Xunit;

namespace ShaderTools.Editor.VisualStudio.Tests.Glsl.Editing.SmartIndenting
{
    public class SmartIndentTests : VisualStudioTestsBase
    {
        [Fact]
        public void TestIndent()
        {
            T(@"struct S
{
    |
};");
            T(@"struct S
{
    |
};
");
            T(@"void foo()
{
    if (true)
    {
        |
    }
}");
            T(@"void foo()
{
    if (true)
    {
        while (true)
        {
            |
        }
    }
}");
            T(@"struct S
{
    |
    float f;
    int i;
};");
            T(@"struct S
{
};
|
");
        }

        private static void T(string codeWithCaret)
        {
            int caret = codeWithCaret.IndexOf('|');
            int expectedIndent = 0;
            while (caret - expectedIndent > 1 && codeWithCaret[caret - expectedIndent - 1] == ' ')
            {
                expectedIndent++;
            }

            var indentationService = new GlslIndentationService();
            var syntaxFactsService = new GlslSyntaxFactsService();

            var code = codeWithCaret.Remove(caret, 1);
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(code));
            var actualIndent = SmartIndent.FindTotalParentChainIndent((SyntaxNode) syntaxTree.Root, caret, 0, indentationService, syntaxFactsService);
            Assert.Equal(expectedIndent, actualIndent);
        }
    }
}