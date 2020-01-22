using System;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Core.Interfaces.Queries
{
    public interface IFetchTeaByIdQuery
    {
        EitherAsync<Exception, Option<Tea>> Execute(string id);
    }
}