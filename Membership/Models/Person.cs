namespace Membership.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        //One-to-many relation with Membership
        public List<Memberships> Memberships { get; set; }
    }
}
