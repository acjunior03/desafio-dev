using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DeendencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string SqlConnection)
        {
            serviceCollection.AddScoped(typeof(IRepositoryTransaction), typeof(RepositoryTransaction));
            serviceCollection.AddScoped(typeof(IRepositoryTransactionDescription), typeof(RepositoryTransactionDescription));
            serviceCollection.AddDbContext<ContextDesafioDev>(options => options.UseSqlServer(SqlConnection)
                                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
    }
}
