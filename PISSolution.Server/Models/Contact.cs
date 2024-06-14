namespace PISSolution.Models
{
    public class Contact
    {
         
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Ownership> Ownerships { get; set; }
    
    }
}
