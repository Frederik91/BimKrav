using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("element_property_junction")]
public class RevitCategoryPropertiesTbl
{
    [Column("ID_Element", TypeName = "int(11)")]
    public int RevitCategoryId { get; set; }

    [Column("ID_Property", TypeName = "int(11)")]
    public int PropertyId { get; set; }

    [Column("ID_PSet", TypeName = "int(11)")]
    [DefaultValue("'NULL'")]
    public int? PSetId { get; set; }

    public virtual RevitCategoryTbl RevitCategory { get; set; } = null!;
    public virtual PropertyTbl Property { get; set; } = null!;
}