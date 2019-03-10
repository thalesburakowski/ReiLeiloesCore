using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.AddressRules
{
    public class VerificarCampoObrigatorioAlteracaoEnd : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Address)
            {
                var Address = (Address)entidade;

                if (String.IsNullOrEmpty(Address.Name))
                {
                    return "O nome não pode ser nulo!";
                }
                return null;
            }
            return "Essa entidade não é do tipo endereço!";
        }
    }
}
