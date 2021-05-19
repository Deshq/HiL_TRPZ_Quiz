using HiL_Store.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("default");
                services.AddDbContext<HiLDbContext>(o => o.UseSqlServer(connectionString));
                services.AddSingleton<HiLDbContextCreate>(new HiLDbContextCreate(connectionString));
            });

            return host;
        }
    }
}
