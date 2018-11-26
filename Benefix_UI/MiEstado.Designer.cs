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
            this.evaluacionesListView = new BrightIdeasSoftware.ObjectListView();
            this.equipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.puntaje = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cumplimiento = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.beneficiosListView = new BrightIdeasSoftware.ObjectListView();
            this.beneficioss = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.puntajee = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.exportarPdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosListView)).BeginInit();
            this.SuspendLayout();
            // 
            // evaluacionesListView
            // 
            this.evaluacionesListView.AllColumns.Add(this.equipo);
            this.evaluacionesListView.AllColumns.Add(this.puntaje);
            this.evaluacionesListView.AllColumns.Add(this.cumplimiento);
            this.evaluacionesListView.CellEditUseWholeCell = false;
            this.evaluacionesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.equipo,
            this.puntaje,
            this.cumplimiento});
            this.evaluacionesListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.evaluacionesListView.Location = new System.Drawing.Point(22, 24);
            this.evaluacionesListView.MaximumSize = new System.Drawing.Size(621, 551);
            this.evaluacionesListView.MinimumSize = new System.Drawing.Size(621, 551);
            this.evaluacionesListView.Name = "evaluacionesListView";
            this.evaluacionesListView.Size = new System.Drawing.Size(621, 551);
            this.evaluacionesListView.TabIndex = 55;
            this.evaluacionesListView.UseCompatibleStateImageBehavior = false;
            this.evaluacionesListView.View = System.Windows.Forms.View.Details;
            // 
            // equipo
            // 
            this.equipo.AspectName = "equipoObjetvo.objetivo.nombre";
            this.equipo.AspectToStringFormat = "";
            this.equipo.MaximumWidth = 200;
            this.equipo.MinimumWidth = 1;
            this.equipo.Text = global::Genesis.Recursos_localizables.StringResources.TableEquipoObjetivo;
            this.equipo.Width = 200;
            // 
            // puntaje
            // 
            this.puntaje.AspectName = "puntaje";
            this.puntaje.MaximumWidth = 100;
            this.puntaje.MinimumWidth = 100;
            this.puntaje.Sortable = false;
            this.puntaje.Text = global::Genesis.Recursos_localizables.StringResources.TablePuntaje;
            this.puntaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.puntaje.Width = 100;
            // 
            // cumplimiento
            // 
            this.cumplimiento.AspectName = "alcanzado";
            this.cumplimiento.CheckBoxes = true;
            this.cumplimiento.MaximumWidth = 100;
            this.cumplimiento.MinimumWidth = 1;
            this.cumplimiento.Sortable = false;
            this.cumplimiento.Text = global::Genesis.Recursos_localizables.StringResources.TableCumplimiento;
            this.cumplimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cumplimiento.Width = 100;
            // 
            // beneficiosListView
            // 
            this.beneficiosListView.AllColumns.Add(this.beneficioss);
            this.beneficiosListView.AllColumns.Add(this.puntajee);
            this.beneficiosListView.CellEditUseWholeCell = false;
            this.beneficiosListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.beneficioss,
            this.puntajee});
            this.beneficiosListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.beneficiosListView.Location = new System.Drawing.Point(678, 24);
            this.beneficiosListView.Name = "beneficiosListView";
            this.beneficiosListView.Size = new System.Drawing.Size(361, 551);
            this.beneficiosListView.TabIndex = 56;
            this.beneficiosListView.UseCompatibleStateImageBehavior = false;
            this.beneficiosListView.View = System.Windows.Forms.View.Details;
            // 
            // beneficioss
            // 
            this.beneficioss.AspectName = "nombre";
            this.beneficioss.Groupable = false;
            this.beneficioss.MaximumWidth = 150;
            this.beneficioss.MinimumWidth = 1;
            this.beneficioss.Text = global::Genesis.Recursos_localizables.StringResources.TableBeneficios;
            this.beneficioss.Width = 150;
            // 
            // puntajee
            // 
            this.puntajee.AspectName = "puntaje";
            this.puntajee.Groupable = false;
            this.puntajee.MaximumWidth = 100;
            this.puntajee.MinimumWidth = 1;
            this.puntajee.Text = global::Genesis.Recursos_localizables.StringResources.TablePuntaje;
            this.puntajee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.puntajee.Width = 100;
            // 
            // exportarPdfButton
            // 
            this.exportarPdfButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.exportarPdfButton.Location = new System.Drawing.Point(727, 589);
            this.exportarPdfButton.Name = "exportarPdfButton";
            this.exportarPdfButton.Size = new System.Drawing.Size(312, 38);
            this.exportarPdfButton.TabIndex = 64;
            this.exportarPdfButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonExportar;
            this.exportarPdfButton.UseVisualStyleBackColor = true;
            this.exportarPdfButton.Click += new System.EventHandler(this.exportarPdfButton_Click);
            // 
            // MiEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 641);
            this.Controls.Add(this.exportarPdfButton);
            this.Controls.Add(this.beneficiosListView);
            this.Controls.Add(this.evaluacionesListView);
            this.Name = "MiEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mi estado";
            this.Load += new System.EventHandler(this.MiEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.ObjectListView evaluacionesListView;
        private BrightIdeasSoftware.OLVColumn equipo;
        private BrightIdeasSoftware.OLVColumn puntaje;
        private BrightIdeasSoftware.OLVColumn cumplimiento;
        private BrightIdeasSoftware.ObjectListView beneficiosListView;
        private BrightIdeasSoftware.OLVColumn beneficioss;
        private BrightIdeasSoftware.OLVColumn puntajee;
        private System.Windows.Forms.Button exportarPdfButton;
    }
}