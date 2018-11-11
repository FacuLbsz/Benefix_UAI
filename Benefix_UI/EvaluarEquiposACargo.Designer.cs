namespace Genesis
{
    partial class EvaluarEquiposACargo
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
            this.beneficiosAsignadosDataGridView = new System.Windows.Forms.DataGridView();
            this.equipos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beneficiosDataGridView = new System.Windows.Forms.DataGridView();
            this.empleados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosAsignadosDataGridView
            // 
            this.beneficiosAsignadosDataGridView.AllowUserToAddRows = false;
            this.beneficiosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipos});
            this.beneficiosAsignadosDataGridView.Location = new System.Drawing.Point(18, 20);
            this.beneficiosAsignadosDataGridView.Name = "beneficiosAsignadosDataGridView";
            this.beneficiosAsignadosDataGridView.ReadOnly = true;
            this.beneficiosAsignadosDataGridView.RowTemplate.Height = 28;
            this.beneficiosAsignadosDataGridView.Size = new System.Drawing.Size(240, 551);
            this.beneficiosAsignadosDataGridView.TabIndex = 41;
            // 
            // equipos
            // 
            this.equipos.HeaderText = "Equipos";
            this.equipos.Name = "equipos";
            this.equipos.ReadOnly = true;
            // 
            // beneficiosDataGridView
            // 
            this.beneficiosDataGridView.AllowUserToAddRows = false;
            this.beneficiosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleados});
            this.beneficiosDataGridView.Location = new System.Drawing.Point(310, 20);
            this.beneficiosDataGridView.Name = "beneficiosDataGridView";
            this.beneficiosDataGridView.ReadOnly = true;
            this.beneficiosDataGridView.RowTemplate.Height = 28;
            this.beneficiosDataGridView.Size = new System.Drawing.Size(240, 489);
            this.beneficiosDataGridView.TabIndex = 45;
            // 
            // empleados
            // 
            this.empleados.HeaderText = Genesis.Recursos_localizables.StringResources.TableEmpleados;
            this.empleados.Name = "empleados";
            this.empleados.ReadOnly = true;
            // 
            // evaluarButton
            // 
            this.evaluarButton.Location = new System.Drawing.Point(308, 533);
            this.evaluarButton.Name = "evaluarButton";
            this.evaluarButton.Size = new System.Drawing.Size(242, 38);
            this.evaluarButton.TabIndex = 44;
            this.evaluarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonEvaluar;
            this.evaluarButton.UseVisualStyleBackColor = true;
            this.evaluarButton.Click += new System.EventHandler(this.evaluarButton_Click);
            // 
            // EvaluarEquiposACargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 591);
            this.Controls.Add(this.beneficiosAsignadosDataGridView);
            this.Controls.Add(this.beneficiosDataGridView);
            this.Controls.Add(this.evaluarButton);
            this.Name = "EvaluarEquiposACargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Genesis.Recursos_localizables.StringResources.SistemaMenuItemEvaluarEquiposACargo;
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosAsignadosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipos;
        private System.Windows.Forms.DataGridView beneficiosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleados;
        private System.Windows.Forms.Button evaluarButton;
    }
}