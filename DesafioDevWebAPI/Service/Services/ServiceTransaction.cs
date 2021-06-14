using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;

namespace Service.Services
{
    public class ServiceTransaction : IServiceTransaction
    {
        private IRepositoryTransaction _repository;
        public ServiceTransaction(IRepositoryTransaction repository)
        {
            _repository = repository;
        }
        public object SearchTransactionByType(string type)
        {
            return _repository.SearchTransactionByType(type);
        }
    }
}
