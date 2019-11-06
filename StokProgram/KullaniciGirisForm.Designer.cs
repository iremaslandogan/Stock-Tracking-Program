namespace StokProgram
{
    partial class KullaniciGirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciGirisForm));
            this.btnKullaniciGiris = new DevExpress.XtraEditors.SimpleButton();
            this.lblKullaniciSifre = new DevExpress.XtraEditors.LabelControl();
            this.lblKulllaniciAd = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciAd = new DevExpress.XtraEditors.TextEdit();
            this.gboxKullanici = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAd.Properties)).BeginInit();
            this.gboxKullanici.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKullaniciGiris
            // 
            this.btnKullaniciGiris.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciGiris.Appearance.Options.UseFont = true;
            this.btnKullaniciGiris.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKullaniciGiris.Location = new System.Drawing.Point(247, 171);
            this.btnKullaniciGiris.Name = "btnKullaniciGiris";
            this.btnKullaniciGiris.Size = new System.Drawing.Size(94, 29);
            this.btnKullaniciGiris.TabIndex = 4;
            this.btnKullaniciGiris.Text = "GİRİŞ";
            this.btnKullaniciGiris.Click += new System.EventHandler(this.btnKullaniciGiris_Click);
            // 
            // lblKullaniciSifre
            // 
            this.lblKullaniciSifre.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciSifre.Appearance.Options.UseFont = true;
            this.lblKullaniciSifre.Location = new System.Drawing.Point(112, 124);
            this.lblKullaniciSifre.Name = "lblKullaniciSifre";
            this.lblKullaniciSifre.Size = new System.Drawing.Size(45, 20);
            this.lblKullaniciSifre.TabIndex = 3;
            this.lblKullaniciSifre.Text = "ŞİFRE";
            // 
            // lblKulllaniciAd
            // 
            this.lblKulllaniciAd.Appearance.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKulllaniciAd.Appearance.Options.UseFont = true;
            this.lblKulllaniciAd.Location = new System.Drawing.Point(112, 82);
            this.lblKulllaniciAd.Name = "lblKulllaniciAd";
            this.lblKulllaniciAd.Size = new System.Drawing.Size(119, 20);
            this.lblKulllaniciAd.TabIndex = 2;
            this.lblKulllaniciAd.Text = "KULLANICI ADI";
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.Location = new System.Drawing.Point(247, 121);
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.Properties.PasswordChar = '*';
            this.txtKullaniciSifre.Size = new System.Drawing.Size(125, 22);
            this.txtKullaniciSifre.TabIndex = 1;
            // 
            // txtKullaniciAd
            // 
            this.txtKullaniciAd.Location = new System.Drawing.Point(247, 80);
            this.txtKullaniciAd.Name = "txtKullaniciAd";
            this.txtKullaniciAd.Size = new System.Drawing.Size(125, 22);
            this.txtKullaniciAd.TabIndex = 0;
            this.txtKullaniciAd.EditValueChanged += new System.EventHandler(this.txtKullaniciAd_EditValueChanged);
            // 
            // gboxKullanici
            // 
            this.gboxKullanici.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gboxKullanici.Controls.Add(this.btnKullaniciGiris);
            this.gboxKullanici.Controls.Add(this.txtKullaniciAd);
            this.gboxKullanici.Controls.Add(this.lblKullaniciSifre);
            this.gboxKullanici.Controls.Add(this.txtKullaniciSifre);
            this.gboxKullanici.Controls.Add(this.lblKulllaniciAd);
            this.gboxKullanici.Location = new System.Drawing.Point(494, 238);
            this.gboxKullanici.Name = "gboxKullanici";
            this.gboxKullanici.Size = new System.Drawing.Size(403, 252);
            this.gboxKullanici.TabIndex = 2;
            this.gboxKullanici.TabStop = false;
            this.gboxKullanici.Text = "GİRİŞ";
            // 
            // KullaniciGirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(1015, 565);
            this.Controls.Add(this.gboxKullanici);
            this.Name = "KullaniciGirisForm";
            this.Text = "Kullanıcı Giriş";
            this.Load += new System.EventHandler(this.SatınAlmaGorevliGirisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAd.Properties)).EndInit();
            this.gboxKullanici.ResumeLayout(false);
            this.gboxKullanici.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnKullaniciGiris;
        private DevExpress.XtraEditors.LabelControl lblKullaniciSifre;
        private DevExpress.XtraEditors.LabelControl lblKulllaniciAd;
        private DevExpress.XtraEditors.TextEdit txtKullaniciSifre;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAd;
        private System.Windows.Forms.GroupBox gboxKullanici;
    }
}