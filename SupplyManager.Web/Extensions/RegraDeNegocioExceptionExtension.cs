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
        public static void CopiarPara(this RegraDeNegocioException ex, ModelStateDictionary modelState)
        {
            CopiarPara(ex, modelState, null);
        }

        public static void CopiarPara(this RegraDeNegocioException ex, ModelStateDictionary modelState, string prefixo)
        {
            prefixo = string.IsNullOrEmpty(prefixo) ? "" : prefixo + ".";

            foreach (var prop in ex.Erros)
            {
                string chave = ExpressionHelper.GetExpressionText(prop.Propriedade);
                modelState.AddModelError(prefixo + chave, prop.Mensagem);
            }
        }
    }
}