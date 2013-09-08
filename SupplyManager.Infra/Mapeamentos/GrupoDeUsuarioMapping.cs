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
        }
    }
}
