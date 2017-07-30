using System.Collections.Generic;
using System.IO;
using ShaderTools.CodeAnalysis.Options;
using Xunit;

namespace ShaderTools.CodeAnalysis.Tests.Options
{
    public class ConfigFileTests
    {
        [Fact]
        public void CanLoadConfigFile()
        {
            var configFile = ConfigFileLoader.LoadAndMergeConfigFile(Path.GetFullPath(@"Options\Assets\ChildFolder\GrandchildFolder"));

            Assert.Equal(
                new Dictionary<string, string>
                {
                    { "MY_DEFINE", "1" },
                    { "MY_OTHER_DEFINE", "2" }
                }, 
                configFile.GlslPreprocessorDefinitions);

            var workingDirectory = Path.GetFullPath(@"Options\Assets");
            Assert.Equal(
                new string[]
                {
                    Path.Combine(workingDirectory, "ChildFolder", "Bar"),
                    Path.Combine(workingDirectory, "ChildFolder", "Foo"),
                    Path.Combine(workingDirectory, "ChildFolder"),
                    workingDirectory
                },
                configFile.GlslAdditionalIncludeDirectories);
        }

        [Fact]
        public void CanLoadConfigFileWithMissingSettings()
        {
            var configFile = ConfigFileLoader.LoadAndMergeConfigFile(Path.GetFullPath(@"Options\Assets\Folder2"));

            Assert.Empty(configFile.GlslPreprocessorDefinitions);
            Assert.Empty(configFile.GlslAdditionalIncludeDirectories);
        }
    }
}