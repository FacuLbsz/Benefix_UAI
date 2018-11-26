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
    public partial class AdministracionDeEquipos : Form
    {

        private GestorDeEquipos gestorDeEquipos;
        private Equipo equipoSeleccionado;

        public AdministracionDeEquipos()
        {
            InitializeComponent();
            gestorDeEquipos = GestorDeEquipos.ObtenerInstancia();

        }

        private void asignarCoordinadorButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarCoordinador(equipoSeleccionado);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarEmpleadosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarEmpleados(equipoSeleccionado);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarGruposButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarGrupos(equipoSeleccionado);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void AdministracionDeEquipos_Load(object sender, EventArgs e)
        {
            ListarEquipos();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_EQUIPOS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINSITRACION_EQUIPOS_MODIFICACION);
            asignarCoordinadorButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINSITRACION_EQUIPOS_MODIFICACION);
            asignarEmpleadosButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINSITRACION_EQUIPOS_MODIFICACION);
            asignarGruposButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINSITRACION_EQUIPOS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_EQUIPOS_ELIMINACION);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.limpiarButton, "Limpia el formulario");
            toolTip1.SetToolTip(this.crearButton, "Crea un nuevo equipo");
            toolTip1.SetToolTip(this.modificarButton, "Modifica el equipo seleccionado");
            toolTip1.SetToolTip(this.eliminarButton, "Elimina el equipo seleccionado");

            toolTip1.SetToolTip(this.asignarCoordinadorButton, "Permite asignar quien coordinara el equipo y evaluara los objetivos de los empleados asignados");
            toolTip1.SetToolTip(this.asignarEmpleadosButton, "Permite asignar empleados al equipo seleccionado");
            toolTip1.SetToolTip(this.asignarGruposButton, "Permite asignar grupos de beneficios al equipo seleccionado");
            toolTip1.SetToolTip(this.asignarObjetivosButton, "Permite asignar objetivos al equipo seleccionado por los cuales se evaluaran a los empleados");
        }

        private void AdministracionDeEquipos_Shown(object sender, EventArgs e)
        {
            equiposDataGridView.ClearSelection();
            LimpiarFormulario();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            equiposDataGridView.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            equipoSeleccionado = null;

            nombreText.Clear();

            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            asignarCoordinadorButton.Enabled = false;
            asignarGruposButton.Enabled = false;
            asignarEmpleadosButton.Enabled = false;

            crearButton.Enabled = true;

            nombreText.Focus();
        }

        private bool EsUnFormularioValido()
        {
            var nombre = nombreText.Text;

            if (nombre.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageNombreRequerido);
                return false;
            }

            return true;
        }

        private void ListarEquipos()
        {
            List<Equipo> Equipos = gestorDeEquipos.ConsultarEquipos();

            equiposDataGridView.AutoGenerateColumns = false;
            equiposDataGridView.DataSource = Equipos;

            foreach (DataGridViewColumn col in equiposDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            equiposDataGridView.ClearSelection();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                Equipo equipo = new Equipo() { nombre = nombre };

                try
                {
                    gestorDeEquipos.CrearEquipo(equipo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                    LimpiarFormulario();
                    ListarEquipos();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                }
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;

                Equipo Equipo = new Equipo() { identificador = equipoSeleccionado.identificador, nombre = nombre };
                try
                {
                    gestorDeEquipos.ModificarEquipo(Equipo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                    LimpiarFormulario();
                    ListarEquipos();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                gestorDeEquipos.EliminarEquipo(equipoSeleccionado);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                LimpiarFormulario();
                ListarEquipos();
            }
            catch (EntidadDuplicadaExcepcion exception)
            {
                MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado, exception.atributo));
            }
        }

        private void equiposDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (equiposDataGridView.CurrentCell != null)
            {
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;
                asignarCoordinadorButton.Enabled = true;
                asignarGruposButton.Enabled = true;
                asignarEmpleadosButton.Enabled = true;
                crearButton.Enabled = false;

                Equipo equipoSeleccionada = (Equipo)equiposDataGridView.Rows[equiposDataGridView.CurrentCell.RowIndex].DataBoundItem;

                this.equipoSeleccionado = equipoSeleccionada;

                nombreText.Text = equipoSeleccionada.nombre;
            }
        }

        private void asignarObjetivosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarObjetivos(equipoSeleccionado);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }
    }
}
