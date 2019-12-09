using System;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Application.Interfaces.Queries
{
    public interface IFetchTeaByIdQuery
    {
        EitherAsync<Exception, Option<Tea>> Execute(string id);
    }
}