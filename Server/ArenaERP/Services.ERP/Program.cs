
using Common.ERP.UtilityManagement;
using Hangfire;
using Serilog;
using Serilog.Events;
using Services.ERP.Extentions;
using Services.ERP.MiddleWare;
using System;
using System.IO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var conStr = new ConnectionString
{
    Server = builder.Configuration["SqlServer:Server"],
    IntegratedSecurity = builder.Configuration["SqlServer:IntegratedSecurity"],
    Database = builder.Configuration["SqlServer:Database"],
    UserId = builder.Configuration["SqlServer:UserId"],
    Password = builder.Configuration["SqlServer:Password"]
};
Connection.Initialize(conStr);
// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddScopedServices(builder.Configuration);
builder.Services.AddScopedServicesForOnionLayer(builder.Configuration);
builder.Services.AddScopedServicesForUnitOfWork(builder.Configuration);
builder.Services.AddScopedServicesForRepository(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((ctx, lc) => lc
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
.Enrich.FromLogContext()
.ReadFrom.Configuration(builder.Configuration)
 );

try
{
    var app = builder.Build();
    Log.Information("Application Stating Up");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHsts();

    }


    app.UseHttpsRedirection();
    app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    app.UseRouting();
    app.UseAuthorization();
    //app.UseAuthentication();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
}

catch (Exception ex)
{
    Log.Fatal(ex, "Application Start-up failed");
}

finally
{
    Log.CloseAndFlush();
}