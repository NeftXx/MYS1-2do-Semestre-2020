using SimioAPI;

namespace Practica3.Factory.Draw
{
    class Airport
    {
        private readonly Source source;
        private readonly Server station;
        private readonly Sink exit;

        public Airport(
            string name, IIntelligentObjects intelligentObjects, int x, int y, string interarrivalTime,
            string capacityStation, string processingTime, string probability
        )
        {
            source = new Source(intelligentObjects, x, y);
            source.UpdateInterarrivalTime(interarrivalTime);
            source.UpdateName("Llegada_" + name);
            station = new Server(intelligentObjects, x + 2, y + 2);
            station.UpdateInputBufferCapacity(capacityStation);
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
