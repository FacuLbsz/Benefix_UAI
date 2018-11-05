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
    public partial class AsignarUsuarios : Form
    {
        private Familia familia;
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeFamilias gestorDeFamilias;
        private List<Usuario> usuarioAsignados;
        private List<Usuario> usuariosNoAsignados;
        private List<Usuario> usuarioAsignadosFixed;
        public AsignarUsuarios(Familia familia)
        {
            InitializeComponent();
            this.familia = familia;
            this.usuarioAsignados = familia.usuariosAsignados;
            this.gestorDeFamilias = GestorDeFamilias.ObtenerInstancia();
            this.gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();

            this.usuariosNoAsignados = gestorDeUsuarios.ConsultarUsuarios().Except(usuarioAsignados).ToList();
            this.usuarioAsignadosFixed = new List<Usuario>();
            usuarioAsignadosFixed.AddRange(usuarioAsignados);
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (usuariosDataGridView.SelectedRows.Count > 0 && usuariosDataGridView.Rows[usuariosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var usuario = (Usuario)usuariosDataGridView.Rows[usuariosDataGridView.CurrentCell.RowIndex].DataBoundItem;
                usuarioAsignados.Add(usuario);
                usuariosAsignadosDataGridView.AutoGenerateColumns = false;
                var binding1 = new BindingSource();
                binding1.DataSource = usuarioAsignados;
                usuariosAsignadosDataGridView.DataSource = binding1;

                usuariosNoAsignados.Remove(usuario);
                usuariosDataGridView.AutoGenerateColumns = false;
                var binding = new BindingSource();
                binding.DataSource = usuariosNoAsignados;
                usuariosDataGridView.DataSource = binding;

                usuariosAsignadosDataGridView.ClearSelection();
                usuariosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a asignar");
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (usuariosAsignadosDataGridView.SelectedRows.Count > 0 && usuariosAsignadosDataGridView.Rows[usuariosAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var usuario = (Usuario)usuariosAsignadosDataGridView.Rows[usuariosAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                usuariosNoAsignados.Add(usuario);
                usuariosDataGridView.AutoGenerateColumns = false;
                var binding = new BindingSource();
                binding.DataSource = usuariosNoAsignados;
                usuariosDataGridView.DataSource = binding;

                usuarioAsignados.Remove(usuario);
                usuariosAsignadosDataGridView.AutoGenerateColumns = false;
                var binding1 = new BindingSource();
                binding1.DataSource = usuarioAsignados;
                usuariosAsignadosDataGridView.DataSource = binding1;

                usuariosAsignadosDataGridView.ClearSelection();
                usuariosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario a desasignar");
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {

            var usuariosADesasignar = usuarioAsignadosFixed.Except(usuarioAsignados).ToList();


            foreach (Usuario usuario in usuariosADesasignar)
            {
                gestorDeFamilias.DesasignarUsuario(usuario, familia);
            }

            foreach (Usuario usuario in usuarioAsignados)
            {
                gestorDeFamilias.AsignarUsuario(usuario, familia);
            }

            MessageBox.Show("La asignacion se ha guardado correctamente.");
            this.Close();
        }

        private void AsignarUsuarios_Load(object sender, EventArgs e)
        {
            usuariosDataGridView.AutoGenerateColumns = false;
            usuariosDataGridView.DataSource = usuariosNoAsignados;

            usuariosAsignadosDataGridView.AutoGenerateColumns = false;
            usuariosAsignadosDataGridView.DataSource = usuarioAsignados;
        }

        private void AsignarUsuarios_Shown(object sender, EventArgs e)
        {
            usuariosAsignadosDataGridView.ClearSelection();
            usuariosDataGridView.ClearSelection();
        }
    }
}
