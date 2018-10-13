namespace Genesis
{
    partial class AdministracionDeUsuarios
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
            this.asignarPatentesButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.usuarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restablecerContraseñaButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.nombreDeUsuarioLabel = new System.Windows.Forms.Label();
            this.nombreDeUsuarioText = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.apellidoLabel = new System.Windows.Forms.Label();
            this.apellidoText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // asignarPatentesButton
            // 
            this.asignarPatentesButton.Location = new System.Drawing.Point(319, 341);
            this.asignarPatentesButton.Name = "asignarPatentesButton";
            this.asignarPatentesButton.Size = new System.Drawing.Size(242, 38);
            this.asignarPatentesButton.TabIndex = 53;
            this.asignarPatentesButton.Text = "Asignar patentes";
            this.asignarPatentesButton.UseVisualStyleBackColor = true;
            this.asignarPatentesButton.Click += new System.EventHandler(this.asignarPatentesButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarios});
            this.dataGridView1.Location = new System.Drawing.Point(29, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(240, 551);
            this.dataGridView1.TabIndex = 46;
            // 
            // usuarios
            // 
            this.usuarios.HeaderText = "Usuarios";
            this.usuarios.Name = "usuarios";
            this.usuarios.ReadOnly = true;
            // 
            // restablecerContraseñaButton
            // 
            this.restablecerContraseñaButton.Location = new System.Drawing.Point(319, 287);
            this.restablecerContraseñaButton.Name = "restablecerContraseñaButton";
            this.restablecerContraseñaButton.Size = new System.Drawing.Size(242, 38);
            this.restablecerContraseñaButton.TabIndex = 54;
            this.restablecerContraseñaButton.Text = "Restablecer contraseña";
            this.restablecerContraseñaButton.UseVisualStyleBackColor = true;
            this.restablecerContraseñaButton.Click += new System.EventHandler(this.restablecerContraseñaButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(319, 553);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 52;
            this.eliminarButton.Text = "Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(319, 500);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 51;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(319, 447);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 50;
            this.crearButton.Text = "Crear";
            this.crearButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(319, 394);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 49;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // nombreDeUsuarioLabel
            // 
            this.nombreDeUsuarioLabel.AutoSize = true;
            this.nombreDeUsuarioLabel.Location = new System.Drawing.Point(319, 40);
            this.nombreDeUsuarioLabel.Name = "nombreDeUsuarioLabel";
            this.nombreDeUsuarioLabel.Size = new System.Drawing.Size(143, 20);
            this.nombreDeUsuarioLabel.TabIndex = 48;
            this.nombreDeUsuarioLabel.Text = "Nombre de usuario";
            // 
            // nombreDeUsuarioText
            // 
            this.nombreDeUsuarioText.Location = new System.Drawing.Point(319, 66);
            this.nombreDeUsuarioText.Name = "nombreDeUsuarioText";
            this.nombreDeUsuarioText.Size = new System.Drawing.Size(242, 26);
            this.nombreDeUsuarioText.TabIndex = 47;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(319, 101);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 57;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(319, 127);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 56;
            // 
            // apellidoLabel
            // 
            this.apellidoLabel.AutoSize = true;
            this.apellidoLabel.Location = new System.Drawing.Point(319, 161);
            this.apellidoLabel.Name = "apellidoLabel";
            this.apellidoLabel.Size = new System.Drawing.Size(65, 20);
            this.apellidoLabel.TabIndex = 59;
            this.apellidoLabel.Text = "Apellido";
            // 
            // apellidoText
            // 
            this.apellidoText.Location = new System.Drawing.Point(319, 187);
            this.apellidoText.Name = "apellidoText";
            this.apellidoText.Size = new System.Drawing.Size(242, 26);
            this.apellidoText.TabIndex = 58;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(319, 219);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(48, 20);
            this.emailLabel.TabIndex = 61;
            this.emailLabel.Text = "Email";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(319, 245);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(242, 26);
            this.emailText.TabIndex = 60;
            // 
            // AdministracionDeUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 631);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.apellidoLabel);
            this.Controls.Add(this.apellidoText);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Controls.Add(this.asignarPatentesButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.restablecerContraseñaButton);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.nombreDeUsuarioLabel);
            this.Controls.Add(this.nombreDeUsuarioText);
            this.Name = "AdministracionDeUsuarios";
            this.Text = "Administracion de usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button asignarPatentesButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button restablecerContraseñaButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label nombreDeUsuarioLabel;
        private System.Windows.Forms.TextBox nombreDeUsuarioText;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarios;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.TextBox apellidoText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailText;
    }
}