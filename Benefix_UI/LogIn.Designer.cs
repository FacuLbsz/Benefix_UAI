namespace Genesis
{
    partial class LogIn
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombreUsuarioText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contraseñaText = new System.Windows.Forms.TextBox();
            this.ingresarButton = new System.Windows.Forms.Button();
            this.modificarStringButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nombreUsuarioText
            // 
            this.nombreUsuarioText.Location = new System.Drawing.Point(222, 80);
            this.nombreUsuarioText.MaxLength = 25;
            this.nombreUsuarioText.Name = "nombreUsuarioText";
            this.nombreUsuarioText.Size = new System.Drawing.Size(286, 26);
            this.nombreUsuarioText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // contraseñaText
            // 
            this.contraseñaText.Location = new System.Drawing.Point(222, 144);
            this.contraseñaText.MaxLength = 8;
            this.contraseñaText.Name = "contraseñaText";
            this.contraseñaText.Size = new System.Drawing.Size(286, 26);
            this.contraseñaText.TabIndex = 3;
            // 
            // ingresarButton
            // 
            this.ingresarButton.Location = new System.Drawing.Point(222, 204);
            this.ingresarButton.Name = "ingresarButton";
            this.ingresarButton.Size = new System.Drawing.Size(286, 38);
            this.ingresarButton.TabIndex = 5;
            this.ingresarButton.Text = "Ingresar";
            this.ingresarButton.UseVisualStyleBackColor = true;
            this.ingresarButton.Click += new System.EventHandler(this.ingresarButton_Click);
            // 
            // modificarStringButton
            // 
            this.modificarStringButton.Location = new System.Drawing.Point(441, 315);
            this.modificarStringButton.Name = "modificarStringButton";
            this.modificarStringButton.Size = new System.Drawing.Size(286, 38);
            this.modificarStringButton.TabIndex = 6;
            this.modificarStringButton.Text = "Modificar String de conexión";
            this.modificarStringButton.UseVisualStyleBackColor = true;
            this.modificarStringButton.Click += new System.EventHandler(this.modificarStringButton_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 365);
            this.Controls.Add(this.modificarStringButton);
            this.Controls.Add(this.ingresarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contraseñaText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombreUsuarioText);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Benefix - Log In";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombreUsuarioText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox contraseñaText;
        private System.Windows.Forms.Button ingresarButton;
        private System.Windows.Forms.Button modificarStringButton;
    }
}

