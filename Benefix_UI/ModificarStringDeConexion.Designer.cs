namespace Genesis
{
    partial class ModificarStringDeConexion
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
            this.stringDeConexionText = new System.Windows.Forms.TextBox();
            this.stringDeConexionLabel = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stringDeConexionText
            // 
            this.stringDeConexionText.Location = new System.Drawing.Point(71, 63);
            this.stringDeConexionText.Name = "stringDeConexionText";
            this.stringDeConexionText.Size = new System.Drawing.Size(242, 26);
            this.stringDeConexionText.TabIndex = 54;
            // 
            // stringDeConexionLabel
            // 
            this.stringDeConexionLabel.AutoSize = true;
            this.stringDeConexionLabel.Location = new System.Drawing.Point(67, 36);
            this.stringDeConexionLabel.Name = "stringDeConexionLabel";
            this.stringDeConexionLabel.Size = new System.Drawing.Size(140, 20);
            this.stringDeConexionLabel.TabIndex = 53;
            this.stringDeConexionLabel.Text = "String de conexion";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(71, 176);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 52;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // ModificarStringDeConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 251);
            this.Controls.Add(this.stringDeConexionText);
            this.Controls.Add(this.stringDeConexionLabel);
            this.Controls.Add(this.guardarButton);
            this.Name = "ModificarStringDeConexion";
            this.Text = "Modificar string de conexion";
            this.Load += new System.EventHandler(this.ModificarStringDeConexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stringDeConexionText;
        private System.Windows.Forms.Label stringDeConexionLabel;
        private System.Windows.Forms.Button guardarButton;
    }
}