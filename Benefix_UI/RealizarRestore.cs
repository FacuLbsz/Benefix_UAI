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
                        MessageBox.Show(Genesis.Recursos_localizables.StringResources.RestoreMessageSatisfactorio);
                    }
                    else
                    {
                        MessageBox.Show(Genesis.Recursos_localizables.StringResources.RestoreMessageError);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.RestoreMessageSinAutorizacion);
                }
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.RestoreMessageVacio);
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
