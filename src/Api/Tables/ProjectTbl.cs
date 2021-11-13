using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("tblproject")]
public class ProjectTbl
{
    [Column("ID_project", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("ProjectCode", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Code { get; set; }

    [Column("ProjectName", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Name { get; set; }
}