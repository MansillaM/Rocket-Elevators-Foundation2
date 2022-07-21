namespace RocketElevatorsRestApi.Models
{
    public class customers
    {
        public long id { get; set; }
        public int user_id { get; set; }
        public string? company_name { get; set;}
        public int address_id { get; set; }
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? description { get; set; }
        public string? auth_name { get; set; }
        public string? auth_phone { get; set; }
        public string? mangr_email { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}