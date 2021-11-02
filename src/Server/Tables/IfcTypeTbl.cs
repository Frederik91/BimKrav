using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BimKrav.Server.Tables;

[Table("tblifcentitet")]
public class IfcTypeTbl
{
    public IfcTypeTbl()
    {
        IfcTypePset = new HashSet<IfcTypePSetTbl>();
    }

    [Column("ID_entitet", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("Entitet", TypeName = "text")]
    [Required]
    public string Name { get; set; }

    public virtual ICollection<IfcTypePSetTbl> IfcTypePset { get; set; }
}