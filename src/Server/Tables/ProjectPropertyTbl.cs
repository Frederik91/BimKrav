using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("property_project_junction")]
public class ProjectPropertyTbl
{
    [Column("ID_Property")]
    public int? PropertyId { get; set; }

    [Column("ID_Project")]
    public int? ProjectId { get; set; }

    public virtual ProjectTbl Project { get; set; } = null!;
    public virtual PropertyTbl Property { get; set; } = null!;
}