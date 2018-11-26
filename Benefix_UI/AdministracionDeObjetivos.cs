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
    public partial class AdministracionDeObjetivos : Form
    {
        private GestorDeObjetivos gestorDeObjetivos;
        private Objetivo objetivoSeleccionado;
        public AdministracionDeObjetivos()
        {
            InitializeComponent();
            gestorDeObjetivos = GestorDeObjetivos.ObtenerInstancia();
        }

        private void AdministracionDeObjetivos_Load(object sender, EventArgs e)
        {
            ListarObjetivos();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_OBJETIVOS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_OBJETIVOS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_OBJETIVOS_ELIMINACION);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.limpiarButton, "Limpia el formulario");
            toolTip1.SetToolTip(this.crearButton, "Crea un nuevo objetivo");
            toolTip1.SetToolTip(this.modificarButton, "Modifica el objetivo seleccionado");
            toolTip1.SetToolTip(this.eliminarButton, "Elimina el objetivo seleccionado");
            toolTip1.SetToolTip(this.puntajeUpDown, "Indica el puntaje que otorgara cumplir el objetivo");

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "9_Administracindeobjetivos.htm");
        }

        private void AdministracionDeObjetivos_Shown(object sender, EventArgs e)
        {
            objetivosDataGridView.ClearSelection();
            LimpiarFormulario();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            objetivosDataGridView.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            objetivoSeleccionado = null;

            nombreText.Clear();
            puntajeUpDown.ResetText();
            descripcionText.Clear();

            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;

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

            if (puntajeUpDown.Text.Trim().Length == 0 || puntajeUpDown.Value.CompareTo(Decimal.Zero) == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionPuntajeRequerido);
                return false;
            }

            if (descripcionText.Text.Trim().Length == 0)
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBeneficiosDescripcionRequerida);
                return false;
            }

            return true;
        }

        private void ListarObjetivos()
        {
            List<Objetivo> Objetivos = gestorDeObjetivos.ListarObjetivos();

            objetivosDataGridView.AutoGenerateColumns = false;
            objetivosDataGridView.DataSource = Objetivos;

            foreach (DataGridViewColumn col in objetivosDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            objetivosDataGridView.ClearSelection();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                var descripcion = descripcionText.Text;
                String puntaje = puntajeUpDown.Text;
                Objetivo objetivo = new Objetivo() { nombre = nombre, descripcion = descripcion, puntaje = Convert.ToInt32(puntaje) };

                try
                {
                    gestorDeObjetivos.CrearObjetivo(objetivo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.CrearObjetivo);
                    LimpiarFormulario();
                    ListarObjetivos();
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

                Objetivo Objetivo = new Objetivo() { identificador = objetivoSeleccionado.identificador, nombre = nombre };
                try
                {
                    gestorDeObjetivos.ModificarObjetivo(Objetivo);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.ObjetivoMdoficado);
                    LimpiarFormulario();
                    ListarObjetivos();
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
                gestorDeObjetivos.EliminarObjetivo(objetivoSeleccionado);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.EliminarMdoficado);
                LimpiarFormulario();
                ListarObjetivos();
            }
            catch (EntidadDuplicadaExcepcion exception)
            {
                MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado, exception.atributo));
            }
        }

        private void objetivosDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (objetivosDataGridView.CurrentCell != null)
            {
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;

                crearButton.Enabled = false;

                Objetivo objetivoSeleccionada = (Objetivo)objetivosDataGridView.Rows[objetivosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                this.objetivoSeleccionado = objetivoSeleccionada;

                nombreText.Text = objetivoSeleccionada.nombre;
                descripcionText.Text = objetivoSeleccionada.descripcion;
                puntajeUpDown.Value = objetivoSeleccionada.puntaje;
            }
        }
    }
}
