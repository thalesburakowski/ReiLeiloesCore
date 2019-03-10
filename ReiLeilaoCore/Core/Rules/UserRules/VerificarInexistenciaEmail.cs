using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarInexistenciaEmail : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var UserDao = new UserDAO();
            var User = (User)entidade;

            String response = UserDao.VerificarExistencia(User);

            if (string.Compare(response, "inativo") == 0 || string.Compare(response, "inexistente") == 0)
            {
                return "Esse e-mail não está cadastrado!";
            }
            return null;
            throw new NotImplementedException();
        }
    }
}
