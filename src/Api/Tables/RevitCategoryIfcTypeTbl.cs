using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("element_ifcentitet_junction")]
public class RevitCategoryIfcTypeTbl
{
    [Column("RevitElementName", TypeName = "tinytext")]
    [DefaultValue("'NULL'")]
    public string? RevitCategoryName { get; set; }

    [Column("IFCEntityName", TypeName = "tinytext")]
    [DefaultValue("'NULL'")]
    public string? IfcTypeName { get; set; }
}