using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GoodProduct.API.ProductItems
{
    [ApiController]
    [Route("/product-items")]
    public class FetchAllProductItemsController : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> FetchAllProductItems()
        {
            return new JsonResult(new List<ProductItem> {new ProductItem("Skillet 20oz")});
        }
    }
}