using SupplyManager.Comum.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyManager.Web.Extensions
{
    public static class RegraDeNegocioExceptionExtension
    {
        public static void CopiarPara(this RegraDeNegocioException e, ModelStateDictionary modelState)
        {
            CopiarPara(e, modelState, null);
        }

        public static void CopiarPara(this RegraDeNegocioException e, ModelStateDictionary modelState, string prefixo)
        {
            prefixo = string.IsNullOrEmpty(prefixo) ? "" : prefixo + ".";

            foreach (var prop in e.Erros)
            {
                string chave = ExpressionHelper.GetExpressionText(prop.Propriedade);
                modelState.AddModelError(prefixo + chave, prop.Mensagem);
            }
        }
    }
}