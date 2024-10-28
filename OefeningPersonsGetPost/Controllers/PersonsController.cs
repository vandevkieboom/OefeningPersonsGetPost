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
            return CreatedAtAction(nameof(CreatePerson), new { id = item.Id }, item);
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

    }
}
