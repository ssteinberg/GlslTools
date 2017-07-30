using System.IO;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Glsl.Tests.Support;
using ShaderTools.CodeAnalysis.Glsl.Tests.TestSuite;
using ShaderTools.CodeAnalysis.Text;
using ShaderTools.Testing;
using Xunit;

namespace ShaderTools.CodeAnalysis.Glsl.Tests.Parser
{
    public class RoundtrippingTests
    {
        [Theory]
        [GlslTestSuiteData]
        public void CanBuildSyntaxTree(string testFile)
        {
            var sourceCode = File.ReadAllText(testFile);

            // Build syntax tree.
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(sourceCode, testFile), fileSystem: new TestFileSystem());

            SyntaxTreeUtility.CheckForParseErrors(syntaxTree);

            // Check roundtripping.
            var roundtrippedText = syntaxTree.Root.ToFullString();
            Assert.Equal(sourceCode, roundtrippedText);
        }
    }
}