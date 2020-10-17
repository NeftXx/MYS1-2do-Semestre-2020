using System;
using System.Windows.Forms;

namespace Practica3
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///Factory.SimioFacade simio = Factory.SimioFacade.GetInstance();
            //simio.CreateModel(Factory.SimioFacade.FINAL_MODEL_PATH);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
