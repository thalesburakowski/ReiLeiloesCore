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

        public List<Entity> Consultar(Entity entidade)
        {
            Profile Profile = (Profile)entidade;
            string endpoint = "profile/";
            string json = null;

            endpoint = endpoint + entidade.Id;
            json = new RestConnection().GetRequest(endpoint);

            Profile objList = JsonConvert.DeserializeObject<Profile>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);

            return objReturn;
        }

        public List<Entity> Salvar(Entity entidade)
        {
            string json = null;
            Profile Profile = (Profile)entidade;
            string endpoint = "profile";
            json = new RestConnection().PostRequest(endpoint, Profile);

            Profile objList = JsonConvert.DeserializeObject<Profile>(json);

            var objReturn = new List<Entity>();
            objReturn.Add(objList);
            return objReturn;
        }

        public List<Entity> Excluir(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public List<Entity> VerificarRg(Entity entidade)
        {
            Profile Profile = (Profile)entidade;
            string endpoint = "profile/get-by-rg/" + Profile.Rg;
            string json = null;
            var objReturn = new List<Entity>();
            try
            {
                json = new RestConnection().GetRequest(endpoint);
                Profile objList = JsonConvert.DeserializeObject<Profile>(json);
                objReturn.Add(objList);
            }
            catch (Exception)
            {
                return objReturn;
            }
            return objReturn;
        }

        public List<Entity> VerificarCpf(Entity entidade)
        {
            Profile Profile = (Profile)entidade;
            string endpoint = "profile/get-by-cpf/" + Profile.Cpf;
            string json = null;
            var objReturn = new List<Entity>();
            try
            {
                json = new RestConnection().GetRequest(endpoint);
                Profile objList = JsonConvert.DeserializeObject<Profile>(json);
                objReturn.Add(objList);
            }
            catch (Exception)
            {
                return objReturn;
            }
            return objReturn;
        }

        public List<Entity> VerificarNick(Entity entidade)
        {
            Profile Profile = (Profile)entidade;
            string endpoint = "profile/get-by-nick/" + Profile.NickName;
            string json = null;
            var objReturn = new List<Entity>();
            try
            {
                json = new RestConnection().GetRequest(endpoint);
                Profile objList = JsonConvert.DeserializeObject<Profile>(json);
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
