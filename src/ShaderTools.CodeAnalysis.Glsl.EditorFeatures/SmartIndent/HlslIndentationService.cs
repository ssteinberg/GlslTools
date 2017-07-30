﻿using ShaderTools.CodeAnalysis.Editor.Implementation.SmartIndent;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Syntax;

namespace ShaderTools.CodeAnalysis.Editor.Glsl.SmartIndent
{
    [ExportLanguageService(typeof(IIndentationService), LanguageNames.Glsl)]
    internal sealed class GlslIndentationService : IIndentationService
    {
        public bool ShouldIndent(SyntaxNodeBase nodeBase)
        {
            var node = (SyntaxNode) nodeBase;

            if (node.Kind == SyntaxKind.ElseClause)
                return false;

            switch (node.Parent.Kind)
            {
                case SyntaxKind.Block:
                    return true;

                case SyntaxKind.IfStatement:
                case SyntaxKind.DoStatement:
                case SyntaxKind.WhileStatement:
                case SyntaxKind.ForStatement:
                case SyntaxKind.SwitchStatement:
                    return node.Kind != SyntaxKind.Block;

                case SyntaxKind.Namespace:
                case SyntaxKind.ConstantBufferDeclaration:
                case SyntaxKind.ClassType:
                case SyntaxKind.StructType:
                case SyntaxKind.InterfaceType:
                case SyntaxKind.ArrayInitializerExpression:
                    return true;

                default:
                    return false;
            }
        }
    }
}
