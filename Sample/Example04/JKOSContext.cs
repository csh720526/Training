using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example04
{
    public class JKOSContext : DbContext
    {
        public JKOSContext()
            : base("name=con")
        {
            Database.Log = (sql) => System.Diagnostics.Debug.Write(sql);
        }


        public virtual DbSet<MemberEntity> Member { get; set; }
    }
}
