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
            var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Cierre de sesion", funcionalidad = "LOG OUT", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
            GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
            callback(true);
            this.MdiParent.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
