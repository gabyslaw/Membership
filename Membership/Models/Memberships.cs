namespace Membership.Models
{
    public class Memberships : BaseModel
    {
        public int MembershipNumber { get; set; }
        public double AccountBalance { get; set; }
        public string Type { get; set; }

        //One-to-many relation with Person
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

    }

    public enum Type
    {
        Primary = 1,
        Secondary = 2
    }
}
