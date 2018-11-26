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
    public partial class AsignarPatentesAFamilias : Form
    {
        private Familia familia;
        private GestorDePatentes gestorDePatentes;
        private GestorDeFamilias gestorDeFamilias;

        private List<Patente> patentesAsignadas;
        private List<Patente> patentesAsignadasFixed;
        private List<Patente> patentesNoAsignadas;
        public AsignarPatentesAFamilias(Familia familia)
        {
            gestorDePatentes = GestorDePatentes.ObtenerInstancia();
            gestorDeFamilias = GestorDeFamilias.ObtenerInstancia();

            this.familia = familia;
            this.patentesAsignadas = familia.patentesAsignadas;

            this.patentesNoAsignadas = gestorDePatentes.ObtenerPatentes().Except(patentesAsignadas).ToList();
            this.patentesAsignadasFixed = new List<Patente>();
            this.patentesAsignadasFixed.AddRange(patentesAsignadas);


            InitializeComponent();
        }

        private void AsignarPatentesAFamilias_Load(object sender, EventArgs e)
        {

            patentesDataGridView.AutoGenerateColumns = false;
            patentesDataGridView.DataSource = patentesNoAsignadas;

            patentesAsignadosDataGridView.AutoGenerateColumns = false;
            patentesAsignadosDataGridView.DataSource = patentesAsignadas;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, "Asigna la patente seleccionada a la familia");
            toolTip1.SetToolTip(this.desasignarButton, "Desasigna el beneficio seleccionada a la familia");
            toolTip1.SetToolTip(this.guardarButton, "Guarda las asignaciones realizadas");

        }

        private void AsignarPatentesAFamilias_Shown(object sender, EventArgs e)
        {
            patentesAsignadosDataGridView.ClearSelection();
            patentesDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (patentesDataGridView.CurrentCell != null && patentesDataGridView.SelectedRows.Count > 0 && patentesDataGridView.Rows[patentesDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var patente = (Patente)patentesDataGridView.Rows[patentesDataGridView.CurrentCell.RowIndex].DataBoundItem;
                patentesAsignadas.Add(patente);
                patentesAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = patentesAsignadas;
                patentesAsignadosDataGridView.DataSource = binding2;

                patentesNoAsignadas.Remove(patente);
                patentesDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = patentesNoAsignadas;
                patentesDataGridView.DataSource = binding;

                patentesDataGridView.ClearSelection();
                patentesAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessagePatenteAsignarRequerido);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (patentesAsignadosDataGridView.CurrentCell != null && patentesAsignadosDataGridView.CurrentCell != null && patentesAsignadosDataGridView.SelectedRows.Count > 0 && patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var patente = (Patente)patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                patentesNoAsignadas.Add(patente);
                patentesDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = patentesNoAsignadas;
                patentesDataGridView.DataSource = binding;

                patentesAsignadas.Remove(patente);
                patentesAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = patentesAsignadas;
                patentesAsignadosDataGridView.DataSource = binding2;

                patentesDataGridView.ClearSelection();
                patentesAsignadosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessagePatenteDesasignarRequerido);
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var patentesADesasignar = patentesAsignadasFixed.Except(patentesAsignadas).ToList();

            foreach (Patente patente in patentesADesasignar)
            {
                if (gestorDePatentes.VerificarPatenteEscencial(patente, null, familia) == 0)
                {
                    MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError, patente.nombre));
                    return;
                }

            }

            foreach (Patente patente in patentesADesasignar)
            {
                gestorDeFamilias.DesasignarPatente(patente, familia);
            }

            var patentesAAsignar = patentesAsignadas.Except(patentesAsignadasFixed).ToList();

            foreach (Patente patente in patentesAAsignar)
            {
                gestorDeFamilias.AsignarPatente(patente, familia);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageSatisfactorio);
            this.Close();
        }
    }
}
