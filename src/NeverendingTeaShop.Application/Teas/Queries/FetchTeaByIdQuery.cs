using System;
using LanguageExt;
using NeverendingTeaShop.Application.Interfaces.Queries;
using NeverendingTeaShop.Application.Interfaces.Repositories;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Application.Teas.Queries
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