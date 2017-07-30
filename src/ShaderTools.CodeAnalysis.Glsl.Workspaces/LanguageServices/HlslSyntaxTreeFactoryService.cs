using System.IO;
using System.Threading;
using ShaderTools.CodeAnalysis.Glsl.Parser;
using ShaderTools.CodeAnalysis.Glsl.Syntax;
using ShaderTools.CodeAnalysis.Glsl.Text;
using ShaderTools.CodeAnalysis.Host;
using ShaderTools.CodeAnalysis.Syntax;
using ShaderTools.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Glsl.LanguageServices
{
    internal sealed class GlslSyntaxTreeFactoryService : ISyntaxTreeFactoryService
    {
        private readonly Workspace _workspace;
        private readonly IIncludeFileSystem _fileSystem;

        public GlslSyntaxTreeFactoryService(Workspace workspace, IIncludeFileSystem fileSystem)
        {
            _workspace = workspace;
            _fileSystem = fileSystem;
        }

        public SyntaxTreeBase ParseSyntaxTree(SourceText text, CancellationToken cancellationToken)
        {
            var configFile = _workspace.LoadConfigFile(Path.GetDirectoryName(text.FilePath));

            var options = new ParserOptions();
            options.PreprocessorDefines.Add("__INTELLISENSE__", "1");

            foreach (var kvp in configFile.GlslPreprocessorDefinitions)
                options.PreprocessorDefines.Add(kvp.Key, kvp.Value);

            options.AdditionalIncludeDirectories.AddRange(configFile.GlslAdditionalIncludeDirectories);

            return SyntaxFactory.ParseSyntaxTree(
                text,
                options,
                _fileSystem,
                cancellationToken);
        }
    }
}
