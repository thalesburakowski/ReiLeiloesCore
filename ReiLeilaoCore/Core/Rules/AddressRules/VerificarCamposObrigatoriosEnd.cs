using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.AddressRules
{
    public class VerificarCamposObrigatoriosEnd : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Address)
            {
                var Address = (Address)entidade;

                if (String.IsNullOrEmpty(Address.State) || String.IsNullOrEmpty(Address.City) 
                    || String.IsNullOrEmpty(Address.ZipCode) || String.IsNullOrEmpty(Address.Neighboorhood) 
                    || String.IsNullOrEmpty(Address.Street) || String.IsNullOrEmpty(Address.Number) 
                    || String.IsNullOrEmpty(Address.Name))
                {
                    return "Preencha todos os campos obrigatórios!";
                }
                return null;
            }
            return "Essa entidade não é do tipo endereço!";
        }
    }
}
