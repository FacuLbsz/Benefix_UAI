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
    public partial class EvaluarEmpleados : Form
    {
        private GestorDeEvaluaciones gestorDeEvaluaciones;
        private Equipo equipoSeleccionado;
        private Usuario empleadoSeleccionado;
        private List<Evaluacion> evaluacionesActuales;

        public EvaluarEmpleados(Equipo equipoSeleccionado, Usuario empleadoSeleccionado)
        {
            InitializeComponent();
            this.equipoSeleccionado = equipoSeleccionado;
            this.empleadoSeleccionado = empleadoSeleccionado;
            this.gestorDeEvaluaciones = GestorDeEvaluaciones.ObtenerInstancia();
        }

        private void alcanzadoButton_Click(object sender, EventArgs e)
        {
            if (evaluacionesDataGridView.CurrentCell != null && evaluacionesDataGridView.SelectedRows.Count > 0 && evaluacionesDataGridView.Rows[evaluacionesDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var evaluacionSeleccionada = (Evaluacion)evaluacionesDataGridView.Rows[evaluacionesDataGridView.CurrentCell.RowIndex].DataBoundItem;
                if (!evaluacionSeleccionada.alcanzado)
                {
                    evaluacionSeleccionada.alcanzado = true;
                    evaluacionSeleccionada.usuario = empleadoSeleccionado;
                    gestorDeEvaluaciones.CrearEvaluacion(evaluacionSeleccionada);

                    ListarEvaluaciones();
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ObjetivoEvaluadoCorrectamente);
                }
                else
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ObjetivoYaCumplido);
                }
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.DebeSeleccionarUnObjetivo);
            }
        }

        private void incumplidoButton_Click(object sender, EventArgs e)
        {
            if (evaluacionesDataGridView.CurrentCell != null && evaluacionesDataGridView.SelectedRows.Count > 0 && evaluacionesDataGridView.Rows[evaluacionesDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var evaluacionSeleccionada = (Evaluacion)evaluacionesDataGridView.Rows[evaluacionesDataGridView.CurrentCell.RowIndex].DataBoundItem;
                if (evaluacionSeleccionada.alcanzado)
                {
                    evaluacionSeleccionada.alcanzado = false;
                    evaluacionSeleccionada.usuario = empleadoSeleccionado;
                    gestorDeEvaluaciones.CrearEvaluacion(evaluacionSeleccionada);

                    ListarEvaluaciones();
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ObjetivoEvaluadoCorrectamente);
                }
                else
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ObjetivoYaIncumplido);
                }
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.DebeSeleccionarUnObjetivo);
            }
        }

        private void EvaluarEmpleados_Load(object sender, EventArgs e)
        {
            ListarEvaluaciones();

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.alcanzadoButton, "Indica que el objetivo seleccionado ha sido alcanzado");
            toolTip1.SetToolTip(this.incumplidoButton, "Indica que el objetivo seleccionado no ha sido alcanzado");
            toolTip1.SetToolTip(this.guardarButton, "Guarda las evaluaciones realizadas");
            this.cumplimiento.ToolTipText = "Indica si se ha cumplido el objetivo";

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "5_Evaluarempleado.htm");

        }

        private void ListarEvaluaciones()
        {
            this.evaluacionesActuales = gestorDeEvaluaciones.ObtenerEvaluacionDeUnEmpleadoParaUnPeriodoYUnEquipo(equipoSeleccionado, empleadoSeleccionado, Convert.ToInt32(DateTime.Now.ToString("yyyyMM"))).Where(d => d.equipoObjetvo.objetivo.habilitado || d.alcanzado).ToList();
            var binding2 = new BindingSource();
            binding2.DataSource = evaluacionesActuales;
            evaluacionesDataGridView.DataSource = binding2;
            foreach (DataGridViewColumn col in evaluacionesDataGridView.Columns)
            {
                if (col.DataPropertyName != "equipoObjetvo" && col.DataPropertyName != "alcanzado")
                    col.Visible = false;
            }

            evaluacionesDataGridView.ClearSelection();
        }

        private void EvaluarEmpleados_Shown(object sender, EventArgs e)
        {
            evaluacionesDataGridView.ClearSelection();
        }

        private void evaluarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
