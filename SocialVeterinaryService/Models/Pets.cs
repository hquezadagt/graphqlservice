using System;
using System.Collections.Generic;

namespace SocialVeterinaryService.Models
{
    public partial class Pets
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int? OwnerId { get; set; }
        public int? TypeId { get; set; }

        public virtual Person Owner { get; set; }
        public virtual AnimalType Type { get; set; }
    }
}
