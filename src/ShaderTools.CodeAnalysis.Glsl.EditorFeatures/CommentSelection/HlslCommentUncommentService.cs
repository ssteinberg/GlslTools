using System.Composition;
using ShaderTools.CodeAnalysis.Editor.Implementation.CommentSelection;
using ShaderTools.CodeAnalysis.Host.Mef;

namespace ShaderTools.CodeAnalysis.Editor.Glsl.CommentSelection
{
    [ExportLanguageService(typeof(ICommentUncommentService), LanguageNames.Glsl), Shared]
    internal class GlslCommentUncommentService : AbstractCommentUncommentService
    {
        public override string SingleLineCommentString => "//";

        public override bool SupportsBlockComment => true;

        public override string BlockCommentStartString => "/*";

        public override string BlockCommentEndString => "*/";
    }
}
