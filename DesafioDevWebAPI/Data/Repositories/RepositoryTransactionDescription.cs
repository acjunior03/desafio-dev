using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public List<TransactionDescription> AddList(List<TransactionDescription> list)
        {
            throw new System.NotImplementedException();
        }

        public List<TransactionDescription> SearchAll()
        {
            throw new System.NotImplementedException();
        }

        public List<TransactionDescription> SearchByStore(string Store)
        {
            throw new System.NotImplementedException();
        }
    }
}
