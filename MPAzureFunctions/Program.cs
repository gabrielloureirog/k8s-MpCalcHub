using Fiap.Fase3.MPAzureFunctions;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=MPCalcDB;User Id=sa;Password=@fiap2024;TrustServerCertificate=True;", sqlOptions =>
        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
    )
);

builder.Build().Run();
