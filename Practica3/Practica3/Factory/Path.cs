using SimioAPI;

namespace Practica3.Factory
{
    class Path : Link
    {
        public Path(IIntelligentObjects intelligentObjects, INodeObject node1, INodeObject node2)
            : base(intelligentObjects, node1, node2, "Path")
        {
        }

        public void UpdateDrawToScale(string capacity)
        {
            @object.Properties["DrawnToScale"].Value = capacity;
        }

        public void UpdateLogicalLength(string capacity)
        {
            @object.Properties["LogicalLength"].Value = capacity;
        }

        public void UpdateSelectionWeight(string selectionWeight)
        {
            @object.Properties["SelectionWeight"].Value = selectionWeight;
        }
    }
}
