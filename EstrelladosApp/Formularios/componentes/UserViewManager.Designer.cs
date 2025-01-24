using System.Windows.Forms;

namespace EstrelladosApp.Formularios.componentes
{
    partial class UserViewManager
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.CorreoTextBox = new System.Windows.Forms.TextBox();
            this.ContraseñaTextBox = new System.Windows.Forms.TextBox();
            this.newUsuarioBTN = new System.Windows.Forms.Button();
            this.haseadorContraseñas = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(582, 410);
            this.dataGridView1.TabIndex = 0;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(67, 473);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(100, 20);
            this.NombreTextBox.TabIndex = 1;
            this.NombreTextBox.Tag = "Nombre";
            // 
            // CorreoTextBox
            // 
            this.CorreoTextBox.Location = new System.Drawing.Point(173, 473);
            this.CorreoTextBox.Name = "CorreoTextBox";
            this.CorreoTextBox.Size = new System.Drawing.Size(126, 20);
            this.CorreoTextBox.TabIndex = 2;
            // 
            // ContraseñaTextBox
            // 
            this.ContraseñaTextBox.Location = new System.Drawing.Point(305, 473);
            this.ContraseñaTextBox.Name = "ContraseñaTextBox";
            this.ContraseñaTextBox.Size = new System.Drawing.Size(174, 20);
            this.ContraseñaTextBox.TabIndex = 3;
            // 
            // newUsuarioBTN
            // 
            this.newUsuarioBTN.Location = new System.Drawing.Point(485, 471);
            this.newUsuarioBTN.Name = "newUsuarioBTN";
            this.newUsuarioBTN.Size = new System.Drawing.Size(75, 23);
            this.newUsuarioBTN.TabIndex = 4;
            this.newUsuarioBTN.Text = "guardar";
            this.newUsuarioBTN.UseVisualStyleBackColor = true;
            this.newUsuarioBTN.Click += new System.EventHandler(this.NewUsuarioBTN_Click);
            // 
            // haseadorContraseñas
            // 
            this.haseadorContraseñas.Location = new System.Drawing.Point(67, 517);
            this.haseadorContraseñas.Name = "haseadorContraseñas";
            this.haseadorContraseñas.Size = new System.Drawing.Size(493, 20);
            this.haseadorContraseñas.TabIndex = 5;
            this.haseadorContraseñas.KeyDown += textBox1_KeyDown;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(67, 454);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(42, 13);
            this.name.TabIndex = 6;
            this.name.Text = "nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contraseña explicita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Combertidor has";
            // 
            // UserViewManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.haseadorContraseñas);
            this.Controls.Add(this.newUsuarioBTN);
            this.Controls.Add(this.ContraseñaTextBox);
            this.Controls.Add(this.CorreoTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserViewManager";
            this.Size = new System.Drawing.Size(679, 550);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.TextBox CorreoTextBox;
        private System.Windows.Forms.TextBox ContraseñaTextBox;
        private System.Windows.Forms.Button newUsuarioBTN;
        private System.Windows.Forms.TextBox haseadorContraseñas;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
