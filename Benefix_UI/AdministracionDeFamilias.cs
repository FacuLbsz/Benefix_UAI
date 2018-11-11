using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class AdministracionDeFamilias : Form
    {
        private Familia familiaSeleccionada;
        private GestorDeFamilias gestorDeFamilias;

        public AdministracionDeFamilias()
        {
            InitializeComponent();
            gestorDeFamilias = GestorDeFamilias.ObtenerInstancia();
        }

        private void asignarPatentesButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarPatentesAFamilias(familiaSeleccionada);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void asignarUsuariosButton_Click(object sender, EventArgs e)
        {
            var mainForm = new AsignarUsuarios(familiaSeleccionada);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.ShowDialog();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            familiasDataGridView.ClearSelection();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                Familia familia = new Familia() { nombre = nombre };

                try
                {
                    gestorDeFamilias.CrearFamilia(familia);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageSatisfactorio);
                    LimpiarFormulario();
                    ListarFamilias();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeFamiliasMessageNombreDubplicado);
                }
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;

                Familia familia = new Familia() { identificador = familiaSeleccionada.identificador, nombre = nombre };
                try
                {
                    gestorDeFamilias.ModificarFamilia(familia);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageSatisfactorio);
                    LimpiarFormulario();
                    ListarFamilias();
                }
                catch (EntidadDuplicadaExcepcion excepcion)
                {
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdminsitracionDeFamiliasMessageNombreDubplicado);
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                gestorDeFamilias.EliminarFamilia(familiaSeleccionada);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminado);
                LimpiarFormulario();
                ListarFamilias();
            }
            catch (EntidadDuplicadaExcepcion exception)
            {
                MessageBox.Show(String.Format(Genesis.Recursos_localizables.StringResources.AdministracionDeFamiliasMessageFamiliaEliminadoError, exception.atributo));
            }
        }

        private bool EsUnFormularioValido()
        {
            var nombre = nombreText.Text;

            if (nombre.Trim().Length == 0 || !Regex.IsMatch(nombre, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageNombreRequerido);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            familiaSeleccionada = null;

            nombreText.Clear();

            asignarUsuariosButton.Enabled = false;
            asignarPatentesButton.Enabled = false;
            modificarButton.Enabled = false;
            eliminarButton.Enabled = false;

            crearButton.Enabled = true;

            nombreText.Focus();
        }

        private void AdministracionDeFamilias_Load(object sender, EventArgs e)
        {
            ListarFamilias();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_FAMILIAS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_FAMILIAS_MODIFICACION);
            asignarPatentesButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_FAMILIAS_MODIFICACION);
            asignarUsuariosButton.Visible = GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_FAMILIAS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_FAMILIAS_ELIMINACION);
        }

        private void AdministracionDeFamilias_Shown(object sender, EventArgs e)
        {
            familiasDataGridView.ClearSelection();
            LimpiarFormulario();
        }

        private void ListarFamilias()
        {
            List<Familia> familias = gestorDeFamilias.ConsultarFamilias();

            familiasDataGridView.AutoGenerateColumns = false;
            familiasDataGridView.DataSource = familias;

            foreach (DataGridViewColumn col in familiasDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            familiasDataGridView.ClearSelection();
        }

        private void familiasDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (familiasDataGridView.CurrentCell != null)
            {
                asignarUsuariosButton.Enabled = true;
                asignarPatentesButton.Enabled = true;
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;

                crearButton.Enabled = false;

                Familia familiaSeleccionada = (Familia)familiasDataGridView.Rows[familiasDataGridView.CurrentCell.RowIndex].DataBoundItem;

                this.familiaSeleccionada = familiaSeleccionada;

                nombreText.Text = familiaSeleccionada.nombre;
            }
        }
    }
}
