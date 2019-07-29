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
    public class PetsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pets>>> Get()
        {
            using (masterContext context = new masterContext())
            {
                return await context
                    .Pets
                    .ToListAsync();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Pets>>> Get(int id)
        {
            using (masterContext context = new masterContext())
            {
                return await context
                    .Pets
                    .Where(p => p.OwnerId == id)
                    .ToListAsync();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Pets>> Post([FromBody]Pets value)
        {
            using (masterContext context = new masterContext())
            {
                var newPet = await context.Pets.AddAsync(value);
                await context.SaveChangesAsync();

                return newPet.Entity;
            }
        }

        // POST api/<controller>/5
        [HttpPost]
        [Route("UpdatePet/{id}")]
        public async Task<ActionResult<Pets>> UpdatePet(int id, [FromBody]Pets value)
        {
            using (masterContext context = new masterContext())
            {
                Pets pet = await context.Pets.Where(p => p.PetId == id).FirstOrDefaultAsync();
                pet.OwnerId = value.OwnerId;
                pet.TypeId = value.TypeId;
                pet.PetName = value.PetName;

                var editedPet = context.Pets.Update(pet);
                await context.SaveChangesAsync();

                return editedPet.Entity;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
