namespace RocketElevatorsRestApi.Models
{
    public class Battery 
    {
        public long id { get; set; }
        public long? Building_Id { get; set; }
        public string? Building_Type { get; set; }
        public string? Status { get; set; }
        public long? Employee_Id { get; set; }
        public DateTime? Comm_Date { get; set; }
        public DateTime? Inspec_Date { get; set; }
        public long? Certificate { get; set; }
        public string? Information { get; set; }
        public string? Notes { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}