using SimioAPI;

namespace Practica3.Factory
{
    class BasicNode : SimioElement
    {
        public BasicNode(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("BasicNode", new FacilityLocation(x, 0, y));
        }

        public INodeObject GetInput()
        {
            return @object as INodeObject;
        }
    }
}
