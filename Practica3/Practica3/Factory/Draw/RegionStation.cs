using SimioAPI;

namespace Practica3.Factory.Draw
{
    class RegionStation
    {
        private readonly Source source;
        private readonly Server station;
        private readonly Sink exit;

        public RegionStation(
            string name, IIntelligentObjects intelligentObjects, int x, int y, string interarrivalTime,
            string capacityStation, string processingTime, string probability
        )
        {
            source = new Source(intelligentObjects, x, y);
            source.UpdateInterarrivalTime(interarrivalTime);
            source.UpdateName("Llegada_" + name);
            source.UpdateEntityType("Turista");
            station = new Server(intelligentObjects, x + 2, y + 2);
            station.UpdateInitialCapacity(capacityStation);
            station.UpdateProcessingTime(processingTime);
            station.UpdateName("Estacion_" + name);
            station.GetOutput().Properties["OutboundLinkRule"].Value = "By Link Weight";
            exit = new Sink(intelligentObjects, x + 4, y);
            exit.UpdateName("Salida_" + name);
            new Path(intelligentObjects, source.GetOutput(), station.GetInput());
            Path path = new Path(intelligentObjects, station.GetOutput(), exit.GetInput());
            path.UpdateDrawToScale("False");
            path.UpdateLogicalLength("0");
            path.UpdateSelectionWeight(probability);
        }

        public void SetDestinationStation(IIntelligentObjects intelligentObjects, INodeObject destinationstation, string distance, string probability)
        {
            Path path = new Path(intelligentObjects, station.GetOutput(), destinationstation);
            path.UpdateDrawToScale("False");
            path.UpdateLogicalLength(distance);
            path.UpdateSelectionWeight(probability);
        }

        public INodeObject GetInput()
        {
            return station.GetInput();
        }

        public INodeObject GetOutput()
        {
            return station.GetOutput();
        }
    }
}
