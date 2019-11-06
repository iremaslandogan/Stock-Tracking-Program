using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StokProgramTestProje
{
    [TestClass]
    public class StokProgramTest
    {
        [TestMethod]
        public void GorevliEkle()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.YeniGorevliEkle("Hakkı", "Bulut", "Gündoğdu", "123456", "Görevli", "Bilgisayar");
        }

        [TestMethod]
        public void KullaniciSil()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.KullaniciSil("Gündoğdu");
        }

        [TestMethod]
        public void StokEkle()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.StokEkle("10", "Logitech M220");
        }
        [TestMethod]
        public void StokSil()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.StokSil("10", "Logitech M220");
        }
        [TestMethod]
        public void UrunEkle()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();            
            SQL.BilgisayarEkle("LENOVO AIO 520","8000","27.12.2018","LENOVO","8GB","İ7 8700T","AMD","Windows 10","23.8 inç","Var","1TB","Yok","4.0","3");                
        }
        [TestMethod]
        public void DepoEkle()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.DepoEkle("TOSHIBA USB BELLEK", "sandisk", "hasarlı");
        }
        [TestMethod]
        public void Zimmetle()
        {
            StokProgram.SQLClass SQL = new StokProgram.SQLClass();
            SQL.UrunZimmetle("LENOVO AIO 520", "elf", "lenovo", "27.12.2018");
        }



    }
}
