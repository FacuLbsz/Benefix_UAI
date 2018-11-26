using Genesis.pdf;
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
        private List<EventoBitacora> eventosBitacora;

        public ConsultarBitacora()
        {
            InitializeComponent();
        }

        private void ConsultarBitacora_Load(object sender, EventArgs e)
        {
            exportarPdfButton.Enabled = false;
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
            fechaDesdeDate.Visible = false;
            fechaDesdeDate.Value = fechaDesdeDate.Value.Date.AddDays(-7);
            fechaDesdeDate.Visible = true;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.criticidadBox, "Criticidad del evento que deseas consultar");
            toolTip1.SetToolTip(this.usuarioBox, "Usuario en sesion");
            toolTip1.SetToolTip(this.consultarButton, "Consulta los eventos existentes para los filtros seleccionados");
            toolTip1.SetToolTip(this.exportarPdfButton, "Exporta los eventos encontrados en un documento PDF");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "23_Bitcora.htm");
        }

        private void popularTablaEventos(DateTime? fechaDesde, DateTime? fechaHasta, int? criticidad, int? idUsuario)
        {
            beneficiosDataGridView.Rows.Clear();
            eventosBitacora = gestorDeBitacora.ConsultarEventos(criticidad, idUsuario, fechaDesde, fechaHasta);

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

            if (eventosBitacora.Count > 0)
            {
                exportarPdfButton.Enabled = true;
            }
            else
            {
                exportarPdfButton.Enabled = false;
            }
        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            var fechaDesde = fechaDesdeDate.Value;
            var fechaHasta = fechaHastaDate.Value;

            Console.WriteLine("COMPARE TO: " + fechaDesde.CompareTo(fechaHasta));

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

        private void exportarPdfButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu arhivo .PDF";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var titulo = "Extracto de bitacora utilizando los filtros:";
                    titulo += "\n"+fechaDesdeLabel.Text + ": " + fechaDesdeDate.Value.ToString();
                    titulo += "\n"+fechaHastaLabel.Text + ": " + fechaHastaDate.Value.ToString();
                    titulo += "\n"+criticidadLabel.Text + ": " + criticidadBox.SelectedItem.ToString();
                    titulo += "\n"+usuarioLabel.Text + ": " + ((Usuario)usuarioBox.SelectedItem).nombreUsuario;
                    var filePath = fbd.SelectedPath + "\\Extracto de Bitacora.pdf";

                    List<String> columns = new List<string>();
                    columns.Add(usuario.HeaderText);
                    columns.Add(fecha.HeaderText);
                    columns.Add(funcionalidad.HeaderText);
                    columns.Add(descripcion.HeaderText);
                    columns.Add(criticidad.HeaderText);

                    new BitacoraPDF().ExportarPDFARuta(titulo, columns, eventosBitacora.Cast<Object>().ToList(), filePath);
                    MessageBox.Show("PDF creado con exito!");
                }
            }
        }
    }
}
