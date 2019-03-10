using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class ConfirmarSenhaAntiga : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var UserDao = new UserDAO();
            try
            {
                if (entidade is User)
                {
                    var User = (User)entidade;

                    var UserRegistred = (User)UserDao.Consultar(User)[0];
                }
            }
            catch (Exception ex)
            {
                return "Senha antiga incorreta!";
            }

            return null;
        }
    }
}
