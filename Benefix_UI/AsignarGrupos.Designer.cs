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
            this.beneficiosDataGridView = new System.Windows.Forms.DataGridView();
            this.grupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guardarButton = new System.Windows.Forms.Button();
            this.asignarButton = new System.Windows.Forms.Button();
            this.beneficiosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.gruposAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desasignarButton = new System.Windows.Forms.Button();
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
            this.grupos});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(598, 20);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.beneficiosDataGridView.TabIndex = 50;
            // 
            // grupos
            // 
            this.grupos.HeaderText = "Grupos";
            this.grupos.Name = "grupos";
            this.grupos.ReadOnly = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(308, 533);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 49;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // asignarButton
            // 
            this.asignarButton.Location = new System.Drawing.Point(308, 66);
            this.asignarButton.Name = "asignarButton";
            this.asignarButton.Size = new System.Drawing.Size(242, 38);
            this.asignarButton.TabIndex = 48;
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
            this.gruposAsignados});
            this.beneficiosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.beneficiosAsignadosDataGridView.Name = "beneficiosAsignadosDataGridView";
            this.beneficiosAsignadosDataGridView.ReadOnly = true;
            this.beneficiosAsignadosDataGridView.RowTemplate.Height = 28;
            this.beneficiosAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.beneficiosAsignadosDataGridView.TabIndex = 46;
            // 
            // gruposAsignados
            // 
            this.gruposAsignados.HeaderText = "Grupos Asignados";
            this.gruposAsignados.Name = "gruposAsignados";
            this.gruposAsignados.ReadOnly = true;
            // 
            // desasignarButton
            // 
            this.desasignarButton.Location = new System.Drawing.Point(308, 119);
            this.desasignarButton.Name = "desasignarButton";
            this.desasignarButton.Size = new System.Drawing.Size(242, 38);
            this.desasignarButton.TabIndex = 47;
            this.desasignarButton.Text = "Desasignar >";
            this.desasignarButton.UseVisualStyleBackColor = true;
            // 
            // AsignarGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 591);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.asignarButton);
            this.Controls.Add(this.beneficiosAsignadosDataGridView);
            this.Controls.Add(this.desasignarButton);
            this.Name = "AsignarGrupos";
            this.Text = "Asignar grupos";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn grupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn gruposAsignados;
    }
}