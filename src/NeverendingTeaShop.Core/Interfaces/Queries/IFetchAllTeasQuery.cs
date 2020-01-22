using System;
using System.Collections.Generic;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Core.Interfaces.Queries
{
    public interface IFetchAllTeasQuery
    {
        EitherAsync<Exception, Option<IList<Tea>>> Execute();
    }
}