using System.Threading.Tasks;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Core.Interfaces.Queries
{
    public interface IFetchTeaByIdQuery
    {
        Task<Tea?> Execute(string id);
    }
}