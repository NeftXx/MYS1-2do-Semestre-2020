using SimioAPI;

namespace Practica3.Factory
{
    class TransferNode : SimioElement
    {
        public TransferNode(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("TransferNode", new FacilityLocation(x, 0, y));
        }

        public INodeObject GetInput()
        {
            return @object as INodeObject;
        }
    }
}
