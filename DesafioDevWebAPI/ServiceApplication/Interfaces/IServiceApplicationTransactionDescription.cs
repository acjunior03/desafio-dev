using System.Collections.Generic;

namespace ServiceApplication.Interfaces
{
    public interface IServiceApplicationTransactionDescription
    {
        public object ImportFileCNAB(List<byte[]> fileBytes);
    }
}
