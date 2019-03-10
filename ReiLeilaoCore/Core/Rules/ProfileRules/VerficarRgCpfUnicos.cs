using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.ProfileRules
{
    public class VerficarRgCpfUnicos : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is Profile)
            {
                var dao = new ProfileDAO();
                var Profile = (Profile)entidade;
                var SearchProfile = (Profile)entidade;

                //Passando um  perfil soh com o rg 
                SearchProfile.Rg = Profile.Rg;
                List<Entity> resultProfile = (List<Entity>) dao.Consultar(SearchProfile);
                if (resultProfile.Count > 0)
                {
                    return "Esse RG já está cadastrado!";
                }

                //Passando um  perfil soh com o cpf
                SearchProfile.Rg = "";
                SearchProfile.Cpf = Profile.Cpf;
                resultProfile = (List<Entity>)dao.Consultar(SearchProfile);
                if (resultProfile.Count > 0)
                {
                    return "Esse CPF já está cadastrado!";
                }

                return null;
            }
            return "Essa entidade não é do tipo usuário!";

        }
    }
}
