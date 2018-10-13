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
            this.textLabel.Size = new System.Drawing.Size(373, 111);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "¿Desea modificar el idioma? \n Es necesario reinciar la aplicacion para visualizar" +
    " el cambio.";
            // 
            // confirmarButton
            // 
            this.confirmarButton.Location = new System.Drawing.Point(40, 224);
            this.confirmarButton.Name = "confirmarButton";
            this.confirmarButton.Size = new System.Drawing.Size(179, 38);
            this.confirmarButton.TabIndex = 59;
            this.confirmarButton.Text = "Confirmar";
            this.confirmarButton.UseVisualStyleBackColor = true;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(242, 224);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(179, 38);
            this.cancelarButton.TabIndex = 60;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
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