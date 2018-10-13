namespace Genesis
{
    partial class LogOut
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
            this.cancelarButton = new System.Windows.Forms.Button();
            this.confirmarButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(244, 204);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(179, 38);
            this.cancelarButton.TabIndex = 63;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // confirmarButton
            // 
            this.confirmarButton.Location = new System.Drawing.Point(42, 204);
            this.confirmarButton.Name = "confirmarButton";
            this.confirmarButton.Size = new System.Drawing.Size(179, 38);
            this.confirmarButton.TabIndex = 62;
            this.confirmarButton.Text = "Confirmar";
            this.confirmarButton.UseVisualStyleBackColor = true;
            this.confirmarButton.Click += new System.EventHandler(this.confirmarButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(50, 51);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(373, 111);
            this.textLabel.TabIndex = 61;
            this.textLabel.Text = "¿Desea cerrar su sesion? \n Toda la información no guardada se perdera.";
            // 
            // LogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 292);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.confirmarButton);
            this.Controls.Add(this.textLabel);
            this.Name = "LogOut";
            this.Text = "Log Out";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button confirmarButton;
        private System.Windows.Forms.Label textLabel;
    }
}