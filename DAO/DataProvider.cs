using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get
            { 
                if (instance == null)
                {
                    instance = new DataProvider();    
                }
                return instance;
            } 
            private set => instance = value; 
        }
        private DataProvider() { }

        string ConnectionStr = @"Data Source=DESKTOP-1OFH7OO\MYNAM_SERVER; Initial Catalog=QLSinhVien; Integrated Security=True; TrustServerCertificate=True";
        public DataTable ExecuteQuery(string Query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                if (parameter != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string str in listPara)
                    {
                        if (str.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(str, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                da.Dispose();
            }
            return dt;
        }

       

    }
}
