namespace PISSolution.Models
{
    public class Property
    {
       
            public Guid ID { get; set; }
            public string PropertyName { get; set; }
            public string Address { get; set; }
            public decimal Price { get; set; }
            public DateTime DateOfRegistration { get; set; }

            public ICollection<Ownership>? Ownerships { get; set; } 
            public ICollection<PriceHistory>? PriceHistories { get; set; }
       
        
    }
}
