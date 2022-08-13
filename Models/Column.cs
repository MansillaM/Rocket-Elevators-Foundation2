using System.Text.Json.Serialization;

namespace RocketElevatorsRestApi.Models
{
    public class column
    {
        public long id {get; set; }
        public long battery_id { get; set; }
        public string? status { get; set; }
        public int floors { get; set; }
        public string? information { get; set; }
    }
}