using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers.Command.Impl
{
    public class ConsultarCommand : AbstractCommand
    {
        public override Result Execute(Entity entidade)
        {
            return Facade.Consultar(entidade);
        }
    }
}
