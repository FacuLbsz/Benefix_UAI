namespace Genesis
{
    partial class MiEstado
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
            this.PuntajeBeneficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.equipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.puntaje = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cumplimiento = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.beneficios,
            this.PuntajeBeneficio});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(678, 24);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(361, 551);
            this.beneficiosDataGridView.TabIndex = 51;
            // 
            // beneficios
            // 
            this.beneficios.HeaderText = "Beneficios";
            this.beneficios.Name = "beneficios";
            this.beneficios.ReadOnly = true;
            // 
            // PuntajeBeneficio
            // 
            this.PuntajeBeneficio.FillWeight = 30F;
            this.PuntajeBeneficio.HeaderText = "Puntaje";
            this.PuntajeBeneficio.Name = "PuntajeBeneficio";
            this.PuntajeBeneficio.ReadOnly = true;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.equipo);
            this.objectListView1.AllColumns.Add(this.puntaje);
            this.objectListView1.AllColumns.Add(this.cumplimiento);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.equipo,
            this.puntaje,
            this.cumplimiento});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Location = new System.Drawing.Point(22, 24);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(621, 551);
            this.objectListView1.TabIndex = 55;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // equipo
            // 
            this.equipo.Text = "Equipo - Objetivo";
            this.equipo.Width = 389;
            // 
            // puntaje
            // 
            this.puntaje.Text = "Puntaje";
            this.puntaje.Width = 111;
            // 
            // cumplimiento
            // 
            this.cumplimiento.Text = "Cumplimiento";
            this.cumplimiento.Width = 116;
            // 
            // MiEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 599);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.objectListView1);
            this.Name = "MiEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mi Estado";
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn beneficios;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntajeBeneficio;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn equipo;
        private BrightIdeasSoftware.OLVColumn puntaje;
        private BrightIdeasSoftware.OLVColumn cumplimiento;
    }
}