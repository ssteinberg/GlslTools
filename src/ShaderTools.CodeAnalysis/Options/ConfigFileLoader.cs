using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ShaderTools.CodeAnalysis.Options
{
    public static class ConfigFileLoader
    {
        private static readonly DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(ConfigFile), new DataContractJsonSerializerSettings()
        {
            UseSimpleDictionaryFormat = true
        });

        public static ConfigFile LoadAndMergeConfigFile(string directory)
        {
            if (directory == null)
                return new ConfigFile();

            if (!Path.IsPathRooted(directory))
                throw new ArgumentException();

            var configFiles = GetConfigFiles(directory);

            // We want closer config files to take precedence over further ones.

            var GlslPreprocessorDefinitions = new Dictionary<string, string>();
            foreach (var configFile in configFiles.Reverse())
                foreach (var preprocessorDefinition in configFile.GlslPreprocessorDefinitions)
                    GlslPreprocessorDefinitions[preprocessorDefinition.Key] = preprocessorDefinition.Value;

            return new ConfigFile
            {
                GlslPreprocessorDefinitions = GlslPreprocessorDefinitions,

                GlslAdditionalIncludeDirectories = configFiles
                    .SelectMany(x => x.GetAbsoluteGlslAdditionalIncludeDirectories())
                    .Distinct()
                    .ToList()
            };
        }

        private static IEnumerable<ConfigFile> GetConfigFiles(string initialDirectory)
        {
            var directoryInfo = new DirectoryInfo(initialDirectory);

            var result = new List<ConfigFile>();
            while (true)
            {
                var configFilePath = Path.Combine(directoryInfo.FullName, "shadertoolsconfig.json");
                if (File.Exists(configFilePath))
                {
                    try
                    {
                        ConfigFile configFile;

                        // Workaround for weird DataContractJsonSerializer issue when JSON file starts with BOM.
                        var configFileText = File.ReadAllText(configFilePath);
                        using (var configFileStream = new MemoryStream(Encoding.UTF8.GetBytes(configFileText)))
                            configFile = (ConfigFile) Serializer.ReadObject(configFileStream);

                        configFile.FileName = configFilePath;
                        result.Add(configFile);

                        if (configFile.Root)
                            break;
                    }
                    catch (Exception)
                    {
                        // TODO: Log exception somewhere user can see it.
                    }
                }

                directoryInfo = directoryInfo.Parent;
                if (directoryInfo == null)
                    break;
            }
            return result;
        }
    }
}