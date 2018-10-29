namespace Genesis
{
    partial class AsignarDesasignarPatente
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
            this.permisivaButton = new System.Windows.Forms.Button();
            this.restrictivaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // permisivaButton
            // 
            this.permisivaButton.Location = new System.Drawing.Point(33, 64);
            this.permisivaButton.Name = "permisivaButton";
            this.permisivaButton.Size = new System.Drawing.Size(75, 23);
            this.permisivaButton.TabIndex = 0;
            this.permisivaButton.Text = "Permisiva";
            this.permisivaButton.UseVisualStyleBackColor = true;
            this.permisivaButton.Click += new System.EventHandler(this.permisivaButton_Click);
            // 
            // restrictivaButton
            // 
            this.restrictivaButton.Location = new System.Drawing.Point(120, 64);
            this.restrictivaButton.Name = "restrictivaButton";
            this.restrictivaButton.Size = new System.Drawing.Size(75, 23);
            this.restrictivaButton.TabIndex = 1;
            this.restrictivaButton.Text = "Restrictiva";
            this.restrictivaButton.UseVisualStyleBackColor = true;
            this.restrictivaButton.Click += new System.EventHandler(this.restrictivaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Como desea asignar la patente?";
            // 
            // AsignarDesasignarPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 109);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restrictivaButton);
            this.Controls.Add(this.permisivaButton);
            this.Name = "AsignarDesasignarPatente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button permisivaButton;
        private System.Windows.Forms.Button restrictivaButton;
        private System.Windows.Forms.Label label1;
    }
}