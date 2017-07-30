using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using ShaderTools.Editor.VisualStudio.Core;
using ShaderTools.Editor.VisualStudio.Core.Navigation;
using ShaderTools.Editor.VisualStudio.Core.Util.Extensions;
using ShaderTools.Editor.VisualStudio.Glsl.Navigation;
using ShaderTools.VisualStudio.LanguageServices;
using ShaderTools.VisualStudio.LanguageServices.Glsl.Options.Formatting;
using ShaderTools.VisualStudio.LanguageServices.Registration;

namespace ShaderTools.Editor.VisualStudio.Glsl
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [Guid(Guids.GlslPackageIdString)]

    [ProvideLanguageService(typeof(GlslLanguageInfo), GlslConstants.LanguageName, 0,
        ShowCompletion = true,
        ShowSmartIndent = true,
        ShowDropDownOptions = true,
        EnableAdvancedMembersOption = true,
        DefaultToInsertSpaces = true,
        EnableLineNumbers = true,
        RequestStockColors = true)]

    [ProvideService(typeof(GlslLanguageInfo), ServiceName = "GLSL Language Service")]

    [ProvideLanguageEditorOptionPage(typeof(AdvancedOptionPage), GlslConstants.LanguageName, null, "Advanced", "120")]
    [ProvideLanguageEditorOptionPage(typeof(FormattingOptionPage), GlslConstants.LanguageName, "Formatting", "General", "123")]
    [ProvideLanguageEditorOptionPage(typeof(FormattingIndentationOptionPage), GlslConstants.LanguageName, "Formatting", "Indentation", "124")]
    [ProvideLanguageEditorOptionPage(typeof(FormattingNewLinesPage), GlslConstants.LanguageName, "Formatting", "New Lines", "125")]
    [ProvideLanguageEditorOptionPage(typeof(FormattingSpacingPage), GlslConstants.LanguageName, "Formatting", "Spacing", "126")]

    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension1)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension2)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension3)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension4)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension5)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension6)]
    [ProvideLanguageExtension(typeof(GlslLanguageInfo), GlslConstants.FileExtension7)]

    // Adds support for user mapping of custom file extensions.
    [ProvideFileExtensionMapping(
        "{A95B1F48-2A2E-492C-BABE-8DCC8A4643A8}", 
        "GLSL Editor", 
        typeof(IVsEditorFactory), // A bit weird, but seems to work, and means we don't need to implement IVsEditorFactory ourselves.
        typeof(GlslLanguageInfo),
        Guids.GlslPackageIdString, 
        100)]

    [ProvideBraceCompletion(GlslConstants.LanguageName)]
    internal sealed class GlslPackage : LanguagePackageBase
    {
        public static GlslPackage Instance { get; private set; }

        protected override CodeWindowManagerBase CreateCodeWindowManager(IVsCodeWindow window)
        {
            return new CodeWindowManager(this, window, this.AsVsServiceProvider());
        }

        protected override LanguageInfoBase CreateLanguageInfo()
        {
            return new GlslLanguageInfo(this);
        }

        protected override void Initialize()
        {
            Instance = this;        

            base.Initialize();
        }
    }
}