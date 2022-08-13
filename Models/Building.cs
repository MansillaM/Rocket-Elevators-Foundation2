using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class building
    {
        public long? id { get; set; }
        [JsonIgnore]
        public long? customer_id { get; set; }
        public int address_id { get; set; }
        public string? tech_name { get; set; }
        public string? tech_phone { get; set; }
    }
}