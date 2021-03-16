using SimioAPI;

namespace Practica3.Factory
{
    class Server : SimioElement
    {
        public Server(IIntelligentObjects intelligentObjects, int x, int y)
        {
            @object = intelligentObjects.CreateObject("Server", new FacilityLocation(x, 0, y));
        }

        public void UpdateInitialCapacity(string capacity)
        {
            @object.Properties["InitialCapacity"].Value = capacity;
        }

        public void UpdateInputBufferDecisionType(string decision)
        {
            @object.Properties["InputBufferBalkDecisionType"].Value = decision;
        }

        public void UpdateInputBufferBalkConditionOrProbability(string prob)
        {
            @object.Properties["InputBufferBalkConditionOrProbability"].Value = prob;
        }

        public void UpdateInputBufferBalkNodeName(string node)
        {
            @object.Properties["InputBufferBalkNodeName"].Value = node;
        }

        public void UpdateInputBufferCapacity(string inputBufferCapacity)
        {
            @object.Properties["InputBufferCapacity"].Value = inputBufferCapacity;
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
            return ((IFixedObject)@object).Nodes[0];
        }

        public INodeObject GetOutput()
        {
            return ((IFixedObject)@object).Nodes[1];
        }
    }
}
