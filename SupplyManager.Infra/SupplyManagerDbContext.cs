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
        public IDbSet<GrupoDeUsuario> GruposDeUsuario { get; set; }
        public IDbSet<Menu> Menus { get; set; }
        public IDbSet<NivelDeAcesso> NiveisDeAcesso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new GrupoDeUsuarioMapping());
            modelBuilder.Configurations.Add(new NivelDeAcessoMapping());
            modelBuilder.Configurations.Add(new MenuMapping());
        }
    }
}
