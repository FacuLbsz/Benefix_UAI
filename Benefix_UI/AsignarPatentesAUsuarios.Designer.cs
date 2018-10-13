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
            this.beneficiosDataGridView = new System.Windows.Forms.DataGridView();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.beneficiosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.desasignarButton = new System.Windows.Forms.Button();
            this.patentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patentesAsignadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permisivaRestringiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosDataGridView
            // 
            this.beneficiosDataGridView.AllowUserToAddRows = false;
            this.beneficiosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentes});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(649, 20);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.beneficiosDataGridView.TabIndex = 55;
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
            // beneficiosAsignadosDataGridView
            // 
            this.beneficiosAsignadosDataGridView.AllowUserToAddRows = false;
            this.beneficiosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentesAsignadas,
            this.permisivaRestringiva});
            this.beneficiosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.beneficiosAsignadosDataGridView.Name = "beneficiosAsignadosDataGridView";
            this.beneficiosAsignadosDataGridView.ReadOnly = true;
            this.beneficiosAsignadosDataGridView.RowTemplate.Height = 28;
            this.beneficiosAsignadosDataGridView.Size = new System.Drawing.Size(291, 551);
            this.beneficiosAsignadosDataGridView.TabIndex = 51;
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
            // patentes
            // 
            this.patentes.HeaderText = "Patentes";
            this.patentes.Name = "patentes";
            this.patentes.ReadOnly = true;
            // 
            // patentesAsignadas
            // 
            this.patentesAsignadas.FillWeight = 194.9239F;
            this.patentesAsignadas.HeaderText = "Patentes Asignadas";
            this.patentesAsignadas.Name = "patentesAsignadas";
            this.patentesAsignadas.ReadOnly = true;
            // 
            // permisivaRestringiva
            // 
            this.permisivaRestringiva.FillWeight = 40F;
            this.permisivaRestringiva.HeaderText = "P/R";
            this.permisivaRestringiva.Name = "permisivaRestringiva";
            this.permisivaRestringiva.ReadOnly = true;
            // 
            // AsignarPatentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 591);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.beneficiosAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarPatentes";
            this.Text = "Asignar patentes";
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView beneficiosAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentesAsignadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn permisivaRestringiva;
    }
}