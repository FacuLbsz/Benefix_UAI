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
    public partial class AdministracionDeUsuarios : Form
    {
        public AdministracionDeUsuarios()
        {
            InitializeComponent();
        }

        private void asignarPatentesButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarPatentesAUsuarios();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void restablecerContraseñaButton_Click(object sender, EventArgs e)
        {

        }
    }
}
