using SimioAPI;

namespace Practica3.Factory
{
    class BasicNode : SimioElement
    {
        public BasicNode(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("BasicNode", new FacilityLocation(x, 0, y)) as IFixedObject;
        }

        public INodeObject GetInput()
        {
            return @object.Nodes[0];
        }
    }
}
