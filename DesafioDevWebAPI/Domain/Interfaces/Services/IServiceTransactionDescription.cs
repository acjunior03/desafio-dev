

using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IServiceTransactionDescription
    {
        public object AddList(List<TransactionDescription> list);
        public object SearchAll();
        public object SearchByStore(string Store);
        public object ImportFileCNAB(List<byte[]> fileBytes);
    }
}
