using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("pset_property_junction")]
public class PsetPropertyTbl
{
    [Column("ID_Pset")]
    public int PSetId { get; set; }

    [Column("ID_Property")]
    public int PropertyId { get; set; }

    public virtual PropertyTbl Property { get; set; } = null!;
    public virtual PSetTbl PSet { get; set; } = null!;
}