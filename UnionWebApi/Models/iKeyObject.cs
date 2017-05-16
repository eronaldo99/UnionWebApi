using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionWebApi.Models
{
    public interface iKeyObject
    {
        string Key { get; set; }
        System.Data.Linq.Binary Version { get; }
        System.Nullable<bool> Deleted { get; }
    }
}
