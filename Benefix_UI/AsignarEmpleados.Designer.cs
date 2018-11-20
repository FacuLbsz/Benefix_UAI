namespace Genesis
{
    partial class AsignarEmpleados
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
            this.empleadosDataGridView = new System.Windows.Forms.DataGridView();
            this.empleados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.empleadosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.desasignarButton = new System.Windows.Forms.Button();
            this.empleadosAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // empleadosDataGridView
            // 
            this.empleadosDataGridView.AllowUserToAddRows = false;
            this.empleadosDataGridView.AllowUserToDeleteRows = false;
            this.empleadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empleadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empleadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleados});
            this.empleadosDataGridView.Location = new System.Drawing.Point(598, 20);
            this.empleadosDataGridView.MultiSelect = false;
            this.empleadosDataGridView.Name = "empleadosDataGridView";
            this.empleadosDataGridView.ReadOnly = true;
            this.empleadosDataGridView.RowHeadersVisible = false;
            this.empleadosDataGridView.RowTemplate.Height = 28;
            this.empleadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empleadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.empleadosDataGridView.TabIndex = 45;
            // 
            // empleados
            // 
            this.empleados.DataPropertyName = "nombreUsuario";
            this.empleados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.empleados.Name = "empleados";
            this.empleados.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(308, 533);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 44;
            this.guardarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(308, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 43;
            this.asignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignar;
            this.asignarButton.UseVisualStyleBackColor = true;
            this.asignarButton.Click += new System.EventHandler(this.asignarButton_Click);
            // 
            // empleadosAsignadosDataGridView
            // 
            this.empleadosAsignadosDataGridView.AllowUserToAddRows = false;
            this.empleadosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.empleadosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empleadosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empleadosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleadosAsignados});
            this.empleadosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.empleadosAsignadosDataGridView.MultiSelect = false;
            this.empleadosAsignadosDataGridView.Name = "empleadosAsignadosDataGridView";
            this.empleadosAsignadosDataGridView.ReadOnly = true;
            this.empleadosAsignadosDataGridView.RowHeadersVisible = false;
            this.empleadosAsignadosDataGridView.RowTemplate.Height = 28;
            this.empleadosAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empleadosAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.empleadosAsignadosDataGridView.TabIndex = 41;
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(308, 119);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 42;
            this.desasignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonDesasignar;
            this.desasignarButton.UseVisualStyleBackColor = true;
            this.desasignarButton.Click += new System.EventHandler(this.desasignarButton_Click);
            // 
            // empleadosAsignados
            // 
            this.empleadosAsignados.DataPropertyName = "nombreUsuario";
            this.empleadosAsignados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleadosAsignados;
            this.empleadosAsignados.Name = "empleadosAsignados";
            this.empleadosAsignados.ReadOnly = true;
            // 
            // AsignarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 591);
            this.Controls.Add(this.empleadosDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.empleadosAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarEmpleados";
            this.Text = "Asignar empleados";
            this.Load += new System.EventHandler(this.AsignarEmpleados_Load);
            this.Shown += new System.EventHandler(this.AsignarUsuariosAEquipos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView empleadosDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView empleadosAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleados;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadosAsignados;
    }
}