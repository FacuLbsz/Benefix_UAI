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
    public partial class ReportesDeObjetivosPorEquipos : Form
    {
        private Dictionary<string, int> periodos;
        private GestorDeEquipos gestorDeEquipos;
        private GestorDeEvaluaciones gestorDeEvaluaciones;
        private Equipo equipoSeleccionadoo;
        private List<object[]> evaluaciones;

        public ReportesDeObjetivosPorEquipos()
        {
            InitializeComponent();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();
            gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
        }

        private void ReportesDeObjetivosPorEquipos_Load(object sender, EventArgs e)
        {

            exportarPdfButton.Enabled = false;
            periodos = new Dictionary<String, int>();
            var periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));


            var dateAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            var periodoAnterior = Convert.ToInt32(dateAnterior.ToString("yyyyMM"));

            periodos.Add(ObtenerMes(DateTime.Now.Month) + " " + DateTime.Now.Year, periodoActual);
            periodos.Add(ObtenerMes(dateAnterior.Month) + " " + dateAnterior.Year, periodoAnterior);

            periodoBox.DataSource = periodos.Keys.ToList();

            ListarEquipos();

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            this.empleado.ToolTipText = "Empleados asignados al equipo seleccionado";
            this.cumplimientoPorc.ToolTipText = "Indica el porcentaje de objetivos cumplidos respecto de los asignados";

            toolTip1.SetToolTip(this.exportarPdfButton, Genesis.Recursos_localizables.StringResources.ExportarPdfButtonTooltip);
            toolTip1.SetToolTip(this.consultarButton, Genesis.Recursos_localizables.StringResources.ConsultarPorcentajeButtonTooltip);
            toolTip1.SetToolTip(this.periodoBox, Genesis.Recursos_localizables.StringResources.PeriodoBoxTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "7_ReportesObjetivosporequipo.htm");
        }

        private void ListarEquipos()
        {
            List<Equipo> equipos = gestorDeEquipos.ConsultarEquipos();

            equiposDataGridView.DataSource = equipos;
            equiposDataGridView.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in equiposDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            equiposDataGridView.ClearSelection();
        }

        private void ReportesDeObjetivosPorEquipos_Shown(object sender, EventArgs e)
        {
            equiposDataGridView.ClearSelection();
        }

        private void consultarButton_Click(object sender, EventArgs e)
        {
            var equipoSeleccionado = equiposDataGridView.CurrentCell != null && equiposDataGridView.SelectedRows.Count > 0 && equiposDataGridView.Rows[equiposDataGridView.SelectedRows[0].Index].DataBoundItem != null;

            if (!equipoSeleccionado)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.DebeSeleccionarUnEquipo);
                return;
            }

            var periodoSeleccionado = periodoBox.SelectedItem != null;

            if (!periodoSeleccionado)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.DebeSeleccionarUnPeriodo);
                return;
            }

            equipoSeleccionadoo = (Equipo)equiposDataGridView.Rows[equiposDataGridView.CurrentCell.RowIndex].DataBoundItem;

            empleadosListView.UseAlternatingBackColors = true;
            evaluaciones = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEquipoParaUnPeriodo(equipoSeleccionadoo, periodos[periodoBox.SelectedItem.ToString()]);
            empleadosListView.ClearObjects();

            this.empleado.AspectGetter = delegate (object rowObject)
            {
                Object[] obj = (Object[])rowObject;
                return obj[0].ToString();
            };

            this.cumplimientoPorc.AspectGetter = delegate (object rowObject)
            {
                Object[] obj = (Object[])rowObject;
                return obj[1].ToString();
            };

            if (evaluaciones.Count > 0)
            {
                empleadosListView.AddObjects(evaluaciones);
                exportarPdfButton.Enabled = true;
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.SinEmpleadosParaElPeriodo);
                exportarPdfButton.Enabled = false;
            }
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

        private void exportarPdfButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona donde depositar tu arhivo .PDF";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var nombreEquipo = equipoSeleccionadoo.nombre;
                    var titulo = "Cumplimiento de los objetivos por empleado del equipo " + nombreEquipo + " para el periodo " + periodoBox.SelectedItem;
                    var filePath = fbd.SelectedPath + "\\" + periodoBox.SelectedItem + "_Objetivos de " + nombreEquipo + ".pdf";

                    List<String> columns = new List<string>();
                    columns.Add(empleado.Text);
                    columns.Add(cumplimientoPorc.Text);

                    new ReportesDeObjetivosPorEquiposPDF().ExportarPDFARuta(titulo, columns, evaluaciones.Cast<Object>().ToList(), filePath);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.PDFCreadoSatisfactorio);
                }
            }
        }
    }
}
