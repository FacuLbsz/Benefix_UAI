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
            this.permisivaButton.Location = new System.Drawing.Point(50, 98);
            this.permisivaButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.permisivaButton.Name = "permisivaButton";
            this.permisivaButton.Size = new System.Drawing.Size(112, 35);
            this.permisivaButton.TabIndex = 0;
            this.permisivaButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonPermisiva;
            this.permisivaButton.UseVisualStyleBackColor = true;
            this.permisivaButton.Click += new System.EventHandler(this.permisivaButton_Click);
            // 
            // restrictivaButton
            // 
            this.restrictivaButton.Location = new System.Drawing.Point(180, 98);
            this.restrictivaButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.restrictivaButton.Name = "restrictivaButton";
            this.restrictivaButton.Size = new System.Drawing.Size(112, 35);
            this.restrictivaButton.TabIndex = 1;
            this.restrictivaButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonRestrictiva;
            this.restrictivaButton.UseVisualStyleBackColor = true;
            this.restrictivaButton.Click += new System.EventHandler(this.restrictivaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Como desea asignar la patente?";
            // 
            // AsignarDesasignarPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 168);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restrictivaButton);
            this.Controls.Add(this.permisivaButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AsignarDesasignarPatente";
            this.Load += new System.EventHandler(this.AsignarDesasignarPatente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button permisivaButton;
        private System.Windows.Forms.Button restrictivaButton;
        private System.Windows.Forms.Label label1;
    }
}