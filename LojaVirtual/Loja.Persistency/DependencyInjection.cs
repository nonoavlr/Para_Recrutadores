using Loja.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Persistency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistency(this IServiceCollection services)
        {
            services.AddDbContext<LojaDbContext>(options =>
            { 
                options.UseSqlite("Filename=../Loja.Persistency/Loja.db", opt =>
                {
                    opt.MigrationsAssembly(
                        typeof(LojaDbContext).Assembly.FullName
                    );
                });
            });

            services.AddScoped<IApplicationDbContext>(ctx =>
                ctx.GetRequiredService<LojaDbContext>());

            return services;
        }
    }
}
