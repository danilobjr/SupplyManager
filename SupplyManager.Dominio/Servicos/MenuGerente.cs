using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Dominio.Servicos
{
    public class MenuGerente
    {
        private IDominioContext Contexto { get; set; }

        public MenuGerente(IDominioContext contexto)
        {
            Contexto = contexto;
        }

        public List<Menu> ObterMenusPor(NumeroNivelDeAcesso numeroNivelDeAcesso)
        {
            var nivelDeAcesso = Contexto.NiveisDeAcesso.SingleOrDefault(n => n.Nivel == numeroNivelDeAcesso);
            var menus = Contexto.Menus.Where(m => m.NivelDeAcessoId <= nivelDeAcesso.Id && m.MenuPai == null).ToList();
            menus = RemoverSubMenusComDiferentesNiveisDeAcesso(menus, numeroNivelDeAcesso);
            return menus;
        }

        private List<Menu> RemoverSubMenusComDiferentesNiveisDeAcesso(List<Menu> menus, NumeroNivelDeAcesso numeroNivelDeAcesso)
        {
            var menusRemovidos = new List<Menu>();

            foreach (var menu in menus)
            {
                if (menu.NivelDeAcesso.Nivel > numeroNivelDeAcesso)
                {
                    menusRemovidos.Add(menu);
                }
                else if (menu.SubMenus.Count > 0)
                {
                    menu.SubMenus = RemoverSubMenusComDiferentesNiveisDeAcesso(menu.SubMenus.ToList(), numeroNivelDeAcesso);
                }
            }

            if (menusRemovidos.Count > 0)
            {
                foreach (var menuRemovido in menusRemovidos)
                {
                    menus.RemoveAll(m => m.Id == menuRemovido.Id);
                }
            }
            
            return menus;
        }
    }
}
