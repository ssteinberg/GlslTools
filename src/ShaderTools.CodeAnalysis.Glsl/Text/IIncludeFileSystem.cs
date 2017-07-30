using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Text
{
    public interface IIncludeFileSystem
    {
        bool TryGetFile(string path, out SourceText text);
    }
}