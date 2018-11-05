namespace Genesis
{
    partial class AsignarUsuarios
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
            this.usuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.usuariosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.desasignarButton = new System.Windows.Forms.Button();
            this.usuarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariosAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usuariosDataGridView
            // 
            this.usuariosDataGridView.AllowUserToAddRows = false;
            this.usuariosDataGridView.AllowUserToDeleteRows = false;
            this.usuariosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarios});
            this.usuariosDataGridView.Location = new System.Drawing.Point(598, 20);
            this.usuariosDataGridView.Name = "usuariosDataGridView";
            this.usuariosDataGridView.ReadOnly = true;
            this.usuariosDataGridView.RowHeadersVisible = false;
            this.usuariosDataGridView.RowTemplate.Height = 28;
            this.usuariosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usuariosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.usuariosDataGridView.TabIndex = 50;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(308, 532);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 49;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(308, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 48;
            this.asignarButton.Text = "< Asignar";
            this.asignarButton.UseVisualStyleBackColor = true;
            this.asignarButton.Click += new System.EventHandler(this.asignarButton_Click);
            // 
            // usuariosAsignadosDataGridView
            // 
            this.usuariosAsignadosDataGridView.AllowUserToAddRows = false;
            this.usuariosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.usuariosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usuariosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuariosAsignados});
            this.usuariosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.usuariosAsignadosDataGridView.Name = "usuariosAsignadosDataGridView";
            this.usuariosAsignadosDataGridView.ReadOnly = true;
            this.usuariosAsignadosDataGridView.RowHeadersVisible = false;
            this.usuariosAsignadosDataGridView.RowTemplate.Height = 28;
            this.usuariosAsignadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usuariosAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.usuariosAsignadosDataGridView.TabIndex = 46;
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(308, 118);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 47;
            this.desasignarButton.Text = "Desasignar >";
            this.desasignarButton.UseVisualStyleBackColor = true;
            this.desasignarButton.Click += new System.EventHandler(this.desasignarButton_Click);
            // 
            // usuarios
            // 
            this.usuarios.DataPropertyName = "nombreUsuario";
            this.usuarios.HeaderText = "Usuarios";
            this.usuarios.Name = "usuarios";
            this.usuarios.ReadOnly = true;
            // 
            // usuariosAsignados
            // 
            this.usuariosAsignados.DataPropertyName = "nombreUsuario";
            this.usuariosAsignados.HeaderText = "Usuarios Asignados";
            this.usuariosAsignados.Name = "usuariosAsignados";
            this.usuariosAsignados.ReadOnly = true;
            // 
            // AsignarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 591);
            this.Controls.Add(this.usuariosDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.usuariosAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarUsuarios";
            this.Text = "AsignarUsuarios";
            this.Load += new System.EventHandler(this.AsignarUsuarios_Load);
            this.Shown += new System.EventHandler(this.AsignarUsuarios_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView usuariosDataGridView;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button asignarButton;
        private System.Windows.Forms.DataGridView usuariosAsignadosDataGridView;
        private System.Windows.Forms.Button desasignarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariosAsignados;
    }
}