namespace Genesis
{
    partial class AsignarPatentesAUsuarios
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
            this.patentesDataGridView = new System.Windows.Forms.DataGridView();
            this.patentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.patentesAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.desasignarButton = new System.Windows.Forms.Button();
            this.patentesAsignadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permisivaRestringiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.patentesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patentesAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // patentesDataGridView
            // 
            this.patentesDataGridView.AllowUserToAddRows = false;
            this.patentesDataGridView.AllowUserToDeleteRows = false;
            this.patentesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patentesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patentesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentes});
            this.patentesDataGridView.Location = new System.Drawing.Point(649, 20);
            this.patentesDataGridView.Name = "patentesDataGridView";
            this.patentesDataGridView.ReadOnly = true;
            this.patentesDataGridView.RowHeadersVisible = false;
            this.patentesDataGridView.RowTemplate.Height = 28;
            this.patentesDataGridView.Size = new System.Drawing.Size(240, 551);
            this.patentesDataGridView.TabIndex = 55;
            // 
            // patentes
            // 
            this.patentes.DataPropertyName = "nombre";
            this.patentes.HeaderText = "Patentes";
            this.patentes.Name = "patentes";
            this.patentes.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(359, 533);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 54;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(359, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 53;
            this.asignarButton.Text = "< Asignar";
            this.asignarButton.UseVisualStyleBackColor = true;
            // 
            // patentesAsignadosDataGridView
            // 
            this.patentesAsignadosDataGridView.AllowUserToAddRows = false;
            this.patentesAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.patentesAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patentesAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patentesAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentesAsignadas,
            this.permisivaRestringiva});
            this.patentesAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.patentesAsignadosDataGridView.Name = "patentesAsignadosDataGridView";
            this.patentesAsignadosDataGridView.RowHeadersVisible = false;
            this.patentesAsignadosDataGridView.RowTemplate.Height = 28;
            this.patentesAsignadosDataGridView.Size = new System.Drawing.Size(291, 551);
            this.patentesAsignadosDataGridView.TabIndex = 51;
            this.patentesAsignadosDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.patentesAsignadosDataGridView_CellFormatting);
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(359, 119);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 52;
            this.desasignarButton.Text = "Desasignar >";
            this.desasignarButton.UseVisualStyleBackColor = true;
            // 
            // patentesAsignadas
            // 
            this.patentesAsignadas.DataPropertyName = "patente.nombre";
            this.patentesAsignadas.FillWeight = 194.9239F;
            this.patentesAsignadas.HeaderText = "Patentes Asignadas";
            this.patentesAsignadas.Name = "patentesAsignadas";
            this.patentesAsignadas.ReadOnly = true;
            // 
            // permisivaRestringiva
            // 
            this.permisivaRestringiva.DataPropertyName = "esPermisivo";
            this.permisivaRestringiva.FalseValue = "false";
            this.permisivaRestringiva.FillWeight = 40F;
            this.permisivaRestringiva.HeaderText = "P/R";
            this.permisivaRestringiva.Name = "permisivaRestringiva";
            this.permisivaRestringiva.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.permisivaRestringiva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.permisivaRestringiva.TrueValue = "true";
            // 
            // AsignarPatentesAUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 591);
            this.Controls.Add(this.patentesDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.patentesAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarPatentesAUsuarios";
            this.Text = "Asignar patentes";
            this.Load += new System.EventHandler(this.AsignarPatentesAUsuarios_Load);
            this.Shown += new System.EventHandler(this.AsignarPatentesAUsuarios_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.patentesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patentesAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView patentesDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView patentesAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentesAsignadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn permisivaRestringiva;
    }
}