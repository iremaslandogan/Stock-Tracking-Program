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
    public partial class YetkiliEkran : DevExpress.XtraEditors.XtraForm
    {
        SQLClass SQL = new SQLClass();
        public YetkiliEkran()
        {
            InitializeComponent();
            BilgisayarZimmetListeYenile();
            BilesenZimmetListeYenile();
            DepoYenile();
            this.FormClosed += new FormClosedEventHandler(YetkiliEkran_FormClosed);
        }
        private void YetkiliEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisForm grs = new GirisForm();
            grs.Show();
        }

        private void YetkiliEkran_Load(object sender, EventArgs e)
        {

        }
        // textboxları işlemlerden sonra temizlemek için fonksiyon
        public void textTemizle()
        {
            txtUrunAd.Text = null;
            txtUrunZimmetAd.Text = null;
            txtKullaniciZimmetAd.Text = null;
            dtZimmetlemeTarihi.Text = null;
            txtZimmetBilgi.Text = null;
            txtKisiZimmetKullaniciAdi.Text = null;
            txtUrunZimmetAd.Text = null;
            txtDepoZimmetBilgi.Text = null;
            txtDepoUrunAdi.Text = null;
            txtDepoBilgi.Text = null;
        }
        public void BilgisayarZimmetListeYenile()
        {
            dgvBilgisayarZimmetListe.DataSource = SQL.BilgisayarZimmetListele();           
        }
        public void BilesenZimmetListeYenile()
        {
            dgvBilesenZimmetListe.DataSource = SQL.BilesenZimmetListele();
        }
        public void KisiZimmetListeYenile()
        {
            dgvKisiZimmetListe.DataSource = SQL.KisiZimmetListele(txtKisiZimmetKullaniciAdi.Text);
            textTemizle();
        }
        public void UrunTabloYenile()
        {
            dgvUrunler.DataSource = SQL.SeciliUrunListele(txtUrunAd.Text);
            textTemizle();
        }
        public void DepoUrunTabloYenile()
        {
            dgvDepoUrun.DataSource = SQL.KisiZimmetListele(txtUrunAd.Text);
            textTemizle();
        }
        public void DepoYenile()
        {
            dgvDepo.DataSource = SQL.DepoListele();
        }
        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            UrunTabloYenile();
        }
        //Görevlileri listelemek için
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dgvGorevliler.DataSource = SQL.GorevliListele();
        }
        //Ürün zimmetlem için kullanılan buton
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtUrunZimmetAd.Text!="" && txtKullaniciZimmetAd.Text!="" && dtZimmetlemeTarihi.Text!="" && txtZimmetBilgi.Text!="")
            {
                SQL.UrunZimmetle(txtUrunZimmetAd.Text, txtKullaniciZimmetAd.Text, txtZimmetBilgi.Text, dtZimmetlemeTarihi.Text);                
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            BilgisayarZimmetListeYenile();
            BilesenZimmetListeYenile();
            KisiZimmetListeYenile();
            textTemizle();
        }

        private void btnKisiZimmetListe_Click(object sender, EventArgs e)
        {
            KisiZimmetListeYenile();
            textTemizle();
        }

        private void btnDepoUrunListele_Click(object sender, EventArgs e)
        {
            DepoUrunTabloYenile();
        }
        //Depoya ürün eklemek içişn kullanılan buton
        private void btnDepoEkle_Click(object sender, EventArgs e)
        {
            if(txtDepoUrunAdi.Text!="" && txtDepoZimmetBilgi.Text!="")
            {
                SQL.DepoEkle(txtDepoUrunAdi.Text, txtDepoZimmetBilgi.Text,txtDepoBilgi.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            DepoYenile();
            textTemizle();
        }

        private void lblKisiZimmetKullaniciAdi_Click(object sender, EventArgs e)
        {

        }

        private void txtKisiZimmetKullaniciAdi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tabNavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}