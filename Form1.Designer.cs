
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.botonayuda = new System.Windows.Forms.Button();
            this.botonsalir = new System.Windows.Forms.Button();
            this.botoncargar = new System.Windows.Forms.Button();
            this.botonguardar = new System.Windows.Forms.Button();
            this.imagenvista = new System.Windows.Forms.PictureBox();
            this.botonguardarimagen = new System.Windows.Forms.Button();
            this.dimension = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gotero = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagenvista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gotero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // botonayuda
            // 
            this.botonayuda.Location = new System.Drawing.Point(448, 27);
            this.botonayuda.Name = "botonayuda";
            this.botonayuda.Size = new System.Drawing.Size(75, 23);
            this.botonayuda.TabIndex = 0;
            this.botonayuda.Text = "Ayuda";
            this.botonayuda.UseVisualStyleBackColor = true;
            this.botonayuda.Click += new System.EventHandler(this.botonayuda_Click);
            // 
            // botonsalir
            // 
            this.botonsalir.Location = new System.Drawing.Point(736, 411);
            this.botonsalir.Name = "botonsalir";
            this.botonsalir.Size = new System.Drawing.Size(75, 23);
            this.botonsalir.TabIndex = 1;
            this.botonsalir.Text = "Salir";
            this.botonsalir.UseVisualStyleBackColor = true;
            this.botonsalir.Click += new System.EventHandler(this.botonsalir_Click);
            // 
            // botoncargar
            // 
            this.botoncargar.Location = new System.Drawing.Point(692, 226);
            this.botoncargar.Name = "botoncargar";
            this.botoncargar.Size = new System.Drawing.Size(101, 23);
            this.botoncargar.TabIndex = 2;
            this.botoncargar.Text = "Abrir codigo";
            this.botoncargar.UseVisualStyleBackColor = true;
            this.botoncargar.Click += new System.EventHandler(this.botoncargar_Click);
            // 
            // botonguardar
            // 
            this.botonguardar.Location = new System.Drawing.Point(692, 168);
            this.botonguardar.Name = "botonguardar";
            this.botonguardar.Size = new System.Drawing.Size(101, 23);
            this.botonguardar.TabIndex = 3;
            this.botonguardar.Text = "Guardar codigo";
            this.botonguardar.UseVisualStyleBackColor = true;
            this.botonguardar.Click += new System.EventHandler(this.botonguardar_Click);
            // 
            // imagenvista
            // 
            this.imagenvista.Location = new System.Drawing.Point(12, 12);
            this.imagenvista.Name = "imagenvista";
            this.imagenvista.Size = new System.Drawing.Size(400, 400);
            this.imagenvista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagenvista.TabIndex = 18;
            this.imagenvista.TabStop = false;
            this.imagenvista.Click += new System.EventHandler(this.imagenvista_Click);
            this.imagenvista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagenvista_MouseDown);
            this.imagenvista.MouseLeave += new System.EventHandler(this.imagenvista_MouseLeave);
            this.imagenvista.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagenvista_MouseMove);
            this.imagenvista.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagenvista_MouseLeave);
            // 
            // botonguardarimagen
            // 
            this.botonguardarimagen.Location = new System.Drawing.Point(692, 197);
            this.botonguardarimagen.Name = "botonguardarimagen";
            this.botonguardarimagen.Size = new System.Drawing.Size(101, 23);
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
            this.dimension.Location = new System.Drawing.Point(448, 69);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(112, 21);
            this.dimension.TabIndex = 8;
            this.dimension.SelectedIndexChanged += new System.EventHandler(this.dimension_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dimensiones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(445, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(448, 388);
            this.textBox1.MaxLength = 15;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // gotero
            // 
            this.gotero.Image = global::QR_Imagenes.Properties.Resources.color_dropper;
            this.gotero.Location = new System.Drawing.Point(586, 290);
            this.gotero.Name = "gotero";
            this.gotero.Size = new System.Drawing.Size(40, 40);
            this.gotero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gotero.TabIndex = 17;
            this.gotero.TabStop = false;
            this.gotero.Click += new System.EventHandler(this.gotero_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(661, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(448, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Paleta de colores";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(494, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(540, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 23;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(586, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 24;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(448, 198);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 25;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(494, 198);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 26;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(540, 198);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 27;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(586, 198);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 40);
            this.button8.TabIndex = 28;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(448, 244);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 40);
            this.button9.TabIndex = 29;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(494, 244);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 40);
            this.button10.TabIndex = 30;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(540, 244);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(40, 40);
            this.button11.TabIndex = 31;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(586, 243);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(40, 40);
            this.button12.TabIndex = 32;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(448, 290);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(40, 40);
            this.button13.TabIndex = 33;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(494, 290);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 40);
            this.button14.TabIndex = 34;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(540, 290);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(40, 40);
            this.button15.TabIndex = 35;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(180, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(661, 290);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 446);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.imagenvista);
            this.Controls.Add(this.gotero);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dimension);
            this.Controls.Add(this.botonguardarimagen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botonguardar);
            this.Controls.Add(this.botoncargar);
            this.Controls.Add(this.botonsalir);
            this.Controls.Add(this.botonayuda);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qr-Imagenes";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagenvista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gotero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonayuda;
        private System.Windows.Forms.Button botonsalir;
        private System.Windows.Forms.Button botoncargar;
        private System.Windows.Forms.Button botonguardar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button botonguardarimagen;
        private System.Windows.Forms.ComboBox dimension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox gotero;
        private System.Windows.Forms.PictureBox imagenvista;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

