using Aspire.Hosting;
using Aspire.Hosting.Yarp.Transforms;
using Microsoft.Extensions.Hosting;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.LoadBalancing;

var builder = DistributedApplication.CreateBuilder(args);

//var compose = builder.AddDockerComposeEnvironment("compose");

#region Blog service
var blogDb = builder.AddPostgres("blog-db").WithPgAdmin();
var blogApi = builder
    .AddProject<Projects.GeminiReference_Blog_API>("geminireference-blog-api")
    .WithHttpHealthCheck("/health")
    .WithReference(blogDb);
#endregion

#region Backoffice service
var backOfficeDb = builder.AddPostgres("backoffice-db").WithPgAdmin();
var backofficeApi = builder
    .AddProject<Projects.GeminiReference_Backoffice_API>("geminireference-backoffice-api")
    .WithHttpHealthCheck("/health")
    .WithReference(backOfficeDb);
#endregion

if (builder.Environment.IsDevelopment())
{
    #region Blog migration
    var blogMigrations = builder
        .AddProject<Projects.GeminiReference_Blog_Migrations>("geminireference-blog-migrations")
        .WithReference(blogDb)
        .WaitFor(blogDb);

    blogApi = blogApi.WaitForCompletion(blogMigrations);
    #endregion

    #region Backoffice migration
    var backofficeMigrations = builder
        .AddProject<Projects.GeminiReference_Backoffice_Migrations>(
            "geminireference-backoffice-migrations"
        )
        .WithReference(backOfficeDb)
        .WaitFor(backOfficeDb);

    backofficeApi = backofficeApi.WaitForCompletion(backofficeMigrations);
    #endregion
}

var gateway = builder
    .AddProject<Projects.GeminiReference_Gateway>("geminireference-gateway")
    .WithReference(blogApi)
    .WithReference(backofficeApi)
    .WaitFor(blogApi)
    .WaitFor(backofficeApi)
    .WithExternalHttpEndpoints();
    //.PublishAsDockerComposeService((resource, service) => { });

blogApi.WithParentRelationship(gateway);
backofficeApi.WithParentRelationship(gateway);

builder.Build().Run();
