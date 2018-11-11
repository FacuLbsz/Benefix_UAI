namespace Genesis
{
    partial class AsignarCoordinador
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
            this.guardarButton = new System.Windows.Forms.Button();
            this.coordinadorBox = new System.Windows.Forms.ComboBox();
            this.coordinadorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(67, 166);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(242, 38);
            this.guardarButton.TabIndex = 40;
            this.guardarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonGuardar;
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // coordinadorBox
            // 
            this.coordinadorBox.FormattingEnabled = true;
            this.coordinadorBox.Location = new System.Drawing.Point(67, 63);
            this.coordinadorBox.Name = "coordinadorBox";
            this.coordinadorBox.Size = new System.Drawing.Size(242, 28);
            this.coordinadorBox.TabIndex = 41;
            // 
            // coordinadorLabel
            // 
            this.coordinadorLabel.AutoSize = true;
            this.coordinadorLabel.Location = new System.Drawing.Point(63, 40);
            this.coordinadorLabel.Name = "coordinadorLabel";
            this.coordinadorLabel.Size = new System.Drawing.Size(96, 20);
            this.coordinadorLabel.TabIndex = 42;
            this.coordinadorLabel.Text = Genesis.Recursos_localizables.StringResources.FormularioCoordinador;
            // 
            // AsignarCoordinador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 251);
            this.Controls.Add(this.coordinadorLabel);
            this.Controls.Add(this.coordinadorBox);
            this.Controls.Add(this.guardarButton);
            this.Name = "AsignarCoordinador";
            this.Text = Genesis.Recursos_localizables.StringResources.ButtonAsignarCoordinador;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.ComboBox coordinadorBox;
        private System.Windows.Forms.Label coordinadorLabel;
    }
}