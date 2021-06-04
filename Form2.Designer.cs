
namespace QR_Imagenes
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttoncargar = new System.Windows.Forms.Button();
            this.buttoncancelar = new System.Windows.Forms.Button();
            this.buttonguardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::QR_Imagenes.Properties.Resources.Mcbck;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttoncargar
            // 
            this.buttoncargar.BackColor = System.Drawing.Color.Transparent;
            this.buttoncargar.BackgroundImage = global::QR_Imagenes.Properties.Resources.btn_load;
            this.buttoncargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttoncargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttoncargar.FlatAppearance.BorderSize = 0;
            this.buttoncargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttoncargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttoncargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoncargar.Location = new System.Drawing.Point(10, 340);
            this.buttoncargar.Name = "buttoncargar";
            this.buttoncargar.Size = new System.Drawing.Size(110, 40);
            this.buttoncargar.TabIndex = 1;
            this.buttoncargar.Text = " ";
            this.buttoncargar.UseVisualStyleBackColor = false;
            this.buttoncargar.Click += new System.EventHandler(this.buttoncargar_Click);
            // 
            // buttoncancelar
            // 
            this.buttoncancelar.BackColor = System.Drawing.Color.Transparent;
            this.buttoncancelar.BackgroundImage = global::QR_Imagenes.Properties.Resources.btn_cancel;
            this.buttoncancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttoncancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttoncancelar.FlatAppearance.BorderSize = 0;
            this.buttoncancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttoncancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttoncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoncancelar.Location = new System.Drawing.Point(380, 340);
            this.buttoncancelar.Name = "buttoncancelar";
            this.buttoncancelar.Size = new System.Drawing.Size(110, 40);
            this.buttoncancelar.TabIndex = 2;
            this.buttoncancelar.Text = " ";
            this.buttoncancelar.UseVisualStyleBackColor = false;
            this.buttoncancelar.Click += new System.EventHandler(this.buttoncancelar_Click);
            // 
            // buttonguardar
            // 
            this.buttonguardar.BackColor = System.Drawing.Color.Transparent;
            this.buttonguardar.BackgroundImage = global::QR_Imagenes.Properties.Resources.btn_save_img;
            this.buttonguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonguardar.FlatAppearance.BorderSize = 0;
            this.buttonguardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonguardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonguardar.Location = new System.Drawing.Point(195, 340);
            this.buttonguardar.Name = "buttonguardar";
            this.buttonguardar.Size = new System.Drawing.Size(110, 40);
            this.buttonguardar.TabIndex = 3;
            this.buttonguardar.Text = " ";
            this.buttonguardar.UseVisualStyleBackColor = false;
            this.buttonguardar.Click += new System.EventHandler(this.buttonguardar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QR_Imagenes.Properties.Resources.MAIN_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(499, 386);
            this.Controls.Add(this.buttonguardar);
            this.Controls.Add(this.buttoncancelar);
            this.Controls.Add(this.buttoncargar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargar Dibujo";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttoncargar;
        private System.Windows.Forms.Button buttoncancelar;
        private System.Windows.Forms.Button buttonguardar;
    }
}