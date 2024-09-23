using CaptaCase.Data;
using CaptaCase.Data.Repositories;
using CaptaCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CaptaCase.Application.Services.CustomerServices;
using CaptaCase.Application.Services.CustomerTypeServices;
using CaptaCase.Application.Services.CustomerSituationServices;
using CaptaCase.Application.Services.CustomerServices.Intefaces;
using CaptaCase.Application.Services.CustomerTypeServices.Interfaces;
using CaptaCase.Application.Services.CustomerSituationServices.Intefaces;

namespace CaptaCase.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);
            services.AddRepository();
            services.AddAutoMapper();
            services.AddServices();
            services.AddHandler();

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<CaptaCaseContext>(options => { options.UseSqlServer(configuration["ConnectionString:DefaultConnection"]); });

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(ICustomerTypeRepository), typeof(CustomerTypeRepository));
            services.AddScoped(typeof(ICustomerSituationRepository), typeof(CustomerSituationRepository));

            services.AddScoped(typeof(DbContext), typeof(CaptaCaseContext));
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(Core.AssemblyReference.Assembly);

        public static IServiceCollection AddHandler(this IServiceCollection services) =>
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IManageCustomerService, ManageCustomerService>();
            services.AddScoped<ISearchCustomerService, SearchCustomerService>();

            services.AddScoped<IManageCustomerTypeService, ManageCustomerTypeService>();
            services.AddScoped<ISearchCustomerTypeService, SearchCustomerTypeService>();

            services.AddScoped<IManageCustomerSituationService, ManageCustomerSituationService>();
            services.AddScoped<ISearchCustomerSituationService, SearchCustomerSituationService>();

            return services;
        }
    }
}
