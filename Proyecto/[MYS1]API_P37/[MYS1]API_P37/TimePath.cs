using SimioAPI;

namespace Practica3.Factory
{
    class TimePath : Link
    {
        public TimePath(IIntelligentObjects intelligentObjects, INodeObject node1, INodeObject node2)
            : base(intelligentObjects, node1, node2, "TimePath")
        {
        }

        public void UpdateSelectionWeight(string selectionWeight)
        {
            @object.Properties["SelectionWeight"].Value = selectionWeight;
        }

        public void UpdateTravelTime(string travelTime)
        {
            @object.Properties["TravelTime"].Value = travelTime;
        }
    }
}
