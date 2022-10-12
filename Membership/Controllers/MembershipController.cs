using Membership.Models;
using Membership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Membership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipController(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        [HttpGet]
        [Route("GetAllMemberships")]
        public async Task<IActionResult> GetMemberships()
        {
            var memberships = await _membershipRepository.GetMembershipAsync();

            if (memberships == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Memberships in database");
            }

            return StatusCode(StatusCodes.Status200OK, memberships);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetMembership(Guid id)
        {
            Memberships memberships = await _membershipRepository.GetMembershipAsync(id); 

            if (memberships == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Memberships found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, memberships);
        }

        [HttpPost]
        public async Task<ActionResult<Memberships>> AddMemberships(Memberships memberships)
        {
            var dbMemberships = await _membershipRepository.AddMembershipAsync(memberships);

            if (dbMemberships == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{memberships.MembershipNumber} could not be added.");
            }

            return CreatedAtAction("GetMembership", new { id = memberships.Id }, memberships);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateMembership(Guid id, Memberships memberships)
        {
            if (id != memberships.Id)
            {
                return BadRequest();
            }

            Memberships dbMembership = await _membershipRepository.UpdateMembershipAsync(memberships);

            if (dbMembership == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{memberships.MembershipNumber} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMembership(Guid id)
        {
            var membership = await _membershipRepository.GetMembershipAsync(id);
            (bool status, string message) = await _membershipRepository.DeleteMembershipAsync(membership);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, membership);
        }

    }
}
