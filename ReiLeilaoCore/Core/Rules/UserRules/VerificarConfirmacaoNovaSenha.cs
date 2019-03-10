using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarConfirmacaoNovaSenha : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (string.Compare(User.NewPassword, User.ConfirmationPassword) != 0)
                {
                    return "As senhas precisam ser iguais!";
                }
                return null;
            }
            else
            {
                return "Essa entidade não é do tipo usuário!";
            }
        }
    }
}
