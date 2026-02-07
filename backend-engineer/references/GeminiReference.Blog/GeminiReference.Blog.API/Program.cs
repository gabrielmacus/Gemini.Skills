using GeminiReference.Blog.API.Resources.v1.Posts.Actions.CreatePost;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions;
using GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services;
using Neuraltech.SharedKernel.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.AddServiceDefaults();

#region Modules
builder.UsePostsModule();
#endregion

#region Defaults
builder.UseDefaultExtensions();
#endregion

#region Health Checks
builder
    .UseHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("postgres")!)
    .AddKafka(builder.Configuration);
#endregion

#region Persistence
builder.UsePostgresDb<BlogDbContext>();
#endregion

#region Validation
builder.UseFluentValidation<CreatePostValidator>();
#endregion

#region Localization
builder.UseLocalization(["es"], "es");
#endregion

#region Events
builder.UseWolverineFx<BlogDbContext>();
#endregion

#region Caching
builder.UseFusionCache();
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

app.UseHttpsRedirection();

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
