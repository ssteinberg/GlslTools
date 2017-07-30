using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding
{
    internal sealed class NamespaceBinder : Binder
    {
        public NamespaceSymbol NamespaceSymbol { get; }

        public NamespaceBinder(SharedBinderState sharedBinderState, Binder parent, NamespaceSymbol namespaceSymbol)
            : base(sharedBinderState, parent)
        {
            NamespaceSymbol = namespaceSymbol;
        }
    }
}