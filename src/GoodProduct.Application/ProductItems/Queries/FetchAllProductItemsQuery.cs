using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Domain;

namespace GoodProduct.Application.ProductItems.Queries
{
    public class FetchAllProductItemsQuery : IFetchAllProductItemsQuery
    {
        public Task<T> Execute<T>(IFetchAllProductItemsOutcomeHandler<Task<T>> outcomeHandler)
            => outcomeHandler.ReceivedAllProducts(new List<ProductItem> {new ProductItem("Skillet 20oz")});
    }
}