using SimioAPI;

namespace Practica3.Factory
{
    class Sink : SimioElement
    {
        public Sink(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("Sink", new FacilityLocation(x, 0, y));
        }

        public INodeObject GetInput()
        {
            return ((IFixedObject)@object).Nodes[0];
        }
    }
}
