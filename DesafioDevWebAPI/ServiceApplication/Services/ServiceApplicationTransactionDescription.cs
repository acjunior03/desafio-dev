using Domain.Interfaces.Services;
using ServiceApplication.Interfaces;
using System.Collections.Generic;

namespace ServiceApplication.Services
{
    public class ServiceApplicationTransactionDescription : IServiceApplicationTransactionDescription
    {
        private IServiceTransactionDescription _service;
        public ServiceApplicationTransactionDescription(IServiceTransactionDescription serviceTransactionDescription)
        {
            _service = serviceTransactionDescription;
        }

        public object ImportFileCNAB(List<byte[]> fileBytes)
        {
            throw new System.NotImplementedException();
        }
    }
}
