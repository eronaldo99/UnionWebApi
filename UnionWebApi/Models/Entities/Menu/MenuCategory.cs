using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionWebApi.Model.Entities.Menu
{
    public class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String BackgroundImage { get; set; }
        public List<MenuItem> MenuList { get; set; }
        public string Icon { get; set; }
        public int Badge { get; set; }
    }
}
