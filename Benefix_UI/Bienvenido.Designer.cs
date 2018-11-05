namespace Genesis
{
    partial class Bienvenido
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bienvenidoLabel = new System.Windows.Forms.Label();
            this.comenzarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(413, 26);
            this.textBox1.TabIndex = 0;
            // 
            // bienvenidoLabel
            // 
            this.bienvenidoLabel.AutoSize = true;
            this.bienvenidoLabel.Location = new System.Drawing.Point(27, 24);
            this.bienvenidoLabel.MaximumSize = new System.Drawing.Size(500, 0);
            this.bienvenidoLabel.Name = "bienvenidoLabel";
            this.bienvenidoLabel.Size = new System.Drawing.Size(435, 40);
            this.bienvenidoLabel.TabIndex = 1;
            this.bienvenidoLabel.Text = "Bienvenido a Benefix, por favor ingrese el string de conexion requerido para el a" +
    "cceso a la base de datos.";
            // 
            // comenzarButton
            // 
            this.comenzarButton.Location = new System.Drawing.Point(177, 122);
            this.comenzarButton.Name = "comenzarButton";
            this.comenzarButton.Size = new System.Drawing.Size(122, 37);
            this.comenzarButton.TabIndex = 2;
            this.comenzarButton.Text = "Comenzar";
            this.comenzarButton.UseVisualStyleBackColor = true;
            this.comenzarButton.Click += new System.EventHandler(this.comenzarButton_Click);
            // 
            // Bienvenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 191);
            this.Controls.Add(this.comenzarButton);
            this.Controls.Add(this.bienvenidoLabel);
            this.Controls.Add(this.textBox1);
            this.Name = "Bienvenido";
            this.Text = "Bienvenido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label bienvenidoLabel;
        private System.Windows.Forms.Button comenzarButton;
    }
}