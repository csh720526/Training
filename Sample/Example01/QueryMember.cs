using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sample.Example01
{
    public class QueryMember
    {
        private MySqlConnection con;

        public QueryMember(string connection)
        {
            con = new MySqlConnection(connection);
        }

        public string QueryEmail(string phone)
        {
            string email;
            StringBuilder sb = new StringBuilder();
            sb.Append("select Email from Member ");
            sb.Append("where Phone = @Phone");
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sb.ToString();
            cmd.Parameters.AddWithValue("@Phone", phone);

            try
            {
                var reader = cmd.ExecuteReader();

                if (!reader.Read())
                    throw new Exception("查詢資料");

                email = reader["Email"].ToString();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }

            return email;
        }
    }
}
