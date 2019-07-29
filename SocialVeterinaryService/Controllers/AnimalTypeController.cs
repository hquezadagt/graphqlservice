using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialVeterinaryService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialVeterinaryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalType>>> Get()
        {
            using (masterContext context = new masterContext())
            {
                return await context
                    .AnimalType
                    .Include(p => p.Pets)
                    .ToListAsync();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> Get(int id)
        {
            using (masterContext context = new masterContext())
            {
                return await context
                    .AnimalType
                    .Include(p => p.Pets)
                    .Where(p => p.TypeId == id)
                    .FirstOrDefaultAsync();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<AnimalType>> Post([FromBody]AnimalType value)
        {
            using (masterContext context = new masterContext())
            {
                var newType = await context.AnimalType.AddAsync(value);
                await context.SaveChangesAsync();

                return newType.Entity;
            }
        }

        // POST api/<controller>/5
        [HttpPost]
        [Route("UpdateType/{id}")]
        public async Task<ActionResult<AnimalType>> UpdateType(int id, [FromBody]AnimalType value)
        {
            using (masterContext context = new masterContext())
            {
                AnimalType animalType = await context.AnimalType.Where(p => p.TypeId == id).FirstOrDefaultAsync();
                animalType.TypeName = value.TypeName;

                var editedType = context.AnimalType.Update(animalType);
                await context.SaveChangesAsync();

                return editedType.Entity;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
