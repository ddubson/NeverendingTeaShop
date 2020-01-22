using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;
using NeverendingTeaShop.Infrastructure.Extensions.Domain;

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

        public async Task<IList<Tea>> FetchAll()
        {
            try
            {
                return (await _dbContext.Teas.ToListAsync())
                    .Select(entity => new Tea(entity.Id.ToString(), entity.Name))
                    .ToList();
            }
            catch (Exception)
            {
                return Array.Empty<Tea>();
            }
        }

        public Task<Tea?> FetchById(string id) => Task.FromResult<Tea?>(_teas.Single());
        
        public async Task Save(Tea tea)
        {
            _dbContext.Teas.Add(tea.MapToEntity());
            await _dbContext.SaveChangesAsync();
        }
    }
}