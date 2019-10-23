using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Domain;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;

namespace GoodProduct.API.ProductItems
{
    [ApiController]
    [Route("/product-items")]
    public class FetchAllProductItemsController : ControllerBase
    {
        private readonly IFetchAllProductItemsQuery _fetchAllProductItemsQuery;
        private readonly IFetchProductItemByIdQuery _fetchProductItemByIdQuery;

        public FetchAllProductItemsController(
            IFetchAllProductItemsQuery fetchAllProductItemsQuery,
            IFetchProductItemByIdQuery fetchProductItemByIdQuery)
        {
            _fetchAllProductItemsQuery = fetchAllProductItemsQuery;
            _fetchProductItemByIdQuery = fetchProductItemByIdQuery;
        }

        [HttpGet]
        public Task<JsonResult> FetchAllProductItems() =>
            _fetchAllProductItemsQuery.Execute(new FetchAllProductItemsOutcomeHandler());

        [HttpGet]
        public async Task<ActionResult<ProductItem>> FetchProductItemById(string id) =>
            await match(_fetchProductItemByIdQuery.Execute(id),
                Right: productItem => Ok(productItem), 
                Left: error => StatusCode(400, "Failed to fetch a product item")
            );

        private class FetchAllProductItemsOutcomeHandler : IFetchAllProductItemsOutcomeHandler<Task<JsonResult>>
        {
            public Task<JsonResult> ReceivedAllProducts(IList<ProductItem> productItems) =>
                Task.FromResult(new JsonResult(productItems));
        }
    }
}