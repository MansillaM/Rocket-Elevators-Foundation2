using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class column
    {
        public long id {get; set; }
        [JsonIgnore]
        public long battery_id { get; set; }
        [JsonIgnore]
        public string? status { get; set; }
    }
}