using SupplyManager.Dominio;
using SupplyManager.Dominio.Entidades;
using SupplyManager.Dominio.Servicos;
using SupplyManager.Infra;
using SupplyManager.Web.AutoMappers;
using SupplyManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManager.Web.Controllers
{
    public class BaseController : Controller
    {
        public IDominioContext Contexto { get; set; }
        public MenuGerente MenuGerente { get; set; }

        public BaseController()
        {
            Contexto = new SupplyManagerDbContext();
            MenuGerente = new MenuGerente(Contexto);
        }

        public BaseController(IDominioContext contexto)
        {
            Contexto = contexto;
        }
    }
}
