using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Application.Interfaces.Repositories;
using GoodProduct.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace GoodProduct.Application.ProductItems.Queries
{
    public class FetchAllProductItemsQuery : IFetchAllProductItemsQuery
    {
        private readonly IProductItemRepository _productItemRepository;

        public FetchAllProductItemsQuery(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
        }

        public EitherAsync<Exception, Option<IList<ProductItem>>> Execute()
            => _productItemRepository.FetchAll();
    }
}