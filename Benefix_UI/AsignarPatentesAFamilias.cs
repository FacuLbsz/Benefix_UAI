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
            this.patentesAsignadasFixed = familia.patentesAsignadas;


            InitializeComponent();
        }

        private void AsignarPatentesAFamilias_Load(object sender, EventArgs e)
        {

            patentesDataGridView.AutoGenerateColumns = false;
            patentesDataGridView.DataSource = patentesNoAsignadas;

            patentesAsignadosDataGridView.AutoGenerateColumns = false;
            patentesAsignadosDataGridView.DataSource = patentesAsignadas;
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
                MessageBox.Show("Debe seleccionar una patente a asignar");
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
                MessageBox.Show("Debe seleccionar una patente a desasignar");
            }
        }


        private void guardarButton_Click(object sender, EventArgs e)
        {
            var patentesADesasignar = patentesAsignadasFixed.Except(patentesAsignadas).ToList();

            foreach (Patente patente in patentesADesasignar)
            {
                if (gestorDePatentes.VerificarPatenteEscencial(patente) == 0)
                {
                    MessageBox.Show(String.Format("No es posible desasignar la patente {0} debido a que no se encuentra asignada a otro usuario o familia.", patente.nombre));
                    return;
                }

            }

            foreach (Patente patente in patentesADesasignar)
            {
                gestorDeFamilias.DesasignarPatente(patente, familia);
            }

            foreach (Patente patente in patentesAsignadas)
            {
                gestorDeFamilias.AsignarPatente(patente, familia);
            }

            MessageBox.Show("La asignacion se ha guardado correctamente.");
            this.Close();
        }
    }
}
