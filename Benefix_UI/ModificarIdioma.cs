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
    public partial class ModificarIdioma : Form
    {
        GestorDeUsuarios gestorDeUsuario;
        GestorSistema gestorSistema;
        private Action<Idioma> action;
        private Idioma idioma;

        public ModificarIdioma(Idioma idioma, Action<Idioma> action)
        {
            this.action = action;
            this.idioma = idioma;
            InitializeComponent();
            gestorDeUsuario = GestorDeUsuarios.ObtenerInstancia();
            gestorSistema = GestorSistema.ObtenerInstancia();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            gestorDeUsuario.ModificarIdioma(gestorSistema.ObtenerUsuarioEnSesion(), idioma);
            action(idioma);
            Close();
        }

        private void textLabel_Click(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.confirmarButton, Genesis.Recursos_localizables.StringResources.ConfirmarIdiomaButtonTooltip);
        }
    }
}
