using SupplyManager.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Infra.Mapeamentos
{
    public class MenuMapping : EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            ToTable("Menus");

            HasKey(m => m.Id);

            Property(m => m.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();
            Property(m => m.Link).HasColumnName("Link").HasMaxLength(100).IsOptional();

            HasOptional(m => m.MenuPai).WithMany().HasForeignKey(m => m.MenuPaiId);
            HasMany(m => m.SubMenus).WithOptional(sm => sm.MenuPai).HasForeignKey(m => m.MenuPaiId);
            //HasRequired(m => m.NivelDeAcesso).WithMany(n => n.Menus).Map(m => m.MapKey("NivelDeAcessoId"));
        }
    }
}
