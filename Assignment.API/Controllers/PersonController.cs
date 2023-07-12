using Assignment.Application.Domain;
using Assignment.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Person>> Add(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Person>> Update(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var updatedPerson = await _personService.UpdateAsync(person);

            return updatedPerson;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Person>>> Filter([FromQuery] string name, [FromQuery] int? age)
        {
            var persons = await _personService.FilterAsync(name, age);
            return Ok(persons);
        }

    }
}
