using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StokProgram
{
    public class SQLClass
    {
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OFNCK1V;Initial Catalog=StokTakip;Integrated Security=True");

        public void YeniYetkiliEkle(string Ad, string Soyad, string KullaniciAd, string Sifre, string BirimID, string Birim)
        {
             conn.Open();
             SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + KullaniciAd + "'", conn);
             SqlDataReader dr = kmt.ExecuteReader();
             if (dr.Read())
             {
                System.Windows.Forms.MessageBox.Show("BU KULLANICI ADI KULLANILIYOR");
                conn.Close();
             }
             else
             {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("INSERT INTO Kullanicilar(Ad,Soyad,KullaniciAdi,Sifre,Silindi,Yetki,Birim) Values('" + Ad + "','" + Soyad + "','" + KullaniciAd + "','" + Sifre + "','" + 0 + "','" + "Yetkili" + "','" + Birim + "')", conn);
                kmt.ExecuteNonQuery();
                //eklenen son kullanıcıdan kullanıcı id yi çekip birim yetkilisi tablosuna aynı id ile ekliyoruz
                string cek = "SELECT TOP 1 KullaniciID FROM Kullanicilar ORDER BY KullaniciID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();
                dr.Read();
                int ID = Convert.ToInt32(dr["KullaniciID"]);
                kmt = new SqlCommand("INSERT INTO BirimYetkilisi(KullaniciID,BirimID) Values('" + ID + "','" + BirimID + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("YETKİLİ BAŞARILI BİR ŞEKİLDE EKLENDİ");
                conn.Close();
             }
        }
        public void YeniGorevliEkle(string Ad, string Soyad, string KullaniciAd, string Sifre, string BirimID, string Birim)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + KullaniciAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show("BU KULLANICI ADI KULLANILIYOR");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("INSERT INTO Kullanicilar(Ad,Soyad,KullaniciAdi,Sifre,Silindi,Yetki,Birim) Values('" + Ad + "','" + Soyad + "','" + KullaniciAd + "','" + Sifre + "','" + 0 + "','" + "Görevli" + "','" + Birim + "')", conn);
                kmt.ExecuteNonQuery();
                //eklenen son kullanıcıdan kullanıcı id yi çekip birim görevli tablosuna aynı id ile ekliyoruz
                string cek = "SELECT TOP 1 KullaniciID FROM Kullanicilar ORDER BY KullaniciID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();
                dr.Read();
                int ID = Convert.ToInt32(dr["KullaniciID"]);
                kmt = new SqlCommand("INSERT INTO SatinAlmaGorevlisi(KullaniciID,BirimID) Values('" + ID + "','" + BirimID + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("GÖREVLİ BAŞARILI BİR ŞEKİLDE EKLENDİ");
                conn.Close();

            }
        }
        public void KullaniciSil(string KullaniciAd)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + KullaniciAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                conn.Open();
                //kullanicilar tablosundaki silindi bölümünü 1 e çeviriyoruz
                kmt = new SqlCommand("UPDATE Kullanicilar set Silindi = @sil WHERE KullaniciAdi = @KullaniciSil", conn);
                kmt.Parameters.AddWithValue("@Sil", int.Parse("1"));
                kmt.Parameters.AddWithValue("@KullaniciSil", KullaniciAd);
                kmt.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("YETKİLİ BAŞARILI BİR ŞEKİLDE SİLİNDİ");
                conn.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("BU KULLANICI BULUNAMIYOR");
                conn.Close();
            }            
        }
        //Kullanicilar tablosunu getirmek için kullanılan fonksiyon
        public DataTable KullanicilariGetir()
        {
            conn.Open();          
            SqlDataAdapter adap = new SqlDataAdapter("SELECT Ad,Soyad,KullaniciAdi,Sifre,Yetki,Birim FROM Kullanicilar WHERE Silindi LIKE '%" + 0 + "%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        //stok tablosundakileri gösterir
        public DataTable StokGetir()
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT U.UrunAdi,S.Adet,S.UrunTuru FROM Stok S INNER JOIN Urun U ON S.UrunID=U.UrunID ORDER BY Adet ASC", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        
        public DataTable GorevliListele()
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT K.KullaniciAdi,B.BirimAdi FROM SatinAlmaGorevlisi G INNER JOIN Kullanicilar K ON  K.KullaniciID = G.KullaniciID " +
            "INNER JOIN Birim B ON B.BirimID = G.BirimID WHERE Silindi LIKE '%" + 0 + "%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable BilgisayarZimmetListele()
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT K.KullaniciAdi,U.UrunAdi,K.Birim,K.Yetki,Z.ZimmetlemeBilgi,Z.ZimmetlemeTarih FROM Kullanicilar K INNER JOIN Zimmetleme Z ON K.KullaniciID = Z.KullaniciID " +
            "INNER JOIN Urun U ON Z.UrunID = U.UrunID WHERE K.Birim LIKE '%" + "Bilgisayar" + "%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable BilesenZimmetListele()
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT K.KullaniciAdi,U.UrunAdi,K.Birim,K.Yetki,Z.ZimmetlemeBilgi,Z.ZimmetlemeTarih FROM Zimmetleme Z INNER JOIN Kullanicilar K ON K.KullaniciID = Z.KullaniciID " +
            "INNER JOIN Urun U ON Z.UrunID = U.UrunID WHERE K.Birim LIKE '%" + "Bileşenleri" + "%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable DepoListele()
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT U.UrunAdi,Z.ZimmetlemeBilgi,D.DepoBilgi FROM Zimmetleme Z INNER JOIN Urun U ON  U.UrunID = Z.UrunID " +
            "INNER JOIN Depo D ON D.ZimmetID = Z.ZimmetID ", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable KisiZimmetListele(string kullaniciAd)
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT K.KullaniciAdi,U.UrunAdi,Z.ZimmetlemeBilgi,Z.ZimmetlemeTarih FROM Zimmetleme Z INNER JOIN Kullanicilar K ON Z.KullaniciID = K.KullaniciID " +
            "INNER JOIN Urun U ON Z.UrunID = U.UrunID WHERE K.KullaniciAdi LIKE '%" + kullaniciAd + "%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public DataTable SeciliUrunListele(string SeciliUrun)
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT U.UrunAdi,U.UrunBirimFiyat,U.SatinAlmaTarih,U.SatinAlinanFirma,S.Adet FROM Urun U INNER JOIN Stok S ON U.UrunID=S.UrunID WHERE UrunAdi LIKE'%"+SeciliUrun+"%'", conn);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            conn.Close();
            return tbl;
        }
        public void StokEkle(string Adet,string urunAd)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + urunAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                //güncelleme ile önceki adeti tutup yeni adeti üstüne ekleyip güncelleme yapıyoruz
                string guncel = @"Update Stok
                set Adet = Adet + @Adet
                From Stok S , URUN U
                Where U.UrunID=S.UrunID AND UrunAdi = @urun_adi";
                int miktar;

                if (int.TryParse(Adet, out miktar))
                {
                    SqlCommand guncelle = new SqlCommand(guncel, conn);
                    guncelle.Parameters.AddWithValue("@Adet", miktar);
                    guncelle.Parameters.AddWithValue("@urun_adi", urunAd);
                    conn.Open();
                    guncelle.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("STOK GÜNCELLENDİ");
                    conn.Close();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("BU ÜRÜN STOKTA BULUNMUYOR");
                conn.Close();
            }          
        }
        public void StokSil(string Adet, string urunAd)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + urunAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                //güncelleme ile önceki adeti tutup yeni adeti üstünden çıkarıp güncelleme yapıyoruz
                string guncel = @"Update stok 
                set Adet = Adet - @Adet 
                From Stok S JOIN URUN U ON U.UrunID=S.UrunID
                Where UrunAdi = @urun_ad";
                int miktar;

                if (int.TryParse(Adet, out miktar))
                {
                    SqlCommand guncelle = new SqlCommand(guncel, conn);
                    guncelle.Parameters.Add("@urun_ad", SqlDbType.NVarChar).Value = urunAd;
                    guncelle.Parameters.Add("@Adet", SqlDbType.Int).Value = miktar;
                    conn.Open();
                    guncelle.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("STOK GÜNCELLENDİ");
                    conn.Close();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("BU ÜRÜN STOKTA BULUNMUYOR");
                conn.Close();
            }      
        }
        public void BilgisayarEkle(string UrunAd, string Fiyat, string AlmaTarihi, string AlınanFirma, string Ram, string Islemci, string EkranKarti, string IsletimSistemi, string EkranBoyut, string Wifi, string HardDisk, string SSD, string Bluetooth, string Adet)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + UrunAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show("BU ÜRÜN BULUNUYOR");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("INSERT INTO Urun (UrunAdi,UrunBirimFiyat,SatinAlmaTarih,SatinAlinanFirma,BirimID) Values('" + UrunAd + "','" + Fiyat + "','" + Convert.ToDateTime(AlmaTarihi) + "','" + AlınanFirma + "','" + 1 + "')", conn);
                kmt.ExecuteNonQuery();
                //son eklenen ürünün ids ini çekip bilgisayar tablosuna ekleme işlemini gerçekleştirir 
                string cek = "SELECT TOP 1 UrunID FROM Urun ORDER BY UrunID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();
                dr.Read();
                int urunID = Convert.ToInt32(dr["UrunID"]);
                kmt = new SqlCommand("INSERT INTO Bilgisayar(UrunID,RAM,Islemci,EkranKarti,IsletimSistemi,EkranBoyutu,WIFI,HardDisk,SSD,Bluetooth) Values('" + urunID + "','" + Ram + "','" + Islemci + "','" + EkranKarti + "','" + IsletimSistemi + "','" +
                EkranBoyut + "','" + Wifi + "','" + HardDisk + "','" + SSD + "','" + Bluetooth + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                string cek2 = "SELECT TOP 1 UrunID FROM Urun ORDER BY UrunID DESC";
                SqlCommand cek2Komut = new SqlCommand(cek2, conn);
                cekKomut.ExecuteNonQuery();
                SqlDataReader dr2 = cekKomut.ExecuteReader();
                dr2.Read();
                int urun2ID = Convert.ToInt32(dr2["UrunID"]);
                kmt = new SqlCommand("INSERT INTO Stok(UrunID,Adet,UrunTuru) Values('" + urun2ID + "','" + Adet + "','" + "Bilgisayar" + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("BİLGİSAYAR BAŞARILI BİR ŞEKİLDE EKLENDİ");
                conn.Close();
            }           
        }
        public void BilesenEkle(string BilesenAd, string BilesenFiyat, string BilesenAlmaTarihi, string BilesenAlınanFirma, string BilesenUrunTuru,string BilesenOzellik,string BilesenAdet)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + BilesenAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show("BU ÜRÜN BULUNUYOR");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("INSERT INTO Urun (UrunAdi,UrunBirimFiyat,SatinAlmaTarih,SatinAlinanFirma,BirimID) Values('" + BilesenAd + "','" + BilesenFiyat + "','" + Convert.ToDateTime(BilesenAlmaTarihi) + "','" + BilesenAlınanFirma + "','" + 2 + "')", conn);
                kmt.ExecuteNonQuery();
                //son eklenen ürünün ids ini çekip bilesen tablosuna ekleme işlemini gerçekleştirir 
                string cek = "SELECT TOP 1 UrunID FROM Urun ORDER BY UrunID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();
                dr.Read();
                int urunID = Convert.ToInt32(dr["UrunID"]);
                kmt = new SqlCommand("INSERT INTO Bilesen(UrunID,UrunTuru,UrunOzellik) Values('" + urunID + "','" + BilesenUrunTuru + "','" + BilesenOzellik + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                string cek2 = "SELECT TOP 1 UrunID FROM Urun ORDER BY UrunID DESC";
                SqlCommand cek2Komut = new SqlCommand(cek2, conn);
                cekKomut.ExecuteNonQuery();
                SqlDataReader dr2 = cekKomut.ExecuteReader();
                dr2.Read();
                int urun2ID = Convert.ToInt32(dr2["UrunID"]);
                kmt = new SqlCommand("INSERT INTO Stok(UrunID,Adet,UrunTuru) Values('" + urun2ID + "','" + BilesenAdet + "','" + BilesenUrunTuru + "')", conn);
                conn.Close();
                conn.Open();
                kmt.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(BilesenUrunTuru + " BAŞARILI BİR ŞEKİLDE EKLENDİ");
                conn.Close();
            }           
        }
        public void UrunZimmetle(string UrunAd,string KullaniciAd, string ZBilgi, string ZTarih)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Zimmetleme Z INNER JOIN Urun U ON U.UrunID=Z.UrunID WHERE UrunAdi = '" + UrunAd + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show("BU ZATEN ZİMMETLİ");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + UrunAd + "'", conn);
                kmt.ExecuteNonQuery();
                //ürün adına göre arama yaptıktan sonra id işlemini çekip zimmetleme tablosuna ekler
                string cek = "SELECT TOP 1 UrunID FROM Urun WHERE UrunAdi = '" + UrunAd + "' ORDER BY UrunID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();                
                dr.Read();
                int UrunID = Convert.ToInt32(dr["UrunID"]);
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = '" + KullaniciAd + "'", conn);
                kmt.ExecuteNonQuery();
                string cek2 = "SELECT TOP 1 KullaniciID FROM Kullanicilar WHERE KullaniciAdi ='" + KullaniciAd + "' ORDER BY KullaniciID DESC";
                SqlCommand cekKomut2 = new SqlCommand(cek2, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut2.ExecuteReader();
                dr.Read();                
                int KullaniciID = Convert.ToInt32(dr["KullaniciID"]);
                conn.Close();
                conn.Open();
                dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    conn.Close();
                    conn.Open();
                    kmt = new SqlCommand("INSERT INTO Zimmetleme(UrunID,KullaniciID,ZimmetlemeBilgi,ZimmetlemeTarih) Values('" + UrunID + "','" + KullaniciID + "','" + ZBilgi + "','" + Convert.ToDateTime(ZTarih) + "')", conn);
                    kmt.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("ÜRÜN ZİMMETLENDİ");
                    conn.Close();     
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("BU ÜRÜN BULUNMAMAKTA");
                    conn.Close();
                }                
            }           
        }
        public void DepoEkle(string UrunAd,string ZimmetBilgi,string DepoBilgi)
        {
            conn.Open();
            SqlCommand kmt = new SqlCommand("SELECT * FROM Zimmetleme Z INNER JOIN Depo D ON D.ZimmetID=Z.ZimmetID WHERE ZimmetlemeBilgi = '" + ZimmetBilgi + "'", conn);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show("BU ÜRÜN ZATEN DEPODA");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("SELECT * FROM Urun WHERE UrunAdi = '" + UrunAd + "'", conn);
                kmt.ExecuteNonQuery();
                //ürün adına göre arama yaptıktan sonra id işlemini çekip depo tablosuna ekler
                string cek = "SELECT TOP 1 UrunID FROM Urun WHERE UrunAdi = '" + UrunAd + "' ORDER BY UrunID DESC";
                SqlCommand cekKomut = new SqlCommand(cek, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut.ExecuteReader();
                dr.Read();
                int UrunID = Convert.ToInt32(dr["UrunID"]);
                conn.Close();
                conn.Open();
                kmt = new SqlCommand("SELECT * FROM Zimmetleme WHERE ZimmetlemeBilgi = '" + ZimmetBilgi + "'", conn);
                kmt.ExecuteNonQuery();
                string cek2 = "SELECT TOP 1 ZimmetID FROM Zimmetleme WHERE ZimmetlemeBilgi = '" + ZimmetBilgi + "' ORDER BY KullaniciID DESC";
                SqlCommand cekKomut2 = new SqlCommand(cek2, conn);
                cekKomut.ExecuteNonQuery();
                dr = cekKomut2.ExecuteReader();
                dr.Read();
                int ZimmetID = Convert.ToInt32(dr["ZimmetID"]);
                conn.Close();
                conn.Open();
                dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    conn.Close();
                    conn.Open();
                    kmt = new SqlCommand("INSERT INTO Depo(ZimmetID,UrunID,DepoBilgi) Values('" + ZimmetID + "','" + UrunID + "','" + DepoBilgi + "')", conn);
                    kmt.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("ÜRÜN BAŞARILI BİR ŞEKİDE DEPOYA EKLENDİ");
                    conn.Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("BU ÜRÜN ZİMMETLENMEMİŞ");
                    conn.Close();
                }

            }               
        }
    }
}
