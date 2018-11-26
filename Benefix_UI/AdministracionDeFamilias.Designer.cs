namespace Genesis
{
    partial class AdministracionDeFamilias
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
            this.asignarPatentesButton = new System.Windows.Forms.Button();
            this.familiasDataGridView = new System.Windows.Forms.DataGridView();
            this.familias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.asignarUsuariosButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.familiasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // asignarPatentesButton
            // 
            this.asignarPatentesButton.Location = new System.Drawing.Point(319, 287);
            this.asignarPatentesButton.Name = "asignarPatentesButton";
            this.asignarPatentesButton.Size = new System.Drawing.Size(242, 38);
            this.asignarPatentesButton.TabIndex = 69;
            this.asignarPatentesButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignarPatentes;
            this.asignarPatentesButton.UseVisualStyleBackColor = true;
            this.asignarPatentesButton.Click += new System.EventHandler(this.asignarPatentesButton_Click);
            // 
            // familiasDataGridView
            // 
            this.familiasDataGridView.AllowUserToAddRows = false;
            this.familiasDataGridView.AllowUserToDeleteRows = false;
            this.familiasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.familiasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.familiasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.familias});
            this.familiasDataGridView.Location = new System.Drawing.Point(29, 40);
            this.familiasDataGridView.MultiSelect = false;
            this.familiasDataGridView.Name = "familiasDataGridView";
            this.familiasDataGridView.ReadOnly = true;
            this.familiasDataGridView.RowHeadersVisible = false;
            this.familiasDataGridView.RowTemplate.Height = 28;
            this.familiasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.familiasDataGridView.Size = new System.Drawing.Size(240, 551);
            this.familiasDataGridView.TabIndex = 62;
            this.familiasDataGridView.Click += new System.EventHandler(this.familiasDataGridView_CurrentCellChanged);
            // 
            // familias
            // 
            this.familias.DataPropertyName = "nombre";
            this.familias.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableFamilias;
            this.familias.Name = "familias";
            this.familias.ReadOnly = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(319, 553);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 68;
            this.eliminarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonEliminar;
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(319, 500);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 67;
            this.modificarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonModificar;
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(319, 447);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 66;
            this.crearButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonCrear;
            this.crearButton.UseVisualStyleBackColor = true;
            this.crearButton.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(319, 394);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 65;
            this.limpiarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonLimpiar;
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(319, 43);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 72;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(319, 69);
            this.nombreText.MaxLength = 20;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 71;
            // 
            // asignarUsuariosButton
            // 
            this.asignarUsuariosButton.Location = new System.Drawing.Point(319, 341);
            this.asignarUsuariosButton.Name = "asignarUsuariosButton";
            this.asignarUsuariosButton.Size = new System.Drawing.Size(242, 38);
            this.asignarUsuariosButton.TabIndex = 73;
            this.asignarUsuariosButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignarUsuarios;
            this.asignarUsuariosButton.UseVisualStyleBackColor = true;
            this.asignarUsuariosButton.Click += new System.EventHandler(this.asignarUsuariosButton_Click);
            // 
            // AdministracionDeFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 631);
            this.Controls.Add(this.asignarUsuariosButton);
            this.Controls.Add(this.asignarPatentesButton);
            this.Controls.Add(this.familiasDataGridView);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Name = "AdministracionDeFamilias";
            this.Text = "Administración de familias";
            this.Load += new System.EventHandler(this.AdministracionDeFamilias_Load);
            this.Shown += new System.EventHandler(this.AdministracionDeFamilias_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.familiasDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asignarPatentesButton;
        private System.Windows.Forms.DataGridView familiasDataGridView;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Button asignarUsuariosButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn familias;
    }
}