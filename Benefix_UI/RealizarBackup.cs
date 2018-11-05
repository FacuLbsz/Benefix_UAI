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
                    MessageBox.Show("El backup se ha realizado correctamente en la ruta indicada.");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error realizando el backup, por favor comuniquese con el administrador del sistema.");
                }
            }
        }

        private bool EsUnFormularioValido()
        {

            if(rutaDestinoText.Text.Trim().Length == 0)
            {
                MessageBox.Show("La ruta destino es requerida.");
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
                MessageBox.Show("Benefix no cuenta con permisos de escritura en la ruta ingresada.");
                return false;
            }
        }

        private void RealizarBackup_Load(object sender, EventArgs e)
        {
            var index = cantidadDeVolumenesComboBox.Items.Add("1");
            cantidadDeVolumenesComboBox.Items.Add("3");
            cantidadDeVolumenesComboBox.Items.Add("5");

            cantidadDeVolumenesComboBox.SelectedIndex = index;

            rutaDestinoText.Text = "C:\\Users\\Facundo-Zenbook\\Desktop";
        }
    }
}
