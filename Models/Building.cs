using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class building
    {
        public long? id { get; set; }
        [JsonIgnore]
        public long? customer_id { get; set; }
        [JsonIgnore]
        public int address_id { get; set; }
    }
}