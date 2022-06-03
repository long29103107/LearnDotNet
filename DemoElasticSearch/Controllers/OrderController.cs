using DemoElasticSearch.Client;
using DemoElasticSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Linq;

namespace DemoElasticSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISearchClient _searchClient;

        public OrderController(ISearchClient searchClient)
        {
            this._searchClient = searchClient;
        }
        [HttpGet]
        public ActionResult GetAll(string searchText)
        {
            var response = _searchClient.SearchOrder(searchText);
            var model = new SearchResultsModel() {
                Results = response.Documents.ToList(),
                Count = response.Documents.ToList().Count
            };
            return Ok(model);
        }
    }
}
