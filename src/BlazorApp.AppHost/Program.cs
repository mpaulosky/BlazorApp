using static BlazorApp.AppHost.Constants.ServiceNames;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<RedisResource> cache = builder.AddRedis(OutputCache);

var db = builder.AddMongoDB("db")
	.WithMongoExpress()
	.AddDatabase(MongoDbName);

builder.AddProject<Projects.BlazorApp>("web-frontend")
	.WithExternalHttpEndpoints()
	.WithReference(cache)
	.WithReference(db);

builder.Build().Run();
