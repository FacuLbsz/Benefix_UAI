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
    public partial class AsignarGrupos : Form
    {
        private Equipo equipo;
        private GestorDeGrupos gestorDeGrupos;
        private GestorDeEquipos gestorDeEquipos;

        private List<Grupo> gruposAsignadoss;
        private List<Grupo> gruposAsignadosFixed;
        private List<Grupo> gruposNoAsignados;

        public AsignarGrupos(Equipo equipo)
        {
            gestorDeGrupos = GestorDeGrupos.ObtenerInstancia();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();

            this.equipo = equipo;
            this.gruposAsignadoss = equipo.gruposAsignados;

            this.gruposNoAsignados = gestorDeGrupos.ConsultarGrupos().Except(gruposAsignadoss).ToList();
            this.gruposAsignadosFixed = new List<Grupo>();
            this.gruposAsignadosFixed.AddRange(gruposAsignadoss);


            InitializeComponent();
        }

        private void AsignarGrupos_Load_1(object sender, EventArgs e)
        {

            gruposDataGridView.AutoGenerateColumns = false;
            gruposDataGridView.DataSource = gruposNoAsignados;

            gruposAsignadosDataGridView.AutoGenerateColumns = false;
            gruposAsignadosDataGridView.DataSource = gruposAsignadoss;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, Genesis.Recursos_localizables.StringResources.AsignarGrupoButtonTooltip);
            toolTip1.SetToolTip(this.desasignarButton, Genesis.Recursos_localizables.StringResources.DeasignarGrupoButtonTooltip);
            toolTip1.SetToolTip(this.guardarButton, Genesis.Recursos_localizables.StringResources.GuardarButtonTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "14_AsignarGrupos.htm");
        }

        private void AsignarGruposAEquipos_Shown(object sender, EventArgs e)
        {
            gruposAsignadosDataGridView.ClearSelection();
            gruposDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (gruposDataGridView.CurrentCell != null && gruposDataGridView.SelectedRows.Count > 0 && gruposDataGridView.Rows[gruposDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var grupo = (Grupo)gruposDataGridView.Rows[gruposDataGridView.CurrentCell.RowIndex].DataBoundItem;
                gruposAsignadoss.Add(grupo);
                gruposAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = gruposAsignadoss;
                gruposAsignadosDataGridView.DataSource = binding2;

                gruposNoAsignados.Remove(grupo);
                gruposDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = gruposNoAsignados;
                gruposDataGridView.DataSource = binding;

                gruposDataGridView.ClearSelection();
                gruposAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (gruposAsignadosDataGridView.CurrentCell != null && gruposAsignadosDataGridView.CurrentCell != null && gruposAsignadosDataGridView.SelectedRows.Count > 0 && gruposAsignadosDataGridView.Rows[gruposAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var grupo = (Grupo)gruposAsignadosDataGridView.Rows[gruposAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                gruposNoAsignados.Add(grupo);
                gruposDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = gruposNoAsignados;
                gruposDataGridView.DataSource = binding;

                gruposAsignadoss.Remove(grupo);
                gruposAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = gruposAsignadoss;
                gruposAsignadosDataGridView.DataSource = binding2;

                gruposDataGridView.ClearSelection();
                gruposAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var gruposADesasignar = gruposAsignadosFixed.Except(gruposAsignadoss).ToList();

            foreach (Grupo grupo in gruposADesasignar)
            {
                gestorDeEquipos.DesasignarGrupo(grupo, equipo);
            }

            var gruposAAsignar = gruposAsignadoss.Except(gruposAsignadosFixed).ToList();

            foreach (Grupo grupo in gruposAAsignar)
            {
                gestorDeEquipos.AsignarGrupo(grupo, equipo);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioSatisfactorio);
            this.Close();
        }

    }
}
