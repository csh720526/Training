using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample.Example
{
    public class StringUtility
    {
        private ILog log;

        public StringUtility(ILog log)
        {
            this.log = log;
        }

        public virtual string ToHex(int val)
        {
            if (val == 0)
            {
                log.Write("Nick");
                throw new ArgumentException($"{nameof(val)} should be greater zero", 
                    nameof(val));
            }

            byte[] data = Encoding.ASCII.GetBytes(val.ToString());
            StringBuilder sb = new StringBuilder();

            foreach(var b in data)
            {
                sb.Append($"{b:X}");
            }

            return sb.ToString();
        }
    }
}
