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
            this.equiposDataGridView = new System.Windows.Forms.DataGridView();
            this.equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadosListView = new BrightIdeasSoftware.ObjectListView();
            this.empleado = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cumplimientoPorc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.consultarButton = new System.Windows.Forms.Button();
            this.periodoLabel = new System.Windows.Forms.Label();
            this.periodoBox = new System.Windows.Forms.ComboBox();
            this.exportarPdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.equiposDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosListView)).BeginInit();
            this.SuspendLayout();
            // 
            // equiposDataGridView
            // 
            this.equiposDataGridView.AllowUserToAddRows = false;
            this.equiposDataGridView.AllowUserToDeleteRows = false;
            this.equiposDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equiposDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equiposDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipos});
            this.equiposDataGridView.Location = new System.Drawing.Point(26, 24);
            this.equiposDataGridView.MultiSelect = false;
            this.equiposDataGridView.Name = "equiposDataGridView";
            this.equiposDataGridView.ReadOnly = true;
            this.equiposDataGridView.RowHeadersVisible = false;
            this.equiposDataGridView.RowTemplate.Height = 28;
            this.equiposDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equiposDataGridView.Size = new System.Drawing.Size(240, 551);
            this.equiposDataGridView.TabIndex = 51;
            // 
            // equipos
            // 
            this.equipos.DataPropertyName = "nombre";
            this.equipos.HeaderText = "Equipos";
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            // 
            // empleadosListView
            // 
            this.empleadosListView.AllColumns.Add(this.empleado);
            this.empleadosListView.AllColumns.Add(this.cumplimientoPorc);
            this.empleadosListView.CellEditUseWholeCell = false;
            this.empleadosListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.empleado,
            this.cumplimientoPorc});
            this.empleadosListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.empleadosListView.Location = new System.Drawing.Point(304, 108);
            this.empleadosListView.Name = "empleadosListView";
            this.empleadosListView.Size = new System.Drawing.Size(735, 411);
            this.empleadosListView.TabIndex = 55;
            this.empleadosListView.UseCompatibleStateImageBehavior = false;
            this.empleadosListView.View = System.Windows.Forms.View.Details;
            // 
            // empleado
            // 
            this.empleado.AspectName = "";
            this.empleado.Groupable = false;
            this.empleado.MaximumWidth = 390;
            this.empleado.Text = global::Genesis.Recursos_localizables.StringResources.TableEmpleado;
            this.empleado.Width = 390;
            // 
            // cumplimientoPorc
            // 
            this.cumplimientoPorc.AspectName = "";
            this.cumplimientoPorc.Groupable = false;
            this.cumplimientoPorc.MaximumWidth = 98;
            this.cumplimientoPorc.Text = global::Genesis.Recursos_localizables.StringResources.TablePorcentCumplimiento;
            this.cumplimientoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cumplimientoPorc.Width = 98;
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(727, 45);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(312, 38);
            this.consultarButton.TabIndex = 54;
            this.consultarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonConsultar;
            this.consultarButton.UseVisualStyleBackColor = true;
            this.consultarButton.Click += new System.EventHandler(this.consultarButton_Click);
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
            // exportarPdfButton
            // 
            this.exportarPdfButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.exportarPdfButton.Location = new System.Drawing.Point(727, 537);
            this.exportarPdfButton.Name = "exportarPdfButton";
            this.exportarPdfButton.Size = new System.Drawing.Size(312, 38);
            this.exportarPdfButton.TabIndex = 63;
            this.exportarPdfButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonExportar;
            this.exportarPdfButton.UseVisualStyleBackColor = true;
            this.exportarPdfButton.Click += new System.EventHandler(this.exportarPdfButton_Click);
            // 
            // ReportesDeObjetivosPorEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.exportarPdfButton);
            this.Controls.Add(this.equiposDataGridView);
            this.Controls.Add(this.empleadosListView);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.periodoLabel);
            this.Controls.Add(this.periodoBox);
            this.Name = "ReportesDeObjetivosPorEquipos";
            this.Text = "Objetivos por equipo";
            this.Load += new System.EventHandler(this.ReportesDeObjetivosPorEquipos_Load);
            this.Shown += new System.EventHandler(this.ReportesDeObjetivosPorEquipos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.equiposDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView equiposDataGridView;
        private BrightIdeasSoftware.ObjectListView empleadosListView;
        private BrightIdeasSoftware.OLVColumn empleado;
        private BrightIdeasSoftware.OLVColumn cumplimientoPorc;
        private System.Windows.Forms.Button consultarButton;
        private System.Windows.Forms.Label periodoLabel;
        private System.Windows.Forms.ComboBox periodoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipos;
        private System.Windows.Forms.Button exportarPdfButton;
    }
}