using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1Destiny.Models
{
    public class DB_Resource
    {
        public short Sl_No { get; set; }
        public string ResourceName { get; set; }
        public string ResourceLink { get; set; }
        public short ResourceID { get; set; }
        public string ResourceImage { get; set; }
        public short TeamID { get; set; }
    }
}