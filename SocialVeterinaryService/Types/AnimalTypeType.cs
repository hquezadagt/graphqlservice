using GraphQL.Types;
using SocialVeterinaryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialVeterinaryService.Types
{
    public class AnimalTypeType : ObjectGraphType<AnimalType>
    {
        public AnimalTypeType()
        {
            Field(x => x.TypeId);
            Field(x => x.TypeName);

            Field(x => x.Pets, type: typeof(ListGraphType<PetsType>))
                .Resolve(
                    context => {
                        masterContext masterContext = (masterContext)context.UserContext;

                        return masterContext.Pets.Where(x => x.TypeId == context.Source.TypeId).ToList();
                    }
                );
        }
    }
}
