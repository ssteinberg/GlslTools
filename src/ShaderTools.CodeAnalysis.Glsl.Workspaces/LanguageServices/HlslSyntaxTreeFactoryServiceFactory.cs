using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.Host;
using ShaderTools.CodeAnalysis.Host.Mef;

namespace ShaderTools.CodeAnalysis.Glsl.LanguageServices
{
    [ExportLanguageServiceFactory(typeof(ISyntaxTreeFactoryService), LanguageNames.Glsl)]
    internal sealed class GlslSyntaxTreeFactoryServiceFactory : ILanguageServiceFactory
    {
        public ILanguageService CreateLanguageService(HostLanguageServices languageServices)
        {
            return new GlslSyntaxTreeFactoryService(
                languageServices.WorkspaceServices.Workspace,
                languageServices.WorkspaceServices.GetRequiredService<IWorkspaceIncludeFileSystem>());
        }
    }
}
