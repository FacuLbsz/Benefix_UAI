﻿namespace Genesis
{
    partial class AdministracionDeEquipos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.asignarGruposButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.asignarEmpleadosButton = new System.Windows.Forms.Button();
            this.asignarCoordinadorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // asignarGruposButton
            // 
            this.asignarGruposButton.Location = new System.Drawing.Point(319, 328);
            this.asignarGruposButton.Name = "asignarGruposButton";
            this.asignarGruposButton.Size = new System.Drawing.Size(242, 38);
            this.asignarGruposButton.TabIndex = 43;
            this.asignarGruposButton.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignarGrupos;
            this.asignarGruposButton.UseVisualStyleBackColor = true;
            this.asignarGruposButton.Click += new System.EventHandler(this.asignarGruposButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipos});
            this.dataGridView1.Location = new System.Drawing.Point(29, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 551);
            this.dataGridView1.TabIndex = 36;
            // 
            // equipos
            // 
            this.equipos.HeaderText = Genesis.Recursos_localizables.StringResources.TableEquipos;
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(319, 540);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 42;
            this.eliminarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonEliminar;
            this.eliminarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(319, 487);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 41;
            this.modificarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonModificar;
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(319, 434);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 40;
            this.crearButton.Text = Genesis.Recursos_localizables.StringResources.ButtonCrear;
            this.crearButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(319, 381);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 39;
            this.limpiarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonLimpiar;
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(319, 27);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 38;
            this.nombreLabel.Text = Genesis.Recursos_localizables.StringResources.FormularioNombre;
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(319, 53);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 37;
            // 
            // asignarEmpleadosButton
            // 
            this.asignarEmpleadosButton.Location = new System.Drawing.Point(319, 274);
            this.asignarEmpleadosButton.Name = "asignarEmpleadosButton";
            this.asignarEmpleadosButton.Size = new System.Drawing.Size(242, 38);
            this.asignarEmpleadosButton.TabIndex = 44;
            this.asignarEmpleadosButton.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignarEmpleados;
            this.asignarEmpleadosButton.UseVisualStyleBackColor = true;
            this.asignarEmpleadosButton.Click += new System.EventHandler(this.asignarEmpleadosButton_Click);
            // 
            // asignarCoordinadorButton
            // 
            this.asignarCoordinadorButton.Location = new System.Drawing.Point(319, 219);
            this.asignarCoordinadorButton.Name = "asignarCoordinadorButton";
            this.asignarCoordinadorButton.Size = new System.Drawing.Size(242, 38);
            this.asignarCoordinadorButton.TabIndex = 45;
            this.asignarCoordinadorButton.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignarCoordinador;
            this.asignarCoordinadorButton.UseVisualStyleBackColor = true;
            this.asignarCoordinadorButton.Click += new System.EventHandler(this.asignarCoordinadorButton_Click);
            // 
            // AdministracionDeEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 604);
            this.Controls.Add(this.asignarCoordinadorButton);
            this.Controls.Add(this.asignarEmpleadosButton);
            this.Controls.Add(this.asignarGruposButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Name = "AdministracionDeEquipos";
            this.Text = Genesis.Recursos_localizables.StringResources.SistemaMenuItemAdministracionDeEquipos;
            this.Load += new System.EventHandler(this.AdministracionDeEquipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asignarGruposButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Button asignarEmpleadosButton;
        private System.Windows.Forms.Button asignarCoordinadorButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipos;
    }
}