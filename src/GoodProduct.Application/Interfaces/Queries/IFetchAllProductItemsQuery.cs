using System;
using System.Collections.Generic;
using GoodProduct.Domain;
using LanguageExt;

namespace GoodProduct.Application.Interfaces.Queries
{
    public interface IFetchAllProductItemsQuery
    {
        EitherAsync<Exception, Option<IList<ProductItem>>> Execute();
    }
}