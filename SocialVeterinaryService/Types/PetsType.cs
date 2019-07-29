using GraphQL.Types;
using SocialVeterinaryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialVeterinaryService.Types
{
    public class PetsType : ObjectGraphType<Pets>
    {
        public PetsType() {
            Field(x => x.PetId);
            Field(x => x.OwnerId, type: typeof(IntGraphType));
            Field(x => x.PetName);
            Field(x => x.TypeId, type: typeof(IntGraphType));

            Field(x => x.Type, type: typeof(AnimalTypeType))
                .Resolve(
                    context => {
                        masterContext masterContext = (masterContext)context.UserContext;

                        return masterContext.AnimalType.Where(x => x.TypeId == context.Source.TypeId).FirstOrDefault();
                    }
                );
        }
    }
}
 