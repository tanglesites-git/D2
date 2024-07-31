namespace D2.Manifest.Kernel;

public class ConnectionStrings
{
    public const string Section = "ConnectionStrings";
    public string D2DataLake { get; set; } = null!;
    public string D2DataWarehouse { get; set; } = null!;
}