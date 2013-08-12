using SupplyManager.Dominio;
using SupplyManager.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManager.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public IDominioContext Contexto { get; set; }

        public BaseController()
        {
            Contexto = new SupplyManagerDbContext();
        }

        public BaseController(IDominioContext contexto)
        {
            Contexto = contexto;
        }
    }
}
