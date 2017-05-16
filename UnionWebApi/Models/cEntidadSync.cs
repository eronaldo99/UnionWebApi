using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models
{
    public class cEntidadSync
    {
        public string Key { get; set; }
        public string Version { get; set; }
        public bool Deleted { get; set; }

    }
}