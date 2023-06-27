using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Infrastructure.Persistence.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence
{   
    //Extension Metods - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            #region Contexts

            if(configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                service.AddDbContext<ApplicationContext>(options => 
                                                         options.UseSqlServer(connectionString, 
                                                         m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            #region Repositories

            service.AddTransient<IPokemonRepository, PokemonRepository>();
            service.AddTransient<IRegionRepository, RegionRepository>();
            service.AddTransient<ITypeRepository, TypeRepository>();

            #endregion
        }
    }
}
