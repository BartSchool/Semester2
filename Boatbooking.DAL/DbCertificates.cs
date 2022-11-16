using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatbookingDAL
{
    internal class DbCertificates
    {
        private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=Bootbooking; Trusted_Connection=True";

        public List<string> GetCertificatesFromDb()
        {
            List<string> list = new List<String>();

            using var connection = new SqlConnection(connectionString);

            connection.Open();

            var command = new SqlCommand(" SELECT * FROM certificates", connection);
            var reader = command.ExecuteReader();

            if (reader != null)
                while (reader.Read())
                {
                    string a = reader.GetString(0);

                    list.Add(a);
                }
            connection.Close();

            return list;
        }
        public bool DoesStringContainRightCertificates(string certificate)
        {
            List<string> correct = GetCertificatesFromDb();
            bool result = true;

            char[] chars = certificate.ToCharArray();
            List<string> cert = new List<string>();
            string test = "";

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != ',')
                    test += chars[i];
                else
                {
                    if (!correct.Contains(test))
                        return false;
                    test = "";
                }
            }
            if (!correct.Contains(test))
                return false;

            return result;
        }
    }
}
