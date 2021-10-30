using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("ifcentitet_pset_junction")]
public class IfcTypePSetTbl
{
    [Column("ID_Entitet")]
    public int IfcTypeId { get; set; }

    [Column("ID_Pset")]
    public int PsetId { get; set; }

    public virtual IfcTypeTbl IfcType { get; set; }
    public virtual PSetTbl Pset { get; set; }
}