using System.Threading.Tasks;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Core.ProductItems.Queries
{
    public class FetchTeaByIdQuery : IFetchTeaByIdQuery
    {
        private readonly ITeaRepository _teaRepository;

        public FetchTeaByIdQuery(ITeaRepository teaRepository)
        {
            _teaRepository = teaRepository;
        }

        public Task<Tea?> Execute(string id) => _teaRepository.FetchById(id);
    }
}