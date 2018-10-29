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
        private static List<PatenteUsuario> patentesDelUsuario;
        private static List<Patente> patentesNoAsignadas;
        private static Usuario usuario;
        public AsignarPatentesAUsuarios(Usuario usuariox)
        {
            usuario = usuariox;
            gestorDePatentes = GestorDePatentes.ObtenerInstancia();


            InitializeComponent();
        }

        private void AsignarPatentesAUsuarios_Load(object sender, EventArgs e)
        {
            patentesDelUsuario = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);
            patentesNoAsignadas = gestorDePatentes.ObtenerPatentesNoAsignadasAUnUsuario(usuario);

            patentesDataGridView.DataSource = patentesNoAsignadas;
            foreach (DataGridViewColumn col in patentesDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            patentesAsignadosDataGridView.DataSource = patentesDelUsuario;
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

            if (patentesDataGridView.SelectedRows.Count > 0 && patentesDataGridView.Rows[patentesDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                AsignarDesasignarPatente asignarDesasignarPatente = new AsignarDesasignarPatente(new PermisivaRestrictiva((Patente)patentesDataGridView.Rows[patentesDataGridView.CurrentCell.RowIndex].DataBoundItem));
                asignarDesasignarPatente.StartPosition = FormStartPosition.CenterScreen;
                asignarDesasignarPatente.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una patente a asignar");
            }



        }

        private class PermisivaRestrictiva : AsignarDesasignarPatente.PermisivaRestrictiva
        {
            private Patente patente;

            public PermisivaRestrictiva(Patente patente)
            {
                this.patente = patente;
            }

            public void permisiva()
            {
                patentesDelUsuario.Add(new PatenteUsuario() { patente = patente, usuario = usuario, esPermisivo = true });
                patentesAsignadosDataGridView.AutoGenerateColumns = false;
                patentesAsignadosDataGridView.DataSource = null;
                patentesAsignadosDataGridView.DataSource = patentesDelUsuario;

                patentesNoAsignadas.Remove(patente);
                patentesDataGridView.AutoGenerateColumns = false;
                patentesDataGridView.DataSource = null;
                patentesDataGridView.DataSource = patentesNoAsignadas;
            }

            public void restrictiva()
            {
                patentesDelUsuario.Add(new PatenteUsuario() { patente = patente, usuario = usuario, esPermisivo = false });
                patentesAsignadosDataGridView.AutoGenerateColumns = false;
                patentesAsignadosDataGridView.DataSource = null;
                patentesAsignadosDataGridView.DataSource = patentesDelUsuario;

                patentesNoAsignadas.Remove(patente);
                patentesDataGridView.AutoGenerateColumns = false;
                patentesDataGridView.DataSource = null;
                patentesDataGridView.DataSource = patentesNoAsignadas;
            }
        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (patentesAsignadosDataGridView.SelectedRows.Count > 0 && patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var patenteUsuario = (PatenteUsuario)patentesAsignadosDataGridView.Rows[patentesAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                patentesNoAsignadas.Add(patenteUsuario.patente);
                patentesDataGridView.AutoGenerateColumns = false;
                patentesDataGridView.DataSource = null;
                patentesDataGridView.DataSource = patentesNoAsignadas;

                patentesDelUsuario.Remove(patenteUsuario);
                patentesAsignadosDataGridView.AutoGenerateColumns = false;
                patentesAsignadosDataGridView.DataSource = null;
                patentesAsignadosDataGridView.DataSource = patentesDelUsuario;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una patente a desasignar");
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {

            List<PatenteUsuario> patentesDelUsuarioViejas = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);

            var patentesADesasignar = patentesDelUsuarioViejas.Except(patentesDelUsuario).ToList();

            foreach (PatenteUsuario patente in patentesADesasignar)
            {
                if (gestorDePatentes.VerificarPatenteEscencial(patente.patente) == 0)
                {
                    MessageBox.Show(String.Format("No es posible desasignar la patente {0} debido a que no se encuentra asignada a otro usuario o familia.", patente.patente.nombre));
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

            MessageBox.Show("La asignacion se ha guardado correctamente.");
            this.Close();
        }
    }
}
