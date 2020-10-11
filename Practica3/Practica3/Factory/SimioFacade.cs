using SimioAPI;
using System;

namespace Practica3.Factory
{
    class SimioFacade
    {
        public readonly static string BASE_MODEL_PATH = "BaseModel.spfx";
        public readonly static string FINAL_MODEL_PATH = "FinalModel.spfx";
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
                Server server1 = new Server(intelligentObjects, 25, 25);
                Server server2 = new Server(intelligentObjects, 50, 50);
                BasicNode node = new BasicNode(intelligentObjects, 35, 35);
                Path path = new Path(intelligentObjects, server1.GetOutput(), server2.GetInput());
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
