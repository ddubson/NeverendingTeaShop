using GoodProduct.Application.Interfaces.Errors;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Application.ProductItems.Errors;
using GoodProduct.Domain;
using LanguageExt;
using static LanguageExt.EitherAsync<GoodProduct.Application.Interfaces.Errors.IFetchProductItemByIdQueryError,GoodProduct.Domain.ProductItem>;

namespace GoodProduct.Application.ProductItems.Queries
{
    public class FetchProductItemByIdQuery: IFetchProductItemByIdQuery
    {
        public EitherAsync<IFetchProductItemByIdQueryError, ProductItem> Execute(string id)
        {
            return Left(new FetchProductItemByIdQueryError());
        }
    }
}