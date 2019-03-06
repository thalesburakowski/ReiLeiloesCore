using ReiLeilaoCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Core
{
    public interface IDAO
    {
        List<Entity> Salvar(Entity entidade);
        List<Entity> Excluir(Entity entidade);
        List<Entity> Alterar(Entity entidade);
        List<Entity> Consultar(Entity entidade);
    }
}
