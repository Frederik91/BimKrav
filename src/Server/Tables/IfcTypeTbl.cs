using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblifcentitet")]
public class IfcTypeTbl
{
    public IfcTypeTbl()
    {
        IfcTypePset = new HashSet<IfcTypePSetTbl>();
    }

    [Column("ID_entitet")]
    public int Id { get; set; }

    [Column("Entitet")]
    public string Name { get; set; }

    public virtual ICollection<IfcTypePSetTbl> IfcTypePset { get; set; }
}