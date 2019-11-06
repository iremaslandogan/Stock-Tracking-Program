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

namespace StokProgram
{
    public partial class YoneticiEkran : DevExpress.XtraEditors.XtraForm
    {
        SQLClass SQL = new SQLClass();
        public YoneticiEkran()
        {
            InitializeComponent();
            KullanicilarTabloYenile();
            StokTabloYenile();
            BilgisayarZimmetListeYenile();
            BilesenZimmetListeYenile();
            this.FormClosed += new FormClosedEventHandler(YoneticiEkran_FormClosed);
        }
        private void YoneticiEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisForm grs = new GirisForm();
            grs.Show();
        }
        // textboxları temizlemek için kulllanılan fonksiyon
        public void textTemizle()
        {
            txtAd.Text = null;
            txtSoyad.Text = null;
            txtKullaniciAdi.Text = null;
            txtSifre.Text = null;
            rdYetkili.Checked = false;
            rdGorevli.Checked = false;
            cbxBirim.Text = null;
            txtKullaniciAd.Text = null;
            txtUrunAdi.Text = null;
            txtAdet.Text = null;
            txtStokUrunAd.Text = null;
            txtKisiZimmetKullaniciAdi.Text = null;
        }

        //sql tablosuna kullanıcı ekleme işlemi yapan buton
        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text!="" && txtSoyad.Text!="" && txtKullaniciAdi.Text!="" && txtSifre.Text!="" && cbxBirim.Text!="")
            {
                if (rdYetkili.Checked == true)
                {
                    if (cbxBirim.Text == "Bilgisayar")
                    {
                        string Birim = "Bilgisayar";
                        cbxBirim.Text = "1";
                        SQL.YeniYetkiliEkle(txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtSifre.Text, cbxBirim.Text, Birim);
                    }
                    else if (cbxBirim.Text == "Bilgisayar Bileşenleri")
                    {
                        string Birim = "PC Bileşenleri";
                        cbxBirim.Text = "2";
                        SQL.YeniYetkiliEkle(txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtSifre.Text, cbxBirim.Text, Birim);
                    }
                    else
                        MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
                }
                if (rdGorevli.Checked == true)
                {
                    if (cbxBirim.Text == "Bilgisayar")
                    {
                        string Birim = "Bilgisayar";
                        cbxBirim.Text = "1";
                        SQL.YeniGorevliEkle(txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtSifre.Text, cbxBirim.Text, Birim);
                    }
                    else if (cbxBirim.Text == "PC Bileşenleri")
                    {
                        string Birim = "Bilgisayar Bileşenleri";
                        cbxBirim.Text = "2";
                        SQL.YeniGorevliEkle(txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtSifre.Text, cbxBirim.Text, Birim);
                    }
                    else
                        MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
                }
            }           
            else               
                 MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            KullanicilarTabloYenile();
            textTemizle();
        }

        private void YoneticiEkran_Load(object sender, EventArgs e)
        {

        }
        //kullanıcı silme işlemini gerçekleştiren buton
        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if(txtKullaniciAd.Text!="")
            {
                SQL.KullaniciSil(txtKullaniciAd.Text);                             
            }
            else
            {
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
            }                         
            KullanicilarTabloYenile();
            textTemizle();
        }

        public void KullanicilarTabloYenile()
        {
            dgwKullanici.DataSource = SQL.KullanicilariGetir();
            dgvKullaniciSilListe.DataSource = SQL.KullanicilariGetir();
        }
        public void StokTabloYenile()
        {
            dgwStok.DataSource = SQL.StokGetir();
        }
        public void UrunTabloYenile()
        {
            dgwUrun.DataSource = SQL.SeciliUrunListele(txtUrunAdi.Text);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dgwUrun.DataSource = SQL.SeciliUrunListele(txtUrunAdi.Text);
            textTemizle();
        }
        // ürünlerin adetini arttırmak için kullanılan buton
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtAdet.Text!="" && txtStokUrunAd.Text!="")
            {
                SQL.StokEkle(txtAdet.Text, txtStokUrunAd.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
            UrunTabloYenile();
            StokTabloYenile();
            textTemizle();
        }
        // ürünlerin adetini azaltmak için kullanılan buton
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text != "" && txtStokUrunAd.Text != "")
            {
                SQL.StokSil(txtAdet.Text, txtStokUrunAd.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
            
            UrunTabloYenile();
            StokTabloYenile();
            textTemizle();
        }
        public void KisiZimmetListeYenile()
        {
            dgvKisiZimmetListe.DataSource = SQL.KisiZimmetListele(txtKisiZimmetKullaniciAdi.Text);
        }
        private void btnKisiZimmetListe_Click(object sender, EventArgs e)
        {
            KisiZimmetListeYenile();
            textTemizle();
        }
        public void BilgisayarZimmetListeYenile()
        {
            dgvBilgisayarZimmetListe.DataSource = SQL.BilgisayarZimmetListele();
        }
        public void BilesenZimmetListeYenile()
        {
            dgvBilesenZimmetListe.DataSource = SQL.BilesenZimmetListele();
        }
    }
}