using SupplyManager.Dominio.Entidades;
using SupplyManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web.AutoMappers
{
    class MenuMapeador
    {
        public static List<MenuVM> Mapear(List<Menu> menus)
        {
            var menusViewModel = new List<MenuVM>();

            foreach (var menu in menus)
            {
                menusViewModel.Add(Mapear(menu));
            }

            return menusViewModel;
        }

        public static MenuVM Mapear(Menu menu)
        {
            var menuViewModel = new MenuVM
            {
                Descricao = menu.Descricao,
                Link = menu.Link
            };

            if (menu.SubMenus.Count > 0)
            {
                menuViewModel.SubMenus = Mapear(menu.SubMenus.ToList());
            }

            return menuViewModel;
        }
    }
}