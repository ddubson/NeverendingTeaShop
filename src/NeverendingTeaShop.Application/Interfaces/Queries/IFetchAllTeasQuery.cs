using System;
using System.Collections.Generic;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Application.Interfaces.Queries
{
    public interface IFetchAllTeasQuery
    {
        EitherAsync<Exception, Option<IList<Tea>>> Execute();
    }
}