namespace NeverendingTeaShop.Domain
{
    public readonly struct Tea
    {
        public string Id { get; }
        public string Name { get; }

        public Tea(string id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}