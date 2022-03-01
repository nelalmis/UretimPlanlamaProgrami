using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace uretimPlanlamaProgrami
{
    public class veritabani
    {
        public static SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=Planlama;Integrated Security = True; MultipleActiveResultSets=true;");

        public static void baglan()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public static void baglantiyiKes()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
