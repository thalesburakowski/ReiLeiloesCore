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

        public List<Entity> Alterar(Entity entidade)
        {
            string json = null;
            var User = (User)entidade;
            string endpoint = "user";
            var Body = new User { Id = User.Id, Password = User.NewPassword };
            json = new RestConnection().PutRequest(endpoint, Body);

            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;
        }

        public List<Entity> Consultar(Entity entidade)
        {
            string json = null;
            var User = (User)entidade;
            string endpoint = "login";
            var Body = new User { Email = User.Email, Password = User.Password };
            json = new RestConnection().PostRequest(endpoint, Body);

            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;
        }

        public List<Entity> Excluir(Entity entidade)
        {
            string json = null;
            var User = (User)entidade;
            string endpoint = "user/" + User.Id;

            //json = new RestConnection().GetRequestById(endpoint, entidade);

            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;

        }

        public List<Entity> Salvar(Entity entidade)
        {
            throw new NotImplementedException();
        }

    }
}
