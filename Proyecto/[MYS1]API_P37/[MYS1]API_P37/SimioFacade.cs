using SimioAPI;
using System;

namespace Practica3.Factory
{
    class SimioFacade
    {
        public readonly static string BASE_MODEL_PATH = "[MYS1]ModeloBase_P37.spfx";
        public readonly static string FINAL_MODEL_PATH = "[MYS1]Tienda3_P37.spfx";
        public readonly static string WARNINGS_FILE_PATH = "log.txt";
        private static SimioFacade _instance;

        private SimioFacade()
        {
        }

        public void CreateModel(string finalModelPath)
        {
            try
            {                
                System.IO.File.WriteAllBytes(BASE_MODEL_PATH, FileStore.Resource.BaseModel);
                ISimioProject project = SimioProjectFactory.LoadProject(BASE_MODEL_PATH, out string[] warnings);
                IModel model = project.Models[1];
                IIntelligentObjects intelligentObjects = model.Facility.IntelligentObjects;

                Source llegadaClientes = new Source(intelligentObjects, 0, 0);
                llegadaClientes.UpdateInterarrivalTime("Random.Uniform(1, 2.5)");
                llegadaClientes.UpdateName("LlegadaClientes");
                llegadaClientes.UpdateEntityType("Cliente");

                Server caja = new Server(intelligentObjects, 10, 0);
                caja.UpdateProcessingTime("Random.Uniform(2/3, 11/6)");
                caja.UpdateName("Caja");
                Path pathLlegadaCaja = new Path(intelligentObjects, llegadaClientes.GetOutput(), caja.GetInput());
                pathLlegadaCaja.UpdateDrawToScale("False");
                pathLlegadaCaja.UpdateLogicalLength("20");

                Source llegadaBotellas = new Source(intelligentObjects, 10, 15);
                llegadaBotellas.UpdateName("AlmacenBotella");
                llegadaBotellas.UpdateEntityType("Botella");
                llegadaBotellas.UpdateArrivalMode("On Event");

                INodeObject entradaCaja = (INodeObject)intelligentObjects["EntradaCaja"];
                new Path(intelligentObjects, entradaCaja, llegadaBotellas.GetOutput());

                Combiner entrega = new Combiner(intelligentObjects, 20, 0);
                entrega.UpdateName("Entrega");
                entrega.GetOutput().Properties["OutboundLinkRule"].Value = "By Link Weight";
                Path cajaEntrega = new Path(intelligentObjects, caja.GetOutput(), entrega.GetParentInput());
                cajaEntrega.UpdateDrawToScale("False");
                cajaEntrega.UpdateLogicalLength("4");

                Sink sink = new Sink(intelligentObjects, 60, -5);
                TimePath pathSalida = new TimePath(intelligentObjects, entrega.GetOutput(), sink.GetInput());
                pathSalida.UpdateSelectionWeight("0.48");
                pathSalida.UpdateTravelTime("0.3");
                TransferNode transferNode = new TransferNode(intelligentObjects, 25, -10);
                transferNode.UpdateName("IrSalida");
                new Path(intelligentObjects, transferNode.GetInput(), sink.GetInput());

                CreateServer(
                    intelligentObjects, 50, 40, "0.12",
                    "Random.Triangular(4, 8, 12)",  "5",
                    null, "3", "Barra", entrega.GetOutput(), sink.GetInput()
                );
                int i = 1;
                int x = 50;
                int y = 35;
                for (; i < 15; i++)
                {
                    CreateServer(
                        intelligentObjects, x, y, "0.025",
                        "Random.Triangular(12, 20, 25)",
                        i <= 8 ? "4" : "3", i <= 8 ? "10/60" : "12/60",
                        null, "Mesa_" + i, entrega.GetOutput(), sink.GetInput()
                    );
                    y -= 5;
                }
                SimioProjectFactory.SaveProject(project, finalModelPath, out warnings);
                System.IO.File.WriteAllLines(WARNINGS_FILE_PATH, warnings);
            } catch (Exception e)
            {
                System.IO.File.WriteAllText(WARNINGS_FILE_PATH, e.Message);
            }
        }

        public void CreateServer(
            IIntelligentObjects intelligentObjects, int x, int y, string probabilidad,
            string processingTime, string initialCapacity, string tiempo, string distancia,
            string nombre, INodeObject deEntrega, INodeObject aSink
        )
        {
            Server server = new Server(intelligentObjects, x, y);
            server.UpdateProcessingTime(processingTime);
            server.UpdateInitialCapacity(initialCapacity);
            server.UpdateInputBufferDecisionType("Probabilistic");
            server.UpdateInputBufferBalkConditionOrProbability("0.08");
            server.UpdateInputBufferBalkNodeName("IrSalida");
            server.UpdateName(nombre);
            if (tiempo != null)
            {
                TimePath path = new TimePath(intelligentObjects, deEntrega, server.GetInput());
                path.UpdateSelectionWeight(probabilidad);
                path.UpdateTravelTime(tiempo);
            }
            else
            {
                Path path = new Path(intelligentObjects, deEntrega, server.GetInput());
                path.UpdateSelectionWeight(probabilidad);
                path.UpdateDrawToScale("False");
                path.UpdateLogicalLength(distancia);
            }
            TimePath timePath = new TimePath(intelligentObjects, server.GetOutput(), aSink);
            timePath.UpdateTravelTime("18/60");
        }

        public static SimioFacade GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SimioFacade();
            }
            return _instance;
        }

    }
}
