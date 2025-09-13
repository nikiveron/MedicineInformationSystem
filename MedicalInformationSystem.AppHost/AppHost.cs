var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("postgres")
                .WithDataVolume("pgdata")
                //.WithPgAdmin()
                .AddDatabase("MISdb");

var apiService = builder.AddProject<Projects.MedicalInformationSystem_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.MedicalInformationSystem_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(db)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
