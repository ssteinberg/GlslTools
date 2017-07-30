using ShaderTools.CodeAnalysis.Diagnostics;
using ShaderTools.CodeAnalysis.Glsl.Properties;

namespace ShaderTools.CodeAnalysis.Glsl.Diagnostics
{
    internal sealed class GlslMessageProvider : MessageProvider
    {
        public static readonly GlslMessageProvider Instance = new GlslMessageProvider();

        private GlslMessageProvider() { }

        public override string CodePrefix { get; } = "GLSL";

        public override string GetMessageFormat(int code)
        {
            return Resources.ResourceManager.GetString(((DiagnosticId) code).ToString());
        }

        public override DiagnosticSeverity GetSeverity(int code)
        {
            switch ((DiagnosticId) code)
            {
                case DiagnosticId.LoopControlVariableConflict:
                case DiagnosticId.ImplicitTruncation:
                    return DiagnosticSeverity.Warning;
                default:
                    return DiagnosticSeverity.Error;
            }
        }
    }
}
