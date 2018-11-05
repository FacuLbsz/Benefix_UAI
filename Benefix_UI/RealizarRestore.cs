using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class RealizarRestore : Form
    {
        private GestorSistema gestorSistema;
        public RealizarRestore()
        {
            InitializeComponent();
            rutaOrigenText.Enabled = false;
            gestorSistema = GestorSistema.ObtenerInstancia();

            openFileDialog1.Filter = "Zip Files|*.zip"; ;
        }

        private void importarButton_Click(object sender, EventArgs e)
        {
            if (rutaOrigenText.Text.Trim().Length > 0)
            {
                try
                {
                    System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(rutaOrigenText.Text);

                    if (gestorSistema.RealizarRestore(rutaOrigenText.Text) == 1)
                    {
                        MessageBox.Show("El restore se ha realizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error realizando el restore, por favor comuniquese con el administrador del sistema.");
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Benefix no cuenta con permisos de lectura en la ruta ingresada.");
                }
            }
            else
            {
                MessageBox.Show("Sebe seleccionar un archivo backup para importar.");
            }
        }

        private void seleccionarArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                rutaOrigenText.Text = openFileDialog1.FileName;
            }
        }
    }
}
