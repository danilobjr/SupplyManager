using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SupplyManager.Dominio.Helpers
{
    public class Util
    {
        public static bool EmailEhValido(string email)
        {
			 string MatchEmailPattern = 
				  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
				+ @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
					[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
				+ @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
					[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
				+ @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

			 if (email != null)
				 return Regex.IsMatch(email, MatchEmailPattern);
			 else
				 return false;
        }

    }
}
