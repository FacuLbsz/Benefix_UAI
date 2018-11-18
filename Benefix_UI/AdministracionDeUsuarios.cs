using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            var contrasena = StringRandom(8);
            Usuario usuario = new Usuario() { identificador = usuarioSeleccionado, contrasena = contrasena };

            gestorDeUsuarios.ModificarUsuario(usuario);
            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageContraseñaRestablecida + contrasena);
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
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageSatisfactorio + " " + contrasena);
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
            gestorDeUsuarios.EliminarUsuario(new Usuario() { identificador = usuarioSeleccionado });
            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageUsuarioEliminado);
            LimpiarFormulario();
            ListarUsuarios();
        }
    }
}
