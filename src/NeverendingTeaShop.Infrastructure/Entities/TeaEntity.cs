namespace NeverendingTeaShop.Infrastructure.entities
{
    public class TeaEntity
    {
        public TeaEntity(string teaId, string name)
        {
            TeaId = teaId;
            Name = name;
        }
        
        public int Id { get; set; }
        public string TeaId { get; set; }
        public string Name { get; set; }
    }
}