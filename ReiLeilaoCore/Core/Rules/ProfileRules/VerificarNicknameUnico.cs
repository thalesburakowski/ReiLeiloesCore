using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.ProfileRules
{
    public class VerificarNicknameUnico : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Profile)
            {
                var dao = new ProfileDAO();
                var Profile = (Profile)entidade;
                var SearchProfile = (Profile)entidade;

                SearchProfile.NickName = Profile.NickName;
                List<Entity> resultProfile = (List<Entity>)dao.Consultar(SearchProfile);
                if (resultProfile.Count > 0)
                {
                    return "Esse Nickname já está cadastrado!";
                }

            }
            return null;
        }
    }
}
