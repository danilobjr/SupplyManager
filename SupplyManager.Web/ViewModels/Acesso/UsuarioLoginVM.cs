using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web.ViewModels.Acesso
{
    public class UsuarioLoginVM : BaseVM
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ManterConectado { get; set; }
    }
}