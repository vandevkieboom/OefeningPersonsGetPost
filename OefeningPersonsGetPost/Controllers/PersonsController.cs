using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OefeningPersonsGetPost.Models;
using OefeningPersonsGetPost.Services;

namespace OefeningPersonsGetPost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person item)
        {
            await _personsService.CreatePerson(item);
            return CreatedAtAction(nameof(GetPersonById), new { id = item.Id }, item);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personsService.GetPerson(id);
            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            var persons = await _personsService.GetAllPersons();
            return Ok(persons);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson(int id, Person item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var updatedPerson = await _personsService.UpdatePerson(id, item);
            if (updatedPerson == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var person = await _personsService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            await _personsService.DeletePerson(id);
            return NoContent();
        }
    }
}
