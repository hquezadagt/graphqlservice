using System;
using System.Collections.Generic;

namespace SocialVeterinaryService.Models
{
    public partial class AnimalType
    {
        public AnimalType()
        {
            Pets = new HashSet<Pets>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Pets> Pets { get; set; }
    }
}
