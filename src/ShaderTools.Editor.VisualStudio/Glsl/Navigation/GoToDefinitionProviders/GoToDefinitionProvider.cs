﻿using System.Linq;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.Editor.VisualStudio.Glsl.Navigation.GoToDefinitionProviders
{
    internal abstract class GoToDefinitionProvider<T> : IGoToDefinitionProvider
        where T : SyntaxNode
    {
        public SourceFileSpan? GetTargetSpan(Document document, SemanticModel semanticModel, SourceLocation position)
        {
            var syntaxTree = semanticModel.Compilation.SyntaxTree;
            return ((SyntaxNode) syntaxTree.Root)
                .FindStartTokens(position, true)
                .Select(token => token.AncestorsAndSelf().OfType<T>().FirstOrDefault())
                .Where(t => t != null)
                .Select(t => CreateTargetSpan(document, semanticModel, position, t))
                .FirstOrDefault();
        }

        protected abstract SourceFileSpan? CreateTargetSpan(Document document, SemanticModel semanticModel, SourceLocation position, T node);
    }
}