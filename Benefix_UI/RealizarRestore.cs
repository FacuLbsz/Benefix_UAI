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

        private void RealizarRestore_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.seleccionarArchivo, "Selecciona el archivo rar que representa el backup a restaurar");
            toolTip1.SetToolTip(this.importarButton, "Restaura la base de datos a partir del archivo seleccionado");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "25_Realizarrestore.htm");
        }
    }
}
