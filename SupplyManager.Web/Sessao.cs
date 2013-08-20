using SupplyManager.Dominio.Entidades;
using SupplyManager.Dominio.Servicos;
using SupplyManager.Infra;
using SupplyManager.Web.AutoMappers;
using SupplyManager.Web.ViewModels;
using SupplyManager.Web.ViewModels.Acesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web
{
    class Sessao
    {
        public static void RegistrarUsuarioLogadoEmSessao(UsuarioLogadoVM usuarioLogado)
        {
            HttpContext.Current.Session["UsuarioLogado"] = usuarioLogado;
        }

        public static UsuarioLogadoVM ObterUsuarioLogado()
        {
            return (UsuarioLogadoVM)HttpContext.Current.Session["UsuarioLogado"];
        }

        public static void RegistrarMenuDoUsuarioLogadoEmSessao(NumeroNivelDeAcesso numeroNivelDeAcesso)
        {
            using (var contexto = new SupplyManagerDbContext())
            {
                var menuGerente = new MenuGerente(contexto);
                var menus = menuGerente.ObterMenusPor(numeroNivelDeAcesso);
                var menusViewModel = MenuMapeador.Mapear(menus);
                HttpContext.Current.Session["Menu"] = menusViewModel;
            }
        }

        public static List<MenuVM> ObterMenuDoUsuarioLogado()
        {
            return (List<MenuVM>)HttpContext.Current.Session["Menu"];
        }
    }
}