using System;
using System.Collections.Generic;
using GoodProduct.Domain;
using LanguageExt;

namespace GoodProduct.Application.Interfaces.Repositories
{
    public interface IProductItemRepository
    {
        EitherAsync<Exception, Option<IList<ProductItem>>> FetchAll();

        EitherAsync<Exception, Option<ProductItem>> FetchById(string id);
    }
}