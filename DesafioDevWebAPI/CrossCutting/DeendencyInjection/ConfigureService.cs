using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using ServiceApplication.Interfaces;
using ServiceApplication.Services;

namespace CrossCutting.DeendencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IServiceTransaction, ServiceTransaction>();
            serviceCollection.AddTransient<IServiceTransactionDescription, ServiceTransactionDescription>();

            serviceCollection.AddTransient<IServiceApplicationTransactionDescription, ServiceApplicationTransactionDescription>();
        }
    }
}
