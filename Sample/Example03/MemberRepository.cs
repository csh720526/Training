using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example03
{
    public class MemberRepository : IMemberRepository, IDisposable
    {
        private IDbConnection con;
        private bool disposed = false;

        public MemberRepository(IDbConnection con)
        {
            this.con = con;
        }

        public IDataReader GetMember(string phone)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Email from Member ");
            sb.Append("where Phone = @Phone");

            var cmd = con.CreateCommand();
            cmd.CommandText = sb.ToString();
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = "@Phone";
            parameter.Value = phone;
            cmd.Parameters.Add(parameter);

            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    if(con.State == ConnectionState.Open)
                        con.Close();
                    con.Dispose();
                }
                disposed = true;
            }
        }
    }
}
