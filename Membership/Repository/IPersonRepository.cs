using Membership.Models;

namespace Membership.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersonsAsync(); // Get all Persons
        Task<Person> GetPersonAsync(Guid id, bool includeMemberships = false); // Get all Persons
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task<(bool, string)> DeletePersonAsync(Person person);
    }
}
