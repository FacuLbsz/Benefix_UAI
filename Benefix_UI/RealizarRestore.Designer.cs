namespace Genesis
{
    partial class RealizarRestore
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
            this.rutaOrigenText = new System.Windows.Forms.TextBox();
            this.rutaOrigenLabel = new System.Windows.Forms.Label();
            this.importarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rutaOrigenText
            // 
            this.rutaOrigenText.Location = new System.Drawing.Point(71, 63);
            this.rutaOrigenText.Name = "rutaOrigenText";
            this.rutaOrigenText.Size = new System.Drawing.Size(242, 26);
            this.rutaOrigenText.TabIndex = 51;
            this.rutaOrigenText.TextChanged += new System.EventHandler(this.rutaOrigenText_TextChanged);
            // 
            // rutaOrigenLabel
            // 
            this.rutaOrigenLabel.AutoSize = true;
            this.rutaOrigenLabel.Location = new System.Drawing.Point(67, 36);
            this.rutaOrigenLabel.Name = "rutaOrigenLabel";
            this.rutaOrigenLabel.Size = new System.Drawing.Size(92, 20);
            this.rutaOrigenLabel.TabIndex = 50;
            this.rutaOrigenLabel.Text = "Ruta origen";
            // 
            // importarButton
            // 
            this.importarButton.Location = new System.Drawing.Point(71, 176);
            this.importarButton.Name = "importarButton";
            this.importarButton.Size = new System.Drawing.Size(242, 38);
            this.importarButton.TabIndex = 49;
            this.importarButton.Text = "Importar";
            this.importarButton.UseVisualStyleBackColor = true;
            // 
            // RealizarRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 251);
            this.Controls.Add(this.rutaOrigenText);
            this.Controls.Add(this.rutaOrigenLabel);
            this.Controls.Add(this.importarButton);
            this.Name = "RealizarRestore";
            this.Text = "Realizar restore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rutaOrigenText;
        private System.Windows.Forms.Label rutaOrigenLabel;
        private System.Windows.Forms.Button importarButton;
    }
}