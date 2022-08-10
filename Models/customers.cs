using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class customers
    {
        public long id { get; set; }
        [JsonIgnore]
        public int user_id { get; set; }
        [JsonIgnore]
        public string? company_name { get; set;}
        [JsonIgnore]
        public int address_id { get; set; }
        [JsonIgnore]
        public string? name { get; set; }
        [JsonIgnore]
        public string? phone { get; set; }
        [JsonIgnore]
        public string? email { get; set; }
        [JsonIgnore]
        public string? description { get; set; }
        [JsonIgnore]
        public string? auth_name { get; set; }
        [JsonIgnore]
        public string? auth_phone { get; set; }
        [JsonIgnore]
        public string? mangr_email { get; set; }
        [JsonIgnore]
        public DateTime created_at { get; set; }
        [JsonIgnore]
        public DateTime updated_at { get; set; }
    }
}