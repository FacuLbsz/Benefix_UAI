﻿namespace Genesis
{
    partial class RealizarBackup
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
            this.rutaDestinoLabel = new System.Windows.Forms.Label();
            this.exportarButton = new System.Windows.Forms.Button();
            this.rutaDestinoText = new System.Windows.Forms.TextBox();
            this.cantidadVolumenesLabel = new System.Windows.Forms.Label();
            this.cantidadDeVolumenesComboBox = new System.Windows.Forms.ComboBox();
            this.seleccionarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rutaDestinoLabel
            // 
            this.rutaDestinoLabel.AutoSize = true;
            this.rutaDestinoLabel.Location = new System.Drawing.Point(67, 29);
            this.rutaDestinoLabel.Name = "rutaDestinoLabel";
            this.rutaDestinoLabel.Size = new System.Drawing.Size(100, 20);
            this.rutaDestinoLabel.TabIndex = 45;
            this.rutaDestinoLabel.Text = "Ruta destino";
            // 
            // exportarButton
            // 
            this.exportarButton.Location = new System.Drawing.Point(149, 170);
            this.exportarButton.Name = "exportarButton";
            this.exportarButton.Size = new System.Drawing.Size(242, 38);
            this.exportarButton.TabIndex = 43;
            this.exportarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonExportar;
            this.exportarButton.UseVisualStyleBackColor = true;
            this.exportarButton.Click += new System.EventHandler(this.exportarButton_Click);
            // 
            // rutaDestinoText
            // 
            this.rutaDestinoText.Location = new System.Drawing.Point(71, 56);
            this.rutaDestinoText.Name = "rutaDestinoText";
            this.rutaDestinoText.Size = new System.Drawing.Size(242, 26);
            this.rutaDestinoText.TabIndex = 46;
            // 
            // cantidadVolumenesLabel
            // 
            this.cantidadVolumenesLabel.AutoSize = true;
            this.cantidadVolumenesLabel.Location = new System.Drawing.Point(67, 89);
            this.cantidadVolumenesLabel.Name = "cantidadVolumenesLabel";
            this.cantidadVolumenesLabel.Size = new System.Drawing.Size(175, 20);
            this.cantidadVolumenesLabel.TabIndex = 47;
            this.cantidadVolumenesLabel.Text = "Cantidad de volumenes";
            // 
            // cantidadDeVolumenesComboBox
            // 
            this.cantidadDeVolumenesComboBox.FormattingEnabled = true;
            this.cantidadDeVolumenesComboBox.Location = new System.Drawing.Point(71, 124);
            this.cantidadDeVolumenesComboBox.Name = "cantidadDeVolumenesComboBox";
            this.cantidadDeVolumenesComboBox.Size = new System.Drawing.Size(374, 28);
            this.cantidadDeVolumenesComboBox.TabIndex = 48;
            // 
            // seleccionarButton
            // 
            this.seleccionarButton.Location = new System.Drawing.Point(335, 56);
            this.seleccionarButton.Name = "seleccionarButton";
            this.seleccionarButton.Size = new System.Drawing.Size(110, 39);
            this.seleccionarButton.TabIndex = 49;
            this.seleccionarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonSeleccionar;
            this.seleccionarButton.UseVisualStyleBackColor = true;
            this.seleccionarButton.Click += new System.EventHandler(this.seleccionarButton_Click);
            // 
            // RealizarBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 251);
            this.Controls.Add(this.seleccionarButton);
            this.Controls.Add(this.cantidadDeVolumenesComboBox);
            this.Controls.Add(this.cantidadVolumenesLabel);
            this.Controls.Add(this.rutaDestinoText);
            this.Controls.Add(this.rutaDestinoLabel);
            this.Controls.Add(this.exportarButton);
            this.Name = "RealizarBackup";
            this.Text = "Realizar Back Up";
            this.Load += new System.EventHandler(this.RealizarBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rutaDestinoLabel;
        private System.Windows.Forms.Button exportarButton;
        private System.Windows.Forms.TextBox rutaDestinoText;
        private System.Windows.Forms.Label cantidadVolumenesLabel;
        private System.Windows.Forms.ComboBox cantidadDeVolumenesComboBox;
        private System.Windows.Forms.Button seleccionarButton;
    }
}