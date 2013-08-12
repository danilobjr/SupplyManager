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
    public class UsuarioLoginGerente
    {
        IDominioContext Contexto { get; set; }

        public UsuarioLoginGerente(IDominioContext contexto)
        {
            Contexto = contexto;
        }

        public bool ValidarLoginESenha(string login, string senha)
        {
            ValidarCamposObrigatorios(login, senha);
            ValidarOutrasRegras(login, senha);

            return true;
        }

        private void ValidarCamposObrigatorios(string login, string senha)
        {
            var violacaoDeRegras = new RegraDeNegocioException<Usuario>();

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(senha))
            {
                violacaoDeRegras.AdicionarErro(x => x.Login, "Informe Login e Senha");
            }

            if (violacaoDeRegras.Erros.Any())
            {
                throw violacaoDeRegras;
            }
        }

        private void ValidarOutrasRegras(string login, string senha)
        {
            var violacaoDeRegras = new RegraDeNegocioException<Usuario>();

            var usuario = Contexto.Usuarios.SingleOrDefault(u => u.Login == login);

            if (usuario == null)
            {
                violacaoDeRegras.AdicionarErro(x => x.Login, "Usuário inexistente");
            }
            else
            {
                var senhaDescriptografada = (new Criptografia()).Descriptografar(usuario.Senha);

                if (senhaDescriptografada != senha)
                {
                    violacaoDeRegras.AdicionarErro(x => x.Login, "Senha incorreta");
                }
            }
            
            if (violacaoDeRegras.Erros.Any())
            {
                throw violacaoDeRegras;
            }
        }
    }
}
