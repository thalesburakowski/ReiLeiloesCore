using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Core.Control;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers.Command.Impl
{
    public class AlterarCommand : AbstractCommand
    {
        public override Result Execute(Entity entidade)
        {
            return Facade.Alterar(entidade);
        }
    }
}
