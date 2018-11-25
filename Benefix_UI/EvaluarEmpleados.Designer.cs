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
            this.evaluacionesDataGridView = new System.Windows.Forms.DataGridView();
            this.objetivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumplimiento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.evaluarButton = new System.Windows.Forms.Button();
            this.alcanzadoButton = new System.Windows.Forms.Button();
            this.incumplidoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // evaluacionesDataGridView
            // 
            this.evaluacionesDataGridView.AllowUserToAddRows = false;
            this.evaluacionesDataGridView.AllowUserToDeleteRows = false;
            this.evaluacionesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.evaluacionesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.evaluacionesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objetivos,
            this.cumplimiento});
            this.evaluacionesDataGridView.Location = new System.Drawing.Point(23, 83);
            this.evaluacionesDataGridView.MultiSelect = false;
            this.evaluacionesDataGridView.Name = "evaluacionesDataGridView";
            this.evaluacionesDataGridView.ReadOnly = true;
            this.evaluacionesDataGridView.RowHeadersVisible = false;
            this.evaluacionesDataGridView.RowTemplate.Height = 28;
            this.evaluacionesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.evaluacionesDataGridView.Size = new System.Drawing.Size(532, 429);
            this.evaluacionesDataGridView.TabIndex = 46;
            // 
            // objetivos
            // 
            this.objetivos.DataPropertyName = "equipoObjetvo";
            this.objetivos.FillWeight = 98.47716F;
            this.objetivos.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableObjetivos;
            this.objetivos.Name = "objetivos";
            this.objetivos.ReadOnly = true;
            // 
            // cumplimiento
            // 
            this.cumplimiento.DataPropertyName = "alcanzado";
            this.cumplimiento.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableCumplimiento;
            this.cumplimiento.Name = "cumplimiento";
            this.cumplimiento.ReadOnly = true;
            // 
            // evaluarButton
            // 
            this.evaluarButton.Location = new System.Drawing.Point(313, 533);
            this.evaluarButton.Name = "evaluarButton";
            this.evaluarButton.Size = new System.Drawing.Size(242, 38);
            this.evaluarButton.TabIndex = 47;
            this.evaluarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.evaluarButton.UseVisualStyleBackColor = true;
            this.evaluarButton.Click += new System.EventHandler(this.evaluarButton_Click);
            // 
            // alcanzadoButton
            // 
            this.alcanzadoButton.Location = new System.Drawing.Point(23, 22);
            this.alcanzadoButton.Name = "alcanzadoButton";
            this.alcanzadoButton.Size = new System.Drawing.Size(258, 38);
            this.alcanzadoButton.TabIndex = 48;
            this.alcanzadoButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonAlcanzado;
            this.alcanzadoButton.UseVisualStyleBackColor = true;
            this.alcanzadoButton.Click += new System.EventHandler(this.alcanzadoButton_Click);
            // 
            // incumplidoButton
            // 
            this.incumplidoButton.Location = new System.Drawing.Point(297, 22);
            this.incumplidoButton.Name = "incumplidoButton";
            this.incumplidoButton.Size = new System.Drawing.Size(258, 38);
            this.incumplidoButton.TabIndex = 49;
            this.incumplidoButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonIncumplido;
            this.incumplidoButton.UseVisualStyleBackColor = true;
            this.incumplidoButton.Click += new System.EventHandler(this.incumplidoButton_Click);
            // 
            // EvaluarEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 591);
            this.Controls.Add(this.incumplidoButton);
            this.Controls.Add(this.alcanzadoButton);
            this.Controls.Add(this.evaluacionesDataGridView);
            this.Controls.Add(this.evaluarButton);
            this.Name = "EvaluarEmpleados";
            this.Text = "Evaluar empleados";
            this.Load += new System.EventHandler(this.EvaluarEmpleados_Load);
            this.Shown += new System.EventHandler(this.EvaluarEmpleados_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.evaluacionesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView evaluacionesDataGridView;
        private System.Windows.Forms.Button evaluarButton;
        private System.Windows.Forms.Button alcanzadoButton;
        private System.Windows.Forms.Button incumplidoButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cumplimiento;
    }
}