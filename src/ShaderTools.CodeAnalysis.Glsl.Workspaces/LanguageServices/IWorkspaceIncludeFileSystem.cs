using ShaderTools.CodeAnalysis.Glsl.Text;
using ShaderTools.CodeAnalysis.Host;

namespace ShaderTools.CodeAnalysis.Glsl.LanguageServices
{
    internal interface IWorkspaceIncludeFileSystem : IIncludeFileSystem, IWorkspaceService
    {
    }
}
