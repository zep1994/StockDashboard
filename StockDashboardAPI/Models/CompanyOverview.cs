namespace StockDashboardAPI.Models
{
    public class CompanyOverview
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
        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        // Declare the enumerator class:  
        public class MyEnumerator
        {
            int nIndex;
            CompanyOverview collection;
            public MyEnumerator(CompanyOverview coll)
            {
                collection = coll;
                nIndex = -1;
            }
            public bool MoveNext()
            {
                nIndex++;
                return nIndex < collection.Name.Length;
            }

            public int Current => collection.Industry[nIndex];
        }

    }
}
