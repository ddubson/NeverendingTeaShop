using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NeverendingTeaShop.Application.Interfaces.Queries;
using NeverendingTeaShop.Application.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.Application.ProductItems.Queries
{
    public class FetchAllTeasQuery : IFetchAllTeasQuery
    {
        private readonly ITeaRepository _teaRepository;

        public FetchAllTeasQuery(ITeaRepository teaRepository)
        {
            _teaRepository = teaRepository;
        }

        public EitherAsync<Exception, Option<IList<Tea>>> Execute()
            => _teaRepository.FetchAll();
    }
}