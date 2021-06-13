using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryTransaction
    {
        public List<Transaction> SearchTransctionByType(string type);
    }
}
