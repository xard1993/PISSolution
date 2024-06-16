using System.Text.Json.Serialization;

namespace PISSolution.Models
{
    public class PriceHistory
    {
     
            public Guid ID { get; set; }
            public Guid PropertyID { get; set; }
            [JsonIgnore]
            public Property Property { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
        
    }
}
