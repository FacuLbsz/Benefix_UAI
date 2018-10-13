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
    public partial class AdministracionDeGrupos : Form
    {
        public AdministracionDeGrupos()
        {
            InitializeComponent();
        }

        private void asignarBeneficiosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarBeneficios();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
