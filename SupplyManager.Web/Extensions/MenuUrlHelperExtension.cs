using SupplyManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SupplyManager.Web.Extensions
{
    public static class MenuUrlHelperExtension
    {
        public static MvcHtmlString Menu(this HtmlHelper helper, string id)
        {
            return Menu(helper, id, null);
        }

        public static MvcHtmlString Menu(this HtmlHelper helper, string id, object atributosDoElementoHtml)
        {
            var classeCssDaUlRaiz = "nav nav-tabs nav-stacked";
            var ul = ObterTagUl(classeCssDaUlRaiz, id, atributosDoElementoHtml);
            
            var conteudoHtmlDaUl = new StringBuilder();
            conteudoHtmlDaUl.Append(ObterTagLi("nav-header", "Menu"));

            var menus = Sessao.ObterMenuDoUsuarioLogado();

            foreach (var menu in menus)
	        {
                conteudoHtmlDaUl.Append(ObterTagLi(menu));
	        }

            ul.InnerHtml = conteudoHtmlDaUl.ToString();

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));
        }

        private static TagBuilder ObterTagUl()
        {
            return ObterTagUl(null);
        }

        private static TagBuilder ObterTagUl(string classeCss)
        {
            return ObterTagUl(classeCss, null);
        }

        private static TagBuilder ObterTagUl(string classeCss, string idDoElemento)
        {
            return ObterTagUl(classeCss, idDoElemento, null);
        }

        private static TagBuilder ObterTagUl(string classeCss, string idDoElemento, object atributosDoElementoHtml)
        {
            var tagUl = new TagBuilder("ul");

            if (!String.IsNullOrEmpty(classeCss))
            {
                tagUl.AddCssClass(classeCss);
            }

            if (!String.IsNullOrEmpty(idDoElemento))
            {
                tagUl.GenerateId(idDoElemento);
            }

            if (atributosDoElementoHtml != null)
            {
                tagUl.MergeAttributes(new RouteValueDictionary(atributosDoElementoHtml));
            }

            return tagUl;
        }

        private static TagBuilder ObterTagLi()
        {
            return ObterTagLi(null, null);
        }

        private static TagBuilder ObterTagLi(string classeCss)
        {
            return ObterTagLi(classeCss, null);
        }

        private static TagBuilder ObterTagLi(string classeCss, string texto)
        {
            var li = new TagBuilder("li");

            if (!String.IsNullOrEmpty(classeCss))
            {
                li.AddCssClass(classeCss);
            }

            if (!String.IsNullOrEmpty(texto))
            {
                li.SetInnerText(texto);
            }

            return li;
        }

        private static TagBuilder ObterTagLi(MenuVM menu)
        {
            TagBuilder tagLi = null;

            if (menu.SubMenus.Count > 0)
            {
                tagLi = ObterTagLi("dropdown");
                // montarTagUl e recursividade
                var tagSpanIcone = ObterTagSpan("iconfa-laptop");
                var tagALink = ObterTagA(tagSpanIcone.ToString() + menu.Descricao);
                var tagUl = ObterTagUl();

                var conteudoUl = new StringBuilder();

                foreach (var subMenu in menu.SubMenus)
                {
                    conteudoUl.Append(ObterTagLi(subMenu));
                }

                tagUl.InnerHtml = conteudoUl.ToString();

                tagLi.InnerHtml = tagALink.ToString() + tagUl.ToString();
            }
            else
            {
                tagLi = ObterTagLi();
                var tagSpanIcone = ObterTagSpan("iconfa-laptop");
                var tagALink = ObterTagA(tagSpanIcone.ToString() + menu.Descricao, menu.Link);
                tagLi.InnerHtml = tagALink.ToString();
            }

            return tagLi;
        }

        private static TagBuilder ObterTagA(string conteudo)
        {
            return ObterTagA(conteudo, null);
        }

        private static TagBuilder ObterTagA(string conteudo, string link)
        {
            var tagA = new TagBuilder("a");

            if (!string.IsNullOrEmpty(link))
            {
                tagA.MergeAttribute("href", link);
            }

            if (!string.IsNullOrEmpty(conteudo))
            {
                tagA.InnerHtml = conteudo;
            }
            
            return tagA;
        }

        private static TagBuilder ObterTagSpan(string icone)
        {
            var tagSpan = new TagBuilder("span");
            tagSpan.AddCssClass(icone);
            return tagSpan;
        }
    }
}