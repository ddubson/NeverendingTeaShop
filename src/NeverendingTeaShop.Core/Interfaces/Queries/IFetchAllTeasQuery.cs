using System.Collections.Generic;
using System.Threading.Tasks;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Core.Interfaces.Queries
{
    public interface IFetchAllTeasQuery
    {
        Task<IList<Tea>> Execute();
    }
}