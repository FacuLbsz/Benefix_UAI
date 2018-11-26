namespace Genesis
{
    partial class ReportesDeObjetivosPorEmpleado
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
            this.empleadosDataGridView = new System.Windows.Forms.DataGridView();
            this.empleados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodoLabel = new System.Windows.Forms.Label();
            this.periodoBox = new System.Windows.Forms.ComboBox();
            this.consultarButton = new System.Windows.Forms.Button();
            this.evaluacionesListView = new BrightIdeasSoftware.ObjectListView();
            this.equipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cumplimiento = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.exportarPdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesListView)).BeginInit();
            this.SuspendLayout();
            // 
            // empleadosDataGridView
            // 
            this.empleadosDataGridView.AllowUserToAddRows = false;
            this.empleadosDataGridView.AllowUserToDeleteRows = false;
            this.empleadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empleadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empleadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleados});
            this.empleadosDataGridView.Location = new System.Drawing.Point(24, 23);
            this.empleadosDataGridView.MultiSelect = false;
            this.empleadosDataGridView.Name = "empleadosDataGridView";
            this.empleadosDataGridView.ReadOnly = true;
            this.empleadosDataGridView.RowHeadersVisible = false;
            this.empleadosDataGridView.RowTemplate.Height = 28;
            this.empleadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empleadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.empleadosDataGridView.TabIndex = 46;
            // 
            // empleados
            // 
            this.empleados.DataPropertyName = "nombreUsuario";
            this.empleados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.empleados.Name = "empleados";
            this.empleados.ReadOnly = true;
            // 
            // periodoLabel
            // 
            this.periodoLabel.AutoSize = true;
            this.periodoLabel.Location = new System.Drawing.Point(298, 27);
            this.periodoLabel.Name = "periodoLabel";
            this.periodoLabel.Size = new System.Drawing.Size(63, 20);
            this.periodoLabel.TabIndex = 48;
            this.periodoLabel.Text = "Periodo";
            // 
            // periodoBox
            // 
            this.periodoBox.FormattingEnabled = true;
            this.periodoBox.Location = new System.Drawing.Point(302, 50);
            this.periodoBox.Name = "periodoBox";
            this.periodoBox.Size = new System.Drawing.Size(390, 28);
            this.periodoBox.TabIndex = 47;
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(725, 44);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(312, 38);
            this.consultarButton.TabIndex = 49;
            this.consultarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonConsultar;
            this.consultarButton.UseVisualStyleBackColor = true;
            this.consultarButton.Click += new System.EventHandler(this.consultarButton_Click);
            // 
            // evaluacionesListView
            // 
            this.evaluacionesListView.AllColumns.Add(this.equipo);
            this.evaluacionesListView.AllColumns.Add(this.cumplimiento);
            this.evaluacionesListView.CellEditUseWholeCell = false;
            this.evaluacionesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.equipo,
            this.cumplimiento});
            this.evaluacionesListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.evaluacionesListView.Location = new System.Drawing.Point(302, 107);
            this.evaluacionesListView.Name = "evaluacionesListView";
            this.evaluacionesListView.Size = new System.Drawing.Size(735, 408);
            this.evaluacionesListView.TabIndex = 50;
            this.evaluacionesListView.UseCompatibleStateImageBehavior = false;
            this.evaluacionesListView.View = System.Windows.Forms.View.Details;
            this.evaluacionesListView.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // equipo
            // 
            this.equipo.AspectName = "equipoObjetvo.objetivo.nombre";
            this.equipo.MaximumWidth = 390;
            this.equipo.MinimumWidth = 1;
            this.equipo.Text = global::Genesis.Recursos_localizables.StringResources.TableEquipoObjetivo;
            this.equipo.Width = 390;
            // 
            // cumplimiento
            // 
            this.cumplimiento.AspectName = "alcanzado";
            this.cumplimiento.CheckBoxes = true;
            this.cumplimiento.Groupable = false;
            this.cumplimiento.IsEditable = false;
            this.cumplimiento.MaximumWidth = 100;
            this.cumplimiento.MinimumWidth = 1;
            this.cumplimiento.Text = global::Genesis.Recursos_localizables.StringResources.TableCumplimiento;
            this.cumplimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cumplimiento.Width = 100;
            // 
            // exportarPdfButton
            // 
            this.exportarPdfButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.exportarPdfButton.Location = new System.Drawing.Point(725, 536);
            this.exportarPdfButton.Name = "exportarPdfButton";
            this.exportarPdfButton.Size = new System.Drawing.Size(312, 38);
            this.exportarPdfButton.TabIndex = 62;
            this.exportarPdfButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonExportar;
            this.exportarPdfButton.UseVisualStyleBackColor = true;
            this.exportarPdfButton.Click += new System.EventHandler(this.exportarPdfButton_Click);
            // 
            // ReportesDeObjetivosPorEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.exportarPdfButton);
            this.Controls.Add(this.evaluacionesListView);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.periodoLabel);
            this.Controls.Add(this.periodoBox);
            this.Controls.Add(this.empleadosDataGridView);
            this.Name = "ReportesDeObjetivosPorEmpleado";
            this.Text = "Objetivos por empleado";
            this.Load += new System.EventHandler(this.ReportesDeObjetivosPorEmpleado_Load);
            this.Shown += new System.EventHandler(this.ReportesDeObjetivosPorEmpleado_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView empleadosDataGridView;
        private System.Windows.Forms.Label periodoLabel;
        private System.Windows.Forms.ComboBox periodoBox;
        private System.Windows.Forms.Button consultarButton;
        private BrightIdeasSoftware.ObjectListView evaluacionesListView;
        private BrightIdeasSoftware.OLVColumn equipo;
        private BrightIdeasSoftware.OLVColumn cumplimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleados;
        private System.Windows.Forms.Button exportarPdfButton;
    }
}