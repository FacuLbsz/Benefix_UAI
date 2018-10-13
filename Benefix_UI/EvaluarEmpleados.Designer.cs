namespace Genesis
{
    partial class EvaluarEmpleados
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
            this.evaluarButton = new System.Windows.Forms.Button();
            this.alcanzadoButton = new System.Windows.Forms.Button();
            this.incumplidoButton = new System.Windows.Forms.Button();
            this.objetivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cumplimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // beneficiosAsignadosDataGridView
            // 
            this.beneficiosAsignadosDataGridView.AllowUserToAddRows = false;
            this.beneficiosAsignadosDataGridView.AllowUserToDeleteRows = false;
            this.beneficiosAsignadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.beneficiosAsignadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosAsignadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objetivos,
            this.Cumplimiento});
            this.beneficiosAsignadosDataGridView.Location = new System.Drawing.Point(23, 83);
            this.beneficiosAsignadosDataGridView.Name = "beneficiosAsignadosDataGridView";
            this.beneficiosAsignadosDataGridView.ReadOnly = true;
            this.beneficiosAsignadosDataGridView.RowTemplate.Height = 28;
            this.beneficiosAsignadosDataGridView.Size = new System.Drawing.Size(532, 429);
            this.beneficiosAsignadosDataGridView.TabIndex = 46;
            this.beneficiosAsignadosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.beneficiosAsignadosDataGridView_CellContentClick);
            // 
            // evaluarButton
            // 
            this.evaluarButton.Location = new System.Drawing.Point(313, 533);
            this.evaluarButton.Name = "evaluarButton";
            this.evaluarButton.Size = new System.Drawing.Size(242, 38);
            this.evaluarButton.TabIndex = 47;
            this.evaluarButton.Text = "Guardar";
            this.evaluarButton.UseVisualStyleBackColor = true;
            // 
            // alcanzadoButton
            // 
            this.alcanzadoButton.Location = new System.Drawing.Point(23, 22);
            this.alcanzadoButton.Name = "alcanzadoButton";
            this.alcanzadoButton.Size = new System.Drawing.Size(258, 38);
            this.alcanzadoButton.TabIndex = 48;
            this.alcanzadoButton.Text = "Alcanzado";
            this.alcanzadoButton.UseVisualStyleBackColor = true;
            // 
            // incumplidoButton
            // 
            this.incumplidoButton.Location = new System.Drawing.Point(297, 22);
            this.incumplidoButton.Name = "incumplidoButton";
            this.incumplidoButton.Size = new System.Drawing.Size(258, 38);
            this.incumplidoButton.TabIndex = 49;
            this.incumplidoButton.Text = "Incumplido";
            this.incumplidoButton.UseVisualStyleBackColor = true;
            // 
            // objetivos
            // 
            this.objetivos.FillWeight = 98.47716F;
            this.objetivos.HeaderText = "Objetivos";
            this.objetivos.Name = "objetivos";
            this.objetivos.ReadOnly = true;
            // 
            // Cumplimiento
            // 
            this.Cumplimiento.FillWeight = 50F;
            this.Cumplimiento.HeaderText = "Cumplimiento";
            this.Cumplimiento.Name = "Cumplimiento";
            this.Cumplimiento.ReadOnly = true;
            // 
            // EvaluarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 591);
            this.Controls.Add(this.incumplidoButton);
            this.Controls.Add(this.alcanzadoButton);
            this.Controls.Add(this.beneficiosAsignadosDataGridView);
            this.Controls.Add(this.evaluarButton);
            this.Name = "EvaluarEmpleados";
            this.Text = "Evaluar empleados";
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosAsignadosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView beneficiosAsignadosDataGridView;
        private System.Windows.Forms.Button evaluarButton;
        private System.Windows.Forms.Button alcanzadoButton;
        private System.Windows.Forms.Button incumplidoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cumplimiento;
    }
}