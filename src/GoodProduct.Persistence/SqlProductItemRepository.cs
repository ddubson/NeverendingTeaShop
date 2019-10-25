using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using GoodProduct.Application.Interfaces.Repositories;
using GoodProduct.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace GoodProduct.Persistence
{
    public class SqlProductItemRepository : IProductItemRepository
    {
        private readonly IList<ProductItem> _productItems =
            ImmutableList.Create(new ProductItem("1", "Skillet 20oz"));

        public EitherAsync<Exception, Option<IList<ProductItem>>> FetchAll() =>
            EitherAsync<Exception, Option<IList<ProductItem>>>.Right(
                new Option<IList<ProductItem>>(Some(_productItems))
            );

        public EitherAsync<Exception, Option<ProductItem>> FetchById(string id) =>
            EitherAsync<Exception, Option<ProductItem>>.Right(
                new Option<ProductItem>(Some(_productItems.Single())));
    }
}