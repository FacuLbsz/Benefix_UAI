﻿using System;
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
    public partial class AdministracionDeBeneficios : Form
    {

        private Beneficio beneficioSeleccionado;
        private GestorDeBeneficios gestorDeBeneficios;

        public AdministracionDeBeneficios()
        {
            InitializeComponent();
            gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
        }

        private void AdministracionDeBeneficios_Load(object sender, EventArgs e)
        {
            ListarBeneficios();
            crearButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_BENEFICIOS_CREACION);
            modificarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_BENEFICIOS_MODIFICACION);
            eliminarButton.Visible =
            GestorSistema.ObtenerInstancia().ConsultarPatentePorUsuario(Patente.ADMINISTRACION_BENEFICIOS_ELIMINACION);

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.limpiarButton, Genesis.Recursos_localizables.StringResources.LimpiarButton);
            toolTip1.SetToolTip(this.crearButton, Genesis.Recursos_localizables.StringResources.CrearBeneficioButton);
            toolTip1.SetToolTip(this.modificarButton, Genesis.Recursos_localizables.StringResources.ModificarBeneficioButton);
            toolTip1.SetToolTip(this.eliminarButton, Genesis.Recursos_localizables.StringResources.EliminarBeneficioButton);
            toolTip1.SetToolTip(this.puntajeUpDown, Genesis.Recursos_localizables.StringResources.PuntajeBeneficio);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "10_Administracindebeneficios.htm");
        }

        private void AdministracionDeBeneficios_Shown(object sender, EventArgs e)
        {
            beneficiosDataGridView.ClearSelection();
            LimpiarFormulario();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            beneficiosDataGridView.ClearSelection();
        }

        private void LimpiarFormulario()
        {
            beneficioSeleccionado = null;

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
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeUsuariosMessageNombreRequerido);
                return false;
            }

            return true;
        }

        private void ListarBeneficios()
        {
            List<Beneficio> Beneficios = gestorDeBeneficios.ConsultarBeneficios();

            beneficiosDataGridView.AutoGenerateColumns = false;
            beneficiosDataGridView.DataSource = Beneficios;

            foreach (DataGridViewColumn col in beneficiosDataGridView.Columns)
            {
                if (col.DataPropertyName != "nombre")
                    col.Visible = false;
            }

            beneficiosDataGridView.ClearSelection();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            if (EsUnFormularioValido())
            {
                var nombre = nombreText.Text;
                var descripcion = descripcionText.Text;
                String puntaje = puntajeUpDown.Text;
                Beneficio beneficio = new Beneficio() { nombre = nombre, descripcion = descripcion, puntaje = Convert.ToInt32(puntaje) };

                try
                {
                    gestorDeBeneficios.CrearBeneficio(beneficio);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBEneficiosMessageCrearSatisfactorio);
                    LimpiarFormulario();
                    ListarBeneficios();
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

                Beneficio Beneficio = new Beneficio() { identificador = beneficioSeleccionado.identificador, nombre = nombre, puntaje = Convert.ToInt32(puntajeUpDown.Value) };
                try
                {
                    gestorDeBeneficios.ModificarBeneficio(Beneficio);
                    MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBEneficiosMessageModificarSatisfactorio);
                    LimpiarFormulario();
                    ListarBeneficios();
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
                gestorDeBeneficios.EliminarBeneficio(beneficioSeleccionado);
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AdministracionDeBEneficiosMessageEliminacionSatisfactorio);
                LimpiarFormulario();
                ListarBeneficios();
            }
            catch (EntidadDuplicadaExcepcion exception)
            {
            }
        }

        private void beneficiosDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (beneficiosDataGridView.CurrentCell != null)
            {
                modificarButton.Enabled = true;
                eliminarButton.Enabled = true;

                crearButton.Enabled = false;

                Beneficio beneficioSeleccionada = (Beneficio)beneficiosDataGridView.Rows[beneficiosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                this.beneficioSeleccionado = beneficioSeleccionada;

                nombreText.Text = beneficioSeleccionada.nombre;
                descripcionText.Text = beneficioSeleccionada.descripcion;
                puntajeUpDown.Value = beneficioSeleccionada.puntaje;
            }
        }
    }
}
