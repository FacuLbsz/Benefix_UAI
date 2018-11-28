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
    public partial class AsignarObjetivos : Form
    {
        private Equipo equipo;
        private GestorDeObjetivos gestorDeObjetivos;
        private GestorDeEquipos gestorDeEquipos;

        private List<Objetivo> objetivosAsignadoss;
        private List<Objetivo> objetivosAsignadosFixed;
        private List<Objetivo> objetivosNoAsignados;

        public AsignarObjetivos(Equipo equipo)
        {
            gestorDeObjetivos = GestorDeObjetivos.ObtenerInstancia();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();

            this.equipo = equipo;
            this.objetivosAsignadoss = equipo.objetivosAsignados;

            this.objetivosNoAsignados = gestorDeObjetivos.ListarObjetivos().Except(objetivosAsignadoss).ToList();
            this.objetivosAsignadosFixed = new List<Objetivo>();
            this.objetivosAsignadosFixed.AddRange(objetivosAsignadoss);


            InitializeComponent();
        }

        private void AsignarEmpleados_Load(object sender, EventArgs e)
        {

            objetivosDataGridView.AutoGenerateColumns = false;
            objetivosDataGridView.DataSource = objetivosNoAsignados;

            objetivosAsignadosDataGridView.AutoGenerateColumns = false;
            objetivosAsignadosDataGridView.DataSource = objetivosAsignadoss;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, Genesis.Recursos_localizables.StringResources.AsignarObjetivoButtonTooltip);
            toolTip1.SetToolTip(this.desasignarButton, Genesis.Recursos_localizables.StringResources.DesasignarObjetivoButtonTooltip);
            toolTip1.SetToolTip(this.guardarButton, Genesis.Recursos_localizables.StringResources.GuardarButtonTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "15_AsignarObjetivos.htm");
        }

        private void AsignarObjetivosAEquipos_Shown(object sender, EventArgs e)
        {
            objetivosAsignadosDataGridView.ClearSelection();
            objetivosDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (objetivosDataGridView.CurrentCell != null && objetivosDataGridView.SelectedRows.Count > 0 && objetivosDataGridView.Rows[objetivosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var objetivo = (Objetivo)objetivosDataGridView.Rows[objetivosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                objetivosAsignadoss.Add(objetivo);
                objetivosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = objetivosAsignadoss;
                objetivosAsignadosDataGridView.DataSource = binding2;

                objetivosNoAsignados.Remove(objetivo);
                objetivosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = objetivosNoAsignados;
                objetivosDataGridView.DataSource = binding;

                objetivosDataGridView.ClearSelection();
                objetivosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (objetivosAsignadosDataGridView.CurrentCell != null && objetivosAsignadosDataGridView.CurrentCell != null && objetivosAsignadosDataGridView.SelectedRows.Count > 0 && objetivosAsignadosDataGridView.Rows[objetivosAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var objetivo = (Objetivo)objetivosAsignadosDataGridView.Rows[objetivosAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                objetivosNoAsignados.Add(objetivo);
                objetivosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = objetivosNoAsignados;
                objetivosDataGridView.DataSource = binding;

                objetivosAsignadoss.Remove(objetivo);
                objetivosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = objetivosAsignadoss;
                objetivosAsignadosDataGridView.DataSource = binding2;

                objetivosDataGridView.ClearSelection();
                objetivosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var objetivosADesasignar = objetivosAsignadosFixed.Except(objetivosAsignadoss).ToList();

            foreach (Objetivo objetivo in objetivosADesasignar)
            {
                gestorDeEquipos.DesasignarObjetivo(objetivo, equipo);
            }

            var objetivosAAsignar = objetivosAsignadoss.Except(objetivosAsignadosFixed).ToList();

            foreach (Objetivo objetivo in objetivosAAsignar)
            {
                gestorDeEquipos.AsignarObjetivo(objetivo, equipo);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioSatisfactorio);
            this.Close();
        }
    }
}
