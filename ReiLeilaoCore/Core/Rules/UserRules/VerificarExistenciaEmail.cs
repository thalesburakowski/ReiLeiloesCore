using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarExistenciaEmail : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var UserDao = new UserDAO();
            var User = (User)entidade;

            String response = UserDao.VerificarExistencia(User);

            if (string.Compare(response, "ativo") == 0)
            {
                return "Esse e-mail já está cadastrado!";
            }
            return null;
        }
    }


}
