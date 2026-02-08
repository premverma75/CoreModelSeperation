using CoreModelSeperation.Data;
using CoreModelSeperation.Extensions;
using CoreModelSeperation.Repogitories.IRepogitory;
using CoreModelSeperation.Repogitories.Repogitory;
using CoreModelSeperation.Service.Implementation;
using CoreModelSeperation.Service.Interface;
using Mapster;
using Microsoft.OpenApi;
using Serilog;
using System.Reflection;

//using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMapster();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSqlServer<AppDbContext>(
    builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// register mappings once at startup
EntityToDtoMapping.Register();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CoreModelSeperation API",
        Version = "v1"
    });
});
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(
            path: "Logs/log-.txt",
            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 7);
});

var app = builder.Build();
app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate =
        "Handled {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreModelSeperation API v1");
    });
}
app.UseSerilogRequestLogging();
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();