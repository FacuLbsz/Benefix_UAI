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
