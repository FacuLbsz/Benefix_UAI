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
    public partial class ModificarStringDeConexion : Form
    {
        private GestorSistema gestorSistema;
        private Action<bool> action;

        public ModificarStringDeConexion(Action<Boolean> action)
        {
            InitializeComponent();
            this.action = action;
            //stringDeConexionText.Text = "Persist Security Info=False;User ID=sa;Password=qwer1234;Initial Catalog=Benefix;Server=DESKTOP-VA9KCI4\\SQLEXPRESS";
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (stringDeConexionText.Text.Trim().Length > 0)
            {
                try
                {
                    GestorSistema.ModificarStringDeConexion(stringDeConexionText.Text);
                    action(true);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un string de conexion a guardar.");
            }
        }

        private void ModificarStringDeConexion_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.guardarButton, "Modifica el string de conexion al acceso a la base de datos");
        }
    }
}
