using ShaderTools.CodeAnalysis.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Symbols
{
    public abstract class TypeSymbol : ContainerSymbol, ITypeSymbol
    {
        internal TypeSymbol(SymbolKind kind, string name, string documentation, Symbol parent)
            : base(kind, name, documentation, parent)
        {
            
        }

        public virtual TypeSymbol GetBaseType()
        {
            return null;
        }
    }
}