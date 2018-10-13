using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class AdministracionDeFamilias : Form
    {
        public AdministracionDeFamilias()
        {
            InitializeComponent();
        }

        private void asignarPatentesButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarPatentesAFamilias();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarUsuariosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarUsuarios();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
