using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sample.Example02
{
    public class QueryMember2
    {
        private IDbConnection con;

        public QueryMember2(IDbConnection con)
        {
            this.con = con;
        }

        public string QueryEmail(string phone)
        {
            string email;
            StringBuilder sb = new StringBuilder();
            sb.Append("select Email from Member ");
            sb.Append("where Phone = @Phone");
            con.Open();

            var cmd = con.CreateCommand();
            cmd.CommandText = sb.ToString();
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "@Phone";
            parameter.Value = phone;
            cmd.Parameters.Add(parameter);

            try
            {
                var reader = cmd.ExecuteReader();

                if (!reader.Read())
                    throw new Exception("查詢資料");

                email = reader["Email"].ToString();

                reader.Close();
            }
            catch (Exception)
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
