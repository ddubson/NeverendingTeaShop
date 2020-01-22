using Microsoft.EntityFrameworkCore;
using NeverendingTeaShop.Infrastructure.entities;

namespace NeverendingTeaShop.Infrastructure
{
    public class NeverendingTeaShopContext : DbContext
    {
        public DbSet<TeaEntity> Teas { get; set; }

        public NeverendingTeaShopContext(DbContextOptions<NeverendingTeaShopContext> options)
            : base(options)
        {
        }
    }
}