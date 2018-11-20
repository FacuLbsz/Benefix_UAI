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
            this.patentesAsignadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esPermisivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.desasignarButton = new System.Windows.Forms.Button();
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
            this.patentesDataGridView.Location = new System.Drawing.Point(650, 20);
            this.patentesDataGridView.Name = "patentesDataGridView";
            this.patentesDataGridView.ReadOnly = true;
            this.patentesDataGridView.RowHeadersVisible = false;
            this.patentesDataGridView.RowTemplate.Height = 28;
            this.patentesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patentesDataGridView.Size = new System.Drawing.Size(240, 551);
            this.patentesDataGridView.TabIndex = 55;
            // 
            // patentes
            // 
            this.patentes.DataPropertyName = "nombre";
            this.patentes.HeaderText = global::Genesis.Recursos_localizables.StringResources.TablePatentes;
            this.patentes.Name = "patentes";
            this.patentes.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(358, 532);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 54;
            this.guardarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(358, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 53;
            this.asignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignar;
            this.asignarButton.UseVisualStyleBackColor = true;
            this.asignarButton.Click += new System.EventHandler(this.asignarButton_Click);
            // 
            // patentesAsignadosDataGridView
            // 
            this.patentesAsignadosDataGridView.AllowUserToAddRows = false;
            this.patentesAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.patentesAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.patentesAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patentesAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patentesAsignadas,
            this.esPermisivo});
            this.patentesAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.patentesAsignadosDataGridView.Name = "patentesAsignadosDataGridView";
            this.patentesAsignadosDataGridView.RowHeadersVisible = false;
            this.patentesAsignadosDataGridView.RowTemplate.Height = 28;
            this.patentesAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patentesAsignadosDataGridView.Size = new System.Drawing.Size(291, 551);
            this.patentesAsignadosDataGridView.TabIndex = 51;
            this.patentesAsignadosDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.patentesAsignadosDataGridView_CellFormatting);
            // 
            // patentesAsignadas
            // 
            this.patentesAsignadas.DataPropertyName = "patente.nombre";
            this.patentesAsignadas.FillWeight = 194.9239F;
            this.patentesAsignadas.HeaderText = global::Genesis.Recursos_localizables.StringResources.TablePatentesAsignadas;
            this.patentesAsignadas.Name = "patentesAsignadas";
            this.patentesAsignadas.ReadOnly = true;
            // 
            // esPermisivo
            // 
            this.esPermisivo.DataPropertyName = "esPermisivo";
            this.esPermisivo.FalseValue = "false";
            this.esPermisivo.FillWeight = 40F;
            this.esPermisivo.HeaderText = global::Genesis.Recursos_localizables.StringResources.TablePatenteEstado;
            this.esPermisivo.Name = "esPermisivo";
            this.esPermisivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.esPermisivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.esPermisivo.TrueValue = "true";
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(358, 118);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 52;
            this.desasignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonDesasignar;
            this.desasignarButton.UseVisualStyleBackColor = true;
            this.desasignarButton.Click += new System.EventHandler(this.desasignarButton_Click);
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
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn patentesAsignadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn esPermisivo;
        private System.Windows.Forms.DataGridView patentesDataGridView;
        private System.Windows.Forms.DataGridView patentesAsignadosDataGridView;
    }
}