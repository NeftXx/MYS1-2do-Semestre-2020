using System;
using System.Windows.Forms;
using Practica3.Factory;

namespace _MYS1_API_P37
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimioFacade simio = SimioFacade.GetInstance();
            simio.CreateModel(SimioFacade.FINAL_MODEL_PATH);
        }
    }
}
