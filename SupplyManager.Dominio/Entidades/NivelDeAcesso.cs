using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Dominio.Entidades
{
    public class NivelDeAcesso
	{
        public int Id { get; set; }
        public NumeroNivelDeAcesso Nivel { get; set; }
	}

    public enum NumeroNivelDeAcesso
    {
        MuitoBaixo = 0,
        Baixo = 1,
        Normal = 2,
        Alto = 3,
        MuitoAlto = 4,
        Total = 5
    }
}
