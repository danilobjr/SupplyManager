using SupplyManager.Dominio;
using SupplyManager.Dominio.Entidades;
using SupplyManager.Dominio.Helpers;
using SupplyManager.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.AppInsereDados
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SupplyManagerDbContext>());

            PopularContexto(new SupplyManagerDbContext());
        }

        public static void PopularContexto(IDominioContext contexto)
        {
            var usuarios = CriarUsuarios();

            usuarios.ForEach(u => contexto.Usuarios.Add(u));
            contexto.SaveChanges();
        }

        private static List<Usuario> CriarUsuarios()
        {
            var usuarios = new List<Usuario>();

            usuarios.Add(new Usuario
            {
                Id = 1,
                Nome = "Danilo Jr.",
                Email = "danilobjr@gmail.com",
                Login = "danilobjr@gmail.com",
                Senha = (new Criptografia()).Criptografar("123456")
            });

            usuarios.Add(new Usuario
            {
                Id = 2,
                Nome = "Felipe Ferreira",
                Email = "felipefrer@gmail.com",
                Login = "felipefrer@gmail.com",
                Senha = (new Criptografia()).Criptografar("654321")
            });

            return usuarios;
        }
    }
}
