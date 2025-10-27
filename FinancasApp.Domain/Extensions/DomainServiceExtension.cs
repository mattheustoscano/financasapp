using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Mappings;
using FinancasApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            services.AddAutoMapper(map => map.AddProfile(typeof(ProfileMap)));

            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IMovimentacaoService, MovimentacaoService>();

            return services;
        }
    }
}
