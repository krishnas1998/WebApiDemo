using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Contracts;
using WebApiDemo.Mapping;
using WebApiDemo.Services;

namespace WebApiDemo.Configurations
{
    public static class Bootstrapper
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IStudentService, StudentService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StudentProfile));
        }

        public static void EnableCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("P1", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }
    }
}
