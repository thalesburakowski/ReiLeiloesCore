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
        public List<Entity> Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Consultar(Entity entidade)
        {
            Profile Profile = (Profile)entidade;
            string endpoint = "profile/";
            string json = null;
            if (String.IsNullOrEmpty(entidade.Id))
            {
                if(String.IsNullOrEmpty(Profile.Cpf))
                json = new RestConnection().GetRequest(endpoint);
            }
            else
            {
               
                endpoint = endpoint + entidade.Id;
                json = new RestConnection().GetRequestById(endpoint, entidade);
            }

            Profile objList = JsonConvert.DeserializeObject<Profile>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;

            throw new NotImplementedException();
        }

        public List<Entity> Excluir(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Salvar(Entity entidade)
        {
            throw new NotImplementedException();
        }

    }
}
