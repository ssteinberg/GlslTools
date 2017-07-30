using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.Editor.VisualStudio.Core.Glyphs;

namespace ShaderTools.Editor.VisualStudio.Glsl.IntelliSense.Completion
{
    [Export(typeof(ICompletionSourceProvider))]
    [ContentType(GlslConstants.ContentTypeName)]
    [Name(nameof(CompletionSourceProvider))]
    internal sealed class CompletionSourceProvider : ICompletionSourceProvider
    {
        [Import]
        public DispatcherGlyphService GlyphService { get; set; }

        public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
        {
            return new CompletionSource(GlyphService);
        }
    }
}