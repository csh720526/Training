using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example03
{
    public interface IMemberRepository : IDisposable
    {
        IDataReader GetMember(string phone);
    }
}
