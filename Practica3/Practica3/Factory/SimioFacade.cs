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
            new int[]{ 0, 0, 5, 20, 30, -10, 15, 20, -15, 20, -40, 10, -40, 20, 10, -50 };

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
                BasicNode node = new BasicNode(intelligentObjects, 35, 35);
                SimioProjectFactory.SaveProject(project, finalModelPath, out warnings);
                System.IO.File.WriteAllLines(WARNINGS_FILE_PATH, warnings);
            } catch (Exception e)
            {
                System.IO.File.WriteAllText(WARNINGS_FILE_PATH, e.Message);
            }
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
