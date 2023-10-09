namespace StockDashboardWeb.Models
{
    public class WinLose
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Price { get; set; }
        public int Change_amount { get; set; }
        public string Change_percentage { get; set;}
        public string Volume { get; set;}
    }
}
