using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web.ViewModels.Acesso
{
    public class UsuarioLogadoVM
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string GrupoDeUsuarioDescricao { get; set; }
        public NumeroNivelDeAcesso NumeroNivelDeAcesso { get; set; }
    }
}