using System;
using System.Windows.Forms;

namespace HT6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnModelo_Click(object sender, EventArgs e)
        {
            _201504420.CrearModelo();
        }
    }
}
