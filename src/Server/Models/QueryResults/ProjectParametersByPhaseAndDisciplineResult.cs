namespace BimKrav.Server.Models.QueryResults;

public class ProjectPropertiesByPhaseAndDisciplineResult
{
    public string PropertyName { get; set; }
    public string Categories { get; set; }
    public string Level { get; set; }
    public string RevitPropertyType { get; set; }
    public byte[] PropertyGUID { get; set; }
}