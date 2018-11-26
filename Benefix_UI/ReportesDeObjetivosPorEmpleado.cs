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
    public partial class ReportesDeObjetivosPorEmpleado : Form
    {
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeEvaluaciones gestorDeEvaluaciones;
        private Dictionary<String, int> periodos;
        private Usuario usuarioSeleccionado;
        private List<Evaluacion> evaluaciones;

        public ReportesDeObjetivosPorEmpleado()
        {
            InitializeComponent();
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
            gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportesDeObjetivosPorEmpleado_Load(object sender, EventArgs e)
        {
            exportarPdfButton.Enabled = false;
            periodos = new Dictionary<String, int>();
            var periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));


            var dateAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            var periodoAnterior = Convert.ToInt32(dateAnterior.ToString("yyyyMM"));

            periodos.Add(ObtenerMes(DateTime.Now.Month) + " " + DateTime.Now.Year, periodoActual);
            periodos.Add(ObtenerMes(dateAnterior.Month) + " " + dateAnterior.Year, periodoAnterior);

            periodoBox.DataSource = periodos.Keys.ToList();

            ListarUsuarios();

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            this.equipo.ToolTipText = "Objetivos asignados a los equipos que pertenece el usuario seleccionado";
            this.cumplimiento.ToolTipText = "Indica si el usuario cumplio el objetivo";

            toolTip1.SetToolTip(this.exportarPdfButton, "Exporta el reporte en un documento PDF");
            toolTip1.SetToolTip(this.consultarButton, "Consulta el estado de cumplimiento de objetivos del empleado seleccionado");
            toolTip1.SetToolTip(this.periodoBox, "Periodo en el cual se evaluaron los empleados");
        }

        private void ListarUsuarios()
        {
            List<Usuario> usuarios = gestorDeUsuarios.ConsultarUsuarios();

            empleadosDataGridView.DataSource = usuarios;
            empleadosDataGridView.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in empleadosDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombreUsuario")
                    col.Visible = false;
            }

            empleadosDataGridView.ClearSelection();
        }

        private String ObtenerMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
                default:
                    return "";
            }
        }

        private void ReportesDeObjetivosPorEmpleado_Shown(object sender, EventArgs e)
        {
            empleadosDataGridView.ClearSelection();
        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            var empleadoSeleccionado = empleadosDataGridView.CurrentCell != null && empleadosDataGridView.SelectedRows.Count > 0 && empleadosDataGridView.Rows[empleadosDataGridView.SelectedRows[0].Index].DataBoundItem != null;

            if (!empleadoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un empleado.");
                return;
            }

            var periodoSeleccionado = periodoBox.SelectedItem != null;

            if (!periodoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un periodo.");
                return;
            }

            usuarioSeleccionado = (Usuario)empleadosDataGridView.Rows[empleadosDataGridView.CurrentCell.RowIndex].DataBoundItem;
            this.equipo.GroupKeyGetter = delegate (object rowObject)
            {
                Evaluacion evaluacion = (Evaluacion)rowObject;
                return evaluacion.equipoObjetvo.equipo.nombre;
            };

            this.equipo.GroupKeyToTitleConverter = delegate (object groupKey)
            {
                return groupKey.ToString();
            };
            evaluacionesListView.UseAlternatingBackColors = true;
            evaluaciones = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEmpleadoParaUnPeriodo(usuarioSeleccionado, periodos[periodoBox.SelectedItem.ToString()]);
            evaluacionesListView.ClearObjects();

            if (evaluaciones.Count > 0)
            {
                evaluacionesListView.AddObjects(evaluaciones);
                exportarPdfButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encuentran equipos y o objetivos para el periodo y el empleado seleccionado.");
                exportarPdfButton.Enabled = false;
            }
        }

        private void exportarPdfButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu arhivo .PDF";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var nombreEmpleado = usuarioSeleccionado.nombreUsuario.Replace(".", " ");
                    var titulo = "Cumplimiento de los objetivos por equipo del empleado " + nombreEmpleado + " para el periodo " + periodoBox.SelectedItem;
                    var filePath = fbd.SelectedPath + "\\" + periodoBox.SelectedItem + "_Objetivos de " + nombreEmpleado + ".pdf";

                    List<String> columns = new List<string>();
                    columns.Add(equipo.Text);
                    columns.Add(cumplimiento.Text);

                    new ReportesDeObjetivosPorEmpleadoPDF().ExportarPDFARuta(titulo, columns, evaluaciones.Cast<Object>().ToList(), filePath);
                    MessageBox.Show("PDF creado con exito!");
                }
            }
        }
    }
}
