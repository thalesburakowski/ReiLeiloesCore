using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Core.Util;
using ReiLeilaoCore.Domain;
using RestSharp;

namespace ReiLeilaoCore.Core.DAO
{
    public class UserDAO : IDAO
    {
        const string url = "localhost:3000/";
        const string endpoint = "user";

        public void Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Consultar(Entity entidade)
        {
            List<KeyValue> parameterList = new List<KeyValue>()
            {
                new KeyValue()
                {
                    Key = "id",
                    Value = entidade.Id
                }
            };
            List<KeyValue> urlSegmentList = null;
            string json = new RestConnection().GetResponseRest(url, endpoint, Method.POST, parameterList, urlSegmentList);
            List<User> objList = JsonConvert.DeserializeObject<List<User>>(json);

            var objReturn = new List<Entity>();

            if (objList != null)
                foreach (var obj in objList)
                {
                    objReturn.Add(obj);
                }

            return objReturn;
            //throw new NotImplementedException();
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
