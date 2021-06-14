using Domain.Interfaces.Services;
using ServiceApplication.Interfaces;
using ServiceApplication.Mapping;
using System;
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
            try
            {
                return _service.ImportFileCNAB(fileBytes).ToBaseResultModelGroupByStore();
            }
            catch (Exception ex)
            {
                return ex.ToBaseErrorModel();
            }
        }
    }
}
