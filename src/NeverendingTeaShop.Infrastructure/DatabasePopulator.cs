using NeverendingTeaShop.Core.Interfaces.Repositories;
using NeverendingTeaShop.Domain;

namespace NeverendingTeaShop.Infrastructure
{
    public class DatabasePopulator
    {
        public static void PopulateDatabase(ITeaRepository teaRepository)
        {
            teaRepository.Save(new Tea("tea1", "Chai Tea"));
            teaRepository.Save(new Tea("tea2", "Chamomile"));
            teaRepository.Save(new Tea("tea3", "Rooibos"));
        }
}

}