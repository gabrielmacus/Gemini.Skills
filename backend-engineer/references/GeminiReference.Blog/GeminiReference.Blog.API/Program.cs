using GeminiReference.Blog.API.Resources.v1.Posts.Actions.PaginatePosts;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions;
using GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services;
using Neuraltech.SharedKernel.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.AddServiceDefaults();

#region Modules
builder.UsePostsModule();
#endregion

#region Validation
builder.UseFluentValidation<PaginatePostsValidator>();
#endregion

#region Defaults
builder.UseDefaultExtensions();
#endregion

#region Health Checks
builder
    .UseHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("blog-db")!)
    .AddRedis(builder.Configuration)
    .AddKafka(builder.Configuration);
#endregion

#region Localization
builder.UseLocalization(["es"], "es");
#endregion

#region Persistence
builder.UsePostgresDb<BlogDbContext>("blog-db");
#endregion

#region Events
builder.UseWolverineFx<BlogDbContext>("blog-db");
#endregion

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.UseRequestTimeouts();

app.UseOutputCache();

app.UseExceptionHandler();

//app.MapDefaultEndpoints();
#region Health check endpoints
app.MapHealthCheckEndpoints();
#endregion

app.Run();
