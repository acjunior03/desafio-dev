using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Service.Services
{
    public class ServiceTransactionDescription : IServiceTransactionDescription
    {
        private IRepositoryTransactionDescription _repository;
        private IServiceTransaction _serviceTransaction;

        public object AddList(List<TransactionDescription> list)
        {
            throw new System.NotImplementedException();
        }

        public object ImportFileCNAB(List<byte[]> fileBytes)
        {
            throw new System.NotImplementedException();
        }

        public object SearchAll()
        {
            throw new System.NotImplementedException();
        }

        public object SearchByStore(string Store)
        {
            throw new System.NotImplementedException();
        }
    }
}
