var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithImage("postgres")
    .WithImageTag("18-alpine")
    .WithDataVolume("hai-medical-system-data")
    .WithPgAdmin();

var postgresdb = postgres.AddDatabase("medical-db");

builder.AddProject<Projects.Hai_MedicalSystem_Api>("api")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

builder.Build().Run();
