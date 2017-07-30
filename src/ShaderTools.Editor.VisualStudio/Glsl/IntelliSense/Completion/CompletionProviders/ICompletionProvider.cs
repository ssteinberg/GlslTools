using System.Collections.Generic;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.Editor.VisualStudio.Glsl.IntelliSense.Completion.CompletionProviders
{
    internal interface ICompletionProvider
    {
        IEnumerable<CompletionItem> GetItems(SemanticModel semanticModel, SourceLocation position);
    }
}