namespace api.Models
{
    public class BusStopModel
    {
        public int BusStopID { get; set; }
        public string BusStop { get; set; } = "";
        public decimal BusRate { get; set; }
        public int RouteID { get; set; }
        public string Current_Session { get; set; } = "";
    }
}
