using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;
using ReiLeilaoCore.Core.Application;


namespace ReiLeilaoCore.Controllers.Command
{
    interface ICommand
    {
        Result Execute(Entity entidade);
    }
}
