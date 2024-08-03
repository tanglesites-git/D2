using D2.Infrastructure;
using D2.Staging.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

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
    await dbInit.Initialize();
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