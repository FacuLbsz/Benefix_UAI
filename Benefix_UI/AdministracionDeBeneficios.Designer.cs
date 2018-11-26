namespace Genesis
{
    partial class AdministracionDeBeneficios
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
            this.beneficios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.puntajeLabel = new System.Windows.Forms.Label();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.descripcionText = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.puntajeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntajeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosDataGridView
            // 
            this.beneficiosDataGridView.AllowUserToAddRows = false;
            this.beneficiosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.beneficios});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(27, 28);
            this.beneficiosDataGridView.MultiSelect = false;
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowHeadersVisible = false;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(240, 576);
            this.beneficiosDataGridView.TabIndex = 13;
            this.beneficiosDataGridView.Click += new System.EventHandler(this.beneficiosDataGridView_CurrentCellChanged);
            // 
            // beneficios
            // 
            this.beneficios.DataPropertyName = "nombre";
            this.beneficios.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableBeneficios;
            this.beneficios.Name = "beneficios";
            this.beneficios.ReadOnly = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(317, 491);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 23;
            this.eliminarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonEliminar;
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(317, 438);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 22;
            this.modificarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonModificar;
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(317, 385);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 21;
            this.crearButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonCrear;
            this.crearButton.UseVisualStyleBackColor = true;
            this.crearButton.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(317, 332);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 20;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // puntajeLabel
            // 
            this.puntajeLabel.AutoSize = true;
            this.puntajeLabel.Location = new System.Drawing.Point(317, 264);
            this.puntajeLabel.Name = "puntajeLabel";
            this.puntajeLabel.Size = new System.Drawing.Size(63, 20);
            this.puntajeLabel.TabIndex = 19;
            this.puntajeLabel.Text = "Puntaje";
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Location = new System.Drawing.Point(317, 88);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(92, 20);
            this.descripcionLabel.TabIndex = 17;
            this.descripcionLabel.Text = "Descripción";
            // 
            // descripcionText
            // 
            this.descripcionText.Location = new System.Drawing.Point(317, 114);
            this.descripcionText.MaxLength = 60;
            this.descripcionText.Multiline = true;
            this.descripcionText.Name = "descripcionText";
            this.descripcionText.Size = new System.Drawing.Size(242, 140);
            this.descripcionText.TabIndex = 16;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(317, 28);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 15;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(317, 54);
            this.nombreText.MaxLength = 26;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 14;
            // 
            // puntajeUpDown
            // 
            this.puntajeUpDown.Location = new System.Drawing.Point(321, 287);
            this.puntajeUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.puntajeUpDown.Name = "puntajeUpDown";
            this.puntajeUpDown.Size = new System.Drawing.Size(238, 26);
            this.puntajeUpDown.TabIndex = 24;
            // 
            // AdministracionDeBeneficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 631);
            this.Controls.Add(this.puntajeUpDown);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.puntajeLabel);
            this.Controls.Add(this.descripcionLabel);
            this.Controls.Add(this.descripcionText);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Name = "AdministracionDeBeneficios";
            this.Text = "Administración de beneficios";
            this.Load += new System.EventHandler(this.AdministracionDeBeneficios_Load);
            this.Shown += new System.EventHandler(this.AdministracionDeBeneficios_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntajeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label puntajeLabel;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.TextBox descripcionText;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.NumericUpDown puntajeUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn beneficios;
    }
}