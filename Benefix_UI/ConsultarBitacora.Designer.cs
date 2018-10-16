namespace Genesis
{
    partial class ConsultarBitacora
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
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criticidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultarButton = new System.Windows.Forms.Button();
            this.fechaHastaLabel = new System.Windows.Forms.Label();
            this.fechaDesdeDate = new System.Windows.Forms.DateTimePicker();
            this.fechaDesdeLabel = new System.Windows.Forms.Label();
            this.fechaHastaDate = new System.Windows.Forms.DateTimePicker();
            this.criticidadLabel = new System.Windows.Forms.Label();
            this.criticidadBox = new System.Windows.Forms.ComboBox();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.usuarioBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosDataGridView
            // 
            this.beneficiosDataGridView.AllowUserToAddRows = false;
            this.beneficiosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuario,
            this.fecha,
            this.funcionalidad,
            this.descripcion,
            this.criticidad});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(26, 85);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(1013, 477);
            this.beneficiosDataGridView.TabIndex = 55;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario en sesion";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // funcionalidad
            // 
            this.funcionalidad.HeaderText = "Funcionalidad";
            this.funcionalidad.Name = "funcionalidad";
            this.funcionalidad.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // criticidad
            // 
            this.criticidad.HeaderText = "Criticidad";
            this.criticidad.Name = "criticidad";
            this.criticidad.ReadOnly = true;
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(727, 32);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(312, 38);
            this.consultarButton.TabIndex = 58;
            this.consultarButton.Text = "Consultar";
            this.consultarButton.UseVisualStyleBackColor = true;
            this.consultarButton.Click += new System.EventHandler(this.consultarButton_Click);
            // 
            // fechaHastaLabel
            // 
            this.fechaHastaLabel.AutoSize = true;
            this.fechaHastaLabel.Location = new System.Drawing.Point(186, 22);
            this.fechaHastaLabel.Name = "fechaHastaLabel";
            this.fechaHastaLabel.Size = new System.Drawing.Size(98, 20);
            this.fechaHastaLabel.TabIndex = 57;
            this.fechaHastaLabel.Text = "Fecha hasta";
            // 
            // fechaDesdeDate
            // 
            this.fechaDesdeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaDesdeDate.Location = new System.Drawing.Point(26, 44);
            this.fechaDesdeDate.Name = "fechaDesdeDate";
            this.fechaDesdeDate.Size = new System.Drawing.Size(140, 26);
            this.fechaDesdeDate.TabIndex = 59;
            // 
            // fechaDesdeLabel
            // 
            this.fechaDesdeLabel.AutoSize = true;
            this.fechaDesdeLabel.Location = new System.Drawing.Point(22, 21);
            this.fechaDesdeLabel.Name = "fechaDesdeLabel";
            this.fechaDesdeLabel.Size = new System.Drawing.Size(102, 20);
            this.fechaDesdeLabel.TabIndex = 60;
            this.fechaDesdeLabel.Text = "Fecha desde";
            // 
            // fechaHastaDate
            // 
            this.fechaHastaDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaHastaDate.Location = new System.Drawing.Point(190, 44);
            this.fechaHastaDate.Name = "fechaHastaDate";
            this.fechaHastaDate.Size = new System.Drawing.Size(140, 26);
            this.fechaHastaDate.TabIndex = 61;
            // 
            // criticidadLabel
            // 
            this.criticidadLabel.AutoSize = true;
            this.criticidadLabel.Location = new System.Drawing.Point(346, 21);
            this.criticidadLabel.Name = "criticidadLabel";
            this.criticidadLabel.Size = new System.Drawing.Size(74, 20);
            this.criticidadLabel.TabIndex = 63;
            this.criticidadLabel.Text = "Criticidad";
            // 
            // criticidadBox
            // 
            this.criticidadBox.FormattingEnabled = true;
            this.criticidadBox.Location = new System.Drawing.Point(350, 43);
            this.criticidadBox.Name = "criticidadBox";
            this.criticidadBox.Size = new System.Drawing.Size(169, 28);
            this.criticidadBox.TabIndex = 62;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.Location = new System.Drawing.Point(537, 21);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(64, 20);
            this.usuarioLabel.TabIndex = 65;
            this.usuarioLabel.Text = "Usuario";
            // 
            // usuarioBox
            // 
            this.usuarioBox.FormattingEnabled = true;
            this.usuarioBox.Location = new System.Drawing.Point(541, 43);
            this.usuarioBox.Name = "usuarioBox";
            this.usuarioBox.Size = new System.Drawing.Size(169, 28);
            this.usuarioBox.TabIndex = 64;
            // 
            // ConsultarBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 589);
            this.Controls.Add(this.usuarioLabel);
            this.Controls.Add(this.usuarioBox);
            this.Controls.Add(this.criticidadLabel);
            this.Controls.Add(this.criticidadBox);
            this.Controls.Add(this.fechaHastaDate);
            this.Controls.Add(this.fechaDesdeLabel);
            this.Controls.Add(this.fechaDesdeDate);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.fechaHastaLabel);
            this.Name = "ConsultarBitacora";
            this.Text = "ConsultarBitacora";
            this.Load += new System.EventHandler(this.ConsultarBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private System.Windows.Forms.Button consultarButton;
        private System.Windows.Forms.Label fechaHastaLabel;
        private System.Windows.Forms.DateTimePicker fechaDesdeDate;
        private System.Windows.Forms.Label fechaDesdeLabel;
        private System.Windows.Forms.DateTimePicker fechaHastaDate;
        private System.Windows.Forms.Label criticidadLabel;
        private System.Windows.Forms.ComboBox criticidadBox;
        private System.Windows.Forms.Label usuarioLabel;
        private System.Windows.Forms.ComboBox usuarioBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn criticidad;
    }
}