using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Parser
{
    public interface ILexer
    {
        //SourceText Text { get; }

        SyntaxToken Lex(LexerMode mode);
    }
}