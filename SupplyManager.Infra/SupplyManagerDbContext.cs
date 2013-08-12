using SupplyManager.Dominio;
using SupplyManager.Dominio.Entidades;
using SupplyManager.Infra.Mapeamentos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Infra
{
    public class SupplyManagerDbContext : DbContext, IDominioContext
    {
        public SupplyManagerDbContext()
            : base("SupplyManagerDB")
        {
        }

        public IDbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }
    }
}
