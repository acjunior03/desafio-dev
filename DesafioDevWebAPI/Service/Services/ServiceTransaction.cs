using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;

namespace Service.Services
{
    public class ServiceTransaction : IServiceTransaction
    {
        private IRepositoryTransaction _repository;
        public object SearchTransactionByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
