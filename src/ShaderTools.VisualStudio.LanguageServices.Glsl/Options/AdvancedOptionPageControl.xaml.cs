using System;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Diagnostics;
using ShaderTools.CodeAnalysis.Editor.Options;
using ShaderTools.CodeAnalysis.Options;
using ShaderTools.VisualStudio.LanguageServices.Options.UI;

namespace ShaderTools.VisualStudio.LanguageServices.Glsl.Options
{
    public partial class AdvancedOptionPageControl : AbstractOptionPageControl
    {
        public AdvancedOptionPageControl(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            InitializeComponent();

            BindToOption(AddSemicolonForTypesCheckBox, BraceCompletionOptions.AddSemicolonForTypes, LanguageNames.Glsl);
            BindToOption(EnterOutliningModeWhenFilesOpenCheckBox, FeatureOnOffOptions.Outlining, LanguageNames.Glsl);
            BindToOption(EnableIntelliSenseCheckBox, FeatureOnOffOptions.IntelliSense, LanguageNames.Glsl);
            BindToOption(EnableErrorReportingCheckBox, DiagnosticsOptions.EnableErrorReporting, LanguageNames.Glsl);
            BindToOption(EnableSquigglesCheckBox, DiagnosticsOptions.EnableSquiggles, LanguageNames.Glsl);
        }
    }
}
