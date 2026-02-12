using GeminiReference.Backoffice.Modules.SharedKernel.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Neuraltech.SharedKernel.Infraestructure.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.UsePostgresDb<BackofficeDbContext>(
    "backoffice-db",
    x => x.MigrationsAssembly("GeminiReference.Backoffice.Migrations")
);

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BackofficeDbContext>();
    await db.Database.MigrateAsync();
}