﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.SignatureHelp
{
    internal static class SignatureHelpExtensions
    {
        public static bool IsBetweenParentheses(this SyntaxNode node, SourceLocation position)
        {
            var argumentList = node.ChildNodes.SingleOrDefault(n => n.IsKind(SyntaxKind.ArgumentList));
            if (argumentList != null)
                return ((SyntaxNode) argumentList).IsBetweenParentheses(position);

            // If there is a nested ArgumentList that contains this position, don't show signature help for this node type.
            if (node.DescendantNodes().Any(x => x.Kind == SyntaxKind.ArgumentList && x.IsBetweenParentheses(position)))
                return false;

            var leftParenthesisToken = node.GetSingleChildToken(SyntaxKind.OpenParenToken);
            var rightParenthesisToken = node.GetSingleChildToken(SyntaxKind.CloseParenToken);
            var start = leftParenthesisToken.IsMissing ? leftParenthesisToken.SourceRange.Start : leftParenthesisToken.SourceRange.End;
            var end = rightParenthesisToken.IsMissing ? node.FullSourceRange.End : rightParenthesisToken.SourceRange.Start;

            return start <= position && position <= end;
        }

        private static SyntaxToken GetSingleChildToken(this SyntaxNode node, SyntaxKind tokenKind)
        {
            return (SyntaxToken) node.ChildNodes.Where(x => x.IsToken).Single(nt => nt.IsKind(tokenKind));
        }
    }
}
