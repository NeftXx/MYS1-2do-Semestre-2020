using SimioAPI;

namespace Practica3.Factory
{
    class TransferNode : BasicNode
    {
        public TransferNode(IIntelligentObjects intelligentObjects, int x, int y) : base(intelligentObjects, x, y)
        {
            @object = intelligentObjects.CreateObject("TransferNode", new FacilityLocation(x, 0, y)) as IFixedObject;
        }
    }
}
