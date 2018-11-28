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
    public partial class AsignarEmpleados : Form
    {
        private Equipo equipo;
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeEquipos gestorDeEquipos;

        private List<Usuario> usuariosAsignadoss;
        private List<Usuario> usuariosAsignadosFixed;
        private List<Usuario> usuariosNoAsignados;

        public AsignarEmpleados(Equipo equipo)
        {
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();

            this.equipo = equipo;
            this.usuariosAsignadoss = equipo.usuariosAsignados;

            this.usuariosNoAsignados = gestorDeUsuarios.ConsultarUsuariosSinEquipo();
            this.usuariosAsignadosFixed = new List<Usuario>();
            this.usuariosAsignadosFixed.AddRange(usuariosAsignadoss);


            InitializeComponent();
        }

        private void AsignarEmpleados_Load(object sender, EventArgs e)
        {

            empleadosDataGridView.AutoGenerateColumns = false;
            empleadosDataGridView.DataSource = usuariosNoAsignados;

            empleadosAsignadosDataGridView.AutoGenerateColumns = false;
            empleadosAsignadosDataGridView.DataSource = usuariosAsignadoss;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, Genesis.Recursos_localizables.StringResources.AsignarEmpleadoButtonTooltip);
            toolTip1.SetToolTip(this.desasignarButton, Genesis.Recursos_localizables.StringResources.DesasignarEmpleadoButtonTooltip);
            toolTip1.SetToolTip(this.guardarButton, Genesis.Recursos_localizables.StringResources.GuardarButtonTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "13_AsignarEmpleados.htm");
        }

        private void AsignarUsuariosAEquipos_Shown(object sender, EventArgs e)
        {
            empleadosAsignadosDataGridView.ClearSelection();
            empleadosDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (empleadosDataGridView.CurrentCell != null && empleadosDataGridView.SelectedRows.Count > 0 && empleadosDataGridView.Rows[empleadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var usuario = (Usuario)empleadosDataGridView.Rows[empleadosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                usuariosAsignadoss.Add(usuario);
                empleadosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = usuariosAsignadoss;
                empleadosAsignadosDataGridView.DataSource = binding2;

                usuariosNoAsignados.Remove(usuario);
                empleadosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = usuariosNoAsignados;
                empleadosDataGridView.DataSource = binding;

                empleadosDataGridView.ClearSelection();
                empleadosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (empleadosAsignadosDataGridView.CurrentCell != null && empleadosAsignadosDataGridView.CurrentCell != null && empleadosAsignadosDataGridView.SelectedRows.Count > 0 && empleadosAsignadosDataGridView.Rows[empleadosAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var usuario = (Usuario)empleadosAsignadosDataGridView.Rows[empleadosAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                usuariosNoAsignados.Add(usuario);
                empleadosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = usuariosNoAsignados;
                empleadosDataGridView.DataSource = binding;

                usuariosAsignadoss.Remove(usuario);
                empleadosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = usuariosAsignadoss;
                empleadosAsignadosDataGridView.DataSource = binding2;

                empleadosDataGridView.ClearSelection();
                empleadosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var usuariosADesasignar = usuariosAsignadosFixed.Except(usuariosAsignadoss).ToList();

            foreach (Usuario usuario in usuariosADesasignar)
            {
                gestorDeEquipos.DesasignarEmpleado(usuario, equipo);
            }

            var usuariosAAsignar = usuariosAsignadoss.Except(usuariosAsignadosFixed).ToList();

            foreach (Usuario usuario in usuariosAAsignar)
            {
                gestorDeEquipos.AsignarEmpleado(usuario, equipo);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioSatisfactorio);
            this.Close();
        }
    }
}
