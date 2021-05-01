using SimioAPI;

namespace HT6
{
    /*
     * Para crear el modelo
     * _201504420.CrearModelo();
     */
    class _201504420
    {
        private readonly static string BASE = "[MYS1]ModeloBase.spfx";
        private readonly static string FINAL_NOMBRE = "[MYS1]ModeloFinalNombre_201504420.spfx";
        private readonly static string FINAL_CARNET = "[MYS1]ModeloFinalCarnet_201504420.spfx";
        private static string[] warnings;
        private static IIntelligentObjects intelligentObjects;
        private static ISimioProject proyectoApi;

        /*
         * Metodo para crear el modelo, se crean dos modelos por la cantidad
         * de objetos que se crean, ya que superan la cantidad permitida por la
         * licencia.
         **/
        public static void CrearModelo()
        {
            CrearNombreYApellido();
            CrearCarnet();
        }
       
        private static void CrearNombreYApellido()
        {
            try
            {
                proyectoApi = SimioProjectFactory.LoadProject(BASE, out warnings);
                intelligentObjects = proyectoApi.Models[1].Facility.IntelligentObjects;
                CrearNombre();
                CrearApellido();
                SimioProjectFactory.SaveProject(proyectoApi, FINAL_NOMBRE, out warnings);
            } catch
            {
            }
        }

        private static void CrearCarnet()
        {
            try
            {
                proyectoApi = SimioProjectFactory.LoadProject(BASE, out warnings);
                intelligentObjects = proyectoApi.Models[1].Facility.IntelligentObjects;
                CrearDos(10, 50);
                CrearCero(50, 50);
                CrearUno(90, 50);
                CrearCinco(120, 50);
                CrearCero(160, 50);
                CrearCuatro(200, 50);
                CrearCuatro(240, 50);
                CrearDos(280, 50);
                CrearCero(320, 50);
                SimioProjectFactory.SaveProject(proyectoApi, FINAL_CARNET, out warnings);
            }
            catch
            {
            }
        }

        private static void CrearNombre()
        {
            // --------------- R
            IIntelligentObject R1 = CrearObjecto("BasicNode", 10, -50),                
                R2 = CrearObjecto("BasicNode", 40, -50),
                R3 = CrearObjecto("BasicNode", 40, -30),
                R4 = CrearObjecto("BasicNode", 10, -30),
                R5 = CrearObjecto("BasicNode", 10, -10),
                R6 = CrearObjecto("BasicNode", 40, -10);
            CrearLink("Path", (INodeObject)R1, (INodeObject)R2);
            CrearLink("Path", (INodeObject)R2, (INodeObject)R3);
            CrearLink("Path", (INodeObject)R3, (INodeObject)R4);
            CrearLink("Path", (INodeObject)R4, (INodeObject)R5);
            CrearLink("Path", (INodeObject)R4, (INodeObject)R6);
            CrearLink("Path", (INodeObject)R1, (INodeObject)R4);
            // --------------- O
            IIntelligentObject O1 = CrearObjecto("BasicNode", 50, -50),
                O2 = CrearObjecto("BasicNode", 50, -10),
                O3 = CrearObjecto("BasicNode", 80, -10),
                O4 = CrearObjecto("BasicNode", 80, -50);
            CrearLink("Path", (INodeObject)O1, (INodeObject)O2);
            CrearLink("Path", (INodeObject)O2, (INodeObject)O3);
            CrearLink("Path", (INodeObject)O3, (INodeObject)O4);
            CrearLink("Path", (INodeObject)O4, (INodeObject)O1);
            // --------------- N
            IIntelligentObject N1 = CrearObjecto("BasicNode", 90, -10),
                N2 = CrearObjecto("BasicNode", 90, -50),
                N3 = CrearObjecto("BasicNode", 120, -10),
                N4 = CrearObjecto("BasicNode", 120, -50);
            CrearLink("Path", (INodeObject)N1, (INodeObject)N2);
            CrearLink("Path", (INodeObject)N2, (INodeObject)N3);
            CrearLink("Path", (INodeObject)N3, (INodeObject)N4);
            // --------------- A
            IIntelligentObject A1 = CrearObjecto("BasicNode", 130, -10),
                A2 = CrearObjecto("BasicNode", 137.5, -30),
                A3 = CrearObjecto("BasicNode", 145, -50),
                A4 = CrearObjecto("BasicNode", 152.5, -30),
                A5 = CrearObjecto("BasicNode", 160, -10);
            CrearLink("Path", (INodeObject)A1, (INodeObject)A2);
            CrearLink("Path", (INodeObject)A2, (INodeObject)A3);
            CrearLink("Path", (INodeObject)A3, (INodeObject)A4);
            CrearLink("Path", (INodeObject)A4, (INodeObject)A5);
            CrearLink("Path", (INodeObject)A2, (INodeObject)A4);
            // --------------- L
            IIntelligentObject L1 = CrearObjecto("BasicNode", 170, -50),
                L2 = CrearObjecto("BasicNode", 170, -10),
                L3 = CrearObjecto("BasicNode", 200, -10);
            CrearLink("Path", (INodeObject)L1, (INodeObject)L2);
            CrearLink("Path", (INodeObject)L2, (INodeObject)L3);
            // --------------- D
            IIntelligentObject D1 = CrearObjecto("BasicNode", 210, -50),
                D2 = CrearObjecto("BasicNode", 210, -10),
                D3 = CrearObjecto("BasicNode", 240, -25),
                D4 = CrearObjecto("BasicNode", 240, -35);
            CrearLink("Path", (INodeObject)D1, (INodeObject)D2);
            CrearLink("Path", (INodeObject)D2, (INodeObject)D3);
            CrearLink("Path", (INodeObject)D3, (INodeObject)D4);
            CrearLink("Path", (INodeObject)D4, (INodeObject)D1);
        }

        private static void CrearApellido()
        {
            // --------------- B
            IIntelligentObject B1 = CrearObjecto("BasicNode", 260, -50),
                B2 = CrearObjecto("BasicNode", 290, -50),
                B3 = CrearObjecto("BasicNode", 290, -32.5),
                B4 = CrearObjecto("BasicNode", 260, -30),
                B5 = CrearObjecto("BasicNode", 290, -27.5),
                B6 = CrearObjecto("BasicNode", 290, -10),
                B7 = CrearObjecto("BasicNode", 260, -10);
            CrearLink("Path", (INodeObject)B1, (INodeObject)B2);
            CrearLink("Path", (INodeObject)B2, (INodeObject)B3);
            CrearLink("Path", (INodeObject)B3, (INodeObject)B4);
            CrearLink("Path", (INodeObject)B4, (INodeObject)B5);
            CrearLink("Path", (INodeObject)B5, (INodeObject)B6);
            CrearLink("Path", (INodeObject)B6, (INodeObject)B7);
            CrearLink("Path", (INodeObject)B7, (INodeObject)B4);
            CrearLink("Path", (INodeObject)B4, (INodeObject)B1);
            // --------------- E
            IIntelligentObject E1 = CrearObjecto("BasicNode", 300, -50),
                E2 = CrearObjecto("BasicNode", 330, -50),
                E3 = CrearObjecto("BasicNode", 300, -30),
                E4 = CrearObjecto("BasicNode", 330, -30),
                E5 = CrearObjecto("BasicNode", 300, -10),
                E6 = CrearObjecto("BasicNode", 330, -10);
            CrearLink("Path", (INodeObject)E1, (INodeObject)E2);
            CrearLink("Path", (INodeObject)E1, (INodeObject)E3);
            CrearLink("Path", (INodeObject)E3, (INodeObject)E4);
            CrearLink("Path", (INodeObject)E3, (INodeObject)E5);
            CrearLink("Path", (INodeObject)E5, (INodeObject)E6);
            // --------------- R
            IIntelligentObject R1 = CrearObjecto("BasicNode", 340, -50),
                R2 = CrearObjecto("BasicNode", 370, -50),
                R3 = CrearObjecto("BasicNode", 370, -30),
                R4 = CrearObjecto("BasicNode", 340, -30),
                R5 = CrearObjecto("BasicNode", 340, -10),
                R6 = CrearObjecto("BasicNode", 370, -10);
            CrearLink("Path", (INodeObject)R1, (INodeObject)R2);
            CrearLink("Path", (INodeObject)R2, (INodeObject)R3);
            CrearLink("Path", (INodeObject)R3, (INodeObject)R4);
            CrearLink("Path", (INodeObject)R4, (INodeObject)R5);
            CrearLink("Path", (INodeObject)R4, (INodeObject)R6);
            CrearLink("Path", (INodeObject)R1, (INodeObject)R4);
            // --------------- D
            IIntelligentObject D1 = CrearObjecto("BasicNode", 380, -50),
                D2 = CrearObjecto("BasicNode", 380, -10),
                D3 = CrearObjecto("BasicNode", 410, -25),
                D4 = CrearObjecto("BasicNode", 410, -35);
            CrearLink("Path", (INodeObject)D1, (INodeObject)D2);
            CrearLink("Path", (INodeObject)D2, (INodeObject)D3);
            CrearLink("Path", (INodeObject)D3, (INodeObject)D4);
            CrearLink("Path", (INodeObject)D4, (INodeObject)D1);
            // --------------- U
            IIntelligentObject U1 = CrearObjecto("BasicNode", 420, -50),
                U2 = CrearObjecto("BasicNode", 420, -10),
                U3 = CrearObjecto("BasicNode", 450, -10),
                U4 = CrearObjecto("BasicNode", 450, -50);
            CrearLink("Path", (INodeObject)U1, (INodeObject)U2);
            CrearLink("Path", (INodeObject)U2, (INodeObject)U3);
            CrearLink("Path", (INodeObject)U3, (INodeObject)U4);
            // --------------- O
            IIntelligentObject O1 = CrearObjecto("BasicNode", 460, -50),
                O2 = CrearObjecto("BasicNode", 460, -10),
                O3 = CrearObjecto("BasicNode", 490, -10),
                O4 = CrearObjecto("BasicNode", 490, -50);
            CrearLink("Path", (INodeObject)O1, (INodeObject)O2);
            CrearLink("Path", (INodeObject)O2, (INodeObject)O3);
            CrearLink("Path", (INodeObject)O3, (INodeObject)O4);
            CrearLink("Path", (INodeObject)O4, (INodeObject)O1);
        }

        private static IIntelligentObject CrearObjecto(string tipo, double x, double y)
        {
            return intelligentObjects.CreateObject(tipo, new FacilityLocation(x, 0, y));
        }

        private static IIntelligentObject CrearLink(string tipo, INodeObject nodo1, INodeObject nodo2)
        {
            return intelligentObjects.CreateLink(tipo, nodo1, nodo2, null);
        }

        private static void CrearCero(int x, int y)
        {
            IIntelligentObject point1 = CrearObjecto("BasicNode", x, y),
                point2 = CrearObjecto("BasicNode", x + 30, y),
                point3 = CrearObjecto("BasicNode", x + 30, y + 40),
                point4 = CrearObjecto("BasicNode", x, y + 40);
            CrearLink("Path", (INodeObject)point1, (INodeObject)point2);
            CrearLink("Path", (INodeObject)point2, (INodeObject)point3);
            CrearLink("Path", (INodeObject)point3, (INodeObject)point4);
            CrearLink("Path", (INodeObject)point4, (INodeObject)point1);
        }

        private static void CrearUno(int x, int y)
        {
            IIntelligentObject point1 = CrearObjecto("BasicNode", x, y + 10),
                point2 = CrearObjecto("BasicNode", x + 10, y),
                point3 = CrearObjecto("BasicNode", x + 10, y + 40);
            CrearLink("Path", (INodeObject)point1, (INodeObject)point2);
            CrearLink("Path", (INodeObject)point2, (INodeObject)point3);
        }

        private static void CrearDos(int x, int y)
        {
            IIntelligentObject point1 = CrearObjecto("BasicNode", x, y),
                point2 = CrearObjecto("BasicNode", x + 30, y),
                point3 = CrearObjecto("BasicNode", x + 30, y + 20),
                point4 = CrearObjecto("BasicNode", x, y + 20),
                point5 = CrearObjecto("BasicNode", x, y + 40),
                point6 = CrearObjecto("BasicNode", x + 30, y + 40);
            CrearLink("Path", (INodeObject)point1, (INodeObject)point2);
            CrearLink("Path", (INodeObject)point2, (INodeObject)point3);
            CrearLink("Path", (INodeObject)point3, (INodeObject)point4);
            CrearLink("Path", (INodeObject)point4, (INodeObject)point5);
            CrearLink("Path", (INodeObject)point5, (INodeObject)point6);
        }

        private static void CrearCuatro(int x, int y)
        {
            IIntelligentObject point1 = CrearObjecto("BasicNode", x, y),
                point2 = CrearObjecto("BasicNode", x, y + 20),
                point3 = CrearObjecto("BasicNode", x + 30, y + 20),
                point4 = CrearObjecto("BasicNode", x + 30, y),
                point5 = CrearObjecto("BasicNode", x + 30, y + 40);
            CrearLink("Path", (INodeObject)point1, (INodeObject)point2);
            CrearLink("Path", (INodeObject)point2, (INodeObject)point3);
            CrearLink("Path", (INodeObject)point3, (INodeObject)point4);
            CrearLink("Path", (INodeObject)point3, (INodeObject)point5);
        }

        private static void CrearCinco(int x, int y)
        {
            IIntelligentObject point1 = CrearObjecto("BasicNode", x, y),
                point2 = CrearObjecto("BasicNode", x + 30, y),
                point3 = CrearObjecto("BasicNode", x, y + 20),
                point4 = CrearObjecto("BasicNode", x + 30, y + 20),
                point5 = CrearObjecto("BasicNode", x + 30, y + 40),
                point6 = CrearObjecto("BasicNode", x, y + 40);
            CrearLink("Path", (INodeObject)point2, (INodeObject)point1);
            CrearLink("Path", (INodeObject)point1, (INodeObject)point3);
            CrearLink("Path", (INodeObject)point3, (INodeObject)point4);
            CrearLink("Path", (INodeObject)point4, (INodeObject)point5);
            CrearLink("Path", (INodeObject)point5, (INodeObject)point6);
        }
    }
}
