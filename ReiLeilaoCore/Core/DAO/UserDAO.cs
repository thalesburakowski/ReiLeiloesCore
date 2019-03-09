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

            json = new RestConnection().DeleteRequest(endpoint, entidade);

            User objList = JsonConvert.DeserializeObject<User>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;

        }

        public List<Entity> Salvar(Entity entidade)
        {
            string json = null;
            var User = (User)entidade;
            var body = User;
            json = new RestConnection().PostRequest("verifyEmail", body);

            var definition = new { response = "" };

            var resObj = JsonConvert.DeserializeAnonymousType(json, definition);

            User objList;

            //var objReturn;

            var objReturn = new List<Entity>();

            if (resObj.response != "inexistente")
            {
                if (resObj.response == "ativo")
                {
                    throw new Exception("Esse email já está sendo usado");
                }
                else if (resObj.response == "inativo")
                {
                    json = new RestConnection().PutRequest("reactivateUser", body);
                    objList = JsonConvert.DeserializeObject<User>(json);

                    objReturn.Add(objList);

                    return objReturn;
                }
            }

            if (User.FlagAdmin)
            {
                json = new RestConnection().PostRequest("admin", body);

                objList = JsonConvert.DeserializeObject<User>( json);

                objReturn.Add(objList);

                return objReturn;
            }

            string endpoint = "user";
            json = new RestConnection().PostRequest(endpoint, body);

            objList = JsonConvert.DeserializeObject<User>(json);

            objReturn.Add(objList);

            return objReturn;
            throw new NotImplementedException();
        }

    }
}
