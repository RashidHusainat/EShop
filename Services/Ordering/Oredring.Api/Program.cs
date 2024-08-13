using Ordering.Application;
using Ordering.Infrastrcture;
using Ordering.Infrastrcture.Data.Extentions;
using Oredring.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer()
    .AddInfrastrcture(builder.Configuration)
    .AddApiService();

var app = builder.Build();

app.MigrateDatabaseAndSeedData();
app.UseService();

app.MapGet("/", () => "Hello World!");

app.Run();
