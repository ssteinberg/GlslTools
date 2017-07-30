using System.Collections.Generic;
using ShaderTools.CodeAnalysis.Glsl.Symbols;

namespace ShaderTools.CodeAnalysis.Glsl.Binding
{
    internal sealed class StructMethodBinder : Binder
    {
        private readonly StructSymbol _structSymbol;

        public StructMethodBinder(SharedBinderState sharedBinderState, Binder parent, StructSymbol classSymbol)
            : base(sharedBinderState, parent)
        {
            _structSymbol = classSymbol;
        }

        protected override IEnumerable<Binder> GetAdditionalParentBinders()
        {
            var baseClass = (StructSymbol) _structSymbol;
            while (baseClass != null)
            {
                yield return baseClass.Binder;
                baseClass = baseClass.BaseType;
            }
        }
    }
}