namespace EstrelladosApp.Formularios.componentes
{
    partial class IncidenciaViewManager
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
            this.latitudTextBox = new System.Windows.Forms.TextBox();
            this.longitudTextBox = new System.Windows.Forms.TextBox();
            this.causaTextBox = new System.Windows.Forms.TextBox();
            this.fechaInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nivelIncidenciaTextBox = new System.Windows.Forms.TextBox();
            this.carreteraTextBox5 = new System.Windows.Forms.TextBox();
            this.ciudadComboBox1 = new System.Windows.Forms.ComboBox();
            this.provinciaComboBox = new System.Windows.Forms.ComboBox();
            this.regionComboBox = new System.Windows.Forms.ComboBox();
            this.tipoIncidenciaComboBox = new System.Windows.Forms.ComboBox();
            this.guardarIncidenciaBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(862, 432);
            this.dataGridView1.TabIndex = 1;
            // 
            // latitudTextBox
            // 
            this.latitudTextBox.Location = new System.Drawing.Point(3, 14);
            this.latitudTextBox.Name = "latitudTextBox";
            this.latitudTextBox.Size = new System.Drawing.Size(100, 20);
            this.latitudTextBox.TabIndex = 2;
            // 
            // longitudTextBox
            // 
            this.longitudTextBox.Location = new System.Drawing.Point(109, 14);
            this.longitudTextBox.Name = "longitudTextBox";
            this.longitudTextBox.Size = new System.Drawing.Size(100, 20);
            this.longitudTextBox.TabIndex = 3;
            // 
            // causaTextBox
            // 
            this.causaTextBox.Location = new System.Drawing.Point(215, 14);
            this.causaTextBox.Name = "causaTextBox";
            this.causaTextBox.Size = new System.Drawing.Size(100, 20);
            this.causaTextBox.TabIndex = 4;
            // 
            // fechaInicioDateTimePicker
            // 
            this.fechaInicioDateTimePicker.Location = new System.Drawing.Point(3, 57);
            this.fechaInicioDateTimePicker.Name = "fechaInicioDateTimePicker";
            this.fechaInicioDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioDateTimePicker.TabIndex = 5;
            // 
            // nivelIncidenciaTextBox
            // 
            this.nivelIncidenciaTextBox.Location = new System.Drawing.Point(321, 14);
            this.nivelIncidenciaTextBox.Name = "nivelIncidenciaTextBox";
            this.nivelIncidenciaTextBox.Size = new System.Drawing.Size(100, 20);
            this.nivelIncidenciaTextBox.TabIndex = 6;
            // 
            // carreteraTextBox5
            // 
            this.carreteraTextBox5.Location = new System.Drawing.Point(427, 14);
            this.carreteraTextBox5.Name = "carreteraTextBox5";
            this.carreteraTextBox5.Size = new System.Drawing.Size(100, 20);
            this.carreteraTextBox5.TabIndex = 7;
            // 
            // ciudadComboBox1
            // 
            this.ciudadComboBox1.FormattingEnabled = true;
            this.ciudadComboBox1.Location = new System.Drawing.Point(215, 57);
            this.ciudadComboBox1.Name = "ciudadComboBox1";
            this.ciudadComboBox1.Size = new System.Drawing.Size(121, 21);
            this.ciudadComboBox1.TabIndex = 8;
            this.ciudadComboBox1.SelectedIndexChanged += new System.EventHandler(this.ciudadComboBox1_SelectedIndexChanged);
            // 
            // provinciaComboBox
            // 
            this.provinciaComboBox.FormattingEnabled = true;
            this.provinciaComboBox.Location = new System.Drawing.Point(342, 57);
            this.provinciaComboBox.Name = "provinciaComboBox";
            this.provinciaComboBox.Size = new System.Drawing.Size(79, 21);
            this.provinciaComboBox.TabIndex = 9;
            this.provinciaComboBox.SelectedIndexChanged += new System.EventHandler(this.provinciaComboBox_SelectedIndexChanged);
            // 
            // regionComboBox
            // 
            this.regionComboBox.FormattingEnabled = true;
            this.regionComboBox.Location = new System.Drawing.Point(431, 57);
            this.regionComboBox.Name = "regionComboBox";
            this.regionComboBox.Size = new System.Drawing.Size(159, 21);
            this.regionComboBox.TabIndex = 10;
            this.regionComboBox.SelectedIndexChanged += new System.EventHandler(this.ciudadComboBox_SelectedIndexChanged);
            // 
            // tipoIncidenciaComboBox
            // 
            this.tipoIncidenciaComboBox.FormattingEnabled = true;
            this.tipoIncidenciaComboBox.Location = new System.Drawing.Point(555, 13);
            this.tipoIncidenciaComboBox.Name = "tipoIncidenciaComboBox";
            this.tipoIncidenciaComboBox.Size = new System.Drawing.Size(121, 21);
            this.tipoIncidenciaComboBox.TabIndex = 11;
            // 
            // guardarIncidenciaBTN
            // 
            this.guardarIncidenciaBTN.Location = new System.Drawing.Point(597, 54);
            this.guardarIncidenciaBTN.Name = "guardarIncidenciaBTN";
            this.guardarIncidenciaBTN.Size = new System.Drawing.Size(75, 23);
            this.guardarIncidenciaBTN.TabIndex = 12;
            this.guardarIncidenciaBTN.Text = "guardar";
            this.guardarIncidenciaBTN.UseVisualStyleBackColor = true;
            this.guardarIncidenciaBTN.Click += new System.EventHandler(this.guardarIncidenciaBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "latitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "longitud";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "causa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "nivelIncidencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "carretera";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "tipoIncidencia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "ciudad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "provincia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "region";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 116);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.latitudTextBox);
            this.panel2.Controls.Add(this.guardarIncidenciaBTN);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tipoIncidenciaComboBox);
            this.panel2.Controls.Add(this.longitudTextBox);
            this.panel2.Controls.Add(this.regionComboBox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.causaTextBox);
            this.panel2.Controls.Add(this.provinciaComboBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.fechaInicioDateTimePicker);
            this.panel2.Controls.Add(this.ciudadComboBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.nivelIncidenciaTextBox);
            this.panel2.Controls.Add(this.carreteraTextBox5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(93, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 100);
            this.panel2.TabIndex = 22;
            // 
            // IncidenciaViewManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(868, 616);
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "IncidenciaViewManager";
            this.Size = new System.Drawing.Size(868, 619);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox latitudTextBox;
        private System.Windows.Forms.TextBox longitudTextBox;
        private System.Windows.Forms.TextBox causaTextBox;
        private System.Windows.Forms.DateTimePicker fechaInicioDateTimePicker;
        private System.Windows.Forms.TextBox nivelIncidenciaTextBox;
        private System.Windows.Forms.TextBox carreteraTextBox5;
        private System.Windows.Forms.ComboBox ciudadComboBox1;
        private System.Windows.Forms.ComboBox provinciaComboBox;
        private System.Windows.Forms.ComboBox regionComboBox;
        private System.Windows.Forms.ComboBox tipoIncidenciaComboBox;
        private System.Windows.Forms.Button guardarIncidenciaBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
