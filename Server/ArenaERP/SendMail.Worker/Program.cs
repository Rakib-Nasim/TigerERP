
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.EntityFrameworkCore;
using SecurityBLLManager.ERP.BranchServiceB.Logic;
using SecurityBLLManager.ERP.IBranchService.Interface;
using SendMail.Worker;
using Serilog;
using Serilog.Events;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var migrationAssemblyName = typeof(Worker).Assembly.FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    Log.Information("Application Starting up");

    IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .UseSerilog()
        .ConfigureServices(services =>
        {
            services.AddDbContext<DatabaseContextDb>(options =>

                options.UseSqlServer(configuration.GetConnectionString("Connection")), ServiceLifetime.Singleton);
            services.AddSingleton<IBranchServiceBLLManager, BranchServiceBLLManager>();
            services.AddSingleton<IBranchRepository, BranchRepository>();
            services.AddSingleton<ICommonUnitOfWork, CommonUnitOfWork>();
            services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);

            services.AddHostedService<Worker>();
        })
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
