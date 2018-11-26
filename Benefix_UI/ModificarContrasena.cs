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
    public partial class ModificarContrasena : Form
    {
        public ModificarContrasena()
        {
            InitializeComponent();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (EsFormularioValido())
            {
                var contrasenaAntigua = contrasenaActualText.Text;
                var contrasena = nuevaContrasenaText.Text;
                if (GestorDeUsuarios.ObtenerInstancia().ModificarContrasena(new Usuario() { identificador = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion().identificador }, contrasenaAntigua, contrasena))
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ModificarContrasenaSatisfactorio);
                }
                else
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ModificarContrasenaError);
                }
            }
        }

        private bool EsFormularioValido()
        {
            if(contrasenaActualText.Text.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.ModificarContrasenaActualRequerida);
                return false;
            }
            if (contrasenaActualText.Text.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.ModificarContrasenaNuevaRequerida);
                return false;
            }
            if (confirmarContraseñaTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.ConfirmarNuevaContraseñaRequerida);
                return false;
            }
            if (contrasenaActualText.Text.Trim().Equals(confirmarContraseñaTextBox.Text.Trim()))
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.ConfirmarNuevaContraseñaRequerida);
                return false;
            }
            return true;
        }

        private void ModificarContrasena_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.modificarButton, "Actualiza la contraseña por la ingresada");
        }
    }
}
