using SimioAPI;

namespace Practica3.Factory
{
    class Source : SimioElement
    {
        public Source(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("Source", new FacilityLocation(x, 0, y));
        }

        public void UpdateArrivalMode(string mode)
        {
            @object.Properties["ArrivalMode"].Value = mode;
        }

        public void UpdateEntityType(string entityType)
        {
            @object.Properties["EntityType"].Value = entityType;
        }

        public void UpdateInterarrivalTime(string interarrivalTime)
        {
            @object.Properties["InterarrivalTime"].Value = interarrivalTime;
        }

        public void UpdateMaximumArrivals(string maximumArrivals)
        {
            @object.Properties["MaximumArrivals"].Value = maximumArrivals;
        }

        public void UpdateEntitiesPerArrival(string entitiesPerArrival)
        {
            @object.Properties["EntitiesPerArrival"].Value = entitiesPerArrival;
        }

        public INodeObject GetOutput()
        {
            return ((IFixedObject)@object).Nodes[0];
        }
    }
}
