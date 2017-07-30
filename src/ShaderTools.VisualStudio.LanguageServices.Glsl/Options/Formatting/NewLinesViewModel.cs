using System;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Glsl.Formatting;
using ShaderTools.CodeAnalysis.Options;
using ShaderTools.VisualStudio.LanguageServices.Options.UI;

namespace ShaderTools.VisualStudio.LanguageServices.Glsl.Options.Formatting
{
    internal sealed class NewLinesViewModel : AbstractOptionPreviewViewModel
    {
        private const string TypePreview = @"
//[
struct S1 {
    float4 position;
    float3 normal;
};

struct S2
{
    float4 position;
    float3 normal;
};
//]";

        private const string TechniquePreview = @"
float4 VS() : SV_Position { return float4(1, 0, 0, 1); }
float4 PS() : SV_Target { return float4(1, 0, 0, 1); }
//[
technique T1 {
    pass P {
        VertexShader = compile vs_2_0 VS();
        PixelShader = compile ps_2_0 PS();
    }
}

technique T2
{
    pass P {
        VertexShader = compile vs_2_0 VS();
        PixelShader = compile ps_2_0 PS();
    }
}
//]";

        private const string FunctionPreview = @"
//[
float4 function1() {
    return float4(1, 0, 0, 1);
}

float4 function2()
{
    return float4(1, 0, 0, 1);
}
//]";

        private const string ControlBlockPreview = @"
void main()
{
//[
    for (int i = 0; i < 10; i++) {
        while (true)
        {
        }
    }
//]
}";

        private const string StateBlockPreview = @"
//[
DepthStencilState DepthDisabling {
	DepthEnable = FALSE;
	DepthWriteMask = ZERO;
};
DepthStencilState DepthEnabling
{
	DepthEnable = TRUE;
};
//]";

        private const string ArrayInitializerPreview = @"
//[
int arrayVariable1[2] = {
    1, 2
};
int arrayVariable2[2] =
{
    1, 2
};
//]";

        private const string ElsePreview = @"
void main()
{
//[
    if (false) {
    } else {
    }
//]
}";

        public NewLinesViewModel(OptionSet options, IServiceProvider serviceProvider)
            : base(options, serviceProvider, LanguageNames.Glsl)
        {
            AddOpenBraceGroup("openbracestypes", "Position of open braces for types", TypePreview, GlslFormattingOptions.OpenBracePositionForTypes);

            AddOpenBraceGroup("openbracestechniques", "Position of open braces for techniques and passes", TechniquePreview, GlslFormattingOptions.OpenBracePositionForTechniques);

            AddOpenBraceGroup("openbracesfunctions", "Position of open braces for functions", FunctionPreview, GlslFormattingOptions.OpenBracePositionForFunctions);

            AddOpenBraceGroup("openbracescontrolblocks", "Position of open braces for control blocks", ControlBlockPreview, GlslFormattingOptions.OpenBracePositionForControlBlocks);

            AddOpenBraceGroup("openbracesstateblocks", "Position of open braces for state blocks", StateBlockPreview, GlslFormattingOptions.OpenBracePositionForStateBlocks);

            AddOpenBraceGroup("openbracesarrayinitializers", "Position of open braces for array initializers", ArrayInitializerPreview, GlslFormattingOptions.OpenBracePositionForArrayInitializers);

            Items.Add(new HeaderItemViewModel { Header = "New line options for keywords" });

            Items.Add(new CheckBoxOptionViewModel(GlslFormattingOptions.PlaceElseOnNewLine, "Place \"else\" on new line", ElsePreview, this, Options));
        }

        private void AddOpenBraceGroup(
            string groupName, 
            string groupDescription, 
            string preview,
            Option<OpenBracesPosition> option)
        {
            Items.Add(new HeaderItemViewModel { Header = groupDescription });

            Items.Add(new RadioButtonViewModel<OpenBracesPosition>("Move to a new line", preview, groupName, OpenBracesPosition.MoveToNewLine, option, this, Options));
            Items.Add(new RadioButtonViewModel<OpenBracesPosition>("Keep on the same line, but add a space before", preview, groupName, OpenBracesPosition.KeepOnSameLineAndPrependSpace, option, this, Options));
            Items.Add(new RadioButtonViewModel<OpenBracesPosition>("Don't automatically reposition", preview, groupName, OpenBracesPosition.DoNotMove, option, this, Options));
        }
    }
}