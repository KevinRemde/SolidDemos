using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Lab
{
    class PhotoFileManagement: IPhotoFileManagement
    {
        public void SavePhotoData(string firstName, string lastName)
        {
            // Use your imagination and ADO.NET
            // Save this info to a database
            string cmdString = "INSERT INTO photoInfo (First_Name, Last_Name) VALUES (@first, @last)";
            string connString = "connecitonsting";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@first", firstName);
                    comm.Parameters.AddWithValue("@last", lastName);
                    //conn.Open();
                    //comm.ExecuteNonQuery();
                }
            }
        }

    }
}
