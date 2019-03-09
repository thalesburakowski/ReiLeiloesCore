using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.ProfileRules
{
    public class VerificarUserId : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Profile)
            {
                var Profile = (Profile)entidade;
                if (String.IsNullOrEmpty(Profile.UserId))
                {
                    return "O Id precisa ser preenchido";
                }
            }

            return null;
        }
    }
}
