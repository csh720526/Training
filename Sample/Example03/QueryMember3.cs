using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example03
{
    public class QueryMember3
    {
        private IMemberRepository rep;

        public QueryMember3(IMemberRepository rep)
        {
            this.rep = rep;
        }

        public string QueryEmail(string phone)
        {
            string email = string.Empty;
            try
            {
                var reader = rep.GetMember(phone);

                if (!reader.Read())
                    throw new Exception("查詢資料");

                email = reader["Email"].ToString();
            }
            catch(Exception)
            {
                throw;
            }

            return email;
        }
    }
}
