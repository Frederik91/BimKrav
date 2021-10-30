using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("element_ifcentitet_junction")]
public class RevitCategoryIfcTypeTbl
{
    [Column("RevitElementName")]
    public string RevitCategoryName { get; set; }

    [Column("IFCEntityName")]
    public string IfcTypeName { get; set; }
}