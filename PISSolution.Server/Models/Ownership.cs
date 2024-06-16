using System.Text.Json.Serialization;

namespace PISSolution.Models
{
    public class Ownership
    {
        public Guid ID { get; set; }
        public Guid PropertyID { get; set; }
        [JsonIgnore]
        public Property Property { get; set; }
        public Guid ContactID { get; set; }      
        public Contact Contact { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public decimal AcquisitionPrice { get; set; }
    }
}
