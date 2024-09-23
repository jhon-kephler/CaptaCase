using CaptaCase.Infrastructure;
using Microsoft.OpenApi.Models;

namespace CaptaCase.API
{
    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment environment);
    }

    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("customer", new OpenApiInfo
                {
                    Title = "Customer API",
                    Version = "v1"
                });

                c.SwaggerDoc("customertype", new OpenApiInfo
                {
                    Title = "Customer Type API",
                    Version = "v1"
                });

                c.SwaggerDoc("customersituation", new OpenApiInfo
                {
                    Title = "Customer Situation API",
                    Version = "v1"
                });
            });

            services.AddApplication(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/customer/swagger.json", "Customer API");
                    c.SwaggerEndpoint("/swagger/customertype/swagger.json", "Customer Type API");
                    c.SwaggerEndpoint("/swagger/customersituation/swagger.json", "Customer Situation API");
                });
            }

            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new Exception("Invalid Startup");

            startup.ConfigureServices(webAppBuilder.Services);

            var app = webAppBuilder.Build();

            startup.Configure(app, app.Environment);

            app.Run();

            return webAppBuilder;
        }

    }
}
