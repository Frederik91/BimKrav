using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblpset")]
public class PSetTbl
{
    public PSetTbl()
    {
        IfcTypes = new HashSet<IfcTypePSetTbl>();
        Properties = new HashSet<PsetPropertyTbl>();
        MasterKrav = new HashSet<MasterKravTbl>();
    }

    [Column("ID_Pset")]
    public int Id { get; set; }

    [Column("PsetName")]
    public string Name { get; set; }

    [Column("PsetDescription")]
    public string Description { get; set; }

    [Column("PsetOrigin")]
    public string PsetOrigin { get; set; }

    public virtual ICollection<IfcTypePSetTbl> IfcTypes { get; set; } = null!;
    public virtual ICollection<PsetPropertyTbl> Properties { get; set; } = null!;
    public virtual ICollection<MasterKravTbl> MasterKrav { get; set; } = null!;
}