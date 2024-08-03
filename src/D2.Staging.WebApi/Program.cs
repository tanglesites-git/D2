using D2.Staging.WebApi.Extensions;

try
{
    var builder = Destiny2ApplicationBuilder.CreateBuilder(args);
    var app = builder.BuildDestiny2();
    
    app.MapGet("/", (ILogger<Program> logger) =>
    {
        logger.LogInformation("Hello World!");
        return Results.Ok("Hello World!");
    });
    
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


