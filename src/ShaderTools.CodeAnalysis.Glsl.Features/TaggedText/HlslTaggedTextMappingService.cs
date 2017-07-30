using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Glsl.Classification;
using ShaderTools.CodeAnalysis.Classification;

namespace ShaderTools.CodeAnalysis.Glsl
{
    [ExportLanguageService(typeof(ITaggedTextMappingService), LanguageNames.Glsl)]
    internal sealed class GlslTaggedTextMappingService : AbstractTaggedTextMappingService
    {
        public override string GetClassificationTypeName(string taggedTextTag)
        {
            switch (taggedTextTag)
            {
                case TextTags.Punctuation:
                    return GlslClassificationTypeNames.Punctuation;

                case TextTags.Semantic:
                    return GlslClassificationTypeNames.Semantic;

                case TextTags.PackOffset:
                    return GlslClassificationTypeNames.PackOffset;

                case TextTags.RegisterLocation:
                    return GlslClassificationTypeNames.RegisterLocation;

                case TextTags.Namespace:
                    return GlslClassificationTypeNames.NamespaceIdentifier;

                case TextTags.Global:
                    return GlslClassificationTypeNames.GlobalVariableIdentifier;

                case TextTags.Field:
                    return GlslClassificationTypeNames.FieldIdentifier;

                case TextTags.Local:
                    return GlslClassificationTypeNames.LocalVariableIdentifier;

                case TextTags.ConstantBufferField:
                    return GlslClassificationTypeNames.ConstantBufferVariableIdentifier;

                case TextTags.Parameter:
                    return GlslClassificationTypeNames.ParameterIdentifier;

                case TextTags.Function:
                    return GlslClassificationTypeNames.FunctionIdentifier;

                case TextTags.Method:
                    return GlslClassificationTypeNames.MethodIdentifier;

                case TextTags.Class:
                    return GlslClassificationTypeNames.ClassIdentifier;

                case TextTags.Struct:
                    return GlslClassificationTypeNames.StructIdentifier;

                case TextTags.Interface:
                    return GlslClassificationTypeNames.InterfaceIdentifier;

                case TextTags.ConstantBuffer:
                    return GlslClassificationTypeNames.ConstantBufferIdentifier;

                case TextTags.Technique:
                    return ClassificationTypeNames.Identifier;

                default:
                    return base.GetClassificationTypeName(taggedTextTag);
            }
        }
    }
}
