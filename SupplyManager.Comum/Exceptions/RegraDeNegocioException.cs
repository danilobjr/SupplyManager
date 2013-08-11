using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyManager.Comum.Exceptions
{
    public class RegraDeNegocioException : Exception
    {
        public readonly IList<ViolacaoDeRegra> Erros = new List<ViolacaoDeRegra>();
        private readonly static Expression<Func<object, object>> EsseObjeto = x => x;

        public void AdicionarErro(string mensagem)
        {
            Erros.Add(new ViolacaoDeRegra { Propriedade = EsseObjeto, Mensagem = mensagem });
        }
    }

    public class ViolacaoDeRegra
    {
        public LambdaExpression Propriedade { get; set; }
        public string Mensagem { get; set; }
    }

    public class RegraDeNegocioException<TModel> : RegraDeNegocioException
    {
        public void AdicionarErro<TProp>(Expression<Func<TModel, TProp>> propriedade, string mensagem)
        {
            Erros.Add(new ViolacaoDeRegra { Propriedade = propriedade, Mensagem = mensagem });
        }
    }
}
