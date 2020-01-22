using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using LanguageExt;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using static LanguageExt.Prelude;

namespace NeverendingTeaShop.Infrastructure
{
    public class SqlTeaRepository : ITeaRepository
    {
        private readonly NeverendingTeaShopContext _dbContext;

        private readonly IList<Tea> _teas =
            ImmutableList.Create(
                new Tea("1", "Chai Tea"),
                new Tea("2", "Chamomile"),
                new Tea("3", "Rooibos")
            );

        public SqlTeaRepository(NeverendingTeaShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EitherAsync<Exception, Option<IList<Tea>>> FetchAll()
        {
            try
            {
                IList<Tea> teas = _dbContext.Teas.ToList()
                    .Select(entity => new Tea(entity.Id.ToString(), entity.Name)
                    ).ToList();
                
                return EitherAsync<Exception, Option<IList<Tea>>>.Right(
                    teas.Count > 0 ? Some(teas): None
                );
            }
            catch (Exception)
            {
                return EitherAsync<Exception, Option<IList<Tea>>>.Left(
                    new Exception("Something went wrong in persistence."));
            }
        }

        public EitherAsync<Exception, Option<Tea>> FetchById(string id) =>
            EitherAsync<Exception, Option<Tea>>.Right(
                new Option<Tea>(Some(_teas.Single())));
    }
}