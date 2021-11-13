using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("pset_property_junction")]
public class PsetPropertyTbl
{
    [Column("ID_Pset", TypeName = "int(11)")]
    public int PSetId { get; set; }

    [Column("ID_Property", TypeName = "int(11)")]
    public int PropertyId { get; set; }

    public virtual PropertyTbl Property { get; set; } = null!;
    public virtual PSetTbl PSet { get; set; } = null!;
}