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
    public partial class RealizarBackup : Form
    {
        private GestorSistema gestorSistema;
        private String SelectedPath = "";
        public RealizarBackup()
        {
            InitializeComponent();
            gestorSistema = GestorSistema.ObtenerInstancia();
        }

        private void exportarButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido() && ConsultarPermisosDeEscrituraEnRuta())
            {
                if (gestorSistema.RealizarBackup(rutaDestinoText.Text, Convert.ToInt32(cantidadDeVolumenesComboBox.SelectedItem.ToString())) == 1)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.BackupMessageSatisfactorio);
                }
                else
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.BackupMessageError);
                }
            }
        }

        private bool EsUnFormularioValido()
        {

            if(SelectedPath.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.BackupMessageRutaDestinoVacia);
                return false;
            }

            return true;
        }


        private bool ConsultarPermisosDeEscrituraEnRuta()
        {
            try
            {
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(rutaDestinoText.Text);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.BackupMessageSinAutorizacion);
                return false;
            }
        }

        private void RealizarBackup_Load(object sender, EventArgs e)
        {
            var index = cantidadDeVolumenesComboBox.Items.Add("1");
            cantidadDeVolumenesComboBox.Items.Add("3");
            cantidadDeVolumenesComboBox.Items.Add("5");

            cantidadDeVolumenesComboBox.SelectedIndex = index;

            rutaDestinoText.Enabled = false;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.seleccionarButton, "Selecciona la ruta donde depositar el backup");
            toolTip1.SetToolTip(this.cantidadDeVolumenesComboBox, "Indica la cantidad de particiones que representara el backup");
            toolTip1.SetToolTip(this.exportarButton, "Realiza el backup de la base de datos en la ruta seleccionada y en la cantidad de particiones ingresadas");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "24_RealizarBackUp.htm");
        }

        private void seleccionarButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu backup";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    rutaDestinoText.Text = fbd.SelectedPath;
                    SelectedPath = fbd.SelectedPath;
                }
            }
        }
    }
}
