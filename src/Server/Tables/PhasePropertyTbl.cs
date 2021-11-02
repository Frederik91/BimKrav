using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("fase_property_junction")]
public class PhasePropertyTbl
{
    [Column("faseID", TypeName = "int(11)")]
    public int PhaseId { get; set; }

    [Column("propertyID", TypeName = "int(11)")]
    public int PropertyId { get; set; }

    public virtual PhaseTbl Phase { get; set; } = null!;
    public virtual PropertyTbl Property { get; set; } = null!;
}