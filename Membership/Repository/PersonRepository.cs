using Membership.Data;
using Membership.Models;
using Microsoft.EntityFrameworkCore;

namespace Membership.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MembershipDbContext _context;

        public PersonRepository(MembershipDbContext context)
        {
            _context = context;
        }
        public async Task<Person> AddPersonAsync(Person person)
        {
            try
            {

                await _context.Person.AddAsync(person);
                await _context.SaveChangesAsync();
                return await _context.Person.FindAsync(person.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<(bool, string)> DeletePersonAsync(Person personData)
        {
            try
            {
                var person = await _context.Person.FindAsync(personData.Id);

                if (person == null)
                {
                    return (false, "Person could not be found");
                }

                _context.Person.Remove(person);

                await _context.SaveChangesAsync();

                return (true, "Person got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        public async Task<Person> GetPersonAsync(Guid id, bool includeMemberships)
        {
            try
            {
                if (includeMemberships) // memberships should be included
                {
                    return await _context.Person.Include(b => b.Memberships)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                // memberships should be excluded
                return await _context.Person.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            try
            {
                return await _context.Person.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            try
            {
                _context.Entry(person).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return person;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
