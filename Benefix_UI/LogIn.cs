using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

            if (EsUnFormularioValido())
            {

                Usuario usuario = new Usuario() { nombreUsuario = nombreUsuarioText.Text.Trim(), contrasena = contraseñaText.Text.Trim() };
                if (GestorSistema.ObtenerInstancia().RealizarLogIn(usuario) == 1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(GestorIdioma.ObtenerInstancia().ObtenerIdiomaDeUnUsuario(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion()).nombre);

                    this.Hide();
                    var mainForm = new Sistema();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.WindowState = FormWindowState.Maximized;
                    mainForm.Show();

                    EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Login", criticidad = 2, funcionalidad = "LOGIN", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
                    GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
                }
            }
        }

        private Boolean EsUnFormularioValido()
        {
            if (nombreUsuarioText.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.");
                return false;
            }
            if (contraseñaText.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return false;
            }

            return true;
        }

        private void modificarStringButton_Click(object sender, EventArgs e)
        {
            var mainForm = new ModificarStringDeConexion((cb) =>
            {
                //SDC Agregar llamado a consultar integridad de base de datos
                if (GestorSistema.ObtenerInstancia().ConsultarIntegridadDeBaseDeDatos() == 0)
                {
                    //     ingresarButton.Enabled = false;
                    MessageBox.Show("La integridad de la base de datos ha sido corrompida, por favor comuniquese con el administrador de sistema.");
                }
                else
                {
                    ingresarButton.Enabled = cb;
                }
            });
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            nombreUsuarioText.Text = "facundo.nicolas";
            contraseñaText.Text = "osxApZQd";

            try
            {
                GestorSistema.ObtenerInstancia();

            }
            catch (Exception exc)
            {
                Bienvenido bienvenido = new Bienvenido((stringDConexion) =>
                {
                    GestorSistema.ModificarStringDeConexion(stringDConexion);
                });
                bienvenido.ShowDialog();
            }

            try
            {
                if (GestorSistema.ObtenerInstancia().ConsultarIntegridadDeBaseDeDatos() == 0)
                {
                    //     ingresarButton.Enabled = false;
                    MessageBox.Show("La integridad de la base de datos ha sido corrompida, por favor comuniquese con el administrador de sistema.");
                }

            }
            catch (Exception exc)
            {
                //     ingresarButton.Enabled = false;
                MessageBox.Show("No ha sido posible acceder a la base de datos configurada, por favor modifique el string de conexion.");
            }
        }

    }
}
