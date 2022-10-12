using Membership.Data;
using Membership.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Membership.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly MembershipDbContext _context;

        public MembershipRepository(MembershipDbContext context)
        {
            _context = context;
        }
        public async Task<Memberships> AddMembershipAsync(Memberships membership)
         {
            try
            {
                

                if (membership.Type == "1")
                {
                    membership.Type = Models.Type.Primary.ToString();
                }
                else if(membership.Type == "2"){
                    membership.Type = Models.Type.Secondary.ToString();
                }
                else
                {
                    membership.Type = "Others";
                }
                
                await _context.Membership.AddAsync(membership);
                await _context.SaveChangesAsync();
                return await _context.Membership.FindAsync(membership.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<(bool, string)> DeleteMembershipAsync(Memberships membership)
        {
            try
            {
                var member = await _context.Membership.FindAsync(membership.Id);

                if (member == null)
                {
                    return (false, "Membership could not be found");
                }

                _context.Membership.Remove(member);

                await _context.SaveChangesAsync();

                return (true, "Membership got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        public async Task<List<Memberships>> GetMembershipAsync()
        {
            try
            {
                return await _context.Membership.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Memberships> GetMembershipAsync(Guid id)
        {
            try
            {
                return await _context.Membership.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Memberships> UpdateMembershipAsync(Memberships membership)
        {
            try
            {
                _context.Entry(membership).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return membership;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
