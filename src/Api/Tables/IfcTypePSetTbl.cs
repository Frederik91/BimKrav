using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("ifcentitet_pset_junction")]
public class IfcTypePSetTbl
{
    [Column("ID_Entitet", TypeName = "int(11)")]
    public int IfcTypeId { get; set; }

    [Column("ID_Pset", TypeName = "int(11)")]
    public int PsetId { get; set; }

    public virtual IfcTypeTbl IfcType { get; set; } = null!;
    public virtual PSetTbl Pset { get; set; } = null!;
}