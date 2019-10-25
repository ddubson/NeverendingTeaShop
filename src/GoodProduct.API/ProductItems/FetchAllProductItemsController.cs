using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;

namespace GoodProduct.API.ProductItems
{
    [ApiController]
    [Route("/product-items")]
    public class FetchAllProductItemsController : ControllerBase
    {
        private readonly IFetchAllProductItemsQuery _fetchAllProductItemsQuery;

        public FetchAllProductItemsController(
            IFetchAllProductItemsQuery fetchAllProductItemsQuery)
        {
            _fetchAllProductItemsQuery = fetchAllProductItemsQuery;
        }

        [HttpGet]
        public async Task<ActionResult> FetchAllProductItems() =>
            await match(_fetchAllProductItemsQuery.Execute(),
                Right: option => match(option,
                    Some: Ok,
                    None: () => StatusCode(404, "None found")),
                Left: error => StatusCode(500, "Whoa! Error!"));
    }
}