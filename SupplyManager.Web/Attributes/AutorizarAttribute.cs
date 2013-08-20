using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SupplyManager.Web.Attributes
{
    class AutorizarAttribute : AuthorizeAttribute
    {
        public NumeroNivelDeAcesso NumeroNivelDeAcesso { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var estahAutorizado = base.AuthorizeCore(httpContext);
            if (!estahAutorizado)
            {
                return false;
            }

            var numeroNivelDeAcessoDoUsuario = Sessao.ObterUsuarioLogado().NumeroNivelDeAcesso;
                //string.Join("", GetUserRights(httpContext.User.Identity.Name.ToString())); // Call another method to get rights of the user from DB

            if (numeroNivelDeAcessoDoUsuario >= NumeroNivelDeAcesso)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //base.HandleUnauthorizedRequest(filterContext);

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                        new
                        {
                            controller = "Erro",
                            action = "AcessoNaoAutorizado"
                        }
                    ));
        }
    }
}