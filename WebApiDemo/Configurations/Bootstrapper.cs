using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApiDemo.Commands.Students.Create;
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

        public static void AddMediateRServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStudentCommandHandler));
        }
    }
}
