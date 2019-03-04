using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Core.Application
{
    public class Result
    {
        public string Msg { get; set; }
        public List<Entity> Entities { get; set; }
    }
}
