using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManager.Web.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult AcessoNaoAutorizado()
        {
            return View();
        }
    }
}
