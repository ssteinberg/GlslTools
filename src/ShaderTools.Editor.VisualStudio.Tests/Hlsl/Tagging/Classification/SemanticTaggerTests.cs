using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Xunit;

namespace ShaderTools.Editor.VisualStudio.Tests.Glsl.Tagging.Classification
{
#if false
    public class SemanticTaggerTests : AsyncTaggerTestsBase
    {
        private readonly GlslClassificationService _GlslClassificationService;

        public SemanticTaggerTests()
        {
            _GlslClassificationService = Container.GetExportedValue<GlslClassificationService>();
        }

        [Theory(Skip = "Need to update test")]
        //[GlslTestSuiteData]
        public async Task CanDoTagging(string testFile)
        {
            await RunTestAsync<SemanticTagger, IClassificationTag>(testFile, CreateTagger);
        }

        private SemanticTagger CreateTagger(BackgroundParser backgroundParser, ITextBuffer textBuffer)
        {
            return new SemanticTagger(_GlslClassificationService, backgroundParser);
        }
    }
#endif
}