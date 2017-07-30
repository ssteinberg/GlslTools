using System.Runtime.InteropServices;
using ShaderTools.Editor.VisualStudio.Core;
using ShaderTools.VisualStudio.LanguageServices;

namespace ShaderTools.Editor.VisualStudio.Glsl
{
    [Guid(Guids.GlslLanguageServiceIdString)]
    internal sealed class GlslLanguageInfo : LanguageInfoBase
    {
        public GlslLanguageInfo(LanguagePackageBase languagePackage)
            : base(languagePackage)
        {
        }

        internal override string LanguageName { get; } = GlslConstants.LanguageName;
    }
}