using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GoodProduct.Application.Interfaces.Queries;
using GoodProduct.Application.ProductItems.Queries;
using GoodProduct.Domain;
using Xunit;

namespace GoodProduct.Application.Tests.ProductItems.Queries
{
    public class FetchAllProductItemsQueryTest
    {
        [Fact]
        public async Task Execute_WhenProvidedAnOutcomeHandler_ReturnsAListOfAllProductItems()
        {
            IFetchAllProductItemsQuery query = new FetchAllProductItemsQuery();
            var fetchAllProductItemsOutcomeHandlerSpy = new FetchAllProductItemsOutcomeHandlerSpy();
            var productItems = await query.Execute(fetchAllProductItemsOutcomeHandlerSpy);
            productItems.Should().BeEquivalentTo(new List<ProductItem> { new ProductItem("Skillet 20oz")});
        }
    }

    class FetchAllProductItemsOutcomeHandlerSpy : IFetchAllProductItemsOutcomeHandler<Task<IList<ProductItem>>>
    {
        public Task<IList<ProductItem>> ReceivedAllProducts(IList<ProductItem> productItems)
            => Task.FromResult(productItems);
    }
}