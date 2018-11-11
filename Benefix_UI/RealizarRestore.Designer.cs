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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.seleccionarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rutaOrigenText
            // 
            this.rutaOrigenText.Location = new System.Drawing.Point(63, 60);
            this.rutaOrigenText.Name = "rutaOrigenText";
            this.rutaOrigenText.Size = new System.Drawing.Size(356, 26);
            this.rutaOrigenText.TabIndex = 51;
            // 
            // rutaOrigenLabel
            // 
            this.rutaOrigenLabel.AutoSize = true;
            this.rutaOrigenLabel.Location = new System.Drawing.Point(59, 33);
            this.rutaOrigenLabel.Name = "rutaOrigenLabel";
            this.rutaOrigenLabel.Size = new System.Drawing.Size(92, 20);
            this.rutaOrigenLabel.TabIndex = 50;
            this.rutaOrigenLabel.Text = Genesis.Recursos_localizables.StringResources.FormularioRutaOrigen;
            // 
            // importarButton
            // 
            this.importarButton.Location = new System.Drawing.Point(177, 116);
            this.importarButton.Name = "importarButton";
            this.importarButton.Size = new System.Drawing.Size(242, 38);
            this.importarButton.TabIndex = 49;
            this.importarButton.Text = Genesis.Recursos_localizables.StringResources.ButtonImportar;
            this.importarButton.UseVisualStyleBackColor = true;
            this.importarButton.Click += new System.EventHandler(this.importarButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // seleccionarArchivo
            // 
            this.seleccionarArchivo.Location = new System.Drawing.Point(425, 58);
            this.seleccionarArchivo.Name = "seleccionarArchivo";
            this.seleccionarArchivo.Size = new System.Drawing.Size(105, 31);
            this.seleccionarArchivo.TabIndex = 52;
            this.seleccionarArchivo.Text = Genesis.Recursos_localizables.StringResources.ButtonSeleccionar;
            this.seleccionarArchivo.UseVisualStyleBackColor = true;
            this.seleccionarArchivo.Click += new System.EventHandler(this.seleccionarArchivo_Click);
            // 
            // RealizarRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 201);
            this.Controls.Add(this.seleccionarArchivo);
            this.Controls.Add(this.rutaOrigenText);
            this.Controls.Add(this.rutaOrigenLabel);
            this.Controls.Add(this.importarButton);
            this.Name = "RealizarRestore";
            this.Text = Genesis.Recursos_localizables.StringResources.SistemaMenuItemRealizarRestore;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rutaOrigenText;
        private System.Windows.Forms.Label rutaOrigenLabel;
        private System.Windows.Forms.Button importarButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button seleccionarArchivo;
    }
}