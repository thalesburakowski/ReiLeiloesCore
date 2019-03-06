using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarSenhaIgual : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var UserDao = new UserDAO();
            try
            {
                if (entidade is User)
                {
                    var user = (User)entidade;
                    var userRegistred = UserDao.Consultar(user);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
