using System;

namespace GoodProduct.Domain
{
    public readonly struct ProductItem
    {
        public string Id { get; }
        public string Name { get; }

        public ProductItem(string id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}