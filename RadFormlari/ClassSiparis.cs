using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uretimPlanlamaProgrami.RadFormlari
{
    class ClassSiparis
    {
        
        public string siparisKod { get; set; }
        public string urunKod { get; set; }
        public string firmaAdi { get; set; }
        public int hammadde { get; set; }
        public string oncelikSirasi { get; set; }
        public long boy { get; set; }
        public long adet { get; set; }
        public int renk { get; set; }
        public DateTime baslangicTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }
        public int toplamSure { get; set; }
        public float gerekenUrunMiktari { get; set; }
        public bool siparisBittimi { get; set; }
        public int kullanilacakHat { get; set; }
        public int devamDurumu { get; set; }
        public string bitTarih { get; set; }
        public int bitSaat { get; set; }
        public string sonrakiSiparisKodu { get; set; }
        public DateTime kayitTarihi { get; set; }
        public int tatilDahilSure { get; set; }
        public bool sil { get; set; }

    }
}
