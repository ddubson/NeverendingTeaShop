using System;
using NeverendingTeaShop.Application.Interfaces.Queries;
using NeverendingTeaShop.Application.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Application.ProductItems.Queries
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