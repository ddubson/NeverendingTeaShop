using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Domain;

namespace GoodProduct.Application.Interfaces.Queries
{
    public interface IFetchAllProductItemsQuery
    {
        Task<IList<ProductItem>> Execute();
    }
}