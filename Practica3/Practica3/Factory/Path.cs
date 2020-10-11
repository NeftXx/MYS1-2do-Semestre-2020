using SimioAPI;

namespace Practica3.Factory
{
    class Path : Link
    {
        public Path(IIntelligentObjects intelligentObjects, INodeObject node1, INodeObject node2)
            : base(intelligentObjects, node1, node2, "Path")
        {
        }
    }
}
