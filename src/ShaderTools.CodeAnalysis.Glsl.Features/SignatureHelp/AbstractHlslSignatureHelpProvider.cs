using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShaderTools.CodeAnalysis.Glsl.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Symbols;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.SignatureHelp;
using ShaderTools.CodeAnalysis.Symbols;
using ShaderTools.CodeAnalysis.Symbols.Markup;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.SignatureHelp
{
    internal abstract class AbstractGlslSignatureHelpProvider<TNode> : AbstractSignatureHelpProvider
        where TNode : SyntaxNode
    {
        protected sealed override async Task<SignatureHelpItems> GetItemsWorkerAsync(Document document, int position, SignatureHelpTriggerInfo triggerInfo, CancellationToken cancellationToken)
        {
            var syntaxTree = await document.GetSyntaxTreeAsync(cancellationToken).ConfigureAwait(false);

            var sourceLocation = syntaxTree.MapRootFilePosition(position);
            var token = ((SyntaxNode) syntaxTree.Root).FindTokenOnLeft(sourceLocation);

            var node = token.Parent
                .AncestorsAndSelf()
                .OfType<TNode>()
                .FirstOrDefault(c => c.IsBetweenParentheses(sourceLocation));

            if (node == null)
                return null;

            var rootSpan = node.GetTextSpanRoot();
            if (rootSpan == null)
                return null;

            var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
            if (semanticModel == null)
                return null;

            return GetModel((SemanticModel) semanticModel, node, sourceLocation);
        }
        
        protected abstract SignatureHelpItems GetModel(SemanticModel semanticModel, TNode node, SourceLocation position);

        private static readonly IList<SymbolMarkupToken> _separatorParts = new List<SymbolMarkupToken>
        {
            new SymbolMarkupToken(SymbolMarkupKind.Punctuation, ","),
            new SymbolMarkupToken(SymbolMarkupKind.Whitespace, " ")
        };

        protected static IList<SymbolMarkupToken> GetSeparatorParts() => _separatorParts;

        protected static SignatureHelpSymbolParameter Convert(ParameterSymbol parameter)
        {
            return new SignatureHelpSymbolParameter(
                parameter.Name,
                parameter.HasDefaultValue,
                c => parameter.Documentation != null
                    ? ImmutableArray.Create(new TaggedText(TextTags.Text, parameter.Documentation))
                    : ImmutableArray<TaggedText>.Empty,
                parameter.ToMarkup(SymbolDisplayFormat.MinimallyQualified).Tokens);
        }
    }
}
