using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarCamposNulosAlterar : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (String.IsNullOrEmpty(User.NewPassword))
                {
                    return "Preencha todos os campos obrigatórios!";
                }
                if (String.IsNullOrEmpty(User.ConfirmationPassword))
                {
                    return "Preencha todos os campos obrigatórios!";
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
