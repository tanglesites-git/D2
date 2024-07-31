using System.Reflection;
using D2.Manifest;
using D2.Manifest.Application;
using D2.Manifest.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var manager = builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Run the app
using var scope = app.Services.CreateScope(); 
{
    var manifestApp = scope.ServiceProvider.GetRequiredService<IManifestApp>();
    await manifestApp.RunApp();
}
