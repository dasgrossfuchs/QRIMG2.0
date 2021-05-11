
namespace QR_Imagenes
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.botonayuda = new System.Windows.Forms.Button();
            this.botonsalir = new System.Windows.Forms.Button();
            this.botoncargar = new System.Windows.Forms.Button();
            this.botonguardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botonguardarimagen = new System.Windows.Forms.Button();
            this.dimension = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botoncolor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // botonayuda
            // 
            this.botonayuda.Location = new System.Drawing.Point(441, 27);
            this.botonayuda.Margin = new System.Windows.Forms.Padding(4);
            this.botonayuda.Name = "botonayuda";
            this.botonayuda.Size = new System.Drawing.Size(100, 28);
            this.botonayuda.TabIndex = 0;
            this.botonayuda.Text = "Ayuda";
            this.botonayuda.UseVisualStyleBackColor = true;
            this.botonayuda.Click += new System.EventHandler(this.botonayuda_Click);
            // 
            // botonsalir
            // 
            this.botonsalir.Location = new System.Drawing.Point(672, 368);
            this.botonsalir.Margin = new System.Windows.Forms.Padding(4);
            this.botonsalir.Name = "botonsalir";
            this.botonsalir.Size = new System.Drawing.Size(100, 28);
            this.botonsalir.TabIndex = 1;
            this.botonsalir.Text = "Salir";
            this.botonsalir.UseVisualStyleBackColor = true;
            this.botonsalir.Click += new System.EventHandler(this.botonsalir_Click);
            // 
            // botoncargar
            // 
            this.botoncargar.Location = new System.Drawing.Point(651, 271);
            this.botoncargar.Margin = new System.Windows.Forms.Padding(4);
            this.botoncargar.Name = "botoncargar";
            this.botoncargar.Size = new System.Drawing.Size(135, 28);
            this.botoncargar.TabIndex = 2;
            this.botoncargar.Text = "Abrir codigo";
            this.botoncargar.UseVisualStyleBackColor = true;
            this.botoncargar.Click += new System.EventHandler(this.botoncargar_Click);
            // 
            // botonguardar
            // 
            this.botonguardar.Location = new System.Drawing.Point(651, 199);
            this.botonguardar.Margin = new System.Windows.Forms.Padding(4);
            this.botonguardar.Name = "botonguardar";
            this.botonguardar.Size = new System.Drawing.Size(135, 28);
            this.botonguardar.TabIndex = 3;
            this.botonguardar.Text = "Guardar codigo";
            this.botonguardar.UseVisualStyleBackColor = true;
            this.botonguardar.Click += new System.EventHandler(this.botonguardar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(29, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 369);
            this.panel1.TabIndex = 5;
            // 
            // botonguardarimagen
            // 
            this.botonguardarimagen.Location = new System.Drawing.Point(651, 235);
            this.botonguardarimagen.Margin = new System.Windows.Forms.Padding(4);
            this.botonguardarimagen.Name = "botonguardarimagen";
            this.botonguardarimagen.Size = new System.Drawing.Size(135, 28);
            this.botonguardarimagen.TabIndex = 7;
            this.botonguardarimagen.Text = "Guardar imagen";
            this.botonguardarimagen.UseVisualStyleBackColor = true;
            this.botonguardarimagen.Click += new System.EventHandler(this.botonguardarimagen_Click);
            // 
            // dimension
            // 
            this.dimension.BackColor = System.Drawing.SystemColors.Control;
            this.dimension.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dimension.FormattingEnabled = true;
            this.dimension.Items.AddRange(new object[] {
            "1 x 1",
            "2 x 2",
            "3 x 3",
            "4 x 4",
            "5 x 5",
            "6 x 6",
            "7 x 7",
            "8 x 8",
            "9 x 9",
            "10 x 10",
            "11 x 11",
            "12 x 12",
            "13 x 13",
            "14 x 14",
            "15 x 15",
            "16 x 16"});
            this.dimension.Location = new System.Drawing.Point(441, 92);
            this.dimension.Margin = new System.Windows.Forms.Padding(4);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(148, 24);
            this.dimension.TabIndex = 8;
            this.dimension.SelectedIndexChanged += new System.EventHandler(this.dimension_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dimensiones";
            // 
            // botoncolor
            // 
            this.botoncolor.BackColor = System.Drawing.Color.White;
            this.botoncolor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botoncolor.Location = new System.Drawing.Point(441, 183);
            this.botoncolor.Margin = new System.Windows.Forms.Padding(4);
            this.botoncolor.Name = "botoncolor";
            this.botoncolor.Size = new System.Drawing.Size(149, 44);
            this.botoncolor.TabIndex = 11;
            this.botoncolor.UseVisualStyleBackColor = false;
            this.botoncolor.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Color seleccionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "#FFFFFF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(437, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(441, 330);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 15;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 22);
            this.textBox1.TabIndex = 15;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(437, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Seleccionar color";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QR_Imagenes.Properties.Resources.color_dropper;
            this.pictureBox2.Location = new System.Drawing.Point(491, 262);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(617, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 405);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botoncolor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dimension);
            this.Controls.Add(this.botonguardarimagen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonguardar);
            this.Controls.Add(this.botoncargar);
            this.Controls.Add(this.botonsalir);
            this.Controls.Add(this.botonayuda);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qr-Imagenes";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonayuda;
        private System.Windows.Forms.Button botonsalir;
        private System.Windows.Forms.Button botoncargar;
        private System.Windows.Forms.Button botonguardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button botonguardarimagen;
        private System.Windows.Forms.ComboBox dimension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botoncolor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

