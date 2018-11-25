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

        public ReportesDeObjetivosPorEquipos()
        {
            InitializeComponent();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();
            gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
        }

        private void ReportesDeObjetivosPorEquipos_Load(object sender, EventArgs e)
        {
            periodos = new Dictionary<String, int>();
            var periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));


            var dateAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            var periodoAnterior = Convert.ToInt32(dateAnterior.ToString("yyyyMM"));

            periodos.Add(ObtenerMes(DateTime.Now.Month) + " " + DateTime.Now.Year, periodoActual);
            periodos.Add(ObtenerMes(dateAnterior.Month) + " " + dateAnterior.Year, periodoAnterior);

            periodoBox.DataSource = periodos.Keys.ToList();

            ListarEquipos();
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
                MessageBox.Show("Debe seleccionar un equipo.");
                return;
            }

            var periodoSeleccionado = periodoBox.SelectedItem != null;

            if (!periodoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un periodo.");
                return;
            }

            var equipoSeleccionadoo = (Equipo)equiposDataGridView.Rows[equiposDataGridView.CurrentCell.RowIndex].DataBoundItem;

            empleadosListView.UseAlternatingBackColors = true;
            var evaluaciones = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEquipoParaUnPeriodo(equipoSeleccionadoo, periodos[periodoBox.SelectedItem.ToString()]);
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
            }
            else
            {
                MessageBox.Show("No se encuentran empleados para el periodo y el equipo seleccionado.");
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
    }
}
