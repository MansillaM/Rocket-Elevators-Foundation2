using System.Text.Json.Serialization;


namespace RocketElevatorsRestApi.models
{
    public class interventions
    {
        [JsonIgnore]
        public long id { get; set; }
        public int author_id { get; set; }
        public int customer_id { get; set; }
        public int building_id { get; set; }
        public int battery_id { get; set; }
        public int column_id { get; set; }
        public int elevator_id { get; set; }
        public int employee_id { get; set; }
        [JsonIgnore]
        public DateTime? start_date { get; set; }
        [JsonIgnore]
        public DateTime? end_date { get; set; }
        [JsonIgnore]
        public string? result { get; set; }
        public string? report { get; set; }
        [JsonIgnore]
        public string? status { get; set; }
        [JsonIgnore]
        public DateTime created_at { get; set; }
        [JsonIgnore]
        public DateTime updated_at { get; set; }
    }
}