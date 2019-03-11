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
using ReiLeilaoCore.Core.Rules.ProfileRules;
using ReiLeilaoCore.Core.Rules.AddressRules;


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
            var CriptografarSenha = new CriptografarSenha();
            var ConfirmarSenhaAntiga = new ConfirmarSenhaAntiga();
            var CriptografarNovaSenha = new CriptografarNovaSenha();
            var VerificarConfirmacaoSenha = new VerificarConfirmacaoSenha();
            var VerificarExistenciaEmail = new VerificarExistenciaEmail();
            var VerificarCamposNulosCadastro = new VerificarCamposNulosCadastro();
            var VerificarCamposNulosAlterar = new VerificarCamposNulosAlterar();
            var VerificarInexistenciaEmail = new VerificarInexistenciaEmail();
            var ConfirmarNovaSenha = new ConfirmarNovaSenha();

            List<IStrategy> rnsSalvarUser = new List<IStrategy>();
            rnsSalvarUser.Add(VerificarCamposNulosCadastro);
            rnsSalvarUser.Add(VerificarConfirmacaoSenha);
            rnsSalvarUser.Add(CriptografarSenha);
            rnsSalvarUser.Add(VerificarExistenciaEmail);
            
            List<IStrategy> rnsConsultarUser = new List<IStrategy>();
            rnsConsultarUser.Add(VerificarCamposNulosCadastro);
            rnsConsultarUser.Add(CriptografarSenha);
            rnsConsultarUser.Add(VerificarInexistenciaEmail);

            List<IStrategy> rnsAlterarUser = new List<IStrategy>();
            rnsAlterarUser.Add(VerificarCamposNulosCadastro);
            rnsAlterarUser.Add(VerificarCamposNulosAlterar);
            rnsAlterarUser.Add(VerificarId);
            rnsAlterarUser.Add(ConfirmarNovaSenha);
            rnsAlterarUser.Add(CriptografarSenha);
            rnsAlterarUser.Add(ConfirmarSenhaAntiga);
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

            var VerificarCamposObrigatorios = new VerificarCamposObrigatorios();
            var VerificarCpfValido = new VerificarCpfValido();
            var VerficarRgCpfUnicos = new VerficarRgCpfUnicos();
            var VerificarNicknameUnico = new VerificarNicknameUnico();

            List<IStrategy> rnsSalvarProfile = new List<IStrategy>();
            //rnsSalvarProfile.Add(VerificarUserId);
            rnsSalvarProfile.Add(VerificarCamposObrigatorios);
            rnsSalvarProfile.Add(VerificarCpfValido);
            rnsSalvarProfile.Add(VerficarRgCpfUnicos);
            rnsSalvarProfile.Add(VerificarNicknameUnico);

            List<IStrategy> rnsConsultarProfile = new List<IStrategy>();
            rnsConsultarProfile.Add(VerificarId);

            var rnsProfile = new Dictionary<string, List<IStrategy>>();

            rnsProfile.Add("CONSULTAR", rnsConsultarProfile);
            rnsProfile.Add("SALVAR", rnsSalvarProfile);

            _rns.Add(new Profile().GetType(), rnsProfile);


            //Address FACADE
            var AddressDAO  = new AddressDAO();
            _daos.Add(new Address().GetType(), AddressDAO);

            // regras de negócio Address
            var VerificarCamposObrigatoriosEnd = new VerificarCamposObrigatoriosEnd();
            var VerificarNomeUnico = new VerificarNomeUnico();
            var VerificarCampoObgAltEnd = new VerificarCampoObrigatorioAlteracaoEnd();

            List<IStrategy> rnsSalvarAddress = new List<IStrategy>();
            rnsSalvarAddress.Add(VerificarCamposObrigatoriosEnd);
            rnsSalvarAddress.Add(VerificarNomeUnico);

            List<IStrategy> rnsConsultarAddress = new List<IStrategy>();

            List<IStrategy> rnsAlterarAddress = new List<IStrategy>();
            rnsAlterarAddress.Add(VerificarNomeUnico);
            rnsAlterarAddress.Add(VerificarCampoObgAltEnd);

            List<IStrategy> rnsExcluirAddress = new List<IStrategy>();

            var rnsAddress = new Dictionary<string, List<IStrategy>>();

            rnsAddress.Add("CONSULTAR", rnsConsultarAddress);
            rnsAddress.Add("SALVAR", rnsSalvarAddress);
            rnsAddress.Add("ALTERAR", rnsAlterarAddress);
            rnsAddress.Add("EXCLUIR", rnsExcluirAddress);

            _rns.Add(new Address().GetType(), rnsAddress);






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
                    resultado.Msg = "Não foi possí­vel realizar essa operação!";
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
