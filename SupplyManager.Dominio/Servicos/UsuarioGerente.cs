using SupplyManager.Comum.Exceptions;
using SupplyManager.Dominio.Entidades;
using SupplyManager.Dominio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Dominio.Servicos
{
    public class UsuarioGerente
    {
		IDominioContext ctx;

		public UsuarioGerente(IDominioContext ctx)
		{
			this.ctx = ctx;
		}

		public Usuario CriarNovoUsuario(string nome, string senha, string email)
		{
			var novoUsuario = new Usuario { Nome = nome, Senha = senha, Email = email };
			ValidarNovoUsuario(novoUsuario);
			return novoUsuario;
		}

        public void ValidarAlterarUsuario(Usuario usuario)
        {
            var violacaoDeRegras = new RegraDeNegocioException<Usuario>();

            bool emailJaExiste = ctx.Usuarios.Any(u => u.Email == usuario.Email && u.Id != usuario.Id);

            if (emailJaExiste)
                violacaoDeRegras.AdicionarErro(u => u.Email, "E-mail já existente");

            ValidaCamposObrigatorios(usuario, violacaoDeRegras);

            if (violacaoDeRegras.Erros.Any())
            {
                throw violacaoDeRegras;
            }
        }

		private void ValidarNovoUsuario(Usuario novoUsuario)
		{
			var violacaoDeRegras = new RegraDeNegocioException<Usuario>();

			ValidaCamposObrigatorios(novoUsuario, violacaoDeRegras);

			ValidaOutraRegras(novoUsuario, violacaoDeRegras);
		}

		private void ValidaOutraRegras(Usuario novoUsuario, RegraDeNegocioException<Usuario> violacaoDeRegras)
		{
			if (EmailJaExiste(novoUsuario.Email))
			{
				violacaoDeRegras.AdicionarErro(x => x.Email, "Email já existente");
			}

            if (!Util.EmailEhValido(novoUsuario.Email))
			{
				violacaoDeRegras.AdicionarErro(x => x.Email, "Email inválido");
			}

			if (violacaoDeRegras.Erros.Any())
			{
				throw violacaoDeRegras;
			}
		}

		private static void ValidaCamposObrigatorios(Usuario novoUsuario, RegraDeNegocioException<Usuario> violacaoDeRegras)
		{
			if (String.IsNullOrEmpty(novoUsuario.Nome))
			{
				violacaoDeRegras.AdicionarErro(x => x.Nome, "Informe o nome do usuário");
			}

			if (String.IsNullOrEmpty(novoUsuario.Senha))
			{
				violacaoDeRegras.AdicionarErro(x => x.Nome, "Informe a senha do usuário");
			}

			if (String.IsNullOrEmpty(novoUsuario.Email))
			{
				violacaoDeRegras.AdicionarErro(x => x.Nome, "Informe o email do usuário");
			}

			if (violacaoDeRegras.Erros.Any())
			{
				throw violacaoDeRegras;
			}
		}

		private bool EmailJaExiste(string email)
		{
			var usuario = ctx.Usuarios.Where(u => u.Email == email).FirstOrDefault();
			if (usuario != null)
				return true;
			return false;
		}
    }
}
