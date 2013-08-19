using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Dominio.Entidades
{
    public class Menu
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }

        public int? MenuPaiId { get; set; }
        public virtual Menu MenuPai { get; set; }

        public virtual ICollection<Menu> SubMenus { get; set; }

        public int NivelDeAcessoId { get; set; }
        public virtual NivelDeAcesso NivelDeAcesso { get; set; }
    }
}
