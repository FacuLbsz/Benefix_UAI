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
        public Sistema()
        {
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

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new ModificarIdioma();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainForm = new LogOut();
            mainForm.MdiParent = this;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
        }
    }
}
