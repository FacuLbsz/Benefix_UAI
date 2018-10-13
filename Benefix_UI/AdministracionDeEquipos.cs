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
    public partial class AdministracionDeEquipos : Form
    {
        public AdministracionDeEquipos()
        {
            InitializeComponent();
        }

        private void asignarCoordinadorButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarCoordinador();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarEmpleadosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarEmpleados();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarGruposButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarGrupos();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
