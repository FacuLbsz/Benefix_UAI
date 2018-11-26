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
    public partial class AsignarBeneficios : Form
    {
        private Grupo grupo;
        private GestorDeBeneficios gestorDeBeneficios;
        private GestorDeGrupos gestorDeGrupos;

        private List<Beneficio> beneficiosAsignadoss;
        private List<Beneficio> beneficiosAsignadosFixed;
        private List<Beneficio> beneficiosNoAsignados;

        public AsignarBeneficios(Grupo grupo)
        {
            gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
            gestorDeGrupos = GestorDeGrupos.ObtenerInstancia();

            this.grupo = grupo;
            this.beneficiosAsignadoss = grupo.beneficiosAsignados;

            this.beneficiosNoAsignados = gestorDeBeneficios.ConsultarBeneficios().Except(beneficiosAsignadoss).ToList();
            this.beneficiosAsignadosFixed = new List<Beneficio>();
            this.beneficiosAsignadosFixed.AddRange(beneficiosAsignadoss);


            InitializeComponent();
        }

        private void AsignarBeneficios_Load(object sender, EventArgs e)
        {

            beneficiosDataGridView.AutoGenerateColumns = false;
            beneficiosDataGridView.DataSource = beneficiosNoAsignados;

            beneficiosAsignadosDataGridView.AutoGenerateColumns = false;
            beneficiosAsignadosDataGridView.DataSource = beneficiosAsignadoss;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, "Asigna el beneficio seleccionada al grupo");
            toolTip1.SetToolTip(this.desasignarButton, "Desasigna el beneficio seleccionada al grupo");
            toolTip1.SetToolTip(this.guardarButton, "Guarda las asignaciones realizadas");
        }

        private void AsignarBeneficiosAGrupos_Shown(object sender, EventArgs e)
        {
            beneficiosAsignadosDataGridView.ClearSelection();
            beneficiosDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (beneficiosDataGridView.CurrentCell != null && beneficiosDataGridView.SelectedRows.Count > 0 && beneficiosDataGridView.Rows[beneficiosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var beneficio = (Beneficio)beneficiosDataGridView.Rows[beneficiosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                beneficiosAsignadoss.Add(beneficio);
                beneficiosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = beneficiosAsignadoss;
                beneficiosAsignadosDataGridView.DataSource = binding2;

                beneficiosNoAsignados.Remove(beneficio);
                beneficiosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = beneficiosNoAsignados;
                beneficiosDataGridView.DataSource = binding;

                beneficiosDataGridView.ClearSelection();
                beneficiosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (beneficiosAsignadosDataGridView.CurrentCell != null && beneficiosAsignadosDataGridView.CurrentCell != null && beneficiosAsignadosDataGridView.SelectedRows.Count > 0 && beneficiosAsignadosDataGridView.Rows[beneficiosAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var beneficio = (Beneficio)beneficiosAsignadosDataGridView.Rows[beneficiosAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                beneficiosNoAsignados.Add(beneficio);
                beneficiosDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = beneficiosNoAsignados;
                beneficiosDataGridView.DataSource = binding;

                beneficiosAsignadoss.Remove(beneficio);
                beneficiosAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = beneficiosAsignadoss;
                beneficiosAsignadosDataGridView.DataSource = binding2;

                beneficiosDataGridView.ClearSelection();
                beneficiosAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var beneficiosADesasignar = beneficiosAsignadosFixed.Except(beneficiosAsignadoss).ToList();

            foreach (Beneficio beneficio in beneficiosADesasignar)
            {
                gestorDeGrupos.DesasignarBeneficio(beneficio, grupo);
            }

            var beneficiosAAsignar = beneficiosAsignadoss.Except(beneficiosAsignadosFixed).ToList();

            foreach (Beneficio beneficio in beneficiosAAsignar)
            {
                gestorDeGrupos.AsignarBeneficio(beneficio, grupo);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            this.Close();
        }
    }
}
