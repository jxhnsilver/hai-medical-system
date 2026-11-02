var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hai_MedicalSystem_Api>("hai-medicalsystem-api");

builder.Build().Run();
