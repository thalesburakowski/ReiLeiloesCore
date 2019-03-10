using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReiLeilaoCore.Domain
{
    public class Address : Entity
    {
        public string ProfileId { get; set; }
        public string State { get; set; }
        public string City { get; set; }       
        public string ZipCode { get; set; }
        public string Neighboorhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
