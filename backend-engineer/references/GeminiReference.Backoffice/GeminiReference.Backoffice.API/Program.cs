using GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.CreatePost;
using GeminiReference.Backoffice.Modules.Posts.Infraestructure.Extensions;
using GeminiReference.Backoffice.Modules.SharedKernel.Infraestructure.Services;
using Neuraltech.SharedKernel.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
//builder.AddServiceDefaults();

#region Modules
builder.UsePostsModule();
#endregion

#region Validation
builder.UseFluentValidation<CreatePostValidator>();
#endregion

#region Defaults
builder.UseDefaultExtensions();
#endregion

#region Health Checks
builder
    .UseHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("backoffice-db")!)
    .AddRedis(builder.Configuration)
    .AddKafka(builder.Configuration);
#endregion

#region Localization
builder.UseLocalization(["es"], "es");
#endregion

#region Persistence
builder.UsePostgresDb<BackofficeDbContext>("backoffice-db");
#endregion

#region Events
builder.UseWolverineFx<BackofficeDbContext>("backoffice-db");
#endregion

builder.Services.AddControllers();
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

#region Health check endpoints
app.MapHealthCheckEndpoints();
#endregion

app.Run();
