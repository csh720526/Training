using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample.Example
{
    public class FakeRemotService : IRemoteService
    {
        private IList<Member> data;

        public FakeRemotService()
        {
            data = new List<Member>();
            data.Add(new Member() { Phone = "+886923829323", Email = "aa@lkdsjf.com" });
            data.Add(new Member() { Phone = "+886911506909", Email = "csh720526@gmail.com" });
        }

        public string GetEmail(string phone)
        {
            return data.Where(d => d.Phone.Equals(phone))
                .FirstOrDefault().Email;
        }

        private class Member
        {
            public string Phone { get; set; }

            public string Email { get; set; }

        }
    }
}
