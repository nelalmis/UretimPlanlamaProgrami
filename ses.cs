using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace uretimPlanlamaProgrami
{
    class ses
    {
         public void hata_sesi()
        {
            SoundPlayer s = new SoundPlayer();
            s.SoundLocation =@"C:\Users\nevzat\documents\visual studio 2012\Projects\uretimPlanlamaProgrami\uretimPlanlamaProgrami\media\hata.wav";
            s.Play();
        }
        public void onay_sesi()
        {
            SoundPlayer s = new SoundPlayer();
            s.SoundLocation = @"C:\Users\nevzat\documents\visual studio 2012\Projects\uretimPlanlamaProgrami\uretimPlanlamaProgrami\media\onay.wav";
            s.Play();
        }
    }
}
