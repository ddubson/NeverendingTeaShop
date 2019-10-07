using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GoodProduct.API.ProductItems
{
    [ApiController]
    [Route("/product-items")]
    public class FetchAllProductItemsController : ControllerBase
    {
        private readonly IFetchAllProductItemsQuery _fetchAllProductItemsQuery;

        public FetchAllProductItemsController(IFetchAllProductItemsQuery fetchAllProductItemsQuery)
        {
            _fetchAllProductItemsQuery = fetchAllProductItemsQuery;
        }

        [HttpGet]
        public Task<JsonResult> FetchAllProductItems() =>
            _fetchAllProductItemsQuery.Execute(new FetchAllProductItemsOutcomeHandler());

        private class FetchAllProductItemsOutcomeHandler : IFetchAllProductItemsOutcomeHandler<Task<JsonResult>>
        {
            public Task<JsonResult> ReceivedAllProducts(IList<ProductItem> productItems) =>
                Task.FromResult(new JsonResult(productItems));
        }
    }
}