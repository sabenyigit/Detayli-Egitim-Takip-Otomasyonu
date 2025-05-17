namespace Eğitim_Takip_Otomasyonu
{
    partial class OgretmenDevamsizlikIslemleriFormu
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
            this.cmbOgrenciSec = new System.Windows.Forms.ComboBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.nudDersSaati = new System.Windows.Forms.NumericUpDown();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDersSaati)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbOgrenciSec
            // 
            this.cmbOgrenciSec.FormattingEnabled = true;
            this.cmbOgrenciSec.Location = new System.Drawing.Point(44, 41);
            this.cmbOgrenciSec.Name = "cmbOgrenciSec";
            this.cmbOgrenciSec.Size = new System.Drawing.Size(211, 21);
            this.cmbOgrenciSec.TabIndex = 0;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(44, 68);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(211, 20);
            this.dtpTarih.TabIndex = 1;
            // 
            // nudDersSaati
            // 
            this.nudDersSaati.Location = new System.Drawing.Point(44, 94);
            this.nudDersSaati.Name = "nudDersSaati";
            this.nudDersSaati.Size = new System.Drawing.Size(211, 20);
            this.nudDersSaati.TabIndex = 2;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(106, 143);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 80);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yukarıda derse girmeyen öğrencinin\r\nadı soyadını seçebilir, hangi ders \r\nkaç saat" +
    " yok yazıldığını\r\nsisteme girebilirsiniz.";
            // 
            // OgretmenDevamsizlikIslemleriFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(301, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.nudDersSaati);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.cmbOgrenciSec);
            this.Name = "OgretmenDevamsizlikIslemleriFormu";
            this.Text = "OgretmenDevamsizlikIslemleriFormu";
            this.Load += new System.EventHandler(this.OgretmenDevamsizlikIslemleriFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDersSaati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOgrenciSec;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.NumericUpDown nudDersSaati;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label1;
    }
}