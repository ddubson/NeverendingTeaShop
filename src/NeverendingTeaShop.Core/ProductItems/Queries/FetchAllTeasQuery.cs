using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using NeverendingTeaShop.Core.Interfaces.Queries;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.Core.ProductItems.Queries
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