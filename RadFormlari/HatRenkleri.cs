using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
namespace uretimPlanlamaProgrami.RadFormlari
{
    
    class HatRenkleri
    {


                //public Color ekTatilRengi { get; set; }
                //public Color haftalikTatilRengi { get; set; }
                //public Color tamamenPasiflestirilenHatRengi { get; set; }
                //public Color kismenPasifleştirilenHatRengi { get; set; }


        public Color ekTatilRengi = Color.DarkGray;
        public Color haftalikTatilRengi = Color.Black;
        public Color kismenPasifleştirilenHatRengi = Color.Black;
        public Color tamamenPasiflestirilenHatRengi = Color.BlanchedAlmond;


               //public void getir() {
               //    veritabani.baglan();
               //    SqlCommand sor = new SqlCommand("select * from Tema where id=1",veritabani.conn);
               //    SqlDataReader oku=sor.ExecuteReader();
               //    while (oku.Read()) {
               //        ekTatilRengi = (Color)oku["ekTatilRengi"];
               //        haftalikTatilRengi = (Color)oku["haftalikTatilRengi"];
               //        tamamenPasiflestirilenHatRengi = (Color)oku["tamamenPasiflestirilenHatRengi"];
               //        kismenPasifleştirilenHatRengi = (Color)oku["kismenPasifleştirilenHatRengi"];

                   
               //    }
               
               //}
              
                
               //public void defaultDegerAta(){
                   
               //    ekTatilRengi = Color.DarkGray;
               //    haftalikTatilRengi = Color.Blue;
               //    kismenPasifleştirilenHatRengi = Color.Black;
               //    tamamenPasiflestirilenHatRengi = Color.BlanchedAlmond;

               //}

            
    }

    

}
