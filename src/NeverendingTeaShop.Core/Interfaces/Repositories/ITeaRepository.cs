using System.Collections.Generic;
using System.Threading.Tasks;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Core.Interfaces.Repositories
{
    public interface ITeaRepository
    {
        Task<IList<Tea>> FetchAll();

        Task<Tea?> FetchById(string id);

        Task Save(Tea tea);
    }
}