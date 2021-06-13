using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        protected readonly ContextDesafioDev _contexto;
        protected DbSet<Transaction> dbSet;
        public RepositoryTransaction(ContextDesafioDev context){
            this._contexto = context;
            this.dbSet = context.Set<Transaction>();
        }
    }
}
