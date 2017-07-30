using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Structure;

namespace ShaderTools.CodeAnalysis.Glsl.Structure
{
    [ExportLanguageService(typeof(IBlockStructureProvider), LanguageNames.Glsl)]
    internal sealed class GlslBlockStructureProvider : IBlockStructureProvider
    {
        public async Task<ImmutableArray<BlockSpan>> ProvideBlockStructureAsync(Document document, CancellationToken cancellationToken)
        {
            var results = ImmutableArray.CreateBuilder<BlockSpan>();
            var outliningVisitor = new OutliningVisitor(document.SourceText, results, cancellationToken);

            var syntaxTree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);
            if (syntaxTree != null)
                outliningVisitor.VisitCompilationUnit((CompilationUnitSyntax) syntaxTree.Root);

            return results.ToImmutable();
        }
    }
}
