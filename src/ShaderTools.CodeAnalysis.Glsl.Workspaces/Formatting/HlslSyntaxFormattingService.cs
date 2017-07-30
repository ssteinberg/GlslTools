using System;
using System.Collections.Generic;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;
using ShaderTools.CodeAnalysis.Formatting;
using ShaderTools.CodeAnalysis.Glsl.Options;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Options;
using ShaderTools.CodeAnalysis.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Formatting
{
    [ExportLanguageService(typeof(ISyntaxFormattingService), LanguageNames.Glsl)]
    internal sealed class GlslSyntaxFormattingService : ISyntaxFormattingService
    {
        private readonly IGlslOptionsService _optionsService;

        [ImportingConstructor]
        public GlslSyntaxFormattingService(IGlslOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        public string Format(SyntaxTreeBase tree, TextSpan span, OptionSet options, CancellationToken cancellationToken)
        {
            var text = tree.Text;
            var edits = Formatter.GetEdits((SyntaxTree) tree, (SyntaxNode) tree.Root, span, _optionsService.GetFormattingOptions(options));
            return Formatter.ApplyEdits(text.ToString(), edits);
        }

        public Task<IFormattingResult> FormatAsync(SyntaxTreeBase tree, SyntaxNodeBase node, IEnumerable<TextSpan> spans, OptionSet options, CancellationToken cancellationToken)
        {
            var edits = new List<TextChange>();

            foreach (var span in spans)
                edits.AddRange(Formatter.GetEdits((SyntaxTree) tree, (SyntaxNode) node, span, _optionsService.GetFormattingOptions(options)));

            return Task.FromResult((IFormattingResult) new FormattingResult(edits));
        }
    }
}
