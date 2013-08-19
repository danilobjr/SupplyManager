using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Infra.Mapeamentos
{
    class NivelDeAcessoMapping : EntityTypeConfiguration<NivelDeAcesso>
    {
        public NivelDeAcessoMapping()
        {
            ToTable("NiveisDeAcesso");

            //HasKey(u => u.Id);

            //Property(u => u.Id).HasColumnName("Id").IsRequired();
            //Property(u => u.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            //Property(u => u.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            //Property(u => u.Login).HasColumnName("Login").HasMaxLength(100).IsRequired();
            //Property(u => u.Senha).HasColumnName("Senha").HasMaxLength(100).IsRequired();

            //HasRequired(u => u.GrupoDeUsuario).WithMany(g => g.Usuarios).HasForeignKey(u => u.GrupoDeUsuarioId);
        }
    }
}
