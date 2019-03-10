using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class ConfirmarNovaSenha : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;

                if (User.NewPassword != User.ConfirmationPassword)
                {
                    return "A senha confirmada está diferente!";
                }
                return null;
            }
            return "Essa entidade não é do tipo usuário!";
        }
    }
}
