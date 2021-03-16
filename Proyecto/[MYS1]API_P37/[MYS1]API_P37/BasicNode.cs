using SimioAPI;

namespace Practica3.Factory
{
    class BasicNode : SimioElement
    {
        public string Distance { get; set; }

        public BasicNode(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("BasicNode", new FacilityLocation(x, 0, y));
            Distance = "0";
        }

        public BasicNode(IIntelligentObjects intelligentObjects, int x, int y, string distance)
        {
            @object = intelligentObjects.CreateObject("BasicNode", new FacilityLocation(x, 0, y));
            Distance = (double.Parse(distance) * 1000) + "";
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
