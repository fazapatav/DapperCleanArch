﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DapperClean.Application.Interfaces;
using DapperClean.Infrastructure.Repository;
using DapperClean.Sql.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace DapperClean.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<ICreditoRepository, CreditoRepository>();        
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

