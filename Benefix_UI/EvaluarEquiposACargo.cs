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
    public partial class EvaluarEquiposACargo : Form
    {
        private GestorDeEquipos gestorDeEquipos;
        private Equipo equipoSeleccionado;
        private Usuario empleadoSeleccionado;

        public EvaluarEquiposACargo()
        {
            InitializeComponent();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();
        }

        private void evaluarButton_Click(object sender, EventArgs e)
        {
            if (empleadosDataGridView.CurrentCell != null && empleadosDataGridView.SelectedRows.Count > 0 && empleadosDataGridView.Rows[empleadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                this.empleadoSeleccionado = (Usuario)empleadosDataGridView.Rows[empleadosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                var mainForm = new EvaluarEmpleados(equipoSeleccionado, empleadoSeleccionado);
                mainForm.StartPosition = FormStartPosition.CenterScreen;
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un empleado a evaluar.");
            }
        }

        private void EvaluarEquiposACargo_Load(object sender, EventArgs e)
        {
            List<Equipo> equiposPorCoordinador = gestorDeEquipos.ObtenerEquiposPorCoordinador(GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion()).Where(d => d.habilitado).ToList();

            if (equiposPorCoordinador.Count > 0)
            {
                equiposAsignadosDataGridView.AutoGenerateColumns = false;
                equiposAsignadosDataGridView.DataSource = equiposPorCoordinador;

            }
            else
            {
                evaluarButton.Enabled = false;
                MessageBox.Show("Usted no tiene equipos asignados");
            }

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.evaluarButton, "Evaluar los objetivos del empleado seleccionado");
            this.equipos.ToolTipText = "Equipos coordinados por el usuario en sesion";
            this.empleados.ToolTipText = "Empleados del equipo seleccionado";

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "4_Evaluarequiposacargo.htm");

        }

        private void EvaluarEquiposACargo_Shown(object sender, EventArgs e)
        {
            equiposAsignadosDataGridView.ClearSelection();
        }


        private void equiposAsignadosDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (equiposAsignadosDataGridView.CurrentCell != null)
            {
                var yo = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion();
                this.equipoSeleccionado = (Equipo)equiposAsignadosDataGridView.Rows[equiposAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                empleadosDataGridView.AutoGenerateColumns = false;
                empleadosDataGridView.DataSource = equipoSeleccionado.usuariosAsignados.Where(u => u.identificador != yo.identificador).ToList();

                empleadosDataGridView.ClearSelection();
            }
        }
    }
}
