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
        private List<Patente> patentesNoAsignadas;
        public AsignarPatentesAUsuarios(Usuario usuario)
        {
            gestorDePatentes = GestorDePatentes.ObtenerInstancia();
            patentesDelUsuario = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);
            patentesNoAsignadas = gestorDePatentes.ObtenerPatentesNoAsignadasAUnUsuario(usuario);

            InitializeComponent();
        }

        private void AsignarPatentesAUsuarios_Load(object sender, EventArgs e)
        {

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
            PatenteUsuario data = patentesAsignadosDataGridView.Rows[e.RowIndex].DataBoundItem as PatenteUsuario;
            patentesAsignadosDataGridView.Rows[e.RowIndex].Cells["patentesAsignadas"].Value = data.patente.nombre;

        }
            private void AsignarPatentesAUsuarios_Shown(object sender, EventArgs e)
        {
            patentesAsignadosDataGridView.ClearSelection();
            patentesDataGridView.ClearSelection();
        }
    }
}
