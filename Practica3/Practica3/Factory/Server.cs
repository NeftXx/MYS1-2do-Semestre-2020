using SimioAPI;

namespace Practica3.Factory
{
    class Server : SimioElement
    {
        public Server(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("Server", new FacilityLocation(x, 0, y)) as IFixedObject;
        }

        public void UpdateInitialCapacity(string capacity)
        {
            @object.Properties["InitialCapacity"].Value = capacity;
        }

        public string GetInitialCapacity()
        {
            return @object.Properties["InitialCapacity"].Value;
        }

        public void UpdateProcessingTime(string processingTime)
        {
            @object.Properties["ProcessingTime"].Value = processingTime;
        }

        public string GetProcessingTime()
        {
            return @object.Properties["ProcessingTime"].Value;
        }

        public INodeObject GetInput()
        {
            return @object.Nodes[0];
        }

        public INodeObject GetOutput()
        {
            return @object.Nodes[1];
        }
    }
}
