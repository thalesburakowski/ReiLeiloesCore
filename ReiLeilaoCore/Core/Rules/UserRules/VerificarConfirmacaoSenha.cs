using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules.UserRules
{
    public class VerificarConfirmacaoSenha : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (entidade is User)
            {
                var User = (User)entidade;
                if (string.Compare(User.Password, User.ConfirmationPassword) != 0)
                {
                    Console.Write("eh diferente msm");
                    return "As senhas precisam ser iguais!";
                }

            }
            else
            {
                return "Essa entidade não é do tipo usuário!";

            }

            Console.Write("Chamou aqui");
            return null;
        }
    }
}
