using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example04
{
    public interface IMemberRepository : IDisposable
    {
        MemberEntity GetMember(string phone);
    }
}
