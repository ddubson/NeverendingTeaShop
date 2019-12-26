using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NeverendingTeaShop.Application.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using LanguageExt;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.Persistence.InMemory
{
    public class InMemoryTeaRepository : ITeaRepository
    {
        private readonly IList<Tea> _teas =
            ImmutableList.Create(
                new Tea("1", "Chai Tea"),
                new Tea("2", "Chamomile"),
                new Tea("3", "Rooibos")
            );

        public EitherAsync<Exception, Option<IList<Tea>>> FetchAll() =>
            EitherAsync<Exception, Option<IList<Tea>>>.Right(
                new Option<IList<Tea>>(Some(_teas))
            );

        public EitherAsync<Exception, Option<Tea>> FetchById(string id) =>
            EitherAsync<Exception, Option<Tea>>.Right(
                new Option<Tea>(Some(_teas.Single())));
    }
}