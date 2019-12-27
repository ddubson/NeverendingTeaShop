using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeverendingTeaShop.Domain;
using LanguageExt;

namespace NeverendingTeaShop.Application.Interfaces.Queries
{
    public interface IFetchAllTeasOutcomes<out T>
    {
        T GotTeas(IList<Tea> teas);
    }
    
    public interface IFetchAllTeasQuery<T>
    {
         Task<T> Execute(IFetchAllTeasOutcomes<T> outcomeHandler);
    }
}