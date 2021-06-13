
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepositoryTransactionDescription
    {
        public List<TransactionDescription> AddList(List<TransactionDescription> list);
        public List<TransactionDescription> SearchAll();
        public List<TransactionDescription> SearchByStore(string Store);
    }
}
