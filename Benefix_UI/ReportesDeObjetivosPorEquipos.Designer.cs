namespace Genesis
{
    partial class ReportesDeObjetivosPorEquipos
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
            this.equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.empleado = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cumplimientoPorc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.consultarButton = new System.Windows.Forms.Button();
            this.periodoLabel = new System.Windows.Forms.Label();
            this.periodoBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosDataGridView
            // 
            this.beneficiosDataGridView.AllowUserToAddRows = false;
            this.beneficiosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipos});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(26, 24);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.beneficiosDataGridView.TabIndex = 51;
            // 
            // equipos
            // 
            this.equipos.HeaderText = "Equipos";
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.empleado);
            this.objectListView1.AllColumns.Add(this.cumplimientoPorc);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.empleado,
            this.cumplimientoPorc});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Location = new System.Drawing.Point(304, 108);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(735, 467);
            this.objectListView1.TabIndex = 55;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // empleado
            // 
            this.empleado.Text = "Empleado";
            this.empleado.Width = 597;
            // 
            // cumplimientoPorc
            // 
            this.cumplimientoPorc.Text = "% Cumplimiento";
            this.cumplimientoPorc.Width = 135;
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(727, 45);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(312, 38);
            this.consultarButton.TabIndex = 54;
            this.consultarButton.Text = "Consultar";
            this.consultarButton.UseVisualStyleBackColor = true;
            // 
            // periodoLabel
            // 
            this.periodoLabel.AutoSize = true;
            this.periodoLabel.Location = new System.Drawing.Point(300, 28);
            this.periodoLabel.Name = "periodoLabel";
            this.periodoLabel.Size = new System.Drawing.Size(63, 20);
            this.periodoLabel.TabIndex = 53;
            this.periodoLabel.Text = "Periodo";
            // 
            // periodoBox
            // 
            this.periodoBox.FormattingEnabled = true;
            this.periodoBox.Location = new System.Drawing.Point(304, 51);
            this.periodoBox.Name = "periodoBox";
            this.periodoBox.Size = new System.Drawing.Size(390, 28);
            this.periodoBox.TabIndex = 52;
            // 
            // ReportesDeObjetivosPorEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.periodoLabel);
            this.Controls.Add(this.periodoBox);
            this.Name = "ReportesDeObjetivosPorEquipos";
            this.Text = "Reportes de objetivos por equipos";
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn empleado;
        private BrightIdeasSoftware.OLVColumn cumplimientoPorc;
        private System.Windows.Forms.Button consultarButton;
        private System.Windows.Forms.Label periodoLabel;
        private System.Windows.Forms.ComboBox periodoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipos;
    }
}