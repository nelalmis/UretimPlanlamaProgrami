using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace uretimPlanlamaProgrami
{
    class hatalar
    {
        public string hataMesajı { get; set; }
        public string hataKodu { get; set; }

        public void hataMesajiKaydet()
        {
            try
            {
                veritabani.baglan();
                SqlCommand kaydet = new SqlCommand("insert into hatalar(hataMesaji,hataKodu,hataTarihi) values('" + hataMesajı + "','" + hataKodu + "','" + DateTime.Now + "')", veritabani.conn);
                kaydet.ExecuteNonQuery();
                veritabani.baglantiyiKes();
            }
            catch { }
        }
    }
   
}
