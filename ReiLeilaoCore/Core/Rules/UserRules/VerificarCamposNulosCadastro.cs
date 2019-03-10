using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarCamposNulosCadastro : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (String.IsNullOrEmpty(User.Email))
                {
                    return "Preencha todos os campos obrigatórios!";
                }
                if (String.IsNullOrEmpty(User.Password))
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
