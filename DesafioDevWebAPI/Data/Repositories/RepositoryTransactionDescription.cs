using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RepositoryTransactionDescription : IRepositoryTransactionDescription
    {
        protected readonly ContextDesafioDev _contexto;
        protected DbSet<TransactionDescription> dbSet;
        public RepositoryTransactionDescription(ContextDesafioDev context)
        {
            this._contexto = context;
            this.dbSet = context.Set<TransactionDescription>();
        }
    }
}
