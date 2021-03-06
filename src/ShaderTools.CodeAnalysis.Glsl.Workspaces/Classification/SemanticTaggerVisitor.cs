﻿using System.Collections.Generic;
using System.Threading;
using ShaderTools.CodeAnalysis.Classification;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Classification
{
    internal sealed class SemanticTaggerVisitor : SyntaxWalker
    {
        private readonly SemanticModel _semanticModel;
        private readonly List<ClassifiedSpan> _results;
        private readonly CancellationToken _cancellationToken;

        public SemanticTaggerVisitor(SemanticModel semanticModel, List<ClassifiedSpan> results, CancellationToken cancellationToken)
        {
            _semanticModel = semanticModel;
            _results = results;
            _cancellationToken = cancellationToken;
        }

        public override void Visit(SyntaxNode node)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            base.Visit(node);
        }

        public override void VisitAttribute(AttributeSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name.Name, GlslClassificationTypeNames.FunctionIdentifier);

            base.VisitAttribute(node);
        }

        public override void VisitInterfaceType(InterfaceTypeSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, GlslClassificationTypeNames.InterfaceIdentifier);

            base.VisitInterfaceType(node);
        }

        public override void VisitStructType(StructTypeSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, node.IsClass ? GlslClassificationTypeNames.ClassIdentifier : GlslClassificationTypeNames.StructIdentifier);

            base.VisitStructType(node);
        }

        public override void VisitConstantBuffer(ConstantBufferSyntax node)
        {
            CreateTag(node.Name, GlslClassificationTypeNames.ConstantBufferIdentifier);

            base.VisitConstantBuffer(node);
        }

        public override void VisitFunctionDefinition(FunctionDefinitionSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);
            if (symbol != null)
                CreateTag(node.Name.GetUnqualifiedName().Name, symbol.Parent != null && (symbol.Parent.Kind == SymbolKind.Class || symbol.Parent.Kind == SymbolKind.Struct)
                    ? GlslClassificationTypeNames.MethodIdentifier
                    : GlslClassificationTypeNames.FunctionIdentifier);

            base.VisitFunctionDefinition(node);
        }

        public override void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);
            if (symbol != null)
                CreateTag(node.Name.GetUnqualifiedName().Name, symbol.Parent != null && (symbol.Parent.Kind == SymbolKind.Class || symbol.Parent.Kind == SymbolKind.Struct)
                    ? GlslClassificationTypeNames.MethodIdentifier
                    : GlslClassificationTypeNames.FunctionIdentifier);

            base.VisitFunctionDeclaration(node);
        }

        public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            var symbol = _semanticModel.GetDeclaredSymbol(node);
            if (symbol != null)
                CreateTag(node.Identifier, GetClassificationType(symbol));

            base.VisitVariableDeclarator(node);
        }

        public override void VisitSemantic(SemanticSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Semantic, GlslClassificationTypeNames.Semantic);

            base.VisitSemantic(node);
        }

        public override void VisitRegisterLocation(RegisterLocation node)
        {
            CreateTag(node.Register, GlslClassificationTypeNames.RegisterLocation);
            base.VisitRegisterLocation(node);
        }

        public override void VisitLogicalRegisterSpace(LogicalRegisterSpace node)
        {
            CreateTag(node.SpaceToken, GlslClassificationTypeNames.RegisterLocation);
            base.VisitLogicalRegisterSpace(node);
        }

        public override void VisitPackOffsetLocation(PackOffsetLocation node)
        {
            CreateTag(node.Register, GlslClassificationTypeNames.PackOffset);
            if (node.ComponentPart != null)
            {
                CreateTag(node.ComponentPart.DotToken, GlslClassificationTypeNames.PackOffset);
                CreateTag(node.ComponentPart.Component, GlslClassificationTypeNames.PackOffset);
            }
            base.VisitPackOffsetLocation(node);
        }

        public override void VisitTypedefStatement(TypedefStatementSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node.Type);
            if (symbol != null)
            {
                var classificationType = GetClassificationType(symbol);
                foreach (var declarator in node.Declarators)
                    CreateTag(declarator.Identifier, classificationType);
            }
            base.VisitTypedefStatement(node);
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, GetClassificationType(symbol));

            base.VisitIdentifierName(node);
        }

        public override void VisitIdentifierDeclarationName(IdentifierDeclarationNameSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, GetClassificationType(symbol));

            base.VisitIdentifierDeclarationName(node);
        }

        public override void VisitFieldAccess(FieldAccessExpressionSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, GlslClassificationTypeNames.FieldIdentifier);

            base.VisitFieldAccess(node);
        }

        public override void VisitMethodInvocationExpression(MethodInvocationExpressionSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name, GlslClassificationTypeNames.MethodIdentifier);

            base.VisitMethodInvocationExpression(node);
        }

        public override void VisitFunctionInvocationExpression(FunctionInvocationExpressionSyntax node)
        {
            var symbol = _semanticModel.GetSymbol(node);
            if (symbol != null)
                CreateTag(node.Name.GetUnqualifiedName().Name, GlslClassificationTypeNames.FunctionIdentifier);

            base.VisitFunctionInvocationExpression(node);
        }

        private static string GetClassificationType(Symbol symbol)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Field:
                    return GlslClassificationTypeNames.FieldIdentifier;
                case SymbolKind.Parameter:
                    return GlslClassificationTypeNames.ParameterIdentifier;
                case SymbolKind.Variable:
                    return symbol.Parent == null
                        ? GlslClassificationTypeNames.GlobalVariableIdentifier
                        : (symbol.Parent.Kind == SymbolKind.ConstantBuffer)
                            ? GlslClassificationTypeNames.ConstantBufferVariableIdentifier
                            : GlslClassificationTypeNames.LocalVariableIdentifier;
                case SymbolKind.Class:
                    return GlslClassificationTypeNames.ClassIdentifier;
                case SymbolKind.Struct:
                    return GlslClassificationTypeNames.StructIdentifier;
                case SymbolKind.Interface:
                    return GlslClassificationTypeNames.InterfaceIdentifier;
                case SymbolKind.TypeAlias:
                    return GetClassificationType(((TypeAliasSymbol) symbol).ValueType);
                case SymbolKind.Function:
                    return GlslClassificationTypeNames.FunctionIdentifier;
                default:
                    return null;
            }
        }

        private void CreateTag(SyntaxToken token, string classificationType)
        {
            if (token == null || !token.FileSpan.IsInRootFile || token.MacroReference != null || classificationType == null)
                return;

            _results.Add(new ClassifiedSpan(token.FileSpan.Span, classificationType));
        }
    }
}