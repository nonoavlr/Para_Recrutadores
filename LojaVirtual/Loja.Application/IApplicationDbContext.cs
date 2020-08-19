﻿using Loja.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Loja.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Client { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<Item> Item { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
