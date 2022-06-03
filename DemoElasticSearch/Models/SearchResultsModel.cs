using System.Collections.Generic;

namespace DemoElasticSearch.Models
{
    public class SearchResultsModel
    {
        public string SearchText { get; set; }

        public int Count { get; set; }
        public List<Order> Results { get; set; }
    }
}
