using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Windows.Media;
using ShaderTools.CodeAnalysis.Glsl.Classification;
using ShaderTools.VisualStudio.LanguageServices.Classification;

namespace ShaderTools.VisualStudio.LanguageServices.Glsl.Classification
{
    [Export(typeof(IClassificationColorProvider))]
    internal sealed class GlslClassificationColorProvider : IClassificationColorProvider
    {
        public ImmutableDictionary<string, Color> LightAndBlueColors
        {
            get
            {
                return new Dictionary<string, Color>
                    {
                    { GlslClassificationTypeNames.Punctuation, Colors.Black },
                    { GlslClassificationTypeNames.Semantic, Color.FromRgb(85, 107, 47) },
                    { GlslClassificationTypeNames.PackOffset, Colors.Purple },
                    { GlslClassificationTypeNames.RegisterLocation, Colors.LightCoral },
                    { GlslClassificationTypeNames.NamespaceIdentifier, Colors.Black },
                    { GlslClassificationTypeNames.GlobalVariableIdentifier, Color.FromRgb(72, 61, 139) },
                    { GlslClassificationTypeNames.FieldIdentifier, Color.FromRgb(139, 0, 139) },
                    { GlslClassificationTypeNames.LocalVariableIdentifier, Colors.Black },
                    { GlslClassificationTypeNames.ConstantBufferVariableIdentifier, Color.FromRgb(72, 61, 139) },
                    { GlslClassificationTypeNames.ParameterIdentifier, Colors.Black },
                    { GlslClassificationTypeNames.FunctionIdentifier, Color.FromRgb(0, 139, 139) },
                    { GlslClassificationTypeNames.MethodIdentifier, Color.FromRgb(0, 139, 139) },
                    { GlslClassificationTypeNames.ClassIdentifier, Color.FromRgb(0, 0, 139) },
                    { GlslClassificationTypeNames.StructIdentifier, Color.FromRgb(0, 0, 139) },
                    { GlslClassificationTypeNames.InterfaceIdentifier, Color.FromRgb(0, 0, 139) },
                    { GlslClassificationTypeNames.ConstantBufferIdentifier, Color.FromRgb(0, 0, 139) }
                }.ToImmutableDictionary();
            }
        }

        public ImmutableDictionary<string, Color> DarkColors
        {
            get
            {
                return new Dictionary<string, Color>
                {
                    { GlslClassificationTypeNames.Punctuation, Colors.White },
                    { GlslClassificationTypeNames.Semantic, Color.FromRgb(144, 238, 144) },
                    { GlslClassificationTypeNames.PackOffset, Colors.Pink },
                    { GlslClassificationTypeNames.RegisterLocation, Colors.LightCoral },
                    { GlslClassificationTypeNames.NamespaceIdentifier, Colors.White },
                    { GlslClassificationTypeNames.GlobalVariableIdentifier, Color.FromRgb(173, 216, 230) },
                    { GlslClassificationTypeNames.FieldIdentifier, Color.FromRgb(221, 160, 221) },
                    { GlslClassificationTypeNames.LocalVariableIdentifier, Color.FromRgb(220, 220, 220) },
                    { GlslClassificationTypeNames.ConstantBufferVariableIdentifier, Color.FromRgb(173, 216, 230) },
                    { GlslClassificationTypeNames.ParameterIdentifier, Color.FromRgb(220, 220, 220) },
                    { GlslClassificationTypeNames.FunctionIdentifier, Color.FromRgb(0, 255, 255) },
                    { GlslClassificationTypeNames.MethodIdentifier, Color.FromRgb(0, 255, 255) },
                    { GlslClassificationTypeNames.ClassIdentifier, Color.FromRgb(173, 216, 230) },
                    { GlslClassificationTypeNames.StructIdentifier, Color.FromRgb(173, 216, 230) },
                    { GlslClassificationTypeNames.InterfaceIdentifier, Color.FromRgb(173, 216, 230) },
                    { GlslClassificationTypeNames.ConstantBufferIdentifier, Color.FromRgb(173, 216, 230) }
                }.ToImmutableDictionary();
            }
        }
    }
}
