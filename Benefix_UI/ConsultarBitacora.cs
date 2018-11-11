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
    public partial class ConsultarBitacora : Form
    {

        private GestorDeBitacora gestorDeBitacora;
        private GestorDeUsuarios gestorDeUsuarios;

        public ConsultarBitacora()
        {
            InitializeComponent();
        }

        private void ConsultarBitacora_Load(object sender, EventArgs e)
        {
            gestorDeBitacora = GestorDeBitacora.ObtenerInstancia();
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();

            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { nombreUsuario = "TODOS", identificador = 0 });
            usuarios.AddRange(gestorDeUsuarios.ConsultarUsuariosTodos());

            usuarioBox.DataSource = usuarios;
            usuarioBox.DisplayMember = "nombreUsuario";
            usuarioBox.ValueMember = "identificador";


            criticidadBox.DataSource = new List<String> { "TODOS", "Alta", "Media", "Baja" };

            fechaDesdeDate.Checked = false;
            fechaDesdeDate.Visible= false;
            fechaDesdeDate.Value =  fechaDesdeDate.Value.Date.AddDays(-7);
            fechaDesdeDate.Visible = true;


        }

        private void popularTablaEventos(DateTime? fechaDesde, DateTime? fechaHasta, int? criticidad, int? idUsuario)
        {
            beneficiosDataGridView.Rows.Clear();
            List<EventoBitacora> eventosBitacora = gestorDeBitacora.ConsultarEventos(criticidad, idUsuario, fechaDesde, fechaHasta);

            foreach (EventoBitacora eventoBitacora in eventosBitacora)
            {
                var index = beneficiosDataGridView.Rows.Add();

                String criticidadString = "";
                switch (eventoBitacora.criticidad)
                {
                    case 1:
                        criticidadString = "Alta";
                        break;
                    case 2:
                        criticidadString = "Media";
                        break;
                    case 3:
                        criticidadString = "Baja";
                        break;
                }
                beneficiosDataGridView.Rows[index].Cells["criticidad"].Value = criticidadString;
                beneficiosDataGridView.Rows[index].Cells["usuario"].Value = eventoBitacora.usuario.nombreUsuario;
                beneficiosDataGridView.Rows[index].Cells["fecha"].Value = eventoBitacora.fecha;
                beneficiosDataGridView.Rows[index].Cells["funcionalidad"].Value = eventoBitacora.funcionalidad;
                beneficiosDataGridView.Rows[index].Cells["descripcion"].Value = eventoBitacora.descripcion;

            }
        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            var fechaDesde = fechaDesdeDate.Value;
            var fechaHasta = fechaHastaDate.Value;

            Console.WriteLine("COMPARE TO: "+fechaDesde.CompareTo(fechaHasta));

            if (fechaDesde.CompareTo(fechaHasta) > 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.BitacoraMessageFechaIncorrecta);
                return;
            }

            String criticidad = criticidadBox.SelectedItem.ToString();
            int? criticidadInt = null;
            switch (criticidad)
            {
                case "Alta":
                    criticidadInt = 1;
                    break;
                case "Media":
                    criticidadInt = 2;
                    break;
                case "Baja":
                    criticidadInt = 3;
                    break;
            }

            Usuario usuario = (Usuario)usuarioBox.SelectedItem;
            int? idUsuario = null;
            if (usuario.identificador > 0)
            {
                idUsuario = usuario.identificador;
            }

            popularTablaEventos(fechaDesde, fechaHasta, criticidadInt, idUsuario);
        }
    }
}
