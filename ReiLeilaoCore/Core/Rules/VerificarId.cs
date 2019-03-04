using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Rules
{
    public class VerificarId : IStrategy
    {
        public string Processar(Entity entidade)
        {
            if (String.IsNullOrEmpty(entidade.Id))
            {
                return "O id precisa ser preenchido";
            }
            return null;
        }
    }
}
