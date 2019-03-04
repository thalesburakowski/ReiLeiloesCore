using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;
using ReiLeilaoCore.Core.Application;

namespace ReiLeilaoCore.Core
{
    public interface IFacade
    {
        Result Salvar(Entity entidade);
        Result Alterar(Entity entidade);
        Result Excluir(Entity entidade);
        Result Consultar(Entity entidade);
    }
}
