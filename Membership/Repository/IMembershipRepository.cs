using Membership.Models;

namespace Membership.Repository
{
    public interface IMembershipRepository
    {
        Task<List<Memberships>> GetMembershipAsync();
        Task<Memberships> GetMembershipAsync(Guid id); 
        Task<Memberships> AddMembershipAsync(Memberships membership);
        Task<Memberships> UpdateMembershipAsync(Memberships membership);
        Task<(bool, string)> DeleteMembershipAsync(Memberships membership);

    }
}
