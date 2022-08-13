using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class elevators
    {
        public long id { get; set; }
        public string? elevator_status { get; set; }
        [JsonIgnore]
        public int column_id {get; set; }
        public string? serial_number { get; set; }
        public int certificate { get; set; }
        

    }
}