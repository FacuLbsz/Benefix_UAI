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
        private GestorDeGrupos gestorDeGrupos;
        private Grupo grupoSeleccionado;

        public AdministracionDeGrupos()
        {
            InitializeComponent();
            gestorDeGrupos = GestorDeGrupos.ObtenerInstancia();
        }

        private void asignarBeneficiosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarBeneficios(grupoSeleccionado);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void AdministracionDeGrupos_Load(object sender, EventArgs e)
        {
            ListarGrupos();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_GRUPOS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_GRUPOS_MODIFICACION);
            asignarBeneficiosButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINSITRACION_EQUIPOS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_GRUPOS_ELIMINACION);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.limpiarButton, "Limpia el formulario");
            toolTip1.SetToolTip(this.crearButton, "Crea un nuevo grupo");
            toolTip1.SetToolTip(this.modificarButton, "Modifica el grupo seleccionado");
            toolTip1.SetToolTip(this.eliminarButton, "Elimina el grupo seleccionado");

            toolTip1.SetToolTip(this.asignarBeneficiosButton, "Permite asignar beneficios al grupo seleccionado");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "16_Administracindegrupos.htm");
        }

        private void AdministracionDeGrupos_Shown(object sender, EventArgs e)
        {
            gruposDataGridView.ClearSelection();
            LimpiarFormulario();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            gruposDataGridView.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            grupoSeleccionado = null;

            nombreText.Clear();

            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;
            asignarBeneficiosButton.Enabled = false;

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

        private void ListarGrupos()
        {
            List<Grupo> Grupos = gestorDeGrupos.ConsultarGrupos();

            gruposDataGridView.AutoGenerateColumns = false;
            gruposDataGridView.DataSource = Grupos;

            foreach (DataGridViewColumn col in gruposDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            gruposDataGridView.ClearSelection();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                Grupo grupo = new Grupo() { nombre = nombre };

                try
                {
                    gestorDeGrupos.CrearGrupo(grupo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.GrupoCreado);
                    LimpiarFormulario();
                    ListarGrupos();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBEneficiosMessageNombreDuplicado);
                }
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;

                Grupo Grupo = new Grupo() { identificador = grupoSeleccionado.identificador, nombre = nombre };
                try
                {
                    gestorDeGrupos.ModificarGrupo(Grupo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.GrupoModificado);
                    LimpiarFormulario();
                    ListarGrupos();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBEneficiosMessageNombreDuplicado);
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                gestorDeGrupos.EliminarGrupo(grupoSeleccionado);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.GrupoEliminado);
                LimpiarFormulario();
                ListarGrupos();
            }
            catch (EntidadDuplicadaExcepcion exception)
            {
                MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado, exception.atributo));
            }
        }

        private void gruposDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gruposDataGridView.CurrentCell != null)
            {
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;
                asignarBeneficiosButton.Enabled = true;

                crearButton.Enabled = false;

                Grupo grupoSeleccionada = (Grupo)gruposDataGridView.Rows[gruposDataGridView.CurrentCell.RowIndex].DataBoundItem;

                this.grupoSeleccionado = grupoSeleccionada;

                nombreText.Text = grupoSeleccionada.nombre;
            }
        }
    }
}
