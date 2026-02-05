using GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Neuraltech.SharedKernel.Infraestructure.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.UsePostgresDb<BlogDbContext>(
    "postgres",
    x => x.MigrationsAssembly("GeminiReference.Blog.Migrations")
);

var host = builder.Build();


using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    await db.Database.MigrateAsync();
}
