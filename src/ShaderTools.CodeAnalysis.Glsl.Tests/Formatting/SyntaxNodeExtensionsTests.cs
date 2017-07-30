using System.IO;
using System.Text;
using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Glsl.Tests.Support;
using ShaderTools.CodeAnalysis.Glsl.Tests.TestSuite;
using ShaderTools.CodeAnalysis.Text;
using Xunit;

namespace ShaderTools.CodeAnalysis.Glsl.Tests.Formatting
{
    public class SyntaxNodeExtensionsTests
    {
        [Theory]
        [GlslTestSuiteData]
        public void CanGetRootLocatedNodes(string testFile)
        {
            var sourceCode = File.ReadAllText(testFile);

            // Build syntax tree.
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(
                SourceText.From(sourceCode, testFile), 
                fileSystem: new TestFileSystem());

            // Check roundtripping.
            var allRootTokensAndTrivia = ((SyntaxNode) syntaxTree.Root).GetRootLocatedNodes();
            var sb = new StringBuilder();
            foreach (var locatedNode in allRootTokensAndTrivia)
                sb.Append(locatedNode.Text);
            var roundtrippedText = sb.ToString();
            Assert.Equal(sourceCode, roundtrippedText);
        }
    }
}