namespace RocketElevatorsRestApi.Models
{
    public class leads
    {
        public long id { get; set; }
        public string? name { get; set; }
        public string? company_name { get; set; }
        public string? email { get; set; }
        public string? phone  { get; set; }
        public string? project_name { get; set; }
        public string? description { get; set; }
        public string? departement { get; set; }
        public string? message { get; set; }
        public string? file { get; set; }
        public DateTime date { get; set; }
        public DateTime create_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}