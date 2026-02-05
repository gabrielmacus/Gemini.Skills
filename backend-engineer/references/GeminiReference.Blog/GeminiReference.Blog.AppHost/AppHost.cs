var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin();

var migrations = builder
    .AddProject<Projects.GeminiReference_Blog_Migrations>("geminireference-blog-migrations")
    .WithReference(postgres)
    .WaitFor(postgres);

var api = builder
    .AddProject<Projects.GeminiReference_Blog_API>("geminireference-blog-api")
    .WithHttpHealthCheck("/health")
    .WithReference(postgres)
    .WaitForCompletion(migrations);


builder.Build().Run();
