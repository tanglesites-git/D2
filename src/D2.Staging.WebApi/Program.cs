using D2.Staging.WebApi.Extensions;

try
{
    var builder = Destiny2ApplicationBuilder.CreateBuilder(args);
    var app = builder.BuildDestiny2();
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


