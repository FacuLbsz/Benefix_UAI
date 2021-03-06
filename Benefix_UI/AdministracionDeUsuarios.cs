﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class AdministracionDeUsuarios : Form
    {
        private GestorDeUsuarios gestorDeUsuarios;
        private int usuarioSeleccionado = 0;

        public AdministracionDeUsuarios()
        {
            InitializeComponent();
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();

        }


        private void AdministracionDeUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_USUARIOS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_USUARIOS_MODIFICACION);
            restablecerContraseñaButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_USUARIOS_MODIFICACION);
            asignarPatentesButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_USUARIOS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_USUARIOS_ELIMINACION);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.limpiarButton, Genesis.Recursos_localizables.StringResources.LimpiarButton);
            toolTip1.SetToolTip(this.crearButton, Genesis.Recursos_localizables.StringResources.CrearUsuarioNuevo);
            toolTip1.SetToolTip(this.modificarButton, Genesis.Recursos_localizables.StringResources.ModificarUsuarioNuevo);
            toolTip1.SetToolTip(this.eliminarButton, Genesis.Recursos_localizables.StringResources.EliminarUsuarioNuevo);

            toolTip1.SetToolTip(this.asignarPatentesButton, Genesis.Recursos_localizables.StringResources.AsignarPatenteUsuarioTooltip);
            toolTip1.SetToolTip(this.desbloquearUsuarioButton, Genesis.Recursos_localizables.StringResources.DesbloquearUsuarioTooltip);
            toolTip1.SetToolTip(this.restablecerContraseñaButton, Genesis.Recursos_localizables.StringResources.RestablecerContraseñaTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "18_Administracindeusuarios.htm");
        }

        private void AdministracionDeUsuarios_Shown(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            LimpiarFormulario();
        }



        private void asignarPatentesButton_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario() { identificador = usuarioSeleccionado };

            AsignarPatentesAUsuarios mainForm = new AsignarPatentesAUsuarios(usuario);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void restablecerContraseñaButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu contraseña";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var contrasena = StringRandom(8);
                    Usuario usuario = new Usuario() { identificador = usuarioSeleccionado, contrasena = contrasena };

                    gestorDeUsuarios.ModificarUsuario(usuario);

                    var filePath = fbd.SelectedPath + "\\" + nombreDeUsuarioText.Text + "_contraseña.txt";

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Dispose();

                        using (TextWriter tw = new StreamWriter(filePath))
                        {
                            tw.WriteLine(contrasena);
                        }

                    }
                    else if (File.Exists(filePath))
                    {
                        using (TextWriter tw = new StreamWriter(filePath))
                        {
                            tw.WriteLine(contrasena);
                        }
                    }

                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageContraseñaRestablecida + filePath);
                }
            }

        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == 0 && nombreText.Text.Trim().Length > 0 && apellidoText.Text.Trim().Length > 0)
                nombreDeUsuarioText.Text = nombreText.Text.Trim().Split(' ')[0] + "." + apellidoText.Text.Trim().Split(' ')[0];
        }

        private void apellidoText_TextChanged(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == 0 && nombreText.Text.Trim().Length > 0 && apellidoText.Text.Trim().Length > 0)
                nombreDeUsuarioText.Text = nombreText.Text.Trim().Split(' ')[0] + "." + apellidoText.Text.Trim().Split(' ')[0];
        }

        private void crearButton_Click(object sender, EventArgs e)
        {

            if (EsUnFormularioValido())
            {
                var nombreUsuario = nombreDeUsuarioText.Text;
                var nombre = nombreText.Text;
                var apellido = apellidoText.Text;
                var email = emailText.Text;
                var contrasena = StringRandom(8);

                Usuario usuario = new Usuario() { nombreUsuario = nombreUsuario, nombre = nombre, apellido = apellido, email = email, contrasena = contrasena, habilitado = true };

                try
                {
                    gestorDeUsuarios.CrearUsuario(usuario);

                    using (var fbd = new FolderBrowserDialog())
                    {
                        fbd.Description = "Selecciona donde depositar tu contraseña";
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {

                            var filePath = fbd.SelectedPath + "\\" + nombreDeUsuarioText.Text + "_contraseña.txt";

                            if (!File.Exists(filePath))
                            {
                                File.Create(filePath).Dispose();

                                using (TextWriter tw = new StreamWriter(filePath))
                                {
                                    tw.WriteLine(contrasena);
                                }

                            }
                            else if (File.Exists(filePath))
                            {
                                using (TextWriter tw = new StreamWriter(filePath))
                                {
                                    tw.WriteLine(contrasena);
                                }
                            }

                        }
                    }


                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageSatisfactorio);
                    LimpiarFormulario();
                    ListarUsuarios();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    if (excepcion.atributo == "nombreUsuario")
                    {
                        nombreDeUsuarioText.Text = nombreDeUsuarioText.Text + StringRandom(2);
                        MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeFamiliasMessageNombreDubplicado + " " + nombreDeUsuarioText.Text);
                        crearButton_Click(sender, e);
                    }
                    else if (excepcion.atributo == "email")
                    {
                        MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeUsuariosMessageEmailDuplicado);
                    }
                }
            }




        }

        private String StringRandom(int cantidadDeCaracteres)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[cantidadDeCaracteres];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
            //return "osxApZQd";
        }

        private void ListarUsuarios()
        {
            List<Usuario> usuarios = gestorDeUsuarios.ConsultarUsuarios();

            dataGridView1.DataSource = usuarios;
            dataGridView1.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.DataPropertyName != "nombreUsuario")
                    col.Visible = false;
            }

            dataGridView1.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            usuarioSeleccionado = 0;

            nombreDeUsuarioText.Clear();
            nombreText.Clear();
            apellidoText.Clear();
            emailText.Clear();

            restablecerContraseñaButton.Enabled = false;
            asignarPatentesButton.Enabled = false;
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            desbloquearUsuarioButton.Enabled = false;

            crearButton.Enabled = true;

            nombreText.Focus();
        }

        private bool EsUnFormularioValido()
        {
            var nombre = nombreText.Text;

            if (nombre.Trim().Length == 0 || !Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageNombreRequerido);
                return false;
            }

            var apellido = apellidoText.Text;
            if (apellido.Trim().Length == 0 || !Regex.IsMatch(apellido, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeUsuariosMessageApellidoRequerido);
                return false;
            }

            var email = emailText.Text;

            if (email.Trim().Length > 0)
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                }
                catch (FormatException)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageEmailInvalido);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageEmailRequerido);
                return false;
            }

            return true;
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

            restablecerContraseñaButton.Enabled = true;
            asignarPatentesButton.Enabled = true;
            modificarButton.Enabled = true;
            eliminarButton.Enabled = true;
            desbloquearUsuarioButton.Enabled = true;

            crearButton.Enabled = false;

            Usuario usuarioSeleccionado = (Usuario)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DataBoundItem;
            Usuario usuario = gestorDeUsuarios.ObtenerUsuario(usuarioSeleccionado.identificador);

            this.usuarioSeleccionado = usuarioSeleccionado.identificador;

            nombreDeUsuarioText.Text = usuario.nombreUsuario;
            nombreText.Text = usuario.nombre;
            apellidoText.Text = usuario.apellido;
            emailText.Text = usuario.email;

            Console.WriteLine("SELECCIONADO: dataGridView1_CellContentClick");
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                var apellido = apellidoText.Text;
                var email = emailText.Text;

                Usuario usuario = new Usuario() { identificador = usuarioSeleccionado, nombre = nombre, apellido = apellido, email = email };

                try
                {
                    gestorDeUsuarios.ModificarUsuario(usuario);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageUsuarioModificado);
                    LimpiarFormulario();
                    ListarUsuarios();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    if (excepcion.atributo == "email")
                    {
                        MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeUsuariosMessageEmailDuplicado);
                    }
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                gestorDeUsuarios.EliminarUsuario(new Usuario() { identificador = usuarioSeleccionado });
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageUsuarioEliminado);
                LimpiarFormulario();
                ListarUsuarios();
            }
            catch (Exception exc)
            {
                MessageBox.Show("No es posible eliminar el usuario debido a que la patente " + exc.Message + " no se encuentra asignada a otro usuario.");

            }
        }

        private void desbloquearUsuarioButton_Click(object sender, EventArgs e)
        {
            gestorDeUsuarios.DesbloquearUsuario(new Usuario() { identificador = usuarioSeleccionado });
            MessageBox.Show(Genesis.Recursos_localizables.StringResources.DesbloquearUsuarioLabel);

            var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se debloquea el usuario " + usuarioSeleccionado, criticidad = 1, funcionalidad = "ADMINISTACION DE USUARIOS", usuario = null };
            GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
        }
    }
}
