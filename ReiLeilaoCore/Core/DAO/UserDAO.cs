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

        public void Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity>Consultar(Entity entidade)
        {
            string json = null;
            if (String.IsNullOrEmpty(entidade.Id))
            {
                string endpoint = "user/";
                json = new RestConnection().GetRequest(endpoint);
            }
            else
            {
                string endpoint = "user/";
                endpoint = endpoint + entidade.Id;
                json = new RestConnection().GetRequestById(endpoint, entidade);
            }

            //List<KeyValue> parameterList = new List<KeyValue>()
            //{
            //    new KeyValue()
            //    {
            //        Key = "id",
            //        Value = entidade.Id
            //    }
            //};
            //string json = new RestConnection().GetResponseRestPost(url, endpoint, parameterList, urlSegmentList);
            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);
            //if (objList != null)
            //    foreach (var obj in objList)
            //    {
            //        objReturn.Add(obj);
            //    }

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
