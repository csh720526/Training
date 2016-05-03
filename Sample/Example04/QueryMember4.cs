using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example04
{
    public class QueryMember4
    {
        private IMemberRepository rep;

        public QueryMember4(IMemberRepository rep)
        {
            this.rep = rep;
        }

        public string QueryEmail(string phone)
        {
            string email = string.Empty;
            try
            {
                var member = rep.GetMember(phone);

                if (member == null)
                    throw new Exception("查無資料");

                email = member.Email;
            }
            catch(Exception)
            {
                throw;
            }

            return email;
        }
    }
}
