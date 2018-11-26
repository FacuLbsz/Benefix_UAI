namespace Genesis
{
    partial class ModificarIdioma
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
            this.textLabel = new System.Windows.Forms.Label();
            this.confirmarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(48, 71);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(374, 111);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "¿Desea modificar el idioma? Es necesario reiniciar la aplicación para visualizar " +
    "el cambio.";
            this.textLabel.Click += new System.EventHandler(this.textLabel_Click);
            // 
            // confirmarButton
            // 
            this.confirmarButton.Location = new System.Drawing.Point(40, 225);
            this.confirmarButton.Name = "confirmarButton";
            this.confirmarButton.Size = new System.Drawing.Size(178, 38);
            this.confirmarButton.TabIndex = 59;
            this.confirmarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonConfirmar;
            this.confirmarButton.UseVisualStyleBackColor = true;
            this.confirmarButton.Click += new System.EventHandler(this.confirmarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(242, 225);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(178, 38);
            this.cancelarButton.TabIndex = 60;
            this.cancelarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonCancelar;
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // ModificarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 292);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.confirmarButton);
            this.Controls.Add(this.textLabel);
            this.Name = "ModificarIdioma";
            this.Text = "Modificar idioma";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button confirmarButton;
        private System.Windows.Forms.Button cancelarButton;
    }
}