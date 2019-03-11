using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Domain
{
    public class Profile : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string BirthDate { get; set; }
        public string NickName { get; set; }
    }
}
