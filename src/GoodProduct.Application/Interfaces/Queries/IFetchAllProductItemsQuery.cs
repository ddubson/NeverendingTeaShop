using System.Collections.Generic;
using System.Threading.Tasks;
using GoodProduct.Domain;

namespace GoodProduct.Application.Interfaces.Queries
{
    public interface IFetchAllProductItemsOutcomeHandler<out T>
    {
        T ReceivedAllProducts(IList<ProductItem> productItems);
    }
    
    public interface IFetchAllProductItemsQuery
    {
        Task<T> Execute<T>(IFetchAllProductItemsOutcomeHandler<Task<T>> outcomeHandler);
    }
}