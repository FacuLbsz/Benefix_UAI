﻿namespace Genesis
{
    partial class AdministracionDeObjetivos
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
            this.objetivosDataGridView = new System.Windows.Forms.DataGridView();
            this.objetivos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.descripcionText = new System.Windows.Forms.TextBox();
            this.puntajeLabel = new System.Windows.Forms.Label();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.crearButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.puntajeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.objetivosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntajeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // objetivosDataGridView
            // 
            this.objetivosDataGridView.AllowUserToAddRows = false;
            this.objetivosDataGridView.AllowUserToDeleteRows = false;
            this.objetivosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.objetivosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.objetivosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.objetivos});
            this.objetivosDataGridView.Location = new System.Drawing.Point(27, 28);
            this.objetivosDataGridView.MultiSelect = false;
            this.objetivosDataGridView.Name = "objetivosDataGridView";
            this.objetivosDataGridView.ReadOnly = true;
            this.objetivosDataGridView.RowHeadersVisible = false;
            this.objetivosDataGridView.RowTemplate.Height = 28;
            this.objetivosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.objetivosDataGridView.Size = new System.Drawing.Size(240, 576);
            this.objetivosDataGridView.TabIndex = 0;
            this.objetivosDataGridView.Click += new System.EventHandler(this.objetivosDataGridView_CurrentCellChanged);
            // 
            // objetivos
            // 
            this.objetivos.DataPropertyName = "nombre";
            this.objetivos.HeaderText = global::Genesis.Recursos_localizables.StringResources.TableObjetivos;
            this.objetivos.Name = "objetivos";
            this.objetivos.ReadOnly = true;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(317, 28);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(65, 20);
            this.nombreLabel.TabIndex = 4;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(317, 54);
            this.nombreText.MaxLength = 26;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(242, 26);
            this.nombreText.TabIndex = 3;
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Location = new System.Drawing.Point(317, 88);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(92, 20);
            this.descripcionLabel.TabIndex = 6;
            this.descripcionLabel.Text = "Descripción";
            // 
            // descripcionText
            // 
            this.descripcionText.Location = new System.Drawing.Point(317, 114);
            this.descripcionText.MaxLength = 45;
            this.descripcionText.Multiline = true;
            this.descripcionText.Name = "descripcionText";
            this.descripcionText.Size = new System.Drawing.Size(242, 140);
            this.descripcionText.TabIndex = 5;
            // 
            // puntajeLabel
            // 
            this.puntajeLabel.AutoSize = true;
            this.puntajeLabel.Location = new System.Drawing.Point(317, 264);
            this.puntajeLabel.Name = "puntajeLabel";
            this.puntajeLabel.Size = new System.Drawing.Size(63, 20);
            this.puntajeLabel.TabIndex = 8;
            this.puntajeLabel.Text = "Puntaje";
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(317, 332);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(242, 38);
            this.limpiarButton.TabIndex = 9;
            this.limpiarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonLimpiar;
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(317, 385);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(242, 38);
            this.crearButton.TabIndex = 10;
            this.crearButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonCrear;
            this.crearButton.UseVisualStyleBackColor = true;
            this.crearButton.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(317, 491);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(242, 38);
            this.eliminarButton.TabIndex = 12;
            this.eliminarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonEliminar;
            this.eliminarButton.UseVisualStyleBackColor = true;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(317, 438);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(242, 38);
            this.modificarButton.TabIndex = 11;
            this.modificarButton.Text = global::Genesis.Recursos_localizables.StringResources.ButtonModificar;
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // puntajeUpDown
            // 
            this.puntajeUpDown.Location = new System.Drawing.Point(317, 287);
            this.puntajeUpDown.Name = "puntajeUpDown";
            this.puntajeUpDown.Size = new System.Drawing.Size(242, 26);
            this.puntajeUpDown.TabIndex = 13;
            // 
            // AdministracionDeObjetivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 631);
            this.Controls.Add(this.puntajeUpDown);
            this.Controls.Add(this.eliminarButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.crearButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.puntajeLabel);
            this.Controls.Add(this.descripcionLabel);
            this.Controls.Add(this.descripcionText);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreText);
            this.Controls.Add(this.objetivosDataGridView);
            this.Name = "AdministracionDeObjetivos";
            this.Text = "Administración de objetivos";
            this.Load += new System.EventHandler(this.AdministracionDeObjetivos_Load);
            this.Shown += new System.EventHandler(this.AdministracionDeObjetivos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.objetivosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puntajeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView objetivosDataGridView;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.TextBox descripcionText;
        private System.Windows.Forms.Label puntajeLabel;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn objetivos;
        private System.Windows.Forms.NumericUpDown puntajeUpDown;
    }
}