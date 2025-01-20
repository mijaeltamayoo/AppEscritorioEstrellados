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
            this.rolComboBox = new System.Windows.Forms.ComboBox();
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
            this.NombreTextBox.Location = new System.Drawing.Point(76, 483);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(100, 20);
            this.NombreTextBox.TabIndex = 1;
            this.NombreTextBox.Tag = "Nombre";
            // 
            // CorreoTextBox
            // 
            this.CorreoTextBox.Location = new System.Drawing.Point(182, 483);
            this.CorreoTextBox.Name = "CorreoTextBox";
            this.CorreoTextBox.Size = new System.Drawing.Size(100, 20);
            this.CorreoTextBox.TabIndex = 2;
            // 
            // ContraseñaTextBox
            // 
            this.ContraseñaTextBox.Location = new System.Drawing.Point(288, 483);
            this.ContraseñaTextBox.Name = "ContraseñaTextBox";
            this.ContraseñaTextBox.Size = new System.Drawing.Size(100, 20);
            this.ContraseñaTextBox.TabIndex = 3;
            // 
            // newUsuarioBTN
            // 
            this.newUsuarioBTN.Location = new System.Drawing.Point(535, 482);
            this.newUsuarioBTN.Name = "newUsuarioBTN";
            this.newUsuarioBTN.Size = new System.Drawing.Size(75, 23);
            this.newUsuarioBTN.TabIndex = 4;
            this.newUsuarioBTN.Text = "guardar";
            this.newUsuarioBTN.UseVisualStyleBackColor = true;
            // 
            // rolComboBox
            // 
            this.rolComboBox.FormattingEnabled = true;
            this.rolComboBox.Location = new System.Drawing.Point(394, 483);
            this.rolComboBox.Name = "rolComboBox";
            this.rolComboBox.Size = new System.Drawing.Size(121, 21);
            this.rolComboBox.TabIndex = 5;
            // 
            // UserViewManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.rolComboBox);
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
        private System.Windows.Forms.ComboBox rolComboBox;
    }
}
