using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialVeterinaryService.Models;
using SocialVeterinaryService.Types;

namespace SocialVeterinaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        // GET: api/Core
        // POST: api/Core
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var schema = new Schema { Query = new VeterinaryQuery() };

            masterContext masterContext = new masterContext();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.UserContext = masterContext;
            }).ConfigureAwait(false);

            
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            masterContext.Dispose();

            return Ok(result);
        }

    }
}
