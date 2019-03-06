using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Domain
{
    public class Profile : Entity
    {
        public string Name { get; set; }
        public string lastName { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime birthDate { get; set; }
        public string NickName { get; set; }
    }
}
