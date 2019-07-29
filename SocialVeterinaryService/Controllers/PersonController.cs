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
    public class PersonController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            using (masterContext context = new masterContext())
            {
                return context
                    .Person
                    .ToList();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            using (masterContext context = new masterContext())
            {
                return await context
                    .Person
                    .Include(p => p.Pets)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Person>> Post([FromBody]Person value)
        {
            using (masterContext context = new masterContext())
            {
                var newPerson = await context.Person.AddAsync(value);
                await context.SaveChangesAsync();

                return newPerson.Entity;
            }
        }

        // POST api/<controller>/5
        [HttpPost]
        [Route("UpdatePerson/{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, [FromBody]Person value)
        {
            using (masterContext context = new masterContext())
            {
                Person person = await context.Person.Where(p => p.Id == id).FirstOrDefaultAsync();
                person.LastName = value.LastName;
                person.Miemployee = value.Miemployee;
                person.Name = value.Name;

                var editedPerson = context.Person.Update(person);
                await context.SaveChangesAsync();

                return editedPerson.Entity;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
