using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblpset")]
public class PSetTbl
{
    public PSetTbl()
    {
        IfcentitetPsetJunctions = new HashSet<IfcTypePSetTbl>();
        PsetProperties = new HashSet<PsetPropertyTbl>();
        Tblmasterkravs = new HashSet<MasterKravTbl>();
    }

    [Column("ID_Pset")]
    public int IdPset { get; set; }

    [Column("PsetName")]
    public string PsetName { get; set; }

    [Column("PsetDescription")]
    public string PsetDescription { get; set; }

    [Column("PsetOrigin")]
    public string PsetOrigin { get; set; }

    public virtual ICollection<IfcTypePSetTbl> IfcentitetPsetJunctions { get; set; } = null!;
    public virtual ICollection<PsetPropertyTbl> PsetProperties { get; set; } = null!;
    public virtual ICollection<MasterKravTbl> Tblmasterkravs { get; set; } = null!;
}