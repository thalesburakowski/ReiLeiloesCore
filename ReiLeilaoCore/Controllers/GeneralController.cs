using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Controllers.Command;
using ReiLeilaoCore.Controllers.Command.Impl;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers
{
    public class GeneralController
    {
        private static Dictionary<string, ICommand> _commands;

        public GeneralController()
        {
            _commands = new Dictionary<string, ICommand>();
            _commands.Add("SALVAR", new SalvarCommand());
            _commands.Add("EXCLUIR", new ExcluirCommand());
            _commands.Add("CONSULTAR", new ConsultarCommand());
            _commands.Add("ALTERAR", new AlterarCommand());
        }

        public Result DoProcessRequest(Entity entidade, string strOperacao)
        {
            ICommand command = _commands[strOperacao];
            Result result = command.Execute(entidade);
            return result;
        }
    }
}
