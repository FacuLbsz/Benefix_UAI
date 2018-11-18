namespace Genesis
{
    partial class ModificarContrasena
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
            this.contraseñaActualLabel = new System.Windows.Forms.Label();
            this.contrasenaActualText = new System.Windows.Forms.TextBox();
            this.nuevaContraseñaLabel = new System.Windows.Forms.Label();
            this.nuevaContrasenaText = new System.Windows.Forms.TextBox();
            this.modificarButton = new System.Windows.Forms.Button();
            this.confirmarContraseñaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contraseñaActualLabel
            // 
            this.contraseñaActualLabel.AutoSize = true;
            this.contraseñaActualLabel.Location = new System.Drawing.Point(48, 31);
            this.contraseñaActualLabel.Name = "contraseñaActualLabel";
            this.contraseñaActualLabel.Size = new System.Drawing.Size(139, 20);
            this.contraseñaActualLabel.TabIndex = 0;
            this.contraseñaActualLabel.Text = "Contraseña actual";
            this.contraseñaActualLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contrasenaActualText
            // 
            this.contrasenaActualText.Location = new System.Drawing.Point(46, 54);
            this.contrasenaActualText.MaxLength = 20;
            this.contrasenaActualText.Name = "contrasenaActualText";
            this.contrasenaActualText.PasswordChar = '*';
            this.contrasenaActualText.Size = new System.Drawing.Size(352, 26);
            this.contrasenaActualText.TabIndex = 1;
            // 
            // nuevaContraseñaLabel
            // 
            this.nuevaContraseñaLabel.AutoSize = true;
            this.nuevaContraseñaLabel.Location = new System.Drawing.Point(48, 106);
            this.nuevaContraseñaLabel.Name = "nuevaContraseñaLabel";
            this.nuevaContraseñaLabel.Size = new System.Drawing.Size(138, 20);
            this.nuevaContraseñaLabel.TabIndex = 2;
            this.nuevaContraseñaLabel.Text = "Nueva contraseña";
            // 
            // nuevaContrasenaText
            // 
            this.nuevaContrasenaText.Location = new System.Drawing.Point(46, 129);
            this.nuevaContrasenaText.MaxLength = 20;
            this.nuevaContrasenaText.Name = "nuevaContrasenaText";
            this.nuevaContrasenaText.PasswordChar = '*';
            this.nuevaContrasenaText.Size = new System.Drawing.Size(352, 26);
            this.nuevaContrasenaText.TabIndex = 3;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(145, 258);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(139, 44);
            this.modificarButton.TabIndex = 4;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // confirmarContraseñaTextBox
            // 
            this.confirmarContraseñaTextBox.Location = new System.Drawing.Point(46, 206);
            this.confirmarContraseñaTextBox.MaxLength = 20;
            this.confirmarContraseñaTextBox.Name = "confirmarContraseñaTextBox";
            this.confirmarContraseñaTextBox.PasswordChar = '*';
            this.confirmarContraseñaTextBox.Size = new System.Drawing.Size(352, 26);
            this.confirmarContraseñaTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = Genesis.Recursos_localizables.StringResources.ConfirmarNuevaContraseñaLabel;
            // 
            // ModificarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 347);
            this.Controls.Add(this.confirmarContraseñaTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.nuevaContrasenaText);
            this.Controls.Add(this.nuevaContraseñaLabel);
            this.Controls.Add(this.contrasenaActualText);
            this.Controls.Add(this.contraseñaActualLabel);
            this.Name = "ModificarContrasena";
            this.Text = "Modificar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contraseñaActualLabel;
        private System.Windows.Forms.TextBox contrasenaActualText;
        private System.Windows.Forms.Label nuevaContraseñaLabel;
        private System.Windows.Forms.TextBox nuevaContrasenaText;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.TextBox confirmarContraseñaTextBox;
        private System.Windows.Forms.Label label1;
    }
}