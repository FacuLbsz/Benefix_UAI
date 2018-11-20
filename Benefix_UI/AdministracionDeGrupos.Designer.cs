namespace Genesis
{
    partial class AdministracionDeGrupos
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
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.asignarBeneficiosButton = new System.Windows.Forms.Button();
            this.grupos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gruposDataGridView)).BeginInit();
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
            this.gruposDataGridView.Location = new System.Drawing.Point(26, 26);
            this.gruposDataGridView.MultiSelect = false;
            this.gruposDataGridView.Name = "gruposDataGridView";
            this.gruposDataGridView.ReadOnly = true;
            this.gruposDataGridView.RowHeadersVisible = false;
            this.gruposDataGridView.RowTemplate.Height = 28;
            this.gruposDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gruposDataGridView.Size = new System.Drawing.Size(240, 551);
            this.gruposDataGridView.TabIndex = 24;
            this.gruposDataGridView.Click += new System.EventHandler(this.gruposDataGridView_CurrentCellChanged);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(316, 539);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 34;
            this.eliminarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonEliminar;
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(316, 486);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 33;
            this.modificarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonModificar;
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(316, 433);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 32;
            this.crearButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonCrear;
            this.crearButton.UseVisualStyleBackColor = true;
            this.crearButton.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(316, 380);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 31;
            this.limpiarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonLimpiar;
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(316, 26);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 26;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(316, 52);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 25;
            // 
            // asignarBeneficiosButton
            // 
            this.asignarBeneficiosButton.Location = new System.Drawing.Point(316, 327);
            this.asignarBeneficiosButton.Name = "asignarBeneficiosButton";
            this.asignarBeneficiosButton.Size = new System.Drawing.Size(242, 38);
            this.asignarBeneficiosButton.TabIndex = 35;
            this.asignarBeneficiosButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAsignarBeneficios;
            this.asignarBeneficiosButton.UseVisualStyleBackColor = true;
            this.asignarBeneficiosButton.Click += new System.EventHandler(this.asignarBeneficiosButton_Click);
            // 
            // grupos
            // 
            this.grupos.DataPropertyName = "nombre";
            this.grupos.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableGrupos;
            this.grupos.Name = "grupos";
            this.grupos.ReadOnly = true;
            // 
            // AdministracionDeGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 604);
            this.Controls.Add(this.asignarBeneficiosButton);
            this.Controls.Add(this.gruposDataGridView);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Name = "AdministracionDeGrupos";
            this.Text = "Administración de grupos";
            this.Load += new System.EventHandler(this.AdministracionDeGrupos_Load);
            this.Shown += new System.EventHandler(this.AdministracionDeGrupos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gruposDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gruposDataGridView;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Button asignarBeneficiosButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupos;
    }
}