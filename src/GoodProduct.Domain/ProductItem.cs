namespace GoodProduct.Domain
{
    public readonly struct ProductItem
    {
        public string Name { get; }
        
        public ProductItem(string name)
        {
            Name = name;
        }
    }
}