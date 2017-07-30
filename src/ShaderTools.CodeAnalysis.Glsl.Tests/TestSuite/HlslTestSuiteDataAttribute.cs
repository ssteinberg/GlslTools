using System;
using System.Collections.Generic;
using ShaderTools.Testing;

namespace ShaderTools.CodeAnalysis.Glsl.Tests.TestSuite
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class GlslTestSuiteDataAttribute : TestSuiteDataAttribute
    {
        protected override IEnumerable<string> FileExtensions { get; } = new[] { ".Glsl", ".fx", ".vsh", ".psh" };
    }
}