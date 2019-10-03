using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Domain;

namespace GoodProduct.Application.ProductItems.Queries
{
    public class FetchAllProductItemsQuery: IFetchAllProductItemsQuery
    {
        public Task<IList<ProductItem>> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}