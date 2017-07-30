using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace ShaderTools.CodeAnalysis.Options
{
    [DataContract]
    public sealed class ConfigFile
    {
        // Not stored in file.
        internal string FileName { get; set; }

        [DataMember(Name = "root")]
        public bool Root { get; set; } = false;

        [DataMember(Name = "Glsl.preprocessorDefinitions")]
        public Dictionary<string, string> GlslPreprocessorDefinitions { get; set; } = new Dictionary<string, string>();

        [DataMember(Name = "Glsl.additionalIncludeDirectories")]
        public List<string> GlslAdditionalIncludeDirectories { get; set; } = new List<string>();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext c)
        {
            if (GlslPreprocessorDefinitions == null)
                GlslPreprocessorDefinitions = new Dictionary<string, string>();

            if (GlslAdditionalIncludeDirectories == null)
                GlslAdditionalIncludeDirectories = new List<string>();
        }

        /// <summary>
        /// Converts the (potentially) relative include directory paths to absolute directory paths.
        /// </summary>
        internal IEnumerable<string> GetAbsoluteGlslAdditionalIncludeDirectories()
        {
            string folder = Path.GetDirectoryName(FileName);

            return GlslAdditionalIncludeDirectories
                .Select(x =>
                {
                    if (Path.IsPathRooted(x))
                        return x;
                    return Path.Combine(folder, x.Replace("/", "\\"));
                })
                .Select(x => Path.GetFullPath(x)); // Expand . and ..
        }
    }
}