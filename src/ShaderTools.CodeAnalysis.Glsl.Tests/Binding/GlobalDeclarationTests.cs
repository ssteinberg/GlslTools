using System.Collections.Immutable;
using System.Linq;
using ShaderTools.CodeAnalysis.Glsl.Diagnostics;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;
using Xunit;

namespace ShaderTools.CodeAnalysis.Glsl.Tests.Binding
{
    public class GlobalDeclarationTests
    {
        [Fact]
        public void DetectsRedefinitionAsVariable()
        {
            var code = @"
struct foo {};
int foo;";
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(code));
            var compilation = new CodeAnalysis.Glsl.Compilation.Compilation(syntaxTree);
            var semanticModel = compilation.GetSemanticModel();
            var diagnostics = syntaxTree.GetDiagnostics().Concat(semanticModel.GetDiagnostics()).ToImmutableArray();

            Assert.Equal(1, diagnostics.Length);
            Assert.Equal(DiagnosticId.SymbolRedefined, (DiagnosticId) diagnostics[0].Descriptor.Code);
        }

        [Fact]
        public void DetectsRedefinitionAsFunction()
        {
            var code = @"
struct foo {};
void foo();";
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(code));
            var compilation = new CodeAnalysis.Glsl.Compilation.Compilation(syntaxTree);
            var semanticModel = compilation.GetSemanticModel();
            var diagnostics = syntaxTree.GetDiagnostics().Concat(semanticModel.GetDiagnostics()).ToImmutableArray();

            Assert.Equal(1, diagnostics.Length);
            Assert.Equal(DiagnosticId.SymbolRedefined, (DiagnosticId) diagnostics[0].Descriptor.Code);
        }

        [Fact]
        public void DetectsUndeclaredVariable()
        {
            var code = @"
void main()
{
    int foo = a;
}";
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(SourceText.From(code));
            var compilation = new CodeAnalysis.Glsl.Compilation.Compilation(syntaxTree);
            var semanticModel = compilation.GetSemanticModel();
            var diagnostics = syntaxTree.GetDiagnostics().Concat(semanticModel.GetDiagnostics()).ToImmutableArray();

            Assert.Equal(1, diagnostics.Length);
            Assert.Equal(DiagnosticId.UndeclaredVariable, (DiagnosticId) diagnostics[0].Descriptor.Code);
        }
    }
}