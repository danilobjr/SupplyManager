using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web.ViewModels
{
    public class MenuVM
    {
        public MenuVM()
        {
            SubMenus = new List<MenuVM>();
        }

        public string Descricao { get; set; }
        public string Link { get; set; }
        public IList<MenuVM> SubMenus { get; set; }
    }
}