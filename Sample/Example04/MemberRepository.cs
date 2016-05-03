using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example04
{
    public class MemberRepository : IMemberRepository, IDisposable
    {
        private JKOSContext ctx;
        private bool disposed = false;

        public MemberRepository(JKOSContext ctx)
        {
            this.ctx = ctx;
        }

        public MemberEntity GetMember(string phone)
        {
            try
            {
                var memberEntity = ctx.Member
                    .Where(m => m.Phone.Equals(phone))
                    .FirstOrDefault();

                return memberEntity;
            }
            catch (Exception)
            {
                throw;
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
                    ctx.Dispose();
                }
                disposed = true;
            }
        }
    }
}
