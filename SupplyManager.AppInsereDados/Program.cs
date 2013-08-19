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
            var niveisDeAcesso = CriarNiveisDeAcesso();

            niveisDeAcesso.ForEach(n => contexto.NiveisDeAcesso.Add(n));
            contexto.SaveChanges();

            var gruposDeUsuario = CriarGruposDeUsuario();

            gruposDeUsuario.ForEach(g => contexto.GruposDeUsuario.Add(g));
            contexto.SaveChanges();

            var usuarios = CriarUsuarios();

            usuarios.ForEach(u => contexto.Usuarios.Add(u));
            contexto.SaveChanges();

            var menus = CriarMenus();

            menus.ForEach(m => contexto.Menus.Add(m));
            contexto.SaveChanges();

            var subMenus = CriarSubMenus(menus);

            subMenus.ForEach(m => contexto.Menus.Add(m));
            contexto.SaveChanges();
        }

        private static List<NivelDeAcesso> CriarNiveisDeAcesso()
        {
            var niveisDeAcesso = new List<NivelDeAcesso>();

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 1,
                Nivel = NumeroNivelDeAcesso.MuitoBaixo
            });

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 2,
                Nivel = NumeroNivelDeAcesso.Baixo
            });

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 3,
                Nivel = NumeroNivelDeAcesso.Normal
            });

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 4,
                Nivel = NumeroNivelDeAcesso.Alto
            });

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 5,
                Nivel = NumeroNivelDeAcesso.MuitoAlto
            });

            niveisDeAcesso.Add(new NivelDeAcesso
            {
                //Id = 6,
                Nivel = NumeroNivelDeAcesso.Total
            });

            return niveisDeAcesso;
        }

        private static List<Usuario> CriarUsuarios()
        {
            var usuarios = new List<Usuario>();

            var senha = (new Criptografia()).Criptografar("123456");

            usuarios.Add(new Usuario
            {
                Id = 1,
                Nome = "Usuário Comum",
                Email = "danilo.emailteste@gmail.com",
                Login = "usuario",
                Senha = senha,
                GrupoDeUsuarioId = 1
            });

            usuarios.Add(new Usuario
            {
                Id = 2,
                Nome = "Supervisor",
                Email = "danilo.emailteste@gmail.com",
                Login = "supervisor",
                Senha = senha,
                GrupoDeUsuarioId = 2
            });

            usuarios.Add(new Usuario
            {
                Id = 3,
                Nome = "Coordenador Regional",
                Email = "danilo.emailteste@gmail.com",
                Login = "coordenadorregional",
                Senha = senha,
                GrupoDeUsuarioId = 3
            });

            usuarios.Add(new Usuario
            {
                Id = 4,
                Nome = "Coordenador Nacional",
                Email = "danilo.emailteste@gmail.com",
                Login = "coordenadornacional",
                Senha = senha,
                GrupoDeUsuarioId = 4
            });

            usuarios.Add(new Usuario
            {
                Id = 5,
                Nome = "Sup. Pedidos e Suprimentos",
                Email = "danilo.emailteste@gmail.com",
                Login = "supervisorpedidos",
                Senha = senha,
                GrupoDeUsuarioId = 5
            });

            usuarios.Add(new Usuario
            {
                Id = 6,
                Nome = "Analista de Suprimentos",
                Email = "danilo.emailteste@gmail.com",
                Login = "analista",
                Senha = senha,
                GrupoDeUsuarioId = 6
            });

            usuarios.Add(new Usuario
            {
                Id = 7,
                Nome = "Gerente Nacional",
                Email = "danilo.emailteste@gmail.com",
                Login = "gerente",
                Senha = senha,
                GrupoDeUsuarioId = 7
            });

            usuarios.Add(new Usuario
            {
                Id = 8,
                Nome = "Administrador",
                Email = "danilo.emailteste@gmail.com",
                Login = "admin",
                Senha = senha,
                GrupoDeUsuarioId = 8
            });

            return usuarios;
        }

        private static List<GrupoDeUsuario> CriarGruposDeUsuario()
        {
            var gruposDeUsuario = new List<GrupoDeUsuario>();

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 1,
                Descricao = "Usuário Comum",
                NivelDeAcessoId = 1
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 2,
                Descricao = "Supervisor",
                NivelDeAcessoId = 2
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 3,
                Descricao = "Coordenador Regional",
                NivelDeAcessoId = 3
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 4,
                Descricao = "Coordenador Nacional",
                NivelDeAcessoId = 4
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 5,
                Descricao = "Supervisor de Pedidos de Suprimentos",
                NivelDeAcessoId = 4
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 6,
                Descricao = "Analista de Suprimento",
                NivelDeAcessoId = 3
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 7,
                Descricao = "Gerente Nacional",
                NivelDeAcessoId = 5
            });

            gruposDeUsuario.Add(new GrupoDeUsuario
            {
                Id = 8,
                Descricao = "Administrador",
                NivelDeAcessoId = 6
            });

            return gruposDeUsuario;
        }

        private static List<Menu> CriarMenus()
        {
            var menus = new List<Menu>();

            menus.Add(new Menu
            {
                Id = 1,
                Descricao = "Usuário Comum Vê",
                Link = "/home/index",
                NivelDeAcessoId = 1
            });

            var menuComSubMenus = new Menu
            {
                Id = 2,
                Descricao = "Coo. Nacional e Sup. Pedidos Vê",
                NivelDeAcessoId = 4
                // Submenus adicionados em outro método                
            };

            menus.Add(menuComSubMenus);
            
            return menus;
        }

        private static List<Menu> CriarSubMenus(IList<Menu> menusRaiz)
        {
            var subMenus = new List<Menu>();

            subMenus.Add(new Menu
            {
                Id = 3,
                Descricao = "Coo. Nacional e Sup. Pedidos Vê",
                Link = "/home/index",
                MenuPaiId = menusRaiz.FirstOrDefault(m => m.Id == 2).Id,
                NivelDeAcessoId = 4
            });

            subMenus.Add(new Menu
            {
                Id = 4,
                Descricao = "Admin Vê",
                Link = "/home/index",
                MenuPaiId = menusRaiz.FirstOrDefault(m => m.Id == 2).Id,
                NivelDeAcessoId = 6
            });

            return subMenus;
        }
    }
}
