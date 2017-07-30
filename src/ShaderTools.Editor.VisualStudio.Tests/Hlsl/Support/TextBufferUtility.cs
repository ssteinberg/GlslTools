using System.ComponentModel.Composition.Hosting;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.Editor.VisualStudio.Glsl;

namespace ShaderTools.Editor.VisualStudio.Tests.Glsl.Support
{
    internal static class TextBufferUtility
    {
        public static ITextBuffer CreateTextBuffer(CompositionContainer container, string text)
        {
            var contentTypeRegistry = container.GetExportedValue<IContentTypeRegistryService>();
            var contentType = contentTypeRegistry.GetContentType(GlslConstants.ContentTypeName)
                ?? contentTypeRegistry.AddContentType(GlslConstants.ContentTypeName, null);

            var textBufferFactory = container.GetExportedValue<ITextBufferFactoryService>();
            var textBuffer = textBufferFactory.CreateTextBuffer(text, contentType);

            return textBuffer;
        }
    }
}