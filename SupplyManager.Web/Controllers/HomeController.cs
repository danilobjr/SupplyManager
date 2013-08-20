using SupplyManager.Dominio.Entidades;
using SupplyManager.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManager.Web.Controllers
{
    public class HomeController : BaseController
    {
        [Autorizar(NumeroNivelDeAcesso=NumeroNivelDeAcesso.MuitoBaixo)]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        [Autorizar(NumeroNivelDeAcesso = NumeroNivelDeAcesso.Alto)]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [Autorizar(NumeroNivelDeAcesso = NumeroNivelDeAcesso.MuitoAlto)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
