using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    enum NICType
    {
        Ethernet, TokenRing
    }

    internal class NIC
    {
        public string Manufacture { get; set; }

        public string MAC { get; set; }

        public NICType Type { get; set; }
        
        public static NIC NetworkCardObj { get; } = new("Intel", "MAC_ADDRESS", NICType.Ethernet);

        NIC(string _man, string _MAC, NICType _type)
        {
            Manufacture = _man;
            MAC = _MAC;
            Type = _type;
        }
    }
}
