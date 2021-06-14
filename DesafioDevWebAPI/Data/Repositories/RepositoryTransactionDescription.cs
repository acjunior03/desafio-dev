using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class RepositoryTransactionDescription : IRepositoryTransactionDescription
    {
        protected readonly ContextDesafioDev _contexto;
        protected DbSet<TransactionDescription> dbSet;
        public RepositoryTransactionDescription(ContextDesafioDev context)
        {
            _contexto = context;
            dbSet = context.Set<TransactionDescription>();
        }

        public List<TransactionDescription> AddList(List<TransactionDescription> list)
        {
            try
            {
                var transaction = _contexto.Database.BeginTransaction();
                using (transaction)
                {
                    _contexto.Set<TransactionDescription>().AddRange(list);
                    _contexto.SaveChanges();
                    transaction.Commit();
                    list = _contexto.Set<TransactionDescription>().Include(x => x.Transaction).Where(x=> list.Select(z=>z.Id).Contains(x.Id)).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TransactionDescription> SearchAll()
        {
            throw new System.NotImplementedException();
        }

        public List<TransactionDescription> SearchByStore(string Store)
        {
            try
            {
                return dbSet.Include(x => x.Transaction).Where(x => x.StoreName.Equals(Store)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
