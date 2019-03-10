﻿using System;
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
using ReiLeilaoCore.Core.Rules.ProfileRules;


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

            // regras de negócio genéricas
            var VerificarId = new VerificarId();

            // USER FACADE
            var UserDAO = new UserDAO();
            _daos.Add(new User().GetType(), UserDAO);

            // regras de negócio User
            var VerificarEmail = new VerificarEmail();
            var VerificarSenha = new VerificarSenha();
            var CriptografarSenha = new CriptografarSenha();
            var VerificarSenhaIgual = new VerificarSenhaIgual();
            var VerificarSenhaVerdadeira = new VerificarSenhaVerdadeira();
            var CriptografarNovaSenha = new CriptografarNovaSenha();
            var VerificarConfirmacaoSenha = new VerificarConfirmacaoSenha();

            List<IStrategy> rnsSalvarUser = new List<IStrategy>();
            rnsSalvarUser.Add(VerificarEmail);
            rnsSalvarUser.Add(VerificarSenha);
            rnsSalvarUser.Add(VerificarConfirmacaoSenha);
            rnsSalvarUser.Add(CriptografarSenha);
            

            List<IStrategy> rnsConsultarUser = new List<IStrategy>();

            rnsConsultarUser.Add(VerificarEmail);
            rnsConsultarUser.Add(VerificarSenha);
            rnsConsultarUser.Add(CriptografarSenha);

            List<IStrategy> rnsAlterarUser = new List<IStrategy>();

            rnsAlterarUser.Add(VerificarId);
            rnsAlterarUser.Add(VerificarSenha);
            rnsAlterarUser.Add(CriptografarSenha);
            rnsAlterarUser.Add(VerificarSenhaVerdadeira);
            rnsAlterarUser.Add(CriptografarNovaSenha);
           
            

            List<IStrategy> rnsExcluirUser = new List<IStrategy>();

            rnsExcluirUser.Add(VerificarId);

            var rnsUser = new Dictionary<string, List<IStrategy>>();

            rnsUser.Add("CONSULTAR", rnsConsultarUser);
            rnsUser.Add("SALVAR", rnsSalvarUser);
            rnsUser.Add("ALTERAR", rnsAlterarUser);
            rnsUser.Add("EXCLUIR", rnsExcluirUser);

            _rns.Add(new User().GetType(), rnsUser);

            // PROFILE FACADE
            var ProfileDAO = new ProfileDAO();

            _daos.Add(new Profile().GetType(), ProfileDAO);

            // regras de negócio Profile
            var VerificarUserId = new VerificarUserId();

            List<IStrategy> rnsSalvarProfile = new List<IStrategy>();
            rnsSalvarProfile.Add(VerificarUserId);

            List<IStrategy> rnsConsultarProfile = new List<IStrategy>();
            rnsConsultarProfile.Add(VerificarId);

            var rnsProfile = new Dictionary<string, List<IStrategy>>();

            rnsProfile.Add("CONSULTAR", rnsConsultarProfile);

            rnsProfile.Add("SALVAR", rnsSalvarProfile);

            _rns.Add(new Profile().GetType(), rnsProfile);


            // PROFILE FACADE
            //var ProfileDAO = new ProfileDAO();

            //_daos.Add(new Profile().GetType(), ProfileDAO);

            //// regras de negócio Profile

            //List<IStrategy> rnsSalvarProfile = new List<IStrategy>();

            //List<IStrategy> rnsConsultarProfile = new List<IStrategy>();

            //List<IStrategy> rnsAlterarProfile = new List<IStrategy>();

            //List<IStrategy> rnsExcluirProfile = new List<IStrategy>();

            //var rnsProfile = new Dictionary<string, List<IStrategy>>();

            //rnsProfile.Add("CONSULTAR", rnsConsultarProfile);
            //rnsProfile.Add("SALVAR", rnsSalvarProfile);
            //rnsProfile.Add("ALTERAR", rnsAlterarProfile);
            //rnsProfile.Add("EXCLUIR", rnsExcluirProfile);

            //_rns.Add(new Profile().GetType(), rnsProfile);


        }

        public Result Alterar(Entity entidade)
        {
            resultado = new Result();
            Type nmClasse = entidade.GetType();

            string msg = executarRegras(entidade, "ALTERAR");

            if (msg == null)
            {
                IDAO dao = _daos[nmClasse];
                try
                {
                    resultado.Entities = dao.Alterar(entidade);
                }
                catch (Exception e)
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
                catch (Exception e)
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
            resultado = new Result();
            Type nmClasse = entidade.GetType();

            string msg = executarRegras(entidade, "EXCLUIR");

            if (msg == null)
            {
                IDAO dao = _daos[nmClasse];
                try
                {
                    
                    resultado.Entities = dao.Excluir(entidade);
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    resultado.Msg = "Não foi possí­vel realizar a exclusão!";
                }
            }
            else
            {
                resultado.Msg = msg;
            }
            return resultado;

        }

        public Result Salvar(Entity entidade)
        {
            resultado = new Result();
            Type nmClasse = entidade.GetType();

            string msg = executarRegras(entidade, "SALVAR");

            if (msg == null)
            {
                IDAO dao = _daos[nmClasse];
                try
                {
                    resultado.Entities = dao.Salvar(entidade);
                }
                catch (Exception e)
                {
                    Console.Write(e.StackTrace);
                    resultado.Msg = "Não foi possí­vel realizar a inserção!";
                }
            }
            else
            {
                resultado.Msg = msg;
            }
            return resultado;
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
