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
        public string ConfirmationPassword { get; set; }
        public string NewPassword { get; set; }
        public bool FlgAdmin { get; set; }
        public bool Active { get; set; }
        public string ProfileId { get; set; }
    }
}
