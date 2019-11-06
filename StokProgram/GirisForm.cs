using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace StokProgram
{
    public partial class GirisForm : DevExpress.XtraEditors.XtraForm
    {
        public GirisForm()
        {
            InitializeComponent();
            
        }
        TextBox txtKullanici = new TextBox();
        private void BtnYonetici_Click(object sender, EventArgs e)
        {
            KullaniciGirisForm kullanici = new KullaniciGirisForm();
            //kullanici giris formuna yonetici bilgisi gönderiyor 
            txtKullanici.Text = "yonetici";
            kullanici.kullaniciAdi = txtKullanici.Text;
            this.Hide();
            kullanici.ShowDialog();
        }

        private void BtnBolumYetkilisi_Click(object sender, EventArgs e)
        {
            KullaniciGirisForm kullanici = new KullaniciGirisForm();
            //kullanici giris formuna yetkili bilgisi gönderiyor 
            txtKullanici.Text = "yetkili";
            kullanici.kullaniciAdi = txtKullanici.Text;
            this.Hide();
            kullanici.ShowDialog();
        }

        private void BtnSatınAlmaGorevlisi_Click(object sender, EventArgs e)
        {
            KullaniciGirisForm kullanici = new KullaniciGirisForm();
            //kullanici giris formuna gorevli bilgisi gönderiyor 
            txtKullanici.Text = "gorevli";
            kullanici.kullaniciAdi = txtKullanici.Text;
            this.Hide();
            kullanici.ShowDialog();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {

        }
    }
}