using System;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Core.ProductItems.Queries
{
    public class FetchTeaByIdQuery : IFetchTeaByIdQuery
    {
        private readonly ITeaRepository _teaRepository;

        public FetchTeaByIdQuery(ITeaRepository teaRepository)
        {
            _teaRepository = teaRepository;
        }

        public EitherAsync<Exception, Option<Tea>> Execute(string id) =>
            _teaRepository.FetchById(id);
    }
}