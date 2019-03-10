using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.AddressRules
{
    public class VerificarNomeUnico : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Address)
            {
                Address Address = (Address)entidade;
                AddressDAO dao = new AddressDAO();
                Address SearchAddress = new Address();

                SearchAddress.Name = Address.Name;
                SearchAddress.ProfileId = Address.ProfileId;
                List<Entity> resultAddress = (List<Entity>)dao.VerificarNome(SearchAddress);

                if (resultAddress.Count > 0)
                {
                    return "Você já possui um endereço cadastrado com esse nome!";
                }
                return null;
            }
            return "Essa entidade não é do tipo endereço!";
        }
    }
}
