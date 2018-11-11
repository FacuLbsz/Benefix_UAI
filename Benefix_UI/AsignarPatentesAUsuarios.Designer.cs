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
            patentesDataGridView = new System.Windows.Forms.DataGridView();
            this.patentes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            patentesAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.patentesAsignadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permisivaRestringiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.desasignarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(patentesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(patentesAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // patentesDataGridView
            // 
            patentesDataGridView.AllowUserToAddRows = false;
            patentesDataGridView.AllowUserToDeleteRows = false;
            patentesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            patentesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            patentesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentes});
            patentesDataGridView.Location = new System.Drawing.Point(650, 20);
            patentesDataGridView.Name = "patentesDataGridView";
            patentesDataGridView.ReadOnly = true;
            patentesDataGridView.RowHeadersVisible = false;
            patentesDataGridView.RowTemplate.Height = 28;
            patentesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            patentesDataGridView.Size = new System.Drawing.Size(240, 551);
            patentesDataGridView.TabIndex = 55;
            // 
            // patentes
            // 
            this.patentes.DataPropertyName = "nombre";
            this.patentes.HeaderText = Genesis.Recursos_localizables.StringResources.TablePatentes;
            this.patentes.Name = "patentes";
            this.patentes.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(358, 532);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 54;
            this.guardarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(358, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 53;
            this.asignarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignar;
            this.asignarButton.UseVisualStyleBackColor = true;
            this.asignarButton.Click += new System.EventHandler(this.asignarButton_Click);
            // 
            // patentesAsignadosDataGridView
            // 
            patentesAsignadosDataGridView.AllowUserToAddRows = false;
            patentesAsignadosDataGridView.AllowUserToDeleteRows = false;
            patentesAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            patentesAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            patentesAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentesAsignadas,
            this.permisivaRestringiva});
            patentesAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            patentesAsignadosDataGridView.Name = "patentesAsignadosDataGridView";
            patentesAsignadosDataGridView.RowHeadersVisible = false;
            patentesAsignadosDataGridView.RowTemplate.Height = 28;
            patentesAsignadosDataGridView.Size = new System.Drawing.Size(291, 551);
            patentesAsignadosDataGridView.TabIndex = 51;
            patentesAsignadosDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.patentesAsignadosDataGridView_CellFormatting);
            patentesAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // patentesAsignadas
            // 
            this.patentesAsignadas.DataPropertyName = "patente.nombre";
            this.patentesAsignadas.FillWeight = 194.9239F;
            this.patentesAsignadas.HeaderText = Genesis.Recursos_localizables.StringResources.TablePatentesAsignadas;
            this.patentesAsignadas.Name = "patentesAsignadas";
            this.patentesAsignadas.ReadOnly = true;
            // 
            // permisivaRestringiva
            // 
            this.permisivaRestringiva.DataPropertyName = "esPermisivo";
            this.permisivaRestringiva.FalseValue = "false";
            this.permisivaRestringiva.FillWeight = 40F;
            this.permisivaRestringiva.HeaderText = Genesis.Recursos_localizables.StringResources.TablePatenteEstado;
            this.permisivaRestringiva.Name = "permisivaRestringiva";
            this.permisivaRestringiva.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.permisivaRestringiva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.permisivaRestringiva.TrueValue = "true";
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(358, 118);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 52;
            this.desasignarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonDesasignar;
            this.desasignarButton.UseVisualStyleBackColor = true;
            this.desasignarButton.Click += new System.EventHandler(this.desasignarButton_Click);
            // 
            // AsignarPatentesAUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 591);
            this.Controls.Add(patentesDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(patentesAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarPatentesAUsuarios";
            this.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignarPatentes;
            this.Load += new System.EventHandler(this.AsignarPatentesAUsuarios_Load);
            this.Shown += new System.EventHandler(this.AsignarPatentesAUsuarios_Shown);
            ((System.ComponentModel.ISupportInitialize)(patentesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(patentesAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentesAsignadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn permisivaRestringiva;
        private static System.Windows.Forms.DataGridView patentesDataGridView;
        private static System.Windows.Forms.DataGridView patentesAsignadosDataGridView;
    }
}