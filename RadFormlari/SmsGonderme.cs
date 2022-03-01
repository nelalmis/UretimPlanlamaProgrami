using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace uretimPlanlamaProgrami.RadFormlari
{
    class SmsGonderme
    {
       public void smsGonder()
        {
            try
            {
                string kullaniciAdi="nelalmis";
                string parola="admin";
                string edit="asdfadf";
                string mesaj="Bu bir deneme mesajıdır";

                // Kullanici adi, parola ve Originator kullanilarak bir sms paketi olusturulur.
                SMSPaketi smspak = new SMSPaketi(kullaniciAdi, parola, edit);

                // eger ileri tarihli sms gonderilecekse tarh parametreli asagidai Consturctor kullanilabilir
                // ornek: 2066-11-20 saat 19:30:00 'da gonder
                //SMSPaketi smspak = new SMSPaketi("user","123456","MUTLUCELL", new DateTime(2006,11,20,19,30,0));

                // mesajin gidecegi numaralar bir array'e doldurulur
                // numara formati onemli degildir, bosluklu parantezli, sifirli, sifirsiz, +90li vs olabilir

                String[] numaralar = { ( "05438236023" ),
                                         ("05530050223" ) };
                

                // gidecek mesaj metni ve numaralar pakaete eklenir. 
                // bu sekilde bir sms paketine birden fazla mesaj eklenebilir
                smspak.addSMS(mesaj, numaralar);

                // sonuc eger mesaj basarili ise # ile baslayan bir mesaj ID'dir. 
                // bir hata olusmussa XML dokumaninda belirtilen hata kodlarindan biri doner
                String sonuc = smspak.gonder();
                MessageBox.Show(sonuc);

                //Raporun cekilmesi
                // rapor kullanici adi, parola ve mesaj gonderme isleminde sonuc olarak donen 
                // message ID ile cekilir. XML dokumaninda belirtilen formatta doner
                String rapor = SMSPaketi.rapor(kullaniciAdi, parola, 156675);
                MessageBox.Show("Mesaj sonuç raporu: " + rapor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
        }

    }
}
