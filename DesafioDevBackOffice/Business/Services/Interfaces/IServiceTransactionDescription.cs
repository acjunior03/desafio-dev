using Business.Models;
namespace Business.Services.Interfaces
{
    public interface IServiceTransactionDescription
    {
        public object ImportFileCNABAsync(ModelFiles file);
    }
}
