namespace api.Models
{
    public class TransportModel
    {
        public int RouteID { get; set; }
        public string RouteName { get; set; } = "";
        public string Current_Session { get; set; } = "";
        public bool IsDeleted { get; set; }
    }
}
