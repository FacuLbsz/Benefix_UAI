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
    public partial class ReportesDeBeneficiosPorEmpleado : Form
    {
        private Dictionary<string, int> periodos;
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeBeneficios gestorDeBeneficios;

        public ReportesDeBeneficiosPorEmpleado()
        {
            InitializeComponent();
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
            gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportesDeBeneficiosPorEmpleado_Load(object sender, EventArgs e)
        {


            periodos = new Dictionary<String, int>();
            var periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));


            var dateAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            var periodoAnterior = Convert.ToInt32(dateAnterior.ToString("yyyyMM"));

            periodos.Add(ObtenerMes(DateTime.Now.Month) + " " + DateTime.Now.Year, periodoActual);
            periodos.Add(ObtenerMes(dateAnterior.Month) + " " + dateAnterior.Year, periodoAnterior);

            periodoBox.DataSource = periodos.Keys.ToList();

            ListarUsuarios();
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

        private void ReportesDeBeneficiosPorEmpleado_Shown(object sender, EventArgs e)
        {
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

            var usuarioSeleccionado = (Usuario)empleadosDataGridView.Rows[empleadosDataGridView.CurrentCell.RowIndex].DataBoundItem;
            beneficiosListView.UseAlternatingBackColors = true;
            var evaluaciones = gestorDeBeneficios.ObtenerReporteDeUnEmpleadoParaUnPeriodo(usuarioSeleccionado, periodos[periodoBox.SelectedItem.ToString()]);
            beneficiosListView.ClearObjects();

            this.beneficio.AspectGetter = delegate (object rowObject)
            {
                Object[] obj = (Object[])rowObject;
                return obj[0].ToString();
            };

            this.otorgado.AspectGetter = delegate (object rowObject)
            {
                Object[] obj = (Object[])rowObject;
                return obj[1];
            };

            if (evaluaciones.Count > 0)
            {
                beneficiosListView.AddObjects(evaluaciones);
            }
            else
            {
                MessageBox.Show("No se encuentran beneficios para el periodo y el empleado seleccionado.");
            }
        }
    }
}
