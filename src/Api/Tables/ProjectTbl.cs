using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Api.Tables;

[Table("tblproject")]
public class ProjectTbl
{
    public ProjectTbl()
    {
        ProjectProperties = new HashSet<ProjectPropertyTbl>();
    }

    [Column("ID_project", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("ProjectCode", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Code { get; set; }

    [Column("ProjectName", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Name { get; set; }

    public virtual ICollection<ProjectPropertyTbl> ProjectProperties { get; set; } = null!;
}