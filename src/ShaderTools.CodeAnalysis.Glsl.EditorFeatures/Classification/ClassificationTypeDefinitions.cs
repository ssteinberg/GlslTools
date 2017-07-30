using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using ShaderTools.CodeAnalysis.Editor.Implementation.Classification;
using ShaderTools.CodeAnalysis.Glsl.Classification;

namespace ShaderTools.CodeAnalysis.Editor.Glsl.Classification
{
    internal sealed class ClassificationTypeDefinitions
    {
        [Export]
        [Name(GlslClassificationTypeNames.Punctuation)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition PunctuationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.Punctuation)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.Punctuation)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class PunctuationFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public PunctuationFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Punctuation";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.Punctuation);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.Semantic)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition SemanticType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.Semantic)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.Semantic)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class SemanticFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public SemanticFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Semantic";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.Semantic);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.PackOffset)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition PackOffsetType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.PackOffset)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.PackOffset)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class PackOffsetFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public PackOffsetFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Pack Offset";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.PackOffset);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.RegisterLocation)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition RegisterLocationType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.RegisterLocation)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.RegisterLocation)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class RegisterLocationFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public RegisterLocationFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Register Location";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.RegisterLocation);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.NamespaceIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition NamespaceIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.NamespaceIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.NamespaceIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class NamespaceIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public NamespaceIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Namespace Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.NamespaceIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.GlobalVariableIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition GlobalVariableIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.GlobalVariableIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.GlobalVariableIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class GlobalVariableIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public GlobalVariableIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Global Variable Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.GlobalVariableIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.FieldIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition FieldIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.FieldIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.FieldIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class FieldIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public FieldIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Field Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.FieldIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.LocalVariableIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition LocalVariableIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.LocalVariableIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.LocalVariableIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class LocalVariableIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public LocalVariableIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Local Variable Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.LocalVariableIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.ConstantBufferVariableIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition ConstantBufferVariableIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.ConstantBufferVariableIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.ConstantBufferVariableIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class ConstantBufferVariableIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public ConstantBufferVariableIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Constant Buffer Variable Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.ConstantBufferVariableIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.ParameterIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition ParameterIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.ParameterIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.ParameterIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class ParameterIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public ParameterIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Parameter Variable Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.ParameterIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.FunctionIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition FunctionIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.FunctionIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.FunctionIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class FunctionIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public FunctionIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Function Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.FunctionIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.MethodIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition MethodIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.MethodIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.MethodIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class MethodIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public MethodIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Method Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.MethodIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.ClassIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition ClassIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.ClassIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.ClassIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class ClassIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public ClassIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Class Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.ClassIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.StructIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition StructIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.StructIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.StructIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class StructIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public StructIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Struct Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.StructIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.InterfaceIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition InterfaceIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.InterfaceIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.InterfaceIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class InterfaceIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public InterfaceIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Interface Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.InterfaceIdentifier);
            }
        }

        [Export]
        [Name(GlslClassificationTypeNames.ConstantBufferIdentifier)]
        [BaseDefinition(PredefinedClassificationTypeNames.FormalLanguage)]
        public ClassificationTypeDefinition ConstantBufferIdentifierType { get; set; }

        [Export(typeof(EditorFormatDefinition))]
        [Name(GlslClassificationTypeNames.ConstantBufferIdentifier)]
        [ClassificationType(ClassificationTypeNames = GlslClassificationTypeNames.ConstantBufferIdentifier)]
        [UserVisible(true)]
        [Order(After = PredefinedClassificationTypeNames.String)]
        public sealed class ConstantBufferIdentifierFormat : ClassificationFormatDefinition
        {
            [ImportingConstructor]
            public ConstantBufferIdentifierFormat(IClassificationColorManager colorManager)
            {
                DisplayName = "GLSL Constant Buffer Identifier";
                ForegroundColor = colorManager.GetDefaultColor(GlslClassificationTypeNames.ConstantBufferIdentifier);
            }
        }
    }
}