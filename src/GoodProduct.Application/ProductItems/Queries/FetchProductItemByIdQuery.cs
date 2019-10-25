using System;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Application.Interfaces.Repositories;
using GoodProduct.Domain;
using LanguageExt;

namespace GoodProduct.Application.ProductItems.Queries
{
    public class FetchProductItemByIdQuery : IFetchProductItemByIdQuery
    {
        private readonly IProductItemRepository _productItemRepository;

        public FetchProductItemByIdQuery(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
        }

        public EitherAsync<Exception, Option<ProductItem>> Execute(string id) =>
            _productItemRepository.FetchById(id);
    }
}