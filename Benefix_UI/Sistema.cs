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
    public partial class Sistema : Form
    {
        private GestorSistema gestorSistema;
        private GestorIdioma gestorIdioma;
        public Sistema(Usuario usuario)
        {
            gestorSistema = GestorSistema.ObtenerInstancia();
            gestorIdioma = GestorIdioma.ObtenerInstancia();
            InitializeComponent();
        }

        private void administraciónDeObjetivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeObjetivos();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void miEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var mainForm = new MiEstado();
            mainForm.MdiParent = this;
            mainForm.TopMost = true;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();

        }

        private void evaluarEquiposACargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new EvaluarEquiposACargo();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void objetivosPorEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new ReportesDeObjetivosPorEmpleado();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void objetivosPorEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new ReportesDeObjetivosPorEquipos();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void beneficioPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new ReportesDeBeneficiosPorEmpleado();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void administraciónDeBeneficiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeBeneficios();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void administracionDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeEquipos();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void administraciónDeGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeGrupos();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void administraciónDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeUsuarios();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void administraciónDeFamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new AdministracionDeFamilias();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new ConsultarBitacora();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void realizarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new RealizarBackup();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void realizarRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new RealizarRestore();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }



        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new LogOut((cb) =>
            {
                if (cb)
                {
                    Console.WriteLine("Confirmacion de logout");
                    this.Close();
                }
            });
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            var idiomas = gestorIdioma.ConsultarIdiomas();

            foreach (Idioma idioma in idiomas)
            {
                var toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

                toolStripMenuItem.Name = idioma.identificador.ToString();
                toolStripMenuItem.Size = new System.Drawing.Size(210, 30);
                toolStripMenuItem.Text = idioma.nombre;
                toolStripMenuItem.Click += new System.EventHandler(this.IdiomaToolStripMenuItem_Click);
                toolStripMenuItem.Checked = idioma.identificador == gestorSistema.ObtenerUsuarioEnSesion().idioma.identificador;
                idiomaToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }


        }


        private void IdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var itemText = (sender as ToolStripMenuItem).Text;
            var itemName = (sender as ToolStripMenuItem).Name;

            var mainForm = new ModificarIdioma(new Idioma() { identificador = Convert.ToInt32(itemName) }, (cb) =>
             {
                 foreach (ToolStripMenuItem item in idiomaToolStripMenuItem.DropDownItems)
                 {
                     item.Checked = item.Name.Equals(cb.identificador.ToString());
                 }

             });
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

    }
}
