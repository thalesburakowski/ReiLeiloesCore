using ReiLeilaoCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Core
{
    public interface IDAO
    {
        void Salvar(Entity entidade);
        void Alterar(Entity entidade);
        void Excluir(Entity entidade);
        List<Entity> Consultar(Entity entidade);
    }
}
