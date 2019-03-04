using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FlagAdmin { get; set; }
        public bool Active { get; set; }
        public string ProfileId { get; set; }
    }
}
