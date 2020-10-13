using SimioAPI;
using System;
using System.Collections.Generic;

namespace Practica3.Factory
{
    class SimioFacade
    {
        public readonly static string BASE_MODEL_PATH = "[MYS1]ModeloBase_P37.spfx";
        public readonly static string FINAL_MODEL_PATH = "[MYS1]ModeloFinal_P37.spfx";
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
                List<Util.Coordinate> lista = Util.ReadCSV.GetCoordanates();





                System.IO.File.WriteAllBytes(BASE_MODEL_PATH, FileStore.Resource.BaseModel);
                ISimioProject project = SimioProjectFactory.LoadProject(BASE_MODEL_PATH, out string[] warnings);
                IModel model = project.Models[1];
                IIntelligentObjects intelligentObjects = model.Facility.IntelligentObjects;
                CreateRegions(intelligentObjects);
                CreateCarnet201503918(intelligentObjects);
                CreateCard201504420(intelligentObjects);

                

                SimioProjectFactory.SaveProject(project, finalModelPath, out warnings);
                System.IO.File.WriteAllLines(WARNINGS_FILE_PATH, warnings);
            } catch (Exception e)
            {
                System.IO.File.WriteAllText(WARNINGS_FILE_PATH, e.Message);
            }
        }

        private void CreateRegions(IIntelligentObjects intelligentObjects)
        {
            BasicNode region1 = new BasicNode(intelligentObjects, COORDINATES[0], COORDINATES[1]),
                region2 = new BasicNode(intelligentObjects, COORDINATES[2], COORDINATES[3]),
                region3 = new BasicNode(intelligentObjects, COORDINATES[4], COORDINATES[5]),
                region4 = new BasicNode(intelligentObjects, COORDINATES[6], COORDINATES[7]),
                region5 = new BasicNode(intelligentObjects, COORDINATES[8], COORDINATES[9]),
                region6 = new BasicNode(intelligentObjects, COORDINATES[10], COORDINATES[11]),
                region7 = new BasicNode(intelligentObjects, COORDINATES[12], COORDINATES[13]),
                region8 = new BasicNode(intelligentObjects, COORDINATES[14], COORDINATES[15]);
            region1.UpdateName("Region1");
            region2.UpdateName("Region2");
            region3.UpdateName("Region3");
            region4.UpdateName("Region4");
            region5.UpdateName("Region5");
            region6.UpdateName("Region6");
            region7.UpdateName("Region7");
            region8.UpdateName("Region8");
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
