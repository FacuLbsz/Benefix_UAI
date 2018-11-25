namespace Genesis
{
    partial class EvaluarEquiposACargo
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
            this.equiposAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadosDataGridView = new System.Windows.Forms.DataGridView();
            this.empleados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluarButton = new System.Windows.Forms.Button();
            this.evaluarEquiposTitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.equiposAsignadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // equiposAsignadosDataGridView
            // 
            this.equiposAsignadosDataGridView.AllowUserToAddRows = false;
            this.equiposAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.equiposAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equiposAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equiposAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipos});
            this.equiposAsignadosDataGridView.Location = new System.Drawing.Point(18, 56);
            this.equiposAsignadosDataGridView.MultiSelect = false;
            this.equiposAsignadosDataGridView.Name = "equiposAsignadosDataGridView";
            this.equiposAsignadosDataGridView.ReadOnly = true;
            this.equiposAsignadosDataGridView.RowHeadersVisible = false;
            this.equiposAsignadosDataGridView.RowTemplate.Height = 28;
            this.equiposAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.equiposAsignadosDataGridView.Size = new System.Drawing.Size(240, 515);
            this.equiposAsignadosDataGridView.TabIndex = 41;
            this.equiposAsignadosDataGridView.Click += new System.EventHandler(this.equiposAsignadosDataGridView_CurrentCellChanged);
            // 
            // equipos
            // 
            this.equipos.DataPropertyName = "nombre";
            this.equipos.HeaderText = "Equipos";
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            // 
            // empleadosDataGridView
            // 
            this.empleadosDataGridView.AllowUserToAddRows = false;
            this.empleadosDataGridView.AllowUserToDeleteRows = false;
            this.empleadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empleadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empleadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleados});
            this.empleadosDataGridView.Location = new System.Drawing.Point(310, 56);
            this.empleadosDataGridView.MultiSelect = false;
            this.empleadosDataGridView.Name = "empleadosDataGridView";
            this.empleadosDataGridView.ReadOnly = true;
            this.empleadosDataGridView.RowHeadersVisible = false;
            this.empleadosDataGridView.RowTemplate.Height = 28;
            this.empleadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empleadosDataGridView.Size = new System.Drawing.Size(240, 453);
            this.empleadosDataGridView.TabIndex = 45;
            // 
            // empleados
            // 
            this.empleados.DataPropertyName = "nombreUsuario";
            this.empleados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.empleados.Name = "empleados";
            this.empleados.ReadOnly = true;
            // 
            // evaluarButton
            // 
            this.evaluarButton.Location = new System.Drawing.Point(308, 533);
            this.evaluarButton.Name = "evaluarButton";
            this.evaluarButton.Size = new System.Drawing.Size(242, 38);
            this.evaluarButton.TabIndex = 44;
            this.evaluarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonEvaluar;
            this.evaluarButton.UseVisualStyleBackColor = true;
            this.evaluarButton.Click += new System.EventHandler(this.evaluarButton_Click);
            // 
            // evaluarEquiposTitleLabel
            // 
            this.evaluarEquiposTitleLabel.AutoSize = true;
            this.evaluarEquiposTitleLabel.Location = new System.Drawing.Point(14, 24);
            this.evaluarEquiposTitleLabel.Name = "evaluarEquiposTitleLabel";
            this.evaluarEquiposTitleLabel.Size = new System.Drawing.Size(165, 20);
            this.evaluarEquiposTitleLabel.TabIndex = 46;
            this.evaluarEquiposTitleLabel.Text = "Seleccione un equipo:";
            // 
            // EvaluarEquiposACargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 591);
            this.Controls.Add(this.evaluarEquiposTitleLabel);
            this.Controls.Add(this.equiposAsignadosDataGridView);
            this.Controls.Add(this.empleadosDataGridView);
            this.Controls.Add(this.evaluarButton);
            this.Name = "EvaluarEquiposACargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Evaluar equipos a cargo";
            this.Load += new System.EventHandler(this.EvaluarEquiposACargo_Load);
            this.Shown += new System.EventHandler(this.EvaluarEquiposACargo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.equiposAsignadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView equiposAsignadosDataGridView;
        private System.Windows.Forms.DataGridView empleadosDataGridView;
        private System.Windows.Forms.Button evaluarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipos;
        private System.Windows.Forms.Label evaluarEquiposTitleLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleados;
    }
}