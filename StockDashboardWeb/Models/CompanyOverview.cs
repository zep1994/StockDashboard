namespace StockDashboardWeb.Models
{
    public class CompanyOverviewDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string PERatio { get; set; }
        public string EPS { get; set; }
        public string DividendYield { get; set; }
        public string ProfitMargin { get; set; }
        public string Beta { get; set; }


    }
}
