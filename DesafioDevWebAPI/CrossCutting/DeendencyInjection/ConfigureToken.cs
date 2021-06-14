using Domain.Security;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DeendencyInjection
{
    public class ConfigureToken
    {
        public static void ConfigureDependenciesToken( IServiceCollection serviceCollection, TokenConfigurations tokenConfigurations)
        {
            serviceCollection.AddSingleton(tokenConfigurations);
        }
    }
}
