using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Core.ProductItems.Queries
{
    public class FetchAllTeasQuery : IFetchAllTeasQuery
    {
        private readonly ITeaRepository _teaRepository;

        public FetchAllTeasQuery(ITeaRepository teaRepository)
        {
            _teaRepository = teaRepository;
        }

        public Task<IList<Tea>> Execute() => _teaRepository.FetchAll();
    }
}