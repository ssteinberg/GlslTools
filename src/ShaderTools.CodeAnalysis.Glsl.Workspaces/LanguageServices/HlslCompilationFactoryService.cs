using ShaderTools.CodeAnalysis.Compilation;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Host;
using ShaderTools.CodeAnalysis.Host.Mef;
using ShaderTools.CodeAnalysis.Syntax;

namespace ShaderTools.CodeAnalysis.Glsl.LanguageServices
{
    [ExportLanguageService(typeof(ICompilationFactoryService), LanguageNames.Glsl)]
    internal sealed class GlslCompilationFactoryService : ICompilationFactoryService
    {
        public CompilationBase CreateCompilation(SyntaxTreeBase syntaxTree)
        {
            return new Compilation.Compilation((SyntaxTree) syntaxTree);
        }
    }
}
