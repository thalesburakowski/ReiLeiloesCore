using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarEmailJaCadastrado : IStrategy
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
                        if (UserRegistred.Password != User.Password)
                        {
                            return "Email ou senha incorretas!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
