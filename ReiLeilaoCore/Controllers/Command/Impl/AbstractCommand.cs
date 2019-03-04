using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Core;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Core.Control;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers.Command.Impl
{
    public class AbstractCommand : ICommand
    {
        protected IFacade Facade = new Facade();

        public virtual Result Execute(Entity entidade)
        {
            throw new NotImplementedException();
        }
    }
}
