using System.Collections.Generic;
using ShaderTools.CodeAnalysis.Diagnostics;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Syntax
{
    public abstract class LocatedNode : SyntaxNode
    {
        public SourceFileSpan FileSpan { get; }
        public string Text { get; }

        protected LocatedNode(SyntaxKind kind, string text, SourceFileSpan span, IEnumerable<Diagnostic> diagnostics)
            : base(kind, diagnostics)
        {
            Text = text;
            FileSpan = span;
        }
    }
}