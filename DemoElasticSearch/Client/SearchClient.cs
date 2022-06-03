using DemoElasticSearch.Models;
using Microsoft.Extensions.Configuration;
using Nest;
using System;

namespace DemoElasticSearch.Client
{
    public interface ISearchClient
    {
        ISearchResponse<Order> SearchOrder(string searchText);
    }
    public class SearchClient : ISearchClient
    {
        private readonly ElasticClient client;

        public SearchClient(IConfiguration configuration)
        {
            client = new ElasticClient(
                new ConnectionSettings(new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint")))
                    .DefaultIndex("kibana_sample_data_ecommerce")
                    .BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
                        configuration.GetValue<string>("ElasticCloud:BasicAuthPassword")));
        }

        public ISearchResponse<Order> SearchOrder(string searchText)
        {
            return client.Search<Order>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.CustomerFullName)
                        .Query(searchText)
                    )
                ));
        }
    }
}
