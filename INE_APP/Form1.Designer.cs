﻿namespace INE_APP
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Contenedor_1 = new System.Windows.Forms.Panel();
            this.Titulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Menu_1 = new System.Windows.Forms.TableLayoutPanel();
            this.Correo = new System.Windows.Forms.Label();
            this.Contraseña = new System.Windows.Forms.Label();
            this.C_correo = new System.Windows.Forms.TextBox();
            this.C_contraseña = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_entrar = new System.Windows.Forms.Button();
            this.Contenedor_1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Menu_1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Contenedor_1
            // 
            this.Contenedor_1.BackColor = System.Drawing.Color.Transparent;
            this.Contenedor_1.Controls.Add(this.Titulo);
            this.Contenedor_1.Controls.Add(this.panel1);
            this.Contenedor_1.Location = new System.Drawing.Point(18, 0);
            this.Contenedor_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Contenedor_1.Name = "Contenedor_1";
            this.Contenedor_1.Size = new System.Drawing.Size(1164, 674);
            this.Contenedor_1.TabIndex = 0;
            this.Contenedor_1.Paint += new System.Windows.Forms.PaintEventHandler(this.Contenedor_1_Paint);
            // 
            // Titulo
            // 
            this.Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Titulo.AutoSize = true;
            this.Titulo.BackColor = System.Drawing.Color.LightPink;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(354, 55);
            this.Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(451, 47);
            this.Titulo.TabIndex = 2;
            this.Titulo.Text = "PANTALLA DE INICIO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Menu_1);
            this.panel1.Location = new System.Drawing.Point(286, 146);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 463);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Menu_1
            // 
            this.Menu_1.BackColor = System.Drawing.Color.LightPink;
            this.Menu_1.ColumnCount = 1;
            this.Menu_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 537F));
            this.Menu_1.Controls.Add(this.Correo, 0, 0);
            this.Menu_1.Controls.Add(this.Contraseña, 0, 2);
            this.Menu_1.Controls.Add(this.C_correo, 0, 1);
            this.Menu_1.Controls.Add(this.C_contraseña, 0, 3);
            this.Menu_1.Controls.Add(this.tableLayoutPanel1, 0, 5);
            this.Menu_1.Controls.Add(this.Btn_entrar, 0, 4);
            this.Menu_1.Location = new System.Drawing.Point(24, 5);
            this.Menu_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Menu_1.Name = "Menu_1";
            this.Menu_1.RowCount = 6;
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.Menu_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.Menu_1.Size = new System.Drawing.Size(506, 462);
            this.Menu_1.TabIndex = 0;
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correo.Location = new System.Drawing.Point(4, 0);
            this.Correo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(116, 33);
            this.Correo.TabIndex = 0;
            this.Correo.Text = "Usuario";
            // 
            // Contraseña
            // 
            this.Contraseña.AutoSize = true;
            this.Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña.Location = new System.Drawing.Point(4, 124);
            this.Contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(165, 33);
            this.Contraseña.TabIndex = 1;
            this.Contraseña.Text = "Contraseña";
            // 
            // C_correo
            // 
            this.C_correo.Location = new System.Drawing.Point(4, 71);
            this.C_correo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.C_correo.Name = "C_correo";
            this.C_correo.Size = new System.Drawing.Size(418, 26);
            this.C_correo.TabIndex = 4;
            // 
            // C_contraseña
            // 
            this.C_contraseña.Location = new System.Drawing.Point(4, 192);
            this.C_contraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.C_contraseña.Name = "C_contraseña";
            this.C_contraseña.Size = new System.Drawing.Size(418, 26);
            this.C_contraseña.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 372);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 38);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "ADMINISTRADOR";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(268, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Registrarse";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Btn_entrar
            // 
            this.Btn_entrar.Location = new System.Drawing.Point(4, 272);
            this.Btn_entrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_entrar.Name = "Btn_entrar";
            this.Btn_entrar.Size = new System.Drawing.Size(420, 65);
            this.Btn_entrar.TabIndex = 3;
            this.Btn_entrar.Text = "ENTRAR";
            this.Btn_entrar.UseVisualStyleBackColor = true;
            this.Btn_entrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.Contenedor_1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Contenedor_1.ResumeLayout(false);
            this.Contenedor_1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Menu_1.ResumeLayout(false);
            this.Menu_1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Contenedor_1;
        private System.Windows.Forms.TableLayoutPanel Menu_1;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label Contraseña;
        private System.Windows.Forms.Button Btn_entrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox C_correo;
        private System.Windows.Forms.TextBox C_contraseña;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

