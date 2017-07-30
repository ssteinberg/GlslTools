using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace ShaderTools.CodeAnalysis.Editor.Glsl.ContentType
{
    internal static class ContentTypeDefinitions
    {
        /// <summary>
        /// Definition of the primary Glsl content type.
        /// </summary>
        [Export]
        [Name(ContentTypeNames.GlslContentType)]
        [BaseDefinition(ContentTypeNames.ShaderToolsContentType)]
        public static readonly ContentTypeDefinition GlslContentTypeDefinition;

        [Export]
        [Name(ContentTypeNames.GlslSignatureHelpContentType)]
        [BaseDefinition("sighelp")]
        public static readonly ContentTypeDefinition SignatureHelpContentTypeDefinition;
    }
}
