using SupplyManager.Dominio.Entidades;
using SupplyManager.Web.ViewModels.Acesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyManager.Web.AutoMappers
{
    class UsuarioMapeador
    {
        public static UsuarioLogadoVM Mapear(Usuario usuario)
        {
            return new UsuarioLogadoVM
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                Email = usuario.Email,
                GrupoDeUsuarioDescricao = usuario.GrupoDeUsuario.Descricao,
                NumeroNivelDeAcesso = usuario.GrupoDeUsuario.NivelDeAcesso.Nivel
            };
        }
    }
}