using System;
using System.Windows.Forms;

namespace Practica3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnGenerateModel_Click(object sender, EventArgs e)
        {
            bar.Visible = true;
            bar.Value = 20;
            Factory.SimioFacade simio = Factory.SimioFacade.GetInstance();
            bar.Value = 30;
            simio.CreateCards();
            bar.Value = 50;
            simio.CreateModel(Factory.SimioFacade.FINAL_MODEL_PATH);
            System.Threading.Thread.Sleep(6000);
            bar.Value = 85;
            System.Threading.Thread.Sleep(6000);
            bar.Value = 100;            
            bar.Visible = false;
        }
    }
}
