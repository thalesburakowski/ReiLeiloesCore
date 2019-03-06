using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarSenha : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (String.IsNullOrEmpty(User.Password))
                {
                    return "A senha precisa ser preenchida";
                }
            }
            return null;
        }
    }
}
