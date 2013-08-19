using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Infra.Mapeamentos
{
    class GrupoDeUsuarioMapping : EntityTypeConfiguration<GrupoDeUsuario>
    {
        public GrupoDeUsuarioMapping()
        {
            ToTable("GruposDeUsuario");

            //HasKey(u => u.Id);

            //Property(u => u.Id).HasColumnName("Id").IsRequired();
            //Property(u => u.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();

            //HasMany(g => g.Usuarios).WithRequired(u => u.GrupoDeUsuario).HasForeignKey(g => g.GrupoDeUsuarioId);
        }
    }
}
