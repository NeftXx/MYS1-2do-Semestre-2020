using SimioAPI;

namespace Practica3.Factory
{
    class Combiner : SimioElement
    {
        public Combiner(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("Combiner", new FacilityLocation(x, 0, y));
        }

        public INodeObject GetParentInput()
        {
            return ((IFixedObject)@object).Nodes[0];
        }

        public INodeObject GetMemberInput()
        {
            return ((IFixedObject)@object).Nodes[1];
        }

        public INodeObject GetOutput()
        {
            return ((IFixedObject)@object).Nodes[2];
        }
    }
}
