using SimioAPI;
using System;
using System.Collections.Generic;

namespace Practica3.Factory
{
    class SimioFacade
    {
        public readonly static string BASE_MODEL_PATH = "[MYS1]ModeloBase_P37.spfx";
        public readonly static string FINAL_MODEL_PATH = "[MYS1]ModeloFinal_P37.spfx";
        public readonly static string CARD_MODEL_PATH = "[MYS1]ModeloCarnets_P37.spfx";
        public readonly static string WARNINGS_FILE_PATH = "log.txt";
        private static SimioFacade _instance;
        public readonly static int[] COORDINATES = 
            new int[]{ 0, 0, 5, -20, 30, -10, 15, 20, -15, 20, -40, 10, -40, -20, 10, -50 };

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
                CreateMap(intelligentObjects);
                CreateShips(intelligentObjects);
                CreatePointCardinal(intelligentObjects);
                CreateAirports(intelligentObjects);
                SimioProjectFactory.SaveProject(project, finalModelPath, out warnings);
                System.IO.File.WriteAllLines(WARNINGS_FILE_PATH, warnings);
            } catch (Exception e)
            {
                System.IO.File.WriteAllText(WARNINGS_FILE_PATH, e.Message);
            }
        }

        private void CreateShips(IIntelligentObjects intelligentObjects)
        {
            if (intelligentObjects["P19"] is INodeObject P19 && intelligentObjects["P20"] is INodeObject P20)
            {
                Source sourceShips = new Source(intelligentObjects, 20, -75);
                sourceShips.UpdateEntityType("Nave");
                sourceShips.UpdateInterarrivalTime("Random.Exponential(15)");
                sourceShips.UpdateMaximumArrivals("15");
                sourceShips.UpdateName("DespliegueDeNaves");
                Path path1 = new Path(intelligentObjects, sourceShips.GetOutput(), P20);
                path1.UpdateLogicalLength("34355");
                Sink sink = new Sink(intelligentObjects, 20, -77);
                sink.UpdateName("AterrizajeDeNaves");
                Path path = new Path(intelligentObjects, P19, sink.GetInput());
                path.UpdateDrawToScale("False");
                path.UpdateLogicalLength("34355");
                path.UpdateSelectionWeight("200");
            }
        }

        private void CreatePointCardinal(IIntelligentObjects intelligentObjects)
        {
            TransferNode norte = new TransferNode(intelligentObjects, 0, -100),
                sur = new TransferNode(intelligentObjects, 0, 70),
                oeste = new TransferNode(intelligentObjects, -90, 0),
                este = new TransferNode(intelligentObjects, 90, 0);
            norte.UpdateName("Norte");
            sur.UpdateName("Sur");
            oeste.UpdateName("Oeste");
            este.UpdateName("Este");
            new Path(intelligentObjects, norte.GetInput(), sur.GetInput());
            new Path(intelligentObjects, oeste.GetInput(), este.GetInput());
        }

        private void CreateMap(IIntelligentObjects intelligentObjects)
        {
            CreateRegions(intelligentObjects);
            List<BasicNode> list = Util.ReadCSV.GetCoordanates(intelligentObjects);
            int countList = list.Count;
            if (countList > 0)
            {
                BasicNode last = list[countList - 1];
                BasicNode current;
                Path path;
                for(int i = 0; i < countList; i++)
                {
                    current = list[i];
                    if (current == last)
                    {
                        path = new Path(intelligentObjects, last.GetInput(), list[0].GetInput());
                    }
                    else
                    {
                        path = new Path(intelligentObjects, current.GetInput(), list[i + 1].GetInput());
                    }
                    path.UpdateDrawToScale("False");
                    path.UpdateLogicalLength(current.Distance);
                    current.UpdateName("P" + (i + 1));
                }
            }
        }

        private void CreateRegions(IIntelligentObjects intelligentObjects)
        {
            TransferNode region1 = new TransferNode(intelligentObjects, COORDINATES[0], COORDINATES[1]),
                region2 = new TransferNode(intelligentObjects, COORDINATES[2], COORDINATES[3]),
                region3 = new TransferNode(intelligentObjects, COORDINATES[4], COORDINATES[5]),
                region4 = new TransferNode(intelligentObjects, COORDINATES[6], COORDINATES[7]),
                region5 = new TransferNode(intelligentObjects, COORDINATES[8], COORDINATES[9]),
                region6 = new TransferNode(intelligentObjects, COORDINATES[10], COORDINATES[11]),
                region7 = new TransferNode(intelligentObjects, COORDINATES[12], COORDINATES[13]),
                region8 = new TransferNode(intelligentObjects, COORDINATES[14], COORDINATES[15]);
            region1.UpdateName("Region1_Metropolitana");
            region2.UpdateName("Region2_Norte");
            region3.UpdateName("Region3_Nor_Oriente");
            region4.UpdateName("Region4_Sur_Oriente");
            region5.UpdateName("Region5_Central");
            region6.UpdateName("Region6_Sur_Occidente");
            region7.UpdateName("Region7_Nor_Occidente");
            region8.UpdateName("Region8_Peten");
        }

        private void CreateAirports(IIntelligentObjects intelligentObjects)
        {
            Draw.Airport metropolitana = new Draw.Airport(
                    "Metro", intelligentObjects, COORDINATES[0], COORDINATES[1] - 2,
                    "Random.Poisson(2)", "200", "Random.Exponential(4)", "0.35"
            );
            Draw.Airport norte = new Draw.Airport(
                    "Norte", intelligentObjects, COORDINATES[2], COORDINATES[3] - 2,
                    "Random.Poisson(8)", "50", "Random.Exponential(5)", "0.40"
            );
            Draw.Airport nor_oriente = new Draw.Airport(
                    "Nor_Oriente", intelligentObjects, COORDINATES[4], COORDINATES[5] - 2,
                    "Random.Poisson(6)", "40", "Random.Exponential(3)", "0.20"
            );
            Draw.Airport sur_oriente = new Draw.Airport(
                    "Sur_Oriente", intelligentObjects, COORDINATES[6], COORDINATES[7] - 2,
                    "Random.Poisson(10)", "30", "Random.Exponential(4)", "0.40"
            );
            Draw.Airport central = new Draw.Airport(
                    "Central", intelligentObjects, COORDINATES[8], COORDINATES[9] - 2,
                    "Random.Poisson(3)", "100", "Random.Exponential(5)", "0.35"
            );
            Draw.Airport sur_occidente = new Draw.Airport(
                    "Sur_Occidente", intelligentObjects, COORDINATES[10], COORDINATES[11] - 2,
                    "Random.Poisson(4)", "120", "Random.Exponential(3)", "0.35"
            );
            Draw.Airport nor_occidente = new Draw.Airport(
                    "Nor_Occidente", intelligentObjects, COORDINATES[12], COORDINATES[13] - 2,
                    "Random.Poisson(12)", "30", "Random.Exponential(150)", "0.40"
            );
            Draw.Airport peten = new Draw.Airport(
                    "Peten", intelligentObjects, COORDINATES[14], COORDINATES[15] - 2,
                    "Random.Poisson(4)", "150", "Random.Exponential(4)", "0.5"
            );

            // conections
            metropolitana.setDestinationStation(intelligentObjects, central, "63000", "0.30");
            metropolitana.setDestinationStation(intelligentObjects, sur_oriente, "124000", "0.15");
            metropolitana.setDestinationStation(intelligentObjects, nor_oriente, "241000", "0.20");

            norte.setDestinationStation(intelligentObjects, peten, "147000", "0.40");
            norte.setDestinationStation(intelligentObjects, nor_oriente, "138000", "0.10");
            norte.setDestinationStation(intelligentObjects, peten, "145000", "0.10");

            nor_oriente.setDestinationStation(intelligentObjects, metropolitana, "241000", "0.30");
            nor_oriente.setDestinationStation(intelligentObjects, norte, "138000", "0.15");
            nor_oriente.setDestinationStation(intelligentObjects, sur_oriente, "231000", "0.05");
            nor_oriente.setDestinationStation(intelligentObjects, peten, "282000", "0.30");

            sur_oriente.setDestinationStation(intelligentObjects, nor_oriente, "231000", "0.20");
            sur_oriente.setDestinationStation(intelligentObjects, metropolitana, "124000", "0.25");
            sur_oriente.setDestinationStation(intelligentObjects, central, "154000", "0.15");

            central.setDestinationStation(intelligentObjects, metropolitana, "63000", "0.35");
            central.setDestinationStation(intelligentObjects, sur_oriente, "154000", "0.05");
            central.setDestinationStation(intelligentObjects, sur_occidente, "155000", "0.15");
            central.setDestinationStation(intelligentObjects, nor_occidente, "269000", "0.10");

            sur_occidente.setDestinationStation(intelligentObjects, nor_occidente, "87000", "0.30");
            sur_occidente.setDestinationStation(intelligentObjects, central, "155000", "0.35");

            nor_occidente.setDestinationStation(intelligentObjects, sur_occidente, "87000", "0.30");
            nor_occidente.setDestinationStation(intelligentObjects, central, "269000", "0.10");
            nor_occidente.setDestinationStation(intelligentObjects, norte, "145000", "0.20");

            peten.setDestinationStation(intelligentObjects, norte, "147000", "0.25");
            peten.setDestinationStation(intelligentObjects, nor_oriente, "282000", "0.25");
        }

        public void CreateCards()
        {
            try
            {
                System.IO.File.WriteAllBytes(BASE_MODEL_PATH, FileStore.Resource.BaseModel);
                ISimioProject project = SimioProjectFactory.LoadProject(BASE_MODEL_PATH, out string[] warnings);
                IModel model = project.Models[1];
                IIntelligentObjects intelligentObjects = model.Facility.IntelligentObjects;
                CreateCarnet201503918(intelligentObjects);
                CreateCard201504420(intelligentObjects);
                SimioProjectFactory.SaveProject(project, CARD_MODEL_PATH, out warnings);
                System.IO.File.WriteAllLines(WARNINGS_FILE_PATH, warnings);
            }
            catch (Exception e)
            {
                System.IO.File.WriteAllText(WARNINGS_FILE_PATH, e.Message);
            }
        }

        private void CreateCarnet201503918(IIntelligentObjects intelligentObjects)
        {
            // 2
            BasicNode t1_superior = new BasicNode(intelligentObjects, 0, -400);
            t1_superior.UpdateName("T1_E2");
            BasicNode t2_superior = new BasicNode(intelligentObjects, 30, -400);
            t2_superior.UpdateName("T2_E2");
            Path conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 30, -380);
            t1_superior.UpdateName("T3_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 0, -380);
            t2_superior.UpdateName("T4_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 0, -360);
            t1_superior.UpdateName("T5_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 30, -360);
            t2_superior.UpdateName("T6_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());


            // 0

            t1_superior = new BasicNode(intelligentObjects, 50, -400);
            t1_superior.UpdateName("T7_E2");
            t2_superior = new BasicNode(intelligentObjects, 80, -400);
            t2_superior.UpdateName("T8_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 80, -360);
            t1_superior.UpdateName("T9_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 50, -360);
            t2_superior.UpdateName("T10_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 50, -400);
            t1_superior.UpdateName("T11_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            //1
            t1_superior = new BasicNode(intelligentObjects, 100, -390);
            t1_superior.UpdateName("T12_E2");
            t2_superior = new BasicNode(intelligentObjects, 110, -400);
            t2_superior.UpdateName("T13_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 110, -360);
            t1_superior.UpdateName("T14_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            // 5
            t1_superior = new BasicNode(intelligentObjects, 130, -400);
            t1_superior.UpdateName("T15_E2");
            t2_superior = new BasicNode(intelligentObjects, 160, -400);
            t2_superior.UpdateName("T16_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 130, -380);
            t2_superior.UpdateName("T17_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 160, -380);
            t1_superior.UpdateName("T18_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 160, -360);
            t2_superior.UpdateName("T19_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 130, -360);
            t1_superior.UpdateName("T20_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            // 0

            t1_superior = new BasicNode(intelligentObjects, 180, -400);
            t1_superior.UpdateName("T21_E2");
            t2_superior = new BasicNode(intelligentObjects, 210, -400);
            t2_superior.UpdateName("T22_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 210, -360);
            t1_superior.UpdateName("T23_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 180, -360);
            t2_superior.UpdateName("T24_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 180, -400);
            t1_superior.UpdateName("T25_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            //3

            t1_superior = new BasicNode(intelligentObjects, 230, -400);
            t1_superior.UpdateName("T26_E2");
            t2_superior = new BasicNode(intelligentObjects, 260, -400);
            t2_superior.UpdateName("T27_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 260, -380);
            t1_superior.UpdateName("T28_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 230, -380);
            t2_superior.UpdateName("T29_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 260, -360);
            t2_superior.UpdateName("T30_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 230, -360);
            t1_superior.UpdateName("T31_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            // 9

            t1_superior = new BasicNode(intelligentObjects, 280, -400);
            t1_superior.UpdateName("T32_E2");
            t2_superior = new BasicNode(intelligentObjects, 310, -400);
            t2_superior.UpdateName("T33_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 310, -380);
            t1_superior.UpdateName("T34_E2");
            BasicNode aux = t1_superior;
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 280, -380);
            t2_superior.UpdateName("T35_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 280, -400);
            t1_superior.UpdateName("T36_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = aux;
            t2_superior = new BasicNode(intelligentObjects, 310, -360);
            t2_superior.UpdateName("T37_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 280, -360);
            t1_superior.UpdateName("T38_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());

            //1
            t1_superior = new BasicNode(intelligentObjects, 330, -390);
            t1_superior.UpdateName("T39_E2");
            t2_superior = new BasicNode(intelligentObjects, 340, -400);
            t2_superior.UpdateName("T40_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 340, -360);
            t1_superior.UpdateName("T41_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());


            //8

            t1_superior = new BasicNode(intelligentObjects, 360, -400);
            t1_superior.UpdateName("T42_E2");
            t2_superior = new BasicNode(intelligentObjects, 390, -400);
            t2_superior.UpdateName("T43_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 390, -380);
            t1_superior.UpdateName("T44_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 360, -380);
            t2_superior.UpdateName("T45_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 360, -400);
            t1_superior.UpdateName("T46_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 390, -380);
            t1_superior.UpdateName("T47_E2");
            t2_superior = new BasicNode(intelligentObjects, 390, -360);
            t2_superior.UpdateName("T48_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t1_superior = new BasicNode(intelligentObjects, 360, -360);
            t1_superior.UpdateName("T49_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
            t2_superior = new BasicNode(intelligentObjects, 360, -380);
            t2_superior.UpdateName("T50_E2");
            conector = new Path(intelligentObjects, t1_superior.GetInput(), t2_superior.GetInput());
        }

        private void CreateCard201504420(IIntelligentObjects intelligentObjects)
        {
            Draw.NumberCreator.CreateTwo(intelligentObjects, 0, -340);
            Draw.NumberCreator.CreateZero(intelligentObjects, 40, -340);
            Draw.NumberCreator.CreateOne(intelligentObjects, 80, -340);
            Draw.NumberCreator.CreateFive(intelligentObjects, 110, -340);
            Draw.NumberCreator.CreateZero(intelligentObjects, 150, -340);
            Draw.NumberCreator.CreateFour(intelligentObjects, 190, -340);
            Draw.NumberCreator.CreateFour(intelligentObjects, 230, -340);
            Draw.NumberCreator.CreateTwo(intelligentObjects, 270, -340);
            Draw.NumberCreator.CreateZero(intelligentObjects, 310, -340);
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
