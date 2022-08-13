using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class battery 
    {
        public long id { get; set; }
        [JsonIgnore]
        public long? building_id { get; set; }
        public string? Building_Type { get; set; }
        public string? Status { get; set; }
        public long? Employee_Id { get; set; }
        [JsonIgnore]
        public DateTime? Comm_Date { get; set; }
        [JsonIgnore]
        public DateTime? Inspec_Date { get; set; }
        [JsonIgnore]
        public long? Certificate { get; set; }
        [JsonIgnore]
        public string? Information { get; set; }
        [JsonIgnore]
        public string? Notes { get; set; }
        [JsonIgnore]
        public DateTime? Created_At { get; set; }
        [JsonIgnore]
        public DateTime? Updated_At { get; set; }
    }
}