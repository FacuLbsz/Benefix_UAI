namespace Genesis
{
    partial class AsignarObjetivos
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
            this.objetivosDataGridView = new System.Windows.Forms.DataGridView();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.objetivosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.desasignarButton = new System.Windows.Forms.Button();
            this.objetivosAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objetivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.objetivosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetivosAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // objetivosDataGridView
            // 
            this.objetivosDataGridView.AllowUserToAddRows = false;
            this.objetivosDataGridView.AllowUserToDeleteRows = false;
            this.objetivosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.objetivosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.objetivosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objetivos});
            this.objetivosDataGridView.Location = new System.Drawing.Point(598, 20);
            this.objetivosDataGridView.MultiSelect = false;
            this.objetivosDataGridView.Name = "objetivosDataGridView";
            this.objetivosDataGridView.ReadOnly = true;
            this.objetivosDataGridView.RowHeadersVisible = false;
            this.objetivosDataGridView.RowTemplate.Height = 28;
            this.objetivosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.objetivosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.objetivosDataGridView.TabIndex = 45;
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
            // objetivosAsignadosDataGridView
            // 
            this.objetivosAsignadosDataGridView.AllowUserToAddRows = false;
            this.objetivosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.objetivosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.objetivosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.objetivosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objetivosAsignados});
            this.objetivosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.objetivosAsignadosDataGridView.MultiSelect = false;
            this.objetivosAsignadosDataGridView.Name = "objetivosAsignadosDataGridView";
            this.objetivosAsignadosDataGridView.ReadOnly = true;
            this.objetivosAsignadosDataGridView.RowHeadersVisible = false;
            this.objetivosAsignadosDataGridView.RowTemplate.Height = 28;
            this.objetivosAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.objetivosAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.objetivosAsignadosDataGridView.TabIndex = 41;
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
            // objetivosAsignados
            // 
            this.objetivosAsignados.DataPropertyName = "nombre";
            this.objetivosAsignados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleadosAsignados;
            this.objetivosAsignados.Name = "objetivosAsignados";
            this.objetivosAsignados.ReadOnly = true;
            // 
            // objetivos
            // 
            this.objetivos.DataPropertyName = "nombre";
            this.objetivos.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.objetivos.Name = "objetivos";
            this.objetivos.ReadOnly = true;
            // 
            // AsignarObjetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 591);
            this.Controls.Add(this.objetivosDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.objetivosAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarObjetivos";
            this.Text = "Asignar empleados";
            this.Load += new System.EventHandler(this.AsignarEmpleados_Load);
            this.Shown += new System.EventHandler(this.AsignarObjetivosAEquipos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.objetivosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetivosAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView objetivosDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView objetivosAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivosAsignados;
    }
}