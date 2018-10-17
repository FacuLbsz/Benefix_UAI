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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainForm = new Sistema();
            mainForm.Closed += (s, args) => this.Close();
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Show();

            Usuario usuario = new Usuario() { identificador = 2 };
            EventoBitacora evento = new EventoBitacora() { fecha = new DateTime(), descripcion = "Login", criticidad = 2, funcionalidad = "LOGIN", usuario = usuario };

            GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        }

        private void modificarStringButton_Click(object sender, EventArgs e)
        {
            var mainForm = new ModificarStringDeConexion();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
