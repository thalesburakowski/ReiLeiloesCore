using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarSenhaVerdadeira : IStrategy
    {
        public string Processar(Entity entidade)
        {
            var UserDao = new UserDAO();
            try
            {
                if (entidade is User)
                {
                    var User = (User)entidade;
                    if (!String.IsNullOrEmpty(User.Password))
                    {
                        var UserRegistred = (User)UserDao.Consultar(User)[0];
                        if (String.IsNullOrEmpty(UserRegistred.Id))
                        {
                            return "Senha antiga incorreta!";
                        }
                    }
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
