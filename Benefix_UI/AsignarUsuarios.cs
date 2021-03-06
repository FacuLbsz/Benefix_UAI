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
    public partial class AsignarUsuarios : Form
    {
        private Familia familia;
        private GestorDeUsuarios gestorDeUsuarios;
        private GestorDeFamilias gestorDeFamilias;
        private List<Usuario> usuarioAsignados;
        private List<Usuario> usuariosNoAsignados;
        private List<Usuario> usuarioAsignadosFixed;
        public AsignarUsuarios(Familia familia)
        {
            InitializeComponent();
            this.familia = familia;
            this.usuarioAsignados = familia.usuariosAsignados;
            this.gestorDeFamilias = GestorDeFamilias.ObtenerInstancia();
            this.gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();

            this.usuariosNoAsignados = gestorDeUsuarios.ConsultarUsuarios().Except(usuarioAsignados).ToList();
            this.usuarioAsignadosFixed = new List<Usuario>();
            usuarioAsignadosFixed.AddRange(usuarioAsignados);
        }

        private void asignarButton_Click(object sender, EventArgs e)
        {
            if (usuariosDataGridView.SelectedRows.Count > 0 && usuariosDataGridView.Rows[usuariosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {

                var usuario = (Usuario)usuariosDataGridView.Rows[usuariosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                gestorDeFamilias.AsignarUsuario(usuario, familia);

                usuarioAsignados.Add(usuario);
                usuariosAsignadosDataGridView.AutoGenerateColumns = false;
                var binding1 = new BindingSource();
                binding1.DataSource = usuarioAsignados;
                usuariosAsignadosDataGridView.DataSource = binding1;

                usuariosNoAsignados.Remove(usuario);
                usuariosDataGridView.AutoGenerateColumns = false;
                var binding = new BindingSource();
                binding.DataSource = usuariosNoAsignados;
                usuariosDataGridView.DataSource = binding;

                usuariosAsignadosDataGridView.ClearSelection();
                usuariosDataGridView.ClearSelection();
            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioAsignarRequerido);
            }

        }

        private void desasignarButton_Click(object sender, EventArgs e)
        {
            if (usuariosAsignadosDataGridView.SelectedRows.Count > 0 && usuariosAsignadosDataGridView.Rows[usuariosAsignadosDataGridView.SelectedRows[0].Index].DataBoundItem != null)
            {
                var usuario = (Usuario)usuariosAsignadosDataGridView.Rows[usuariosAsignadosDataGridView.CurrentCell.RowIndex].DataBoundItem;

                try
                {
                    gestorDeFamilias.DesasignarUsuario(usuario, familia);

                    usuariosNoAsignados.Add(usuario);
                    usuariosDataGridView.AutoGenerateColumns = false;
                    var binding = new BindingSource();
                    binding.DataSource = usuariosNoAsignados;
                    usuariosDataGridView.DataSource = binding;

                    usuarioAsignados.Remove(usuario);
                    usuariosAsignadosDataGridView.AutoGenerateColumns = false;
                    var binding1 = new BindingSource();
                    binding1.DataSource = usuarioAsignados;
                    usuariosAsignadosDataGridView.DataSource = binding1;

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                usuariosAsignadosDataGridView.ClearSelection();
                usuariosDataGridView.ClearSelection();

            }
            else
            {
                MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioDesasignarRequerido);
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Genesis.Recursos_localizables.StringResources.AsignarUsuariosMessageUsuarioSatisfactorio);
            this.Close();
        }

        private void AsignarUsuarios_Load(object sender, EventArgs e)
        {
            usuariosDataGridView.AutoGenerateColumns = false;
            usuariosDataGridView.DataSource = usuariosNoAsignados;

            usuariosAsignadosDataGridView.AutoGenerateColumns = false;
            usuariosAsignadosDataGridView.DataSource = usuarioAsignados;

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.asignarButton, Genesis.Recursos_localizables.StringResources.AsignarusuaroafamiliaButtonTooltip);
            toolTip1.SetToolTip(this.desasignarButton, Genesis.Recursos_localizables.StringResources.DesasignarusuaroafamiliaButtonTooltip);
            toolTip1.SetToolTip(this.guardarButton, Genesis.Recursos_localizables.StringResources.GuardarButtonTooltip);

            System.Windows.Forms.HelpProvider helpProvider1 = new HelpProvider();
            var applicationFolder = Application.StartupPath + "\\Benefix_mu.chm";
            helpProvider1.HelpNamespace = applicationFolder;
            helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);
            helpProvider1.SetHelpKeyword(this, "22_AsignarUsuarios.htm");
        }

        private void AsignarUsuarios_Shown(object sender, EventArgs e)
        {
            usuariosAsignadosDataGridView.ClearSelection();
            usuariosDataGridView.ClearSelection();
        }
    }
}
