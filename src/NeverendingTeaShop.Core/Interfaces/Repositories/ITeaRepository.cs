using System;
using System.Collections.Generic;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Core.Interfaces.Repositories
{
    public interface ITeaRepository
    {
        EitherAsync<Exception, Option<IList<Tea>>> FetchAll();

        EitherAsync<Exception, Option<Tea>> FetchById(string id);
    }
}