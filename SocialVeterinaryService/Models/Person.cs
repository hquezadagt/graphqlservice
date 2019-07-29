using System;
using System.Collections.Generic;

namespace SocialVeterinaryService.Models
{
    public partial class Person
    {
        public Person()
        {
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool? Miemployee { get; set; }

        public virtual ICollection<Pets> Pets { get; set; }
    }
}
