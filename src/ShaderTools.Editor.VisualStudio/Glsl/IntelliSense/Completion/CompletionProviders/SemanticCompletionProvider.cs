using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;
using ShaderTools.Editor.VisualStudio.Core.Glyphs;

namespace ShaderTools.Editor.VisualStudio.Glsl.IntelliSense.Completion.CompletionProviders
{
    [Export(typeof(ICompletionProvider))]
    internal sealed class SemanticCompletionProvider : CompletionProvider<SemanticSyntax>
    {
        protected override IEnumerable<CompletionItem> GetItems(SemanticModel semanticModel, SourceLocation position, SemanticSyntax node)
        {
            if (node.ColonToken.IsMissing || position < node.ColonToken.SourceRange.End)
                return Enumerable.Empty<CompletionItem>();

            // If semantic is used on a variable declaration inside a struct, try to use the name of the struct
            // to guess the shader type it is applied to.
            var parentStruct = node.Ancestors().OfType<StructTypeSyntax>().FirstOrDefault();
            var structUsage = GuessUsage(parentStruct);

            var availableSemantics = semanticModel
                .LookupSymbols(node.Semantic.SourceRange.Start)
                .OfType<SemanticSymbol>();

            if (structUsage != SemanticUsages.None)
                availableSemantics = availableSemantics.Where(x => x.Usages.HasFlag(structUsage));

            return availableSemantics.Select(x => new CompletionItem($"{x.Name}{(x.AllowsMultiple ? "[n]" : "")}", x.Name, $"(semantic) {x.Name}\n{x.FullDescription}", Glyph.Semantic));
        }

        private static SemanticUsages GuessUsage(StructTypeSyntax structSyntax)
        {
            if (structSyntax == null || structSyntax.Name.IsMissing)
                return SemanticUsages.None;

            var structName = structSyntax.Name.Text;

            if (Contains(structName, "vs") || Contains(structName, "vertexshader"))
            {
                if (Contains(structName, "in") || Contains(structName, "input"))
                    return SemanticUsages.VertexShaderInput;
                if (Contains(structName, "out") || Contains(structName, "output"))
                    return SemanticUsages.VertexShaderOutput;
            }

            if (Contains(structName, "gs") || Contains(structName, "geometryshader"))
            {
                if (Contains(structName, "in") || Contains(structName, "input"))
                    return SemanticUsages.GeometryShaderInput;
                if (Contains(structName, "out") || Contains(structName, "output"))
                    return SemanticUsages.GeometryShaderOutput;
            }

            if (Contains(structName, "hs") || Contains(structName, "hullshader"))
            {
                if (Contains(structName, "in") || Contains(structName, "input"))
                    return SemanticUsages.TessControlShaderInput;
                if (Contains(structName, "out") || Contains(structName, "output"))
                    return SemanticUsages.TessControlShaderOutput;
            }

            if (Contains(structName, "ds") || Contains(structName, "domainshader"))
            {
                if (Contains(structName, "in") || Contains(structName, "input"))
                    return SemanticUsages.TessEvalShaderInput;
                if (Contains(structName, "out") || Contains(structName, "output"))
                    return SemanticUsages.TessEvalShaderOutput;
            }

            if (Contains(structName, "ps") || Contains(structName, "pixelshader"))
            {
                if (Contains(structName, "in") || Contains(structName, "input"))
                    return SemanticUsages.PixelShaderInput;
                if (Contains(structName, "out") || Contains(structName, "output"))
                    return SemanticUsages.PixelShaderOutput;
            }

            return SemanticUsages.None;
        }

        private static bool Contains(string text, string value)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase) != -1;
        }
    }
}