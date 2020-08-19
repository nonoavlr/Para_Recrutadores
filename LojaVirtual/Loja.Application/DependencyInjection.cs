﻿using Loja.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEntityCrudHandler<Client>>(
                serviceProvider => new ClientHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                 )
            );

            services.AddScoped<IEntityCrudHandler<Address>>(
                serviceProvider => new AddressHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                 )
            );

            services.AddScoped<IEntityCrudHandler<Order>>(
                serviceProvider => new OrderHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            services.AddScoped<IEntityCrudHandler<Product>>(
                serviceProvider => new ProductHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            services.AddScoped<IEntityCrudHandler<Item>>(
                serviceProvider => new ItemHandler(
                    serviceProvider.GetService<IApplicationDbContext>()
                )
            );

            return services;
        }
    }
}
