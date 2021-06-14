using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        protected readonly ContextDesafioDev _contexto;
        protected DbSet<Transaction> dbSet;
        public RepositoryTransaction(ContextDesafioDev context)
        {
            this._contexto = context;
            this.dbSet = context.Set<Transaction>();
        }

        public Transaction SearchTransactionByType(string type)
        {
            try
            {
                return dbSet.Where(x => x.Type == Convert.ToInt64(type)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
