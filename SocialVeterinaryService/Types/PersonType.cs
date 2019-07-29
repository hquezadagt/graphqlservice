using GraphQL.Types;
using SocialVeterinaryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialVeterinaryService.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType() {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.LastName);
            Field(x => x.Miemployee, type: typeof(BooleanGraphType));

            Field(x => x.Pets, type: typeof(ListGraphType<PetsType>))
                .Resolve(
                    context => {
                        masterContext masterContext = (masterContext)context.UserContext;

                        return masterContext.Pets.Where(x => x.OwnerId == context.Source.Id).ToList();
                    }
                );

        }
    }
}
