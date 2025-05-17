namespace Eğitim_Takip_Otomasyonu
{
    partial class velibilgi
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
            this.pnlGiris = new System.Windows.Forms.Panel();
            this.lblHosgeldiniz = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.picGuvenlikKodu = new System.Windows.Forms.PictureBox();
            this.txtGuvenlikKodu = new System.Windows.Forms.TextBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNotlar = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSinavTakvimi = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            this.pnlGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGuvenlikKodu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotlar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavTakvimi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGiris
            // 
            this.pnlGiris.Controls.Add(this.lblHosgeldiniz);
            this.pnlGiris.Controls.Add(this.label3);
            this.pnlGiris.Controls.Add(this.txtKullaniciAdi);
            this.pnlGiris.Controls.Add(this.picGuvenlikKodu);
            this.pnlGiris.Controls.Add(this.txtGuvenlikKodu);
            this.pnlGiris.Controls.Add(this.btnSorgula);
            this.pnlGiris.Controls.Add(this.label4);
            this.pnlGiris.Location = new System.Drawing.Point(168, 12);
            this.pnlGiris.Name = "pnlGiris";
            this.pnlGiris.Size = new System.Drawing.Size(486, 200);
            this.pnlGiris.TabIndex = 0;
            // 
            // lblHosgeldiniz
            // 
            this.lblHosgeldiniz.AutoSize = true;
            this.lblHosgeldiniz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblHosgeldiniz.Location = new System.Drawing.Point(20, 20);
            this.lblHosgeldiniz.Name = "lblHosgeldiniz";
            this.lblHosgeldiniz.Size = new System.Drawing.Size(387, 24);
            this.lblHosgeldiniz.TabIndex = 6;
            this.lblHosgeldiniz.Text = "Veli Bilgilendirme Sistemine Hoşgeldiniz";
            this.lblHosgeldiniz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Öğrenci Numarası:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(150, 67);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 23);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // picGuvenlikKodu
            // 
            this.picGuvenlikKodu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGuvenlikKodu.Location = new System.Drawing.Point(150, 100);
            this.picGuvenlikKodu.Name = "picGuvenlikKodu";
            this.picGuvenlikKodu.Size = new System.Drawing.Size(150, 50);
            this.picGuvenlikKodu.TabIndex = 2;
            this.picGuvenlikKodu.TabStop = false;
            this.picGuvenlikKodu.Click += new System.EventHandler(this.picGuvenlikKodu_Click);
            // 
            // txtGuvenlikKodu
            // 
            this.txtGuvenlikKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuvenlikKodu.Location = new System.Drawing.Point(150, 157);
            this.txtGuvenlikKodu.Name = "txtGuvenlikKodu";
            this.txtGuvenlikKodu.Size = new System.Drawing.Size(150, 23);
            this.txtGuvenlikKodu.TabIndex = 4;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSorgula.Location = new System.Drawing.Point(306, 153);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(150, 30);
            this.btnSorgula.TabIndex = 5;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(20, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Güvenlik Kodu:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvNotlar);
            this.panel1.Location = new System.Drawing.Point(12, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 300);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not ve Devamsızlık Bilgileri";
            // 
            // dgvNotlar
            // 
            this.dgvNotlar.AllowUserToAddRows = false;
            this.dgvNotlar.AllowUserToDeleteRows = false;
            this.dgvNotlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotlar.Location = new System.Drawing.Point(7, 40);
            this.dgvNotlar.Name = "dgvNotlar";
            this.dgvNotlar.ReadOnly = true;
            this.dgvNotlar.Size = new System.Drawing.Size(760, 250);
            this.dgvNotlar.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvSinavTakvimi);
            this.panel2.Location = new System.Drawing.Point(12, 530);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 250);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sınav Takvimi";
            // 
            // dgvSinavTakvimi
            // 
            this.dgvSinavTakvimi.AllowUserToAddRows = false;
            this.dgvSinavTakvimi.AllowUserToDeleteRows = false;
            this.dgvSinavTakvimi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinavTakvimi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinavTakvimi.Location = new System.Drawing.Point(7, 40);
            this.dgvSinavTakvimi.Name = "dgvSinavTakvimi";
            this.dgvSinavTakvimi.ReadOnly = true;
            this.dgvSinavTakvimi.Size = new System.Drawing.Size(760, 200);
            this.dgvSinavTakvimi.TabIndex = 3;
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(695, 790);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(93, 28);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // velibilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 830);
            this.Controls.Add(this.pnlGiris);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnKapat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "velibilgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veli Bilgilendirme Sistemi";
            this.pnlGiris.ResumeLayout(false);
            this.pnlGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGuvenlikKodu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotlar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavTakvimi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGiris;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.PictureBox picGuvenlikKodu;
        private System.Windows.Forms.TextBox txtGuvenlikKodu;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvNotlar;
        private System.Windows.Forms.DataGridView dgvSinavTakvimi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label lblHosgeldiniz;
    }
}