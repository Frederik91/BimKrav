using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblproject")]
public class ProjectTbl
{
    [Column("ID_project")]
    public int Id { get; set; }

    [Column("ProjectCode")]
    public string Code { get; set; }

    [Column("ProjectName")]
    public string Name { get; set; }
}