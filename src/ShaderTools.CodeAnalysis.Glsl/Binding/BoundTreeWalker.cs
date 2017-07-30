using ShaderTools.CodeAnalysis.Glsl.Binding.BoundNodes;

namespace ShaderTools.CodeAnalysis.Glsl.Binding
{
    internal abstract partial class BoundTreeWalker
    {
        public virtual void VisitCompilationUnit(BoundCompilationUnit node)
        {
            foreach (var declaration in node.Declarations)
                VisitTopLevelDeclaration(declaration);
        }
    }
}