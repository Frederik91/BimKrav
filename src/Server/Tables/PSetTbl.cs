using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblpset")]
public class PSetTbl
{
    public PSetTbl()
    {
        IfcTypes = new HashSet<IfcTypePSetTbl>();
        Properties = new HashSet<PsetPropertyTbl>();
    }

    [Column("ID_Pset", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("PsetName", TypeName = "text")]
    [Required]
    public string Name { get; set; } = null!;

    [Column("PsetDescription", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? Description { get; set; }

    [Column("PsetOrigin", TypeName = "text")]
    [DefaultValue("'NULL'")]
    public string? PsetOrigin { get; set; }

    public virtual ICollection<IfcTypePSetTbl> IfcTypes { get; set; } = null!;
    public virtual ICollection<PsetPropertyTbl> Properties { get; set; } = null!;
}