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
    public partial class AsignarDesasignarPatente : Form
    {
        private PermisivaRestrictiva permisivaRestrictiva;

        public AsignarDesasignarPatente()
        {
            InitializeComponent();
        }

        public AsignarDesasignarPatente(PermisivaRestrictiva permisivaRestrictiva)
        {
            InitializeComponent();
            this.permisivaRestrictiva = permisivaRestrictiva;
        }

        public interface PermisivaRestrictiva
        {

            void permisiva();
            void restrictiva();

        }

        private void permisivaButton_Click(object sender, EventArgs e)
        {
            permisivaRestrictiva.permisiva();
            Close();
        }

        private void restrictivaButton_Click(object sender, EventArgs e)
        {
            permisivaRestrictiva.restrictiva();
            Close();
        }
    }
}
