namespace StokProgram
{
    partial class GirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            this.BtnYonetici = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSatınAlmaGorevlisi = new DevExpress.XtraEditors.SimpleButton();
            this.BtnBolumYetkilisi = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BtnYonetici
            // 
            this.BtnYonetici.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYonetici.Appearance.Options.UseFont = true;
            this.BtnYonetici.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnYonetici.ImageOptions.SvgImage")));
            this.BtnYonetici.Location = new System.Drawing.Point(136, 200);
            this.BtnYonetici.Name = "BtnYonetici";
            this.BtnYonetici.Size = new System.Drawing.Size(202, 183);
            this.BtnYonetici.TabIndex = 3;
            this.BtnYonetici.Text = "YÖNETİCİ GİRİŞİ";
            this.BtnYonetici.Click += new System.EventHandler(this.BtnYonetici_Click);
            // 
            // BtnSatınAlmaGorevlisi
            // 
            this.BtnSatınAlmaGorevlisi.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSatınAlmaGorevlisi.Appearance.Options.UseFont = true;
            this.BtnSatınAlmaGorevlisi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSatınAlmaGorevlisi.ImageOptions.SvgImage")));
            this.BtnSatınAlmaGorevlisi.Location = new System.Drawing.Point(403, 200);
            this.BtnSatınAlmaGorevlisi.Name = "BtnSatınAlmaGorevlisi";
            this.BtnSatınAlmaGorevlisi.Size = new System.Drawing.Size(202, 183);
            this.BtnSatınAlmaGorevlisi.TabIndex = 4;
            this.BtnSatınAlmaGorevlisi.Text = "  SATIN ALMA \r\nGÖREVLİSİ GİRİŞİ";
            this.BtnSatınAlmaGorevlisi.Click += new System.EventHandler(this.BtnSatınAlmaGorevlisi_Click);
            // 
            // BtnBolumYetkilisi
            // 
            this.BtnBolumYetkilisi.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBolumYetkilisi.Appearance.Options.UseFont = true;
            this.BtnBolumYetkilisi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnBolumYetkilisi.ImageOptions.SvgImage")));
            this.BtnBolumYetkilisi.Location = new System.Drawing.Point(657, 200);
            this.BtnBolumYetkilisi.Name = "BtnBolumYetkilisi";
            this.BtnBolumYetkilisi.Size = new System.Drawing.Size(202, 183);
            this.BtnBolumYetkilisi.TabIndex = 5;
            this.BtnBolumYetkilisi.Text = "BÖLÜM \r\nYETKİLİSİ GİRİŞİ";
            this.BtnBolumYetkilisi.Click += new System.EventHandler(this.BtnBolumYetkilisi_Click);
            // 
            // GirisForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Silver;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(991, 585);
            this.Controls.Add(this.BtnBolumYetkilisi);
            this.Controls.Add(this.BtnSatınAlmaGorevlisi);
            this.Controls.Add(this.BtnYonetici);
            this.Name = "GirisForm";
            this.Text = "GirisForm";
            this.Load += new System.EventHandler(this.GirisForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnYonetici;
        private DevExpress.XtraEditors.SimpleButton BtnSatınAlmaGorevlisi;
        private DevExpress.XtraEditors.SimpleButton BtnBolumYetkilisi;
    }
}