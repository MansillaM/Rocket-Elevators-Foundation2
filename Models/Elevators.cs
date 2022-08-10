using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class elevators
    {
        public long id { get; set; }
        [JsonIgnore]
        public string? elevator_status { get; set; }
        [JsonIgnore]
        public int column_id {get; set; }
        

    }
}