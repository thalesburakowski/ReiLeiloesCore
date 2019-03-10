using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.ProfileRules
{
    public class VerificarCamposObrigatorios : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Profile)
            {
                var Profile = (Profile)entidade;

                if (String.IsNullOrEmpty(Profile.Name) || String.IsNullOrEmpty(Profile.LastName) 
                    || String.IsNullOrEmpty(Profile.Cpf) || String.IsNullOrEmpty(Profile.Rg) ||
                    Profile.BirthDate == null || String.IsNullOrEmpty(Profile.NickName))
                {
                    return "Preencha todos os campos obrigatórios!";
                }
                return null;
            }
            return "Essa entidade não é do tipo usuário!";
            
        }
    }
}
