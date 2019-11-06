using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using System.Data;
using System.Data.SqlClient;

namespace StokProgram
{
    public partial class KullaniciGirisForm : DevExpress.XtraEditors.XtraForm
    {       
        public string kullaniciAdi { get; set; }
        public KullaniciGirisForm()
        {         
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(KullaniciGirisForm_FormClosed);
        }

        private void SatınAlmaGorevliGirisForm_Load(object sender, EventArgs e)
        {

        }

        private void txtKullaniciAd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void KullaniciGirisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisForm grs = new GirisForm();
            grs.Show();
        }
        
        //textboxları işlemlerden sonra temizlemek için kullanılan fonksiyon
        public void textTemizle()
        {
            txtKullaniciAd.Text = null;
            txtKullaniciSifre.Text = null;
        }
        private void btnKullaniciGiris_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OFNCK1V;Initial Catalog=StokTakip;Integrated Security=True");

            //giris formundan gönderilen bilgiye göre yönetici, görevli, yetkili olup olmadığına karar verip işlemi gerçekleştiriyor.
            if (kullaniciAdi == "yonetici")
            {
                conn.Open();
                SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + txtKullaniciAd.Text + "' AND Sifre = '" + txtKullaniciSifre.Text + "' AND Yetki = '"+"Yönetici"+"'", conn);
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    YoneticiEkran yonetici = new YoneticiEkran();
                    yonetici.Show();
                    this.Hide();                  
                }
                else
                    MessageBox.Show("Kullanıcı Adı veya Şifre yanlış");

                conn.Close();
            }           
            else if (kullaniciAdi == "yetkili")
            {
                conn.Open();
                SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + txtKullaniciAd.Text + "' AND Sifre = '" + txtKullaniciSifre.Text + "'AND Yetki ='"+ "Yetkili" + "'", conn);
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    YetkiliEkran yetkili = new YetkiliEkran();
                    yetkili.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Kullanıcı Adı veya Şifre yanlış");
                
                conn.Close();
            }
            else if (kullaniciAdi == "gorevli")
            {
                conn.Open();
                SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + txtKullaniciAd.Text + "' AND Sifre = '" + txtKullaniciSifre.Text + "' AND Yetki ='" + "Görevli" + "'", conn);
                SqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    GorevliEkran gorevli = new GorevliEkran();
                    gorevli.kullaniciAd = txtKullaniciAd.Text;
                    this.Hide();
                    gorevli.ShowDialog();
                }
                else
                    MessageBox.Show("Kullanıcı Adı veya Şifre yanlış");

                conn.Close();
            }
            textTemizle();
        }
    }
}