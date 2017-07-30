using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Xunit;

namespace ShaderTools.Editor.VisualStudio.Tests.Glsl.Tagging.Classification
{
#if false
    public class SyntaxTaggerTests : AsyncTaggerTestsBase
    {
        private readonly GlslClassificationService _GlslClassificationService;

        public SyntaxTaggerTests()
        {
            _GlslClassificationService = Container.GetExportedValue<GlslClassificationService>();
        }

        [Theory(Skip = "Need to update test")]
        //[GlslTestSuiteData]
        public async Task CanDoTagging(string testFile)
        {
            await RunTestAsync<SyntaxTagger, IClassificationTag>(testFile, CreateTagger);
        }

        private SyntaxTagger CreateTagger(BackgroundParser backgroundParser, ITextBuffer textBuffer)
        {
            return new SyntaxTagger(_GlslClassificationService, backgroundParser);
        }
    }
#endif
}