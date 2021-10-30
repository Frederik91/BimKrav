using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("fase_property_junction")]
public class PhasePropertyTbl
{
    [Column("faseID")]
    public int PhaseId { get; set; }

    [Column("propertyID")]
    public int PropertyId { get; set; }

    public virtual PhaseTbl Phase { get; set; } = null!;
    public virtual PropertyTbl Property { get; set; } = null!;
}