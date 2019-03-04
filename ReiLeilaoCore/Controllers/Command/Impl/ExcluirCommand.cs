using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Controllers.Command.Impl
{
    public class ExcluirCommand: AbstractCommand
    {
        public override Result Execute(Entity entidade)
        {
            return Facade.Excluir(entidade);
        }
    }
}
