var builder = DistributedApplication.CreateBuilder(args);

var dbServer = builder.AddPostgres("dbserver").WithLifetime(ContainerLifetime.Persistant);
dbServer.WithPgAdmin(options => 
    options.WithHostPort(5555).WithLifetime(ContainerLifetime.Persistant)
);

var db = dbServer.AddDatabase("abnbdb");

builder.AddProject<Projects.Api>("Api").WithExternalHttpEndpoints().WithReference(db).WaitFor(db);

builder.Build().Run();
