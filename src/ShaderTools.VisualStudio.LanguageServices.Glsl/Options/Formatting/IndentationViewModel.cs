﻿using System;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Options;
using ShaderTools.VisualStudio.LanguageServices.Options.UI;

namespace ShaderTools.VisualStudio.LanguageServices.Glsl.Options.Formatting
{
    internal sealed class IndentationViewModel : AbstractOptionPreviewViewModel
    {
        private const string BlockContentPreview = @"
class C {
//[
    int Method() {
        int x;
        int y;
    }
//]
}";

        private const string IndentBracePreview = @"
class C {
//[
    int Method() {
        return 0;
    }
//]
}";

        private const string SwitchCasePreview = @"
class MyClass
{
    int Method(int foo){
//[
        switch (foo){
        case 2:
            break;
        }
//]
    }
}";

        private const string PreprocessorDirectivePreview = @"
float4 ReadTexture() { return float4(1, 0, 0, 1); }
//[
void main()
{
    #if TEXTURES
    float4 color = ReadTexture();
    #endif
}
//]";
        
        public IndentationViewModel(OptionSet options, IServiceProvider serviceProvider) 
            : base(options, serviceProvider, LanguageNames.Glsl)
        {
            Items.Add(new CheckBoxOptionViewModel(GlslFormattingOptions.IndentBlockContents, "Indent block contents", BlockContentPreview, this, Options));
            Items.Add(new CheckBoxOptionViewModel(GlslFormattingOptions.IndentOpenAndCloseBraces, "Indent open and close braces", IndentBracePreview, this, Options));
            Items.Add(new CheckBoxOptionViewModel(GlslFormattingOptions.IndentCaseContents, "Indent case contents", SwitchCasePreview, this, Options));
            Items.Add(new CheckBoxOptionViewModel(GlslFormattingOptions.IndentCaseLabels, "Indent case labels", SwitchCasePreview, this, Options));

            Items.Add(new HeaderItemViewModel { Header = "Preprocessor directive indentation" });

            Items.Add(new RadioButtonViewModel<PreprocessorDirectivePosition>("One indent to the left", PreprocessorDirectivePreview, "directive", PreprocessorDirectivePosition.OneIndentToLeft, GlslFormattingOptions.PreprocessorDirectivePosition, this, Options));
            Items.Add(new RadioButtonViewModel<PreprocessorDirectivePosition>("Move to the leftmost column", PreprocessorDirectivePreview, "directive", PreprocessorDirectivePosition.MoveToLeftmostColumn, GlslFormattingOptions.PreprocessorDirectivePosition, this, Options));
            Items.Add(new RadioButtonViewModel<PreprocessorDirectivePosition>("Leave indented", PreprocessorDirectivePreview, "directive", PreprocessorDirectivePosition.LeaveIndented, GlslFormattingOptions.PreprocessorDirectivePosition, this, Options));
        }
    }
}
