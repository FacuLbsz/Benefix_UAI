﻿using System;
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
                var resultadoLogin = GestorSistema.ObtenerInstancia().RealizarLogIn(usuario);
                if (resultadoLogin == 1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(GestorIdioma.ObtenerInstancia().ObtenerIdiomaDeUnUsuario(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion()).nombre);

                    this.Hide();
                    var mainForm = new Sistema();
                    mainForm.Closed += (s, args) => this.Close();
                    mainForm.WindowState = FormWindowState.Maximized;
                    mainForm.Show();
                }
                else if (resultadoLogin == 2)
                {
                    MessageBox.Show("El usuario se encuentra bloqueado, por favor contacte al adminsitrador de sistema.");
                }
                else
                {
                    MessageBox.Show("El usuario y la contraseña ingresada no coinciden para un usuario valido.");
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
                    ingresarButton.Enabled = false;
                    recalcularDigitosButton.Visible = true;
                    MessageBox.Show("La integridad de la base de datos ha sido corrompida, por favor comuniquese con el administrador de sistema.");
                }
                else
                {
                    ingresarButton.Enabled = cb;
                    MessageBox.Show("La conexion a la base de datos fue satisfactoria.");
                }
            });
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            //nombreUsuarioText.Text = "admin.admin";
            //contraseñaText.Text = "osxApZQd";
            var modificarStringBienvenidoFallo = false;
            recalcularDigitosButton.Visible = false;
            try
            {
                GestorSistema.ObtenerInstancia();

            }
            catch (Exception exc)
            {
                Bienvenido bienvenido = new Bienvenido((stringDConexion) =>
                {
                    try
                    {
                        GestorSistema.ModificarStringDeConexion(stringDConexion);
                        MessageBox.Show("La conexion a la base de datos fue satisfactoria.");
                    }
                    catch (Exception modifExc)
                    {
                        modificarStringBienvenidoFallo = true;
                        MessageBox.Show(modifExc.Message);
                    }
                });
                bienvenido.StartPosition = FormStartPosition.CenterScreen;
                bienvenido.ShowDialog();
            }

            try
            {
                if (GestorSistema.ObtenerInstancia().ConsultarIntegridadDeBaseDeDatos() == 0)
                {
                    ingresarButton.Enabled = false;
                    recalcularDigitosButton.Visible = true;
                    MessageBox.Show("La integridad de la base de datos ha sido corrompida, por favor comuniquese con el administrador de sistema.");
                }

            }
            catch (Exception exc)
            {
                ingresarButton.Enabled = false;
                if (!modificarStringBienvenidoFallo)
                {
                    MessageBox.Show("No ha sido posible acceder a la base de datos configurada, por favor modifique el string de conexion.");
                }
            }

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.ingresarButton, "Ingresa a la aplicacion con los datos de ingreso");
            toolTip1.SetToolTip(this.modificarStringButton, "Modifica el string de conexion para el acceso a la base de datos");
            toolTip1.SetToolTip(this.recalcularDigitosButton, "Reconstruye la integridad de la base de datos");


            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm" ;
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "2_Login.htm");

        }

        private void recalcularDigitosButton_Click(object sender, EventArgs e)
        {
            GestorSistema.ObtenerInstancia().RecalcularDigitosVerificadores();

            if (GestorSistema.ObtenerInstancia().ConsultarIntegridadDeBaseDeDatos() == 0)
            {
                ingresarButton.Enabled = false;
                recalcularDigitosButton.Visible = true;
                MessageBox.Show("La integridad de la base de datos ha sido corrompida, por favor comuniquese con el administrador de sistema.");
            }
            else
            {
                ingresarButton.Enabled = true;
                recalcularDigitosButton.Visible = false;
                MessageBox.Show("Se ha corregido la integridad de la base de datos correctamente.");
            }
        }
    }
}
