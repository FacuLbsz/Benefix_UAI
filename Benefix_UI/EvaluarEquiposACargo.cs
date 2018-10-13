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
    public partial class EvaluarEquiposACargo : Form
    {
        public EvaluarEquiposACargo()
        {
            InitializeComponent();
        }

        private void evaluarButton_Click(object sender, EventArgs e)
        {
            var mainForm = new EvaluarEmpleados();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
