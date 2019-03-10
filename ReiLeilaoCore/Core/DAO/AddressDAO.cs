using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReiLeilaoCore.Core;
using ReiLeilaoCore.Core.Util;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.DAO
{

    public class AddressDAO: IDAO
    {
        public List<Entity> Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Consultar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Excluir(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Salvar(Entity entidade)
        {
            string json = null;
            Address Address = (Address)entidade;
            string endpoint = "address";
            var objReturn = new List<Entity>();
            try
            {
                json = new RestConnection().PostRequest(endpoint, Address);
                Address objList = JsonConvert.DeserializeObject<Address>(json);
                objReturn.Add(objList);
                return objReturn;
            }
            catch (Exception)
            {
                return objReturn;
            }
        }

        public List<Entity> VerificarNome(Entity entidade)
        {
            Address Address = (Address)entidade;
            string endpoint = "address/";
            var objReturn = new List<Entity>();
            /// something ? color1 = red & color2 = blue
            string json = null;
            if (!String.IsNullOrEmpty(Address.Name))
            {
                endpoint = endpoint + Address.ProfileId +  "?name=" + Address.Name;
            }
            try
            {
                json = new RestConnection().GetRequest(endpoint);
                Address objList = JsonConvert.DeserializeObject<Address>(json);
                objReturn.Add(objList);
            }
            catch (Exception)
            {
                return objReturn;
            }
            return objReturn;
        }
    }
}
