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
    public partial class AsignarPatentesAUsuarios : Form
    {
        private GestorDePatentes gestorDePatentes;
        private List<PatenteUsuario> patentesDelUsuario;
        private List<PatenteUsuario> patentesDelUsuarioFixed;
        private List<Patente> patentesNoAsignadas;
        private static Usuario usuario;
        public AsignarPatentesAUsuarios(Usuario usuariox)
        {
            usuario = usuariox;
            gestorDePatentes = GestorDePatentes.ObtenerInstancia();


            InitializeComponent();
        }

        private void AsignarPatentesAUsuarios_Load(object sender, EventArgs e)
        {
            this.patentesDelUsuario = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);
            this.patentesDelUsuarioFixed = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);
            this.patentesNoAsignadas = gestorDePatentes.ObtenerPatentesNoAsignadasAUnUsuario(usuario);

            var binding = new BindingSource();
            binding.DataSource = patentesNoAsignadas;
            patentesDataGridView.DataSource = binding;
            foreach (DataGridViewColumn col in patentesDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }


            var binding2 = new BindingSource();
            binding2.DataSource = patentesDelUsuario;
            patentesAsignadosDataGridView.DataSource = binding2;
            foreach (DataGridViewColumn col in patentesAsignadosDataGridView.Columns)
            {
                if (col.DataPropertyName != "patente.nombre" && col.DataPropertyName != "esPermisivo")
                    col.Visible = false;
            }

        }

        private void patentesAsignadosDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                PatenteUsuario data = patentesAsignadosDataGridView.Rows[e.RowIndex].DataBoundItem as PatenteUsuario;
                patentesAsignadosDataGridView.Rows[e.RowIndex].Cells["patentesAsignadas"].Value = data.patente.nombre;
            }
            catch (Exception ex)
            {

            }

        }
        private void AsignarPatentesAUsuarios_Shown(object sender, EventArgs e)
        {
            patentesAsignadosDataGridView.ClearSelection();
            patentesDataGridView.ClearSelection();
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {

            if (patentesDataGridView.CurrentCell != null && patentesDataGridView.SelectedRows.Count > 0 && patentesDataGridView.Rows[patentesDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                Patente patente = (Patente)patentesDataGridView.Rows[patentesDataGridView.CurrentCell.RowIndex].DataBoundItem;
                AsignarDesasignarPatente asignarDesasignarPatente = new AsignarDesasignarPatente((cb) =>
                {

                    if (cb)
                    {
                        patentesDelUsuario.Add(new PatenteUsuario() { patente = patente, usuario = usuario, esPermisivo = true });
                        patentesAsignadosDataGridView.AutoGenerateColumns = false;

                        var binding2 = new BindingSource();
                        binding2.DataSource = patentesDelUsuario;
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
                        patentesDelUsuario.Add(new PatenteUsuario() { patente = patente, usuario = usuario, esPermisivo = false });
                        patentesAsignadosDataGridView.AutoGenerateColumns = false;

                        var binding2 = new BindingSource();
                        binding2.DataSource = patentesDelUsuario;
                        patentesAsignadosDataGridView.DataSource = binding2;

                        patentesNoAsignadas.Remove(patente);
                        patentesDataGridView.AutoGenerateColumns = false;

                        var binding = new BindingSource();
                        binding.DataSource = patentesNoAsignadas;
                        patentesDataGridView.DataSource = binding;

                        patentesDataGridView.ClearSelection();
                        patentesAsignadosDataGridView.ClearSelection();
                    }


                });
                asignarDesasignarPatente.StartPosition = FormStartPosition.CenterScreen;
                asignarDesasignarPatente.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAUsuariosMessagePatenteAsignarRequerido);
            }



        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (patentesAsignadosDataGridView.CurrentCell != null && patentesAsignadosDataGridView.SelectedRows.Count > 0 && patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var patenteUsuario = (PatenteUsuario)patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                patentesNoAsignadas.Add(patenteUsuario.patente);
                patentesDataGridView.AutoGenerateColumns = false;

                var binding = new BindingSource();
                binding.DataSource = patentesNoAsignadas;
                patentesDataGridView.DataSource = binding;

                patentesDelUsuario.Remove(patenteUsuario);
                patentesAsignadosDataGridView.AutoGenerateColumns = false;

                var binding2 = new BindingSource();
                binding2.DataSource = patentesDelUsuario;
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

            var patentesADesasignar = patentesDelUsuarioFixed.Except(patentesDelUsuario).ToList();

            foreach (PatenteUsuario patente in patentesADesasignar)
            {
                if (gestorDePatentes.VerificarPatenteEscencial(patente.patente, usuario, null) == 0)
                {
                    MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AsignarPatentesAUsuariosMessageDesasignarError, patente.patente.nombre));
                    return;
                }

            }

            foreach (PatenteUsuario patente in patentesADesasignar)
            {
                gestorDePatentes.DesasignarAUnUsuario(patente.usuario, patente.patente);
            }

            foreach (PatenteUsuario patente in patentesDelUsuario)
            {
                gestorDePatentes.AsignarAUnUsuario(patente);
            }

            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAUsuariosMessageSatisfactorio);
            this.Close();
        }
    }
}
