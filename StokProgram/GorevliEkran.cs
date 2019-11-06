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
    public partial class GorevliEkran : DevExpress.XtraEditors.XtraForm
    {
        SQLClass SQL = new SQLClass();
        public string kullaniciAd { get; set; }
        TextBox kullanici = new TextBox();
        public GorevliEkran()
        {
            InitializeComponent();
            StokTabloYenile();
            this.FormClosed += new FormClosedEventHandler(GorevliEkran_FormClosed);
        }
        //textboxları temizlemek için kullanılan fonksiyon
        public void textTemizle()
        {
            txtUrunAdi.Text = null;
            txtUrunBirimFiyati.Text = null;
            dtSatinAlmaTarihi.Text = null;
            txtSatinAlinanFirma.Text = null;
            txtRam.Text = null;
            txtIslemci.Text = null;
            txtEkranKarti.Text = null;
            txtIsletimSistemi.Text = null;
            txtEkranBoyutu.Text = null;
            txtWifi.Text = null;
            txtHardDisk.Text = null;
            txtSSD.Text = null;
            txtBluetooth.Text = null;
            txtAdet.Text = null;
            txtBilesenUrunAdi.Text = null;
            txtBilesenUrunBirimFiyati.Text = null;
            dtBilesenSatinAlmaTarihi.Text = null;
            txtlBilesenSatinAlinanFirma.Text = null;
            cbxBilesenUrunTuru.Text = null;
            txtBilesenOzellik.Text = null;
            txtBilesenAdet.Text = null;
            txtGorevliStokUrunAdi.Text = null;
            txtStokYenileAdet.Text = null;
            txtStokYenileUrunID.Text = null;
        }
        private void GorevliEkran_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisForm grs = new GirisForm();
            grs.Show();
        }
        private void GorevliEkran_Load(object sender, EventArgs e)
        {

        }
        //ürünlerden sqle bilgisayar eklemek için kullanılan buton
        private void btnBilgisayarEkle_Click(object sender, EventArgs e)
        {
            if(txtUrunAdi.Text!="" && txtUrunBirimFiyati.Text!="" && dtSatinAlmaTarihi.Text!="" && txtSatinAlinanFirma.Text!="" && txtRam.Text!="" && txtIslemci.Text!="" && txtEkranKarti.Text!="" && txtIsletimSistemi.Text!="" && txtEkranBoyutu.Text!="" && txtWifi.Text!="" && txtHardDisk.Text!="" && txtSSD.Text!="" && txtBluetooth.Text!="" && txtAdet.Text!="")
            {
                SQL.BilgisayarEkle(txtUrunAdi.Text,txtUrunBirimFiyati.Text,dtSatinAlmaTarihi.Text,txtSatinAlinanFirma.Text,txtRam.Text,txtIslemci.Text,txtEkranKarti.Text,txtIsletimSistemi.Text,txtEkranBoyutu.Text,txtWifi.Text,txtHardDisk.Text,txtSSD.Text,txtBluetooth.Text,txtAdet.Text);                
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            StokTabloYenile();
            ZimmetliUrunleriListele();
            textTemizle();
        }

        private void lblIsletimSistemi_Click(object sender, EventArgs e)
        {

        }
        //ürünlerden sqle bileşen eklemek için kullanılan buton
        private void btnBilesenEkle_Click(object sender, EventArgs e)
        {  
            if(txtBilesenUrunAdi.Text!="" && txtBilesenUrunBirimFiyati.Text!="" && dtBilesenSatinAlmaTarihi.Text!="" && txtlBilesenSatinAlinanFirma.Text!="" && cbxBilesenUrunTuru.Text!="" && txtBilesenOzellik.Text!="" && txtBilesenAdet.Text!="")
            {
                SQL.BilesenEkle(txtBilesenUrunAdi.Text, txtBilesenUrunBirimFiyati.Text, dtBilesenSatinAlmaTarihi.Text, txtlBilesenSatinAlinanFirma.Text,cbxBilesenUrunTuru.Text,txtBilesenOzellik.Text,txtBilesenAdet.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            StokTabloYenile();
            textTemizle();
        }
        public void StokTabloYenile()
        {
            dgwStokListeleGorevli.DataSource = SQL.StokGetir();
        }
        public void UrunTabloYenile()
        {
            dgwGorevliUrun.DataSource = SQL.SeciliUrunListele(txtGorevliStokUrunAdi.Text);
            textTemizle();
        }
        
        public void ZimmetliUrunleriListele()
        {            
            kullanici.Text = kullaniciAd;
            dgvZimmetliUrunleriListele.DataSource = SQL.KisiZimmetListele(kullanici.Text);
            textTemizle();
        }

        private void btnGorevliUrunListele_Click(object sender, EventArgs e)
        {
            dgwGorevliUrun.DataSource = SQL.SeciliUrunListele(txtGorevliStokUrunAdi.Text);
            textTemizle();
        }
        //Stok güncelleme
        private void btnStokYenileEkle_Click(object sender, EventArgs e)
        {
            if(txtStokYenileAdet.Text!="" && txtStokYenileUrunID.Text!="")
            {
                SQL.StokEkle(txtStokYenileAdet.Text, txtStokYenileUrunID.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");

            UrunTabloYenile();
            StokTabloYenile();
            textTemizle();
        }
        //Stok güncelleme
        private void btnStokYenileSil_Click(object sender, EventArgs e)
        {
            if (txtStokYenileAdet.Text != "" && txtStokYenileUrunID.Text != "")
            {
                SQL.StokSil(txtStokYenileAdet.Text, txtStokYenileUrunID.Text);
            }
            else
                MessageBox.Show("ALANLAR BOŞ GEÇİLEMEZ");
            
            UrunTabloYenile();
            StokTabloYenile();
            textTemizle();
        }

        private void btnZimmetliUrunleriniListele_Click(object sender, EventArgs e)
        {
            ZimmetliUrunleriListele();
        }
    }
}