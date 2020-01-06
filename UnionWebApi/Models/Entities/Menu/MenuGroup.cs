using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionWebApi.Model.Entities.Menu
{
    public class MenuGroup : List<MenuItem>
    {
        public MenuGroup(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
