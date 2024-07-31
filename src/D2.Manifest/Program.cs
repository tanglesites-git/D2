using System.Reflection;
using D2.Manifest;
using D2.Manifest.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var manager = builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ManifestApp>();

var app = builder.Build();

// Run the app
var scope = app.Services.GetRequiredService<ManifestApp>();
await scope.RunApp();