using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;
using ReiLeilaoCore.Core.Util;

namespace ReiLeilaoCore.Core.Rules.ProfileRules
{
    public class VerificarCpfValido : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Profile)
            {
                var  VerificarCpf = new VerificarCpf();
                var Profile = (Profile)entidade;

                if (!VerificarCpf.IsCpf(Profile.Cpf))
                {
                    return "Esse cpf não é válido!";
                }
                return null;
            }
            return "Essa entidade não é do tipo perfil!";
        }
    }
}
