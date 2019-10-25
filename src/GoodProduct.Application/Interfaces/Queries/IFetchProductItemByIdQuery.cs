using System;
using GoodProduct.Domain;
using LanguageExt;

namespace GoodProduct.Application.Interfaces.Queries
{
    public interface IFetchProductItemByIdQuery
    {
        EitherAsync<Exception, Option<ProductItem>> Execute(string id);
    }
}