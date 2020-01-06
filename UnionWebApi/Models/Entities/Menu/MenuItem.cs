using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace UnionWebApi.Model.Entities.Menu
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageType { get; set; }
        public string Icon { get; set; }
        public string BackgroundImage { get; set; }
        public bool Modal { get; set; }
        public bool JustNotifyNavigateIntent { get; set; }
        public bool IsNew { get; set; }

    }
}
