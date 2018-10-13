namespace Genesis
{
    partial class AdministracionDeFamilias
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
            this.asignarPatentesButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.familias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.asignarUsuariosButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // asignarPatentesButton
            // 
            this.asignarPatentesButton.Location = new System.Drawing.Point(319, 287);
            this.asignarPatentesButton.Name = "asignarPatentesButton";
            this.asignarPatentesButton.Size = new System.Drawing.Size(242, 38);
            this.asignarPatentesButton.TabIndex = 69;
            this.asignarPatentesButton.Text = "Asignar patentes";
            this.asignarPatentesButton.UseVisualStyleBackColor = true;
            this.asignarPatentesButton.Click += new System.EventHandler(this.asignarPatentesButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.familias});
            this.dataGridView1.Location = new System.Drawing.Point(29, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 551);
            this.dataGridView1.TabIndex = 62;
            // 
            // familias
            // 
            this.familias.HeaderText = "Familias";
            this.familias.Name = "familias";
            this.familias.ReadOnly = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(319, 553);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 68;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(319, 500);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 67;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(319, 447);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 66;
            this.crearButton.Text = "Crear";
            this.crearButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(319, 394);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 65;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(319, 43);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 72;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(319, 69);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 71;
            // 
            // asignarUsuariosButton
            // 
            this.asignarUsuariosButton.Location = new System.Drawing.Point(319, 341);
            this.asignarUsuariosButton.Name = "asignarUsuariosButton";
            this.asignarUsuariosButton.Size = new System.Drawing.Size(242, 38);
            this.asignarUsuariosButton.TabIndex = 73;
            this.asignarUsuariosButton.Text = "Asignar usuarios";
            this.asignarUsuariosButton.UseVisualStyleBackColor = true;
            this.asignarUsuariosButton.Click += new System.EventHandler(this.asignarUsuariosButton_Click);
            // 
            // AdministracionDeFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 631);
            this.Controls.Add(this.asignarUsuariosButton);
            this.Controls.Add(this.asignarPatentesButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Name = "AdministracionDeFamilias";
            this.Text = "Administracion de familias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asignarPatentesButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.DataGridViewTextBoxColumn familias;
        private System.Windows.Forms.Button asignarUsuariosButton;
    }
}