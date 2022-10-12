using Membership.Models;
using Membership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Membership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
    
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _personRepository.GetPersonsAsync();

            if (persons == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No persons in database");
            }

            return StatusCode(StatusCodes.Status200OK, persons);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPerson(Guid id, bool includeMemberships = false)
        {
            Person person = await _personRepository.GetPersonAsync(id, includeMemberships);

            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Person found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            var dbPerson = await _personRepository.AddPersonAsync(person);

            if (dbPerson == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.FirstName} could not be added.");
            }

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdatePerson(Guid id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            Person dbPerson = await _personRepository.UpdatePersonAsync(person); 

            if (dbPerson == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.FirstName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var person = await _personRepository.GetPersonAsync(id, false);
            (bool status, string message) = await _personRepository.DeletePersonAsync(person);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }
    }
}
