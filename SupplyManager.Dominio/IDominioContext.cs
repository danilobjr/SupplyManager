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
        int SaveChanges();
    }
}
