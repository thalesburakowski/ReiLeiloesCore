using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReiLeilaoCore.Core.Util;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.DAO
{
    public class ProfileDAO : IDAO
    {
        public void Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Consultar(Entity entidade)
        {
            string json = null;
            if (String.IsNullOrEmpty(entidade.Id))
            {
                string endpoint = "profile/";
                json = new RestConnection().GetRequest(endpoint);
            }
            else
            {
                string endpoint = "profile/";
                endpoint = endpoint + entidade.Id;
                json = new RestConnection().GetRequestById(endpoint, entidade);
            }

            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;

            throw new NotImplementedException();
        }

        public void Excluir(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Entity entidade)
        {
            throw new NotImplementedException();
        }
    }
}
