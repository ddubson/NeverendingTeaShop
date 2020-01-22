using NeverendingTeaShop.Domain;
using NeverendingTeaShop.Infrastructure.entities;

namespace NeverendingTeaShop.Infrastructure.Extensions.Domain
{
    public static class TeaExtensions
    {
        public static TeaEntity MapToEntity(this Tea tea) => new TeaEntity(tea.Id, tea.Name);
    }
}