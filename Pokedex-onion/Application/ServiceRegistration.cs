using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Services;
using Pokedex.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application
{
    //Extension Metods - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            #region Services

            service.AddTransient<IPokemonService, PokemonService>();
            service.AddTransient<IRegionService, RegionService>();
            service.AddTransient<ITypeService, TypeService>();

            #endregion
        }
    }
}