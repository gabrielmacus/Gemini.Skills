var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddRequestTimeouts();

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.MapReverseProxy();

var aa = builder.Environment.IsDevelopment();

/*
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();*/

app.UseRequestTimeouts();

app.Run();
