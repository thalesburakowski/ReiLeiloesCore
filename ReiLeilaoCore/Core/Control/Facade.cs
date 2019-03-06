using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Core.DAO;
using ReiLeilaoCore.Domain;
using ReiLeilaoCore.Core.Rules;
using System.Text;
using System.Data.SqlClient;
using ReiLeilaoCore.Core.Rules.UserRules;

namespace ReiLeilaoCore.Core.Control
{
    public class Facade : IFacade
    {

        private readonly IDictionary<Type, IDAO> _daos;

        private readonly IDictionary<Type, Dictionary<string, List<IStrategy>>> _rns;

        private Result resultado;

        public Facade()
        {
            _daos = new Dictionary<Type, IDAO>();
            _rns = new Dictionary<Type, Dictionary<string, List<IStrategy>>>();

            // USER FACADE
            var UserDAO = new UserDAO();
            var ProfileDAO = new ProfileDAO();
            _daos.Add(new User().GetType(), UserDAO);
            _daos.Add(new Profile().GetType(), ProfileDAO);


            // regras de negócio genéricas
            var VerificarId = new VerificarId();

            // regras de negócio User
            var CriptografarSenha = new CriptografarSenha();
            var VerificarSenhaIgual = new VerificarSenhaIgual();
            var VerificarEmail = new VerificarEmail();

            // regras de negócio Profile


            List<IStrategy> rnsSalvarUser = new List<IStrategy>();
            rnsSalvarUser.Add(CriptografarSenha);

            List<IStrategy> rnsConsultarUser = new List<IStrategy>();
            rnsConsultarUser.Add(VerificarEmail);
            rnsConsultarUser.Add(CriptografarSenha);
            rnsConsultarUser.Add(VerificarSenhaIgual);

            List<IStrategy> rnsAlterarUser = new List<IStrategy>();
            rnsAlterarUser.Add(VerificarId);

            List<IStrategy> rnsExcluirUser = new List<IStrategy>();
            rnsExcluirUser.Add(VerificarId);



            var rnsUser = new Dictionary<string, List<IStrategy>>();

            rnsUser.Add("CONSULTAR", rnsConsultarUser);

            _rns.Add(new User().GetType(), rnsUser);
        }

        public Result Alterar(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public Result Consultar(Entity entidade)
        {
            resultado = new Result();
            Type nmClasse = entidade.GetType();

            string msg = executarRegras(entidade, "CONSULTAR");

            if (msg == null)
            {
                IDAO dao = _daos[nmClasse];
                try
                {
                    resultado.Entities = dao.Consultar(entidade);
                }
                catch (SqlException e)
                {
                    Console.Write(e.StackTrace);
                    resultado.Msg = "Não foi possí­vel realizar a consulta!";
                }
            }
            else
            {
                resultado.Msg = msg;
            }
            return resultado;
            throw new NotImplementedException();
        }

        public Result Excluir(Entity entidade)
        {
            throw new NotImplementedException();
        }

        public Result Salvar(Entity entidade)
        {
            throw new NotImplementedException();
        }


        private string executarRegras(Entity entidade, string operacao)
        {
            Type nmClasse = entidade.GetType();
            StringBuilder msg = new StringBuilder();

            _rns.TryGetValue(nmClasse, out var regrasOperacao);

            if (regrasOperacao != null)
            {
                List<IStrategy> regras = regrasOperacao[operacao];

                if (regras != null)
                {
                    foreach (IStrategy s in regras)
                    {
                        string m = s.Processar(entidade);

                        if (m != null)
                        {
                            msg.Append(m);
                            msg.Append("\n");
                        }
                    }
                }
            }
            if (msg.Length > 0)
                return msg.ToString();
            else
                return null;
        }
    }
}
