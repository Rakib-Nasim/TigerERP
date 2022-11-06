using Common.ERP.UtilityManagement.MailConfiguration;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
namespace Services.ERP.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContextDb>(options =>

            options.UseSqlServer(configuration.GetConnectionString("Connection")), ServiceLifetime.Scoped);
            services.AddSingleton<IMailer, Mailer>();
            return services;
        }
    }
}
