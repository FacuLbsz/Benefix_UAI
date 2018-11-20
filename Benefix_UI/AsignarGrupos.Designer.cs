namespace Genesis
{
    partial class AsignarGrupos
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
            this.gruposDataGridView = new System.Windows.Forms.DataGridView();
            this.grupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.gruposAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.gruposAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desasignarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gruposDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gruposAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gruposDataGridView
            // 
            this.gruposDataGridView.AllowUserToAddRows = false;
            this.gruposDataGridView.AllowUserToDeleteRows = false;
            this.gruposDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gruposDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gruposDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grupos});
            this.gruposDataGridView.Location = new System.Drawing.Point(598, 20);
            this.gruposDataGridView.MultiSelect = false;
            this.gruposDataGridView.Name = "gruposDataGridView";
            this.gruposDataGridView.ReadOnly = true;
            this.gruposDataGridView.RowHeadersVisible = false;
            this.gruposDataGridView.RowTemplate.Height = 28;
            this.gruposDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gruposDataGridView.Size = new System.Drawing.Size(240, 551);
            this.gruposDataGridView.TabIndex = 50;
            // 
            // grupos
            // 
            this.grupos.DataPropertyName = "nombre";
            this.grupos.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableGrupos;
            this.grupos.Name = "grupos";
            this.grupos.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(308, 533);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 49;
            this.guardarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(308, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 48;
            this.asignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignar;
            this.asignarButton.UseVisualStyleBackColor = true;
            this.asignarButton.Click += new System.EventHandler(this.asignarButton_Click);
            // 
            // gruposAsignadosDataGridView
            // 
            this.gruposAsignadosDataGridView.AllowUserToAddRows = false;
            this.gruposAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.gruposAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gruposAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gruposAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gruposAsignados});
            this.gruposAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.gruposAsignadosDataGridView.MultiSelect = false;
            this.gruposAsignadosDataGridView.Name = "gruposAsignadosDataGridView";
            this.gruposAsignadosDataGridView.ReadOnly = true;
            this.gruposAsignadosDataGridView.RowHeadersVisible = false;
            this.gruposAsignadosDataGridView.RowTemplate.Height = 28;
            this.gruposAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gruposAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.gruposAsignadosDataGridView.TabIndex = 46;
            // 
            // gruposAsignados
            // 
            this.gruposAsignados.DataPropertyName = "nombre";
            this.gruposAsignados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableGruposAsignados;
            this.gruposAsignados.Name = "gruposAsignados";
            this.gruposAsignados.ReadOnly = true;
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(308, 119);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 47;
            this.desasignarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonDesasignar;
            this.desasignarButton.UseVisualStyleBackColor = true;
            this.desasignarButton.Click += new System.EventHandler(this.desasignarButton_Click);
            // 
            // AsignarGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 591);
            this.Controls.Add(this.gruposDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.gruposAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarGrupos";
            this.Text = "Asignar grupos";
            this.Load += new System.EventHandler(this.AsignarGrupos_Load_1);
            this.Shown += new System.EventHandler(this.AsignarGruposAEquipos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gruposDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gruposAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gruposDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView gruposAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn gruposAsignados;
    }
}