using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Domain;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;

namespace GoodProduct.API.ProductItems
{
    [ApiController]
    [Route("/product-items")]
    public class FetchProductItemByIdController: Controller
    {
        private readonly IFetchProductItemByIdQuery _fetchProductItemByIdQuery;

        public FetchProductItemByIdController(IFetchProductItemByIdQuery fetchProductItemByIdQuery)
        {
            _fetchProductItemByIdQuery = fetchProductItemByIdQuery;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> FetchProductItemById(string id) =>
            await match(_fetchProductItemByIdQuery.Execute(id),
                Right: option => match(option,
                    item => Ok(item),
                    () => StatusCode(404, "None Found")),
                Left: error => StatusCode(400, "Failed to fetch a product item")
            );
    }
}