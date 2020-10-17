using SimioAPI;

namespace Practica3.Factory
{
    class TransferNode : SimioElement
    {
        public TransferNode(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("TransferNode", new FacilityLocation(x, 0, y));
        }

        public void UpdateOutboundLinkRule(string outboundLinkRule)
        {
            @object.Properties["OutboundLinkRule"].Value = outboundLinkRule;
        }

        public INodeObject GetInput()
        {
            return @object as INodeObject;
        }
    }
}
