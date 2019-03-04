using ReiLeilaoCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Core
{
    public interface IStrategy
    {
        string Processar(Entity entidade);
    }
}
