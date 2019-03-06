using ReiLeilaoCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarEmail : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (String.IsNullOrEmpty(User.Email))
                {
                    return "O email precisa ser preenchido";
                }
            }
            return null;
        }
    }
}
