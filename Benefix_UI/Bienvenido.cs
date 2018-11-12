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
    public partial class Bienvenido : Form
    {
        private Action<string> action;

        public Bienvenido(Action<String> action)
        {
            InitializeComponent();
            this.action = action;
            //textBox1.Text = "Persist Security Info=False;User ID=sa;Password=qwer1234;Initial Catalog=Benefix;Server=DESKTOP-VA9KCI4\\SQLEXPRESS";
        }

        private void comenzarButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length > 0)
            {
                action(textBox1.Text);
                this.Close();
            }
        }
    }
}
