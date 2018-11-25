namespace Genesis
{
    partial class ReportesDeBeneficiosPorEmpleado
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
            this.beneficiosListView = new BrightIdeasSoftware.ObjectListView();
            this.beneficio = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.otorgado = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.consultarButton = new System.Windows.Forms.Button();
            this.periodoLabel = new System.Windows.Forms.Label();
            this.periodoBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosListView)).BeginInit();
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
            this.empleadosDataGridView.Location = new System.Drawing.Point(26, 24);
            this.empleadosDataGridView.MultiSelect = false;
            this.empleadosDataGridView.Name = "empleadosDataGridView";
            this.empleadosDataGridView.ReadOnly = true;
            this.empleadosDataGridView.RowHeadersVisible = false;
            this.empleadosDataGridView.RowTemplate.Height = 28;
            this.empleadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empleadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.empleadosDataGridView.TabIndex = 56;
            // 
            // empleados
            // 
            this.empleados.DataPropertyName = "nombre";
            this.empleados.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.empleados.Name = "empleados";
            this.empleados.ReadOnly = true;
            // 
            // beneficiosListView
            // 
            this.beneficiosListView.AllColumns.Add(this.beneficio);
            this.beneficiosListView.AllColumns.Add(this.otorgado);
            this.beneficiosListView.CellEditUseWholeCell = false;
            this.beneficiosListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.beneficio,
            this.otorgado});
            this.beneficiosListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.beneficiosListView.Location = new System.Drawing.Point(304, 108);
            this.beneficiosListView.Name = "beneficiosListView";
            this.beneficiosListView.Size = new System.Drawing.Size(735, 467);
            this.beneficiosListView.TabIndex = 60;
            this.beneficiosListView.UseCompatibleStateImageBehavior = false;
            this.beneficiosListView.View = System.Windows.Forms.View.Details;
            // 
            // beneficio
            // 
            this.beneficio.Groupable = false;
            this.beneficio.MaximumWidth = 390;
            this.beneficio.Text = global::Genesis.Recursos_localizables.StringResources.TableBeneficios;
            this.beneficio.Width = 390;
            // 
            // otorgado
            // 
            this.otorgado.CheckBoxes = true;
            this.otorgado.Groupable = false;
            this.otorgado.MaximumWidth = 98;
            this.otorgado.Text = global::Genesis.Recursos_localizables.StringResources.TableOtorgado;
            this.otorgado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.otorgado.Width = 98;
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(727, 45);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(312, 38);
            this.consultarButton.TabIndex = 59;
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
            this.periodoLabel.TabIndex = 58;
            this.periodoLabel.Text = "Periodo";
            // 
            // periodoBox
            // 
            this.periodoBox.FormattingEnabled = true;
            this.periodoBox.Location = new System.Drawing.Point(304, 51);
            this.periodoBox.Name = "periodoBox";
            this.periodoBox.Size = new System.Drawing.Size(390, 28);
            this.periodoBox.TabIndex = 57;
            this.periodoBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ReportesDeBeneficiosPorEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.empleadosDataGridView);
            this.Controls.Add(this.beneficiosListView);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.periodoLabel);
            this.Controls.Add(this.periodoBox);
            this.Name = "ReportesDeBeneficiosPorEmpleado";
            this.Text = "Beneficio por empleado";
            this.Load += new System.EventHandler(this.ReportesDeBeneficiosPorEmpleado_Load);
            this.Shown += new System.EventHandler(this.ReportesDeBeneficiosPorEmpleado_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.empleadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView empleadosDataGridView;
        private BrightIdeasSoftware.ObjectListView beneficiosListView;
        private BrightIdeasSoftware.OLVColumn beneficio;
        private BrightIdeasSoftware.OLVColumn otorgado;
        private System.Windows.Forms.Button consultarButton;
        private System.Windows.Forms.Label periodoLabel;
        private System.Windows.Forms.ComboBox periodoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleados;
    }
}