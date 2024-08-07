using System.Diagnostics;
using D2.Infrastructure.Contexts;
using D2.Staging.WebApi.Extensions;

try
{
    var builder = Destiny2ApplicationBuilder.CreateBuilder(args);
    var app = builder.BuildDestiny2();


    app.MapGet("/hello", (ILogger<Program> logger) =>
        {
            logger.LogInformation("Hello World!");
            return Results.Ok("Hello World!");
        })
        .Produces(StatusCodes.Status202Accepted)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError);

    var dbInit = app.Services.GetRequiredService<DbInitializer>();
    var start = Stopwatch.GetTimestamp();
    await dbInit.Initialize();
    var end = Stopwatch.GetTimestamp();
    var diff = Stopwatch.GetElapsedTime(start, end);
    Console.WriteLine($"Database initialized in {diff}ms.");

    Console.WriteLine("Database initialized.");
    
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Application has exited.");
}