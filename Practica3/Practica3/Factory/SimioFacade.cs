using SimioAPI;
using System;

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
                System.IO.File.WriteAllBytes(BASE_MODEL_PATH, FileStore.Resource.BaseModel);
                ISimioProject project = SimioProjectFactory.LoadProject(BASE_MODEL_PATH, out string[] warnings);
                IModel model = project.Models[1];
                IIntelligentObjects intelligentObjects = model.Facility.IntelligentObjects;
                CreateRegions(intelligentObjects);
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
