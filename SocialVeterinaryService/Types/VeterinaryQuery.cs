using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialVeterinaryService.Models;

namespace SocialVeterinaryService.Types
{
    public class VeterinaryQuery : ObjectGraphType
    {
        public VeterinaryQuery()
        {
            Field<ListGraphType<PersonType>>(
                "personList",
                resolve: context =>
                {
                    masterContext masterContext = (masterContext)context.UserContext;

                    return masterContext.Person.ToList();
                }
                );

            Field<ListGraphType<AnimalTypeType>>(
                "animalTypeList",
                resolve: context =>
                {
                    masterContext masterContext = (masterContext)context.UserContext;

                    return masterContext.AnimalType.ToList();
                }
                );
        }
    }
}
