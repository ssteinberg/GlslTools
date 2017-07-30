using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.Text
{
    internal sealed class DummyFileSystem : IIncludeFileSystem
    {
        public bool TryGetFile(string path, out SourceText text)
        {
            text = null;
            return false;
        }
    }
}