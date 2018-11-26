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
    public partial class AsignarCoordinador : Form
    {
        private Equipo equipo;
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeEquipos gestorDeEquipos;
        public AsignarCoordinador(Equipo equipo)
        {
            InitializeComponent();
            this.equipo = equipo;
            gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();

        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (coordinadorBox.SelectedItem != null)
            {
                Usuario coordinador = (Usuario)coordinadorBox.SelectedItem;
                gestorDeEquipos.AsignarCoordinador(coordinador, equipo);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
                this.Close();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarPatentesAFamiliasMessageDesasignarError);
            }
        }

        private void AsignarCoordinador_Load(object sender, EventArgs e)
        {
            var empleados = gestorDeUsuarios.ConsultarUsuariosTodos();
            coordinadorBox.DataSource = gestorDeUsuarios.ConsultarUsuariosTodos();
            coordinadorBox.DisplayMember = "nombreUsuario";
            coordinadorBox.ValueMember = "identificador";

            if (equipo.coordinador != null)
            {
                empleados.ForEach((em) =>
                {
                    if (em.identificador == equipo.coordinador.identificador)
                    {
                        coordinadorBox.SelectedItem = em;
                    }
                });
            }

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.coordinadorBox, "Selecciona el empleado que se encaraga de coordinar y evaluar el equipo");
            toolTip1.SetToolTip(this.guardarButton, "Guarda la asignacion realizada");
        }
    }
}
