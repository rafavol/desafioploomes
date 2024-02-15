using Ploomes.API.Infra;

namespace Ploomes.API
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaClienteRepository, ContaClienteRepository>();
        }
    }
}
