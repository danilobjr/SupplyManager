using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Dominio
{
    public interface IDominioContext    
    {
        IDbSet<Usuario> Usuarios { get; }
        IDbSet<GrupoDeUsuario> GruposDeUsuario { get; }
        IDbSet<Menu> Menus { get; }
        IDbSet<NivelDeAcesso> NiveisDeAcesso { get; }

        int SaveChanges();
    }
}
