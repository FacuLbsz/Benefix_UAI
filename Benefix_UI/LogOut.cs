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
    public partial class LogOut : Form
    {
        private Action<bool> callback;
        public LogOut(Action<bool> callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            callback(true);
            this.MdiParent.Close();
        }
    }
}
